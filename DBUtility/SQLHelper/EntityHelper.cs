using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class SqlBuilder
	{

		private static Dictionary<Type, string> selectSQLCache = new Dictionary<Type, string>();

		public static string SelectSQL(Type entityType, string where = "")
		{
			string selectSQL;
			if (!selectSQLCache.TryGetValue(entityType, out selectSQL))   //如果从缓存里面没有找到
			{
				var columns = entityType.GetProperties().Where(item =>
				{
					return !EntityParser.IsIgnore(item);
				}).Select(item => string.Format(" [{0}]", EntityParser.GetColumnName(item)));

				if (!columns.Any())
				{
					throw new Exception(string.Format("类型{0}没有任何可以SELECT的列", entityType.FullName));
				}

				selectSQL = string.Format("SELECT{0} FROM {1}",
					string.Join(",", columns),
					EntityParser.GetTableName(entityType)
					);
				selectSQLCache.Add(entityType, selectSQL);
			}

			if (!string.IsNullOrEmpty(where))
			{
				where = " WHERE " + where;
			}

			return selectSQL + where;
		}


		/// <summary>
		/// 生成删除数据的SQL语句
		/// </summary>
		/// <param name="tableName">要删除数据的表的名字</param>
		/// <param name="whereSQL">条件表达式</param>
		/// <returns></returns>
		public static string DeleteSQL(string tableName, string whereSQL = null)
		{
			if (string.IsNullOrEmpty(whereSQL))
			{
				return string.Format("DELETE FROM [{0}]", tableName);
			}
			else
			{
				return string.Format("DELETE FROM [{0}] WHERE {1} ", tableName, whereSQL);
			}
		}

		/// <summary>
		/// 生成更新SQL语句
		/// </summary>
		/// <param name="entityType"></param>
		/// <returns>返回</returns>
		public static string ColumnSqlForUpdate(object entity, PropertyInfo propertyInfo, List<SqlParameter> parameter)
		{
			var config = EntityParser.GetColumnConfig(propertyInfo);  //获取对属性/列的配置信息
			var propertyValue = propertyInfo.GetValue(entity, null);
			if (config.UsePropertyForUpdate || propertyValue == null)   //如果使用属性的值更新数据库中的值
			{
				var columnName = EntityParser.GetColumnName(propertyInfo);
				var valueExpression = "@" + columnName;

				if (config.DBType == DBType.PropertyType)  //如果数据库中的类型 和 属性的类型相同
				{
					parameter.Add(new SqlParameter(valueExpression, propertyValue));
				}
				else   //如果要转换类型
				{
					propertyValue = EntityParser.ConvertPropertyValue(propertyInfo, propertyValue, config.DBType);
					parameter.Add(new SqlParameter(valueExpression, propertyValue));
				}
				return valueExpression;
			}
			else
			{
				if (!string.IsNullOrEmpty(config.UpdateSQL))  //如果不用属性，就使用特定的SQL语句指定列的值
				{
					return config.UpdateSQL;
				}
			}

			return string.Empty;
		}

		/// <summary>
		/// 返回null或空字符串表示不生成SQL语句
		/// </summary>
		/// <returns></returns>
		public static string ColumnSqlForInsert(object entity, PropertyInfo propertyInfo, List<SqlParameter> parameter)
		{
			var config = EntityParser.GetColumnConfig(propertyInfo);
			if (config.UsePropertyForInsert)
			{
				var columnName = EntityParser.GetColumnName(propertyInfo);
				var valueExpression = "@" + columnName;
				var propertyValue = propertyInfo.GetValue(entity, null);
				if (config.DBType == DBType.PropertyType)  //如果直接用属性
				{
					parameter.Add(new SqlParameter(valueExpression, propertyValue));
				}
				else   //如果要转换类型
				{
					propertyValue = EntityParser.ConvertPropertyValue(propertyInfo, propertyValue, config.DBType);
					parameter.Add(new SqlParameter(valueExpression, propertyValue));
				}
				return valueExpression;
			}
			else
			{
				if (!string.IsNullOrEmpty(config.InsertSQL))
				{
					return config.InsertSQL;
				}
			}

			return string.Empty;
		}


		private static Dictionary<Type, string> insertSQLCache = new Dictionary<Type, string>();
		public static string InsertSQL(Type entityType)
		{
			string sql;
			if (!insertSQLCache.TryGetValue(entityType, out sql))
			{

				StringBuilder insert = new StringBuilder();

				var key = EntityParser.GetKey(entityType);
				if (!key.KeyConfig.UsePropertyForInsert)
				{
					insert.AppendLine(key.KeyConfig.KeyBeforeInsertSQL);
				}


				string tableName = EntityParser.GetTableName(entityType);
				insert.AppendFormat("INSERT INTO [{0}]", tableName);

				var properties = entityType.GetProperties().Where(item => !EntityParser.IsIgnore(item)).Select(item =>
				{
					string columnSQL = EntityParser.GetColumnName(item);
					string valueSQL = "";
					var config = EntityParser.GetColumnConfig(item);
					if (config.UsePropertyForInsert)
					{
						valueSQL = " @" + item.Name;
					}
					else
					{
						valueSQL = config.InsertSQL;
					}

					return new KeyValuePair<string, string>(columnSQL, valueSQL);
				}).Where(item => !string.IsNullOrEmpty(item.Value));

				insert.AppendFormat("({0})", string.Join(",", properties.Select(item => item.Key))).AppendLine();
				insert.AppendFormat("VALUES({0})", string.Join(",", properties.Select(item => item.Value))).AppendLine();

				if (!key.KeyConfig.UsePropertyForInsert)
				{
					insert.Append("SELECT ").AppendLine(key.KeyConfig.KeyAfterInsertSQL);
				}

				insertSQLCache.Add(entityType, insert.ToString());
				return insert.ToString();
			}
			return sql;
		}
	}

	/// <summary>
	/// 实体辅助类
	/// </summary>
	public static class EntityHelper
	{
		/// <summary>
		/// 从SqlDataReader中将实体的值填充到新实体或已存在的实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="reader">SqlDataReader对象</param>
		/// <param name="entity">实体类的实例，如果不使用此参数，就回创建一个新实例</param>
		/// <returns></returns>
		private static TEntity FilldEntity<TEntity>(SqlDataReader reader, TEntity entity = default(TEntity)) where TEntity : SQLEntity
		{
			return DynamicFillEntity<TEntity>(reader, entity);
		}


		private static Dictionary<Type, List<ColumnContext>> fillEntityCache = new Dictionary<Type, List<ColumnContext>>();

		/// <summary>
		/// 动态的填充一个实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="reader">只接收DataRow和SqlDataReader作为参数，使用其他类型的对象会发生错误</param>
		/// <param name="entity">实体类的实例，如果不使用此参数，就回创建一个新实例</param>
		/// <returns></returns>
		private static TEntity DynamicFillEntity<TEntity>(dynamic reader, TEntity entity = default(TEntity)) where TEntity : SQLEntity
		{
			List<ColumnContext> contexts;

			var entityType = typeof(TEntity);
			if (!fillEntityCache.TryGetValue(entityType, out contexts))
			{
				contexts = new List<ColumnContext>();
				foreach (var propertyInfo in entityType.GetProperties())
				{
					if (EntityParser.IsIgnore(propertyInfo))
					{
						continue;
					}

					var config = EntityParser.GetColumnConfig(propertyInfo);
					var context = new ColumnContext()
					{
						Config = config,
						PropertyInfo = propertyInfo,
						PropertyName = propertyInfo.Name,
						ColumnName = EntityParser.GetColumnName(propertyInfo)
					};
					contexts.Add(context);
				}
				fillEntityCache.Add(entityType, contexts);
			}

			if (entity == null)
			{
				entity = Activator.CreateInstance<TEntity>();
			}
			foreach (var context in contexts)
			{
				var value = reader[context.ColumnName];
				FillProperty(entity, context.PropertyInfo, value);
			}

			entity.EntityState = EntityState.NotChanged;

			return entity;
		}

		/// <summary>
		/// 填充一个实体类的属性
		/// </summary>
		/// <param name="entity">实体类的实例</param>
		/// <param name="propertyInfo">要填充的属性的信息</param>
		/// <param name="sourceValue">从数据源获取到的属性的只</param>
		private static void FillProperty(object entity, PropertyInfo propertyInfo, object sourceValue)
		{
			var result = EntityParser.GetTypeConverter(propertyInfo);
			if (result == null)
			{
				sourceValue = sourceValue.To(propertyInfo.PropertyType);
				propertyInfo.SetValue(entity, sourceValue, null);
			}
			else
			{
				var propertyValue = result.ConvertFrom(sourceValue);
				propertyInfo.SetValue(entity, propertyValue, null);
			}
		}

		/// <summary>
		/// 使用指定的where条件和参数从数据库获取多个实体对象
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="where">where条件，也可以具有order</param>
		/// <param name="pms">参数</param>
		/// <returns></returns>
		public static List<TEntity> Many<TEntity>(string where, params SqlParameter[] pms) where TEntity : SQLEntity
		{
			return Many<TEntity>(where, "", pms);
		}

		/// <summary>
		/// 使用指定的where条件和参数从数据库获取多个实体对象
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="where">where条件，也可以具有order</param>
		/// <param name="pms">参数</param>
		/// <returns></returns>
		public static List<TEntity> Many<TEntity>(string where, string order, params SqlParameter[] pms) where TEntity : SQLEntity
		{
			var sql = new StringBuilder();
			sql.Append(SqlBuilder.SelectSQL(typeof(TEntity), where));
			if (!string.IsNullOrEmpty(order))
			{
				sql.AppendFormat("ORDER BY {0}", order);
			}

			return SQLServerHelper.GetMany((reader) =>
			{
				return FilldEntity<TEntity>(reader);
			}, sql.ToString(), pms);
		}

		/// <summary>
		/// 根据主键从数据库获得一个实体对象
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="key">主键的值</param>
		/// <param name="entity">实体类的实例，如果不使用此参数，就回创建一个新实例</param>
		/// <returns></returns>
		public static TEntity SingleByKey<TEntity>(object key, TEntity entity = default(TEntity)) where TEntity : SQLEntity
		{
			var keyContext = EntityParser.GetKey(typeof(TEntity));
			var keyName = keyContext.KeyName;

			var sql = SqlBuilder.SelectSQL(typeof(TEntity), string.Format("{0} = @{0}", keyName));

			return SQLServerHelper.FirstOrDefault((reader) =>
			{
				return FilldEntity<TEntity>(reader, entity);
			}, sql, new SqlParameter("@" + keyName, key));
		}

		/// <summary>
		/// 刷新一个已存在的实体(如果一个实体类的属性的值是旧的，可以使用此方法从数据库中刷新值)
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static TEntity RefreshEntity<TEntity>(TEntity entity) where TEntity : SQLEntity
		{
			var keyContext = EntityParser.GetKey(typeof(TEntity));
			var keyName = keyContext.KeyName;

			var sql = SqlBuilder.SelectSQL(typeof(TEntity), string.Format("{0} = @{0}", keyName));

			return SQLServerHelper.FirstOrDefault((reader) =>
			{
				return FilldEntity<TEntity>(reader, entity);
			}, sql, new SqlParameter("@" + keyName, keyContext.Key.GetValue(entity, null)));
		}

		/// <summary>
		/// 获取表中的第一条数据，如果没有找到会返回null
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static TEntity Single<TEntity>() where TEntity : SQLEntity
		{
			var sql = SqlBuilder.SelectSQL(typeof(TEntity));

			return SQLServerHelper.FirstOrDefault((reader) =>
			{
				return FilldEntity<TEntity>(reader);
			}, sql);
		}

		/// <summary>
		/// 根据主键删除一个实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="key">主键的值</param>
		public static void DeleteByKey<TEntity>(object key) where TEntity : SQLEntity
		{
			var keyInfo = EntityParser.GetKey(typeof(TEntity));

			var keyName = keyInfo.KeyName;

			var sql = SqlBuilder.DeleteSQL(EntityParser.GetTableName(typeof(TEntity)), string.Format("{0} = @{0}", keyName));

			SQLServerHelper.ExecuteNonQuery(sql, new SqlParameter("@" + keyName, key));
		}

		/// <summary>
		/// 根据指定的条件删除多个实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="where">条件</param>
		/// <param name="pms">参数</param>
		public static void Delete<TEntity>(string where, params SqlParameter[] pms) where TEntity : SQLEntity
		{
			var sql = SqlBuilder.DeleteSQL(EntityParser.GetTableName(typeof(TEntity)), where);
			SQLServerHelper.ExecuteNonQuery(sql, pms);
		}
		/// <summary>
		/// 根据指定的条件删除多个实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="where">条件</param>
		/// <param name="pms">参数</param>
		public static void Delete<TEntity>() where TEntity : SQLEntity
		{
			Delete<TEntity>("");
		}


		/// <summary>
		/// 使用指定的条件获取一个实体
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="where">条件</param>
		/// <param name="pms">参数</param>
		/// <returns></returns>
		public static TEntity Single<TEntity>(string where, params SqlParameter[] pms) where TEntity : SQLEntity
		{
			var sql = SqlBuilder.SelectSQL(typeof(TEntity), where);

			return SQLServerHelper.FirstOrDefault((reader) =>
			{
				return FilldEntity<TEntity>(reader);
			}, sql, pms);
		}


		private static Dictionary<Type, List<ColumnContext>> insertCache = new Dictionary<Type, List<ColumnContext>>();

		/// <summary>
		/// 向数据库中插入一个实体并返回实体类的主键的值，并从数据库中刷新实体的所有值
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity">要插入到数据库的实体类的实例</param>
		/// <returns></returns>
		public static TEntity Insert<TEntity>(TEntity entity) where TEntity : SQLEntity
		{
			var entityType = typeof(TEntity);
			List<ColumnContext> contexts;
			if (!insertCache.TryGetValue(entityType, out contexts))
			{
				contexts = new List<ColumnContext>();

				foreach (var propertyInfo in entityType.GetProperties())
				{
					if (EntityParser.IsIgnore(propertyInfo))
					{
						continue;
					}
					var config = EntityParser.GetColumnConfig(propertyInfo);
					var context = new ColumnContext()
					{
						Config = config,
						PropertyInfo = propertyInfo,
						PropertyName = propertyInfo.Name,
						ColumnName = EntityParser.GetColumnName(propertyInfo)
					};
					contexts.Add(context);
				}
				insertCache.Add(entityType, contexts);
			}


			List<SqlParameter> parameters = new List<SqlParameter>();
			foreach (var context in contexts)
			{
				if (context.Config.UsePropertyForInsert)
				{
					var valueExpression = "@" + context.PropertyName;
					var propertyValue = context.PropertyInfo.GetValue(entity, null);
					if (context.Config.DBType == DBType.PropertyType)  //如果直接用属性
					{
						parameters.Add(new SqlParameter(valueExpression, propertyValue));
					}
					else   //如果要转换类型
					{
						propertyValue = EntityParser.ConvertPropertyValue(context.PropertyInfo, propertyValue, context.Config.DBType);
						parameters.Add(new SqlParameter(valueExpression, propertyValue));
					}
				}
			}

			var keyContext = EntityParser.GetKey(entityType);   //寻找主键特性
			object key;

			string sql = SqlBuilder.InsertSQL(entityType);

			if (keyContext.KeyConfig.UsePropertyForInsert)   //如果使用属性的值插入到数据库
			{
				SQLServerHelper.ExecuteNonQuery(sql, parameters.ToArray());
				key = keyContext.Key.GetValue(entity, null);
			}
			else
			{
				key = SQLServerHelper.GetSingle(sql, parameters.ToArray());   //插入并获取主键的值
			}


			var se = entity as SQLEntity;
			if (se != null)
			{
				se.EntityState = EntityState.NotInitialized;   //未初始化
			}

			string selectSQL = SqlBuilder.SelectSQL(typeof(TEntity), string.Format("{0} = @{0}", keyContext.PropertyName));

			SQLServerHelper.FirstOrDefault((reader) =>
			{
				return FilldEntity<TEntity>(reader, entity);
			}, selectSQL, new SqlParameter("@" + keyContext.PropertyName, key));  //从数据库中刷新实体

			if (se != null)
			{
				se.EntityState = EntityState.NotChanged;  //未修改
			}
			return entity;
		}



		/// <summary>
		/// 将实体实例的属性的值更新到数据库中，必须指定主键
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <param name="updateToEntity"></param>
		/// <returns></returns>
		public static TEntity Update<TEntity>(TEntity entity, bool updateToEntity = true) where TEntity : SQLEntity
		{
			if (entity.EntityState == EntityState.NotInitialized)
			{
				throw new Exception("要更新的实体尚未初始化");
			}
			else if (entity.EntityState == EntityState.NotChanged)
			{
				return entity;
			}
			else
			{
				var entityType = typeof(TEntity);

				var key = EntityParser.GetKey(entityType);  //找到主键属性
				if (key == null)
				{
					throw new Exception("在实体类中没有找主键属性");
				}

				List<SqlParameter> parameters = new List<SqlParameter>();

				var tableName = EntityParser.GetTableName(entityType);
				StringBuilder update = new StringBuilder();
				update.AppendFormat("UPDATE [{0}] SET ", tableName);
				var flags = false;
				foreach (var propertyName in entity)  //遍历更改的属性
				{
					if (propertyName == key.PropertyName)
					{
						continue;
					}
					var propertyInfo = entityType.GetProperty(propertyName);
					if (propertyInfo == null || EntityParser.IsIgnore(propertyInfo))  //如果找不到属性或不映射到数据库
					{
						continue;
					}

					var sqlPair = SqlBuilder.ColumnSqlForUpdate(entity, propertyInfo, parameters);  //获取更新列值的sql语句
					if (string.IsNullOrEmpty(sqlPair))
					{
						continue;
					}
					else
					{
						string columnName = EntityParser.GetColumnName(propertyInfo);
						update.AppendFormat("{0} = {1}, ", columnName, sqlPair);
						flags = true;
					}
				}

				if (flags)
				{
					update.Remove(update.Length - 2, 2).AppendFormat(" ");
				}
				else
				{
					return entity;
				}

				update.AppendFormat(" WHERE {0} = @{0}", key.KeyName);

				var keyValue = key.Key.GetValue(entity, null);  //获取主键的值

				parameters.Add(new SqlParameter("@" + key.PropertyName, keyValue));

				SQLServerHelper.ExecuteNonQuery(update.ToString(), parameters.ToArray());  //更新到数据库
				entity.EntityState = EntityState.NotChanged;  //未更改
				if (updateToEntity)
				{
					//SingleByKey(keyValue, entity);  //从数据库刷新属性
					RefreshEntity(entity);
				}
			}
			return entity;
		}

		/// <summary>
		/// 获取一个实体，只有主键的值，并且状态为NotChanged
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="keyValue">主键的值</param>
		/// <param name="isFill">是否从数据库中填充所有属性的值</param>
		/// <returns></returns>
		public static TEntity GetEntityForUpdate<TEntity>(object keyValue, bool isFill = false) where TEntity : SQLEntity
		{
			var key = EntityParser.GetKey(typeof(TEntity));

			var se = Activator.CreateInstance<TEntity>(); //创建实体对象
			se.EntityState = EntityState.NotInitialized;  //未初始化
			key.Key.SetValue(se, keyValue, null);             //设置主键的值
			se.EntityState = EntityState.NotChanged;  //未更改
			return se;
		}

		/// <summary>
		/// 扩展方法，将DataRow中的数据转换为一个实体类
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="row"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static TEntity ToEntity<TEntity>(this DataRow row, TEntity entity = default(TEntity)) where TEntity : SQLEntity
		{
			return DynamicFillEntity<TEntity>(row, entity);
		}

	}

	/// <summary>
	/// 解析一个实体，如获取实体类对应的表的名字
	/// </summary>
	public static class EntityParser
	{
		/// <summary>
		/// Type对象对表的名字的缓存
		/// </summary>
		public static Dictionary<Type, string> TableNameCache = new Dictionary<Type, string>();

		/// <summary>
		/// 获取实体类所表示的表的名字
		/// </summary>
		/// <param name="entityType"></param>
		/// <returns></returns>
		public static string GetTableName(Type entityType)
		{
			string tableName;
			if (TableNameCache.TryGetValue(entityType, out tableName))
			{
				return tableName;
			}
			var nameAttr = entityType.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault() as NameAttribute;
			if (nameAttr == null)
			{
				tableName = entityType.Name;
			}
			else
			{
				tableName = nameAttr.Name;
			}
			TableNameCache.Add(entityType, string.Format("{0}", tableName));
			return tableName;
		}


		private static Dictionary<PropertyInfo, string> columnNameCache = new Dictionary<PropertyInfo, string>();
		/// <summary>
		/// 获取指定列的名字
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public static string GetColumnName(PropertyInfo info)
		{
			string columnName;
			if (!columnNameCache.TryGetValue(info, out columnName))
			{
				var nameAttr = info.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault() as NameAttribute;
				if (nameAttr == null)
				{
					columnName = info.Name;
				}
				else
				{
					columnName = nameAttr.Name;
				}
			}
			return columnName;
		}



		private static Dictionary<PropertyInfo, bool> isIgnoreCache = new Dictionary<PropertyInfo, bool>();
		/// <summary>
		/// 获取该属性是否被忽略
		/// </summary>
		/// <param name="propertyInfo"></param>
		/// <returns></returns>
		public static bool IsIgnore(PropertyInfo propertyInfo)
		{
			bool result;
			if (!isIgnoreCache.TryGetValue(propertyInfo, out result))
			{
				result = propertyInfo.GetCustomAttributes(typeof(IgnoreAttribute), false).Any();
				isIgnoreCache.Add(propertyInfo, result);
			}

			return result;
		}


		private static Dictionary<PropertyInfo, ColumnConfigAttribute> columnConfigCache = new Dictionary<PropertyInfo, ColumnConfigAttribute>();
		/// <summary>
		/// 获取列的配置
		/// </summary>
		/// <param name="propertyInfo"></param>
		/// <returns></returns>
		public static ColumnConfigAttribute GetColumnConfig(PropertyInfo propertyInfo)
		{
			ColumnConfigAttribute result;
			if (!columnConfigCache.TryGetValue(propertyInfo, out result))
			{
				result = propertyInfo.GetCustomAttribute(typeof(ColumnConfigAttribute)) as ColumnConfigAttribute;
				if (result == null)
				{
					result = ColumnConfigAttribute.Default;
				}
				columnConfigCache.Add(propertyInfo, result);
			}
			return result;
		}


		public static Dictionary<Type, KeyContext> keyCache = new Dictionary<Type, KeyContext>();

		public static KeyContext GetKey(Type entityType)
		{
			KeyContext result;
			if (!keyCache.TryGetValue(entityType, out result))
			{
				try
				{
					result = entityType.GetProperties().Where(item => !IsIgnore(item)).Select(item =>
					{
						var keyAttr = GetKey(item);
						if (keyAttr != null)
						{
							return new KeyContext() { Key = item, KeyName = GetColumnName(item), KeyConfig = keyAttr, PropertyName = item.Name };
						}
						else
						{
							return null;
						}
					}).First(item => item != null);

					keyCache.Add(entityType, result);
				}
				catch (Exception e)
				{
					throw new Exception(string.Format("类{0}可能没有主键，详情请查看内部错误", entityType.FullName), e);
				}
			}
			return result;
		}



		/// <summary>
		/// 从属性中获取主键配置
		/// </summary>
		/// <param name="propertyInfo"></param>
		/// <returns></returns>
		public static KeyAttribute GetKey(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute;
		}

		/// <summary>
		/// 查找属性的自定义类型转换器
		/// </summary>
		/// <param name="propertyInfo"></param>
		/// <returns></returns>
		public static TypeConverter GetTypeConverter(PropertyInfo propertyInfo)
		{
			var result = propertyInfo.GetCustomAttribute(typeof(TypeConverterAttribute)) as TypeConverterAttribute;  //属性上有没有类型转换器
			if (result == null)
			{
				result = propertyInfo.PropertyType.GetCustomAttribute(typeof(TypeConverterAttribute)) as TypeConverterAttribute;  //类型上有没有类型转换器
			}

			if (result == null)
			{
				return null;
			}
			else
			{
				var converter = Activator.CreateInstance(Type.GetType(result.ConverterTypeName)) as TypeConverter;
				return converter;
			}
		}
		/// <summary>
		/// 转换属性的值
		/// </summary>
		/// <param name="propertyInfo">属性信息</param>
		/// <param name="source">从数据源获取到的值</param>
		/// <param name="destination">目标类型</param>
		/// <returns></returns>
		public static object ConvertPropertyValue(PropertyInfo propertyInfo, object source, DBType destination)
		{
			Type destinationType = null;
			switch (destination)
			{
				case DBType.String:
					destinationType = typeof(string);
					break;
				case DBType.Int:
					destinationType = typeof(int);
					break;
				case DBType.Decimal:
					destinationType = typeof(decimal);
					break;
				case DBType.DateTime:
					destinationType = typeof(DateTime);
					break;
				case DBType.BigInt:
					destinationType = typeof(long);
					break;
			}

			if (destinationType == null)
			{
				return null;
			}

			var converter = EntityParser.GetTypeConverter(propertyInfo);  //获取类型转换器
			if (converter != null)
			{
				return converter.ConvertTo(source, destinationType);  //使用自定义类型转换器将值转换为另一种类型
			}

			return source.To(destinationType);
		}

		/// <summary>
		/// 获取主键的值
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static object GetKeyValue(object entity)
		{
			var keyInfo = GetKey(entity.GetType());

			return keyInfo.Key.GetValue(entity, null);
		}
	}

	public class KeyContext
	{
		public PropertyInfo Key { get; set; }

		public string KeyName { get; set; }

		public KeyAttribute KeyConfig { get; set; }


		public String PropertyName { get; set; }
	}

	public class ColumnContext
	{
		public string ColumnName { get; set; }

		public PropertyInfo PropertyInfo { get; set; }

		public ColumnConfigAttribute Config { get; set; }

		public string PropertyName { get; set; }
	}

	/// <summary>
	/// 该特性指示属性是主键
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class KeyAttribute : ColumnConfigAttribute { }

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class IdentityColumn : ColumnConfigAttribute { public IdentityColumn() { UsePropertyForInsert = false; UsePropertyForUpdate = false; } }


	/// <summary>
	/// 该类表示一个具有名称的特性
	/// </summary>
	public abstract class NameAttribute : Attribute
	{
		private string name;

		/// <summary>
		/// 表示表或列的名字
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (value == null || value.Trim() == string.Empty)
				{
					throw new Exception("名字不能为空字符串");
				}
				name = value.Trim();
			}
		}
	}

	/// <summary>
	/// 该特性用于指定表的名字
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class TableAttribute : NameAttribute
	{
		public TableAttribute(string tableName)
		{
			base.Name = tableName;
		}
	}

	/// <summary>
	/// 该特性用于指定列的名字
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ColumnAttribute : NameAttribute
	{
		public ColumnAttribute(string columName)
		{
			base.Name = columName;
		}
	}

	/// <summary>
	/// 指示该属性不是一个列
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class IgnoreAttribute : Attribute { }

	/// <summary>
	/// 配置如何为列生成SQL语句
	/// </summary>
	public class ColumnConfigAttribute : Attribute
	{
		/// <summary>
		/// 是否使用实体属性的值插入到数据库
		/// </summary>
		public bool UsePropertyForInsert { get; set; }

		/// <summary>
		/// 是否使用实体属性的值来更新数据库
		/// </summary>
		public bool UsePropertyForUpdate { get; set; }

		/// <summary>
		/// 如果不使用属性将列的值插入到数据库，就要显式指定插入值的SQL语句，如果为null或空字符串则不插入该列
		/// </summary>
		public string InsertSQL { get; set; }

		/// <summary>
		/// 如果不使用属性将列的值更新到数据库，就要显式指定更新值的SQL语句，如果为null或空字符串则不更新该列
		/// </summary>
		public string UpdateSQL { get; set; }

		/// <summary>
		/// 在INSERT语句执行之前帮助寻找主键的SQL语句
		/// </summary>
		public string KeyBeforeInsertSQL { get; set; }

		/// <summary>
		/// 在INSERT语句执行执行之后帮助寻找主键的SQL语句
		/// </summary>
		public string KeyAfterInsertSQL { get; set; }

		public DBType DBType { get; set; }

		/// <summary>
		/// 默认情况下，所有的列都要生成SQL语句
		/// </summary>
		public ColumnConfigAttribute()
		{
			this.UsePropertyForInsert = true;
			this.UsePropertyForUpdate = true;
		}

		private static ColumnConfigAttribute _default;
		public static ColumnConfigAttribute Default
		{
			get
			{
				if (_default == null)
				{
					_default = new ColumnConfigAttribute();
				}
				return _default;
			}
		}
	}

	public class DefaultAttribute : ColumnConfigAttribute
	{
		public DefaultAttribute(string defaultSQL)
		{
			base.UsePropertyForInsert = false;
			base.InsertSQL = defaultSQL;
		}
	}


	/// <summary>
	/// 使用此枚举指示属性所表示的列的数据类型
	/// </summary>
	public enum DBType
	{
		/// <summary>
		/// 这是默认值，指示属性的类型和数据库列的类型一致
		/// </summary>
		PropertyType = 0,
		/// <summary>
		/// 指示此属性的值在数据库中被存为字符串
		/// </summary>
		String = 1,
		/// <summary>
		/// 指示此属性的值在数据库中被存为Decimal
		/// </summary>
		Decimal = 2,
		/// <summary>
		/// 指示此属性的值在数据库中被存为Int
		/// </summary>
		Int = 3,
		/// <summary>
		/// 指示此属性的值在数据库中被存为DateTime
		/// </summary>
		DateTime = 4,
		/// <summary>
		/// 指示此属性的值在数据库中被存为BigInt(Long)
		/// </summary>
		BigInt = 5
	}

	/// <summary>
	/// 指示这是一个标识列主键
	/// </summary>
	public class IdentityKeyAttribute : KeyAttribute
	{
		public IdentityKeyAttribute()
		{
			UsePropertyForInsert = false;  //标识列不能插入
			UsePropertyForUpdate = false;  //标识列不能更新

			KeyAfterInsertSQL = "SCOPE_IDENTITY()";   //查找标识列的值
		}
	}

	/// <summary>
	/// 指示这是一个计算列
	/// </summary>
	public class CompultedAttribute : ColumnConfigAttribute
	{
		public CompultedAttribute()
		{
			UsePropertyForInsert = false;  //计算列不能插入
			UsePropertyForUpdate = false;  //计算列不能更新
		}
	}



	/// <summary>
	/// 实体类的父类
	/// </summary>
	[DebuggerDisplay("EntityState:{EntityState}")]
	public abstract class SQLEntity : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// 实体的状态
		/// </summary>
		private EntityState state;


		private List<string> modifiedProperties = new List<string>();

		/// <summary>
		/// 获取或设置实体类的状态，默认状态为NotInitialized
		/// </summary>
		[Ignore]
		public EntityState EntityState
		{
			get { return state; }
			set
			{
				state = value;
				if (state == EntityState.NotChanged)
				{
					modifiedProperties.Clear();
				}
			}
		}

		/// <summary>
		/// 当实体类的属性的值更改后调用此方法
		/// </summary>
		/// <param name="propertyName"></param>
		public virtual void OnPropertyChanged(string propertyName)
		{
			if (state == EntityState.NotInitialized || propertyName == "EntityState")
			{
				return;
			}

			state = EntityState.Modified;
			if (!modifiedProperties.Contains(propertyName))
			{
				modifiedProperties.Add(propertyName);
			}
		}

		/// <summary>
		/// 使用foreach 枚举实体类中已经修改的列
		/// </summary>
		/// <returns></returns>
		public IEnumerator<string> GetEnumerator()
		{
			return modifiedProperties.GetEnumerator();
		}
	}

	/// <summary>
	/// 表示实体状态
	/// </summary>
	public enum EntityState
	{
		/// <summary>
		/// 没有初始化
		/// </summary>
		NotInitialized = 0,
		/// <summary>
		/// 没有被修改
		/// </summary>
		NotChanged = 1,
		/// <summary>
		/// 已经被修改
		/// </summary>
		Modified = 2

	}

	/// <summary>
	/// 自定义扩展
	/// </summary>
	public static class Extensions
	{

		/// <summary>
		/// 从指定属性获取一个指定类型的自定义特性
		/// </summary>
		/// <param name="propertyInfo">属性信息</param>
		/// <param name="attributeType">自定义特性类型，会找到此类型的派生类</param>
		/// <returns></returns>
		public static Attribute GetCustomAttribute(this PropertyInfo propertyInfo, Type attributeType)
		{
			return Attribute.GetCustomAttribute(propertyInfo, attributeType);
		}

		/// <summary>
		/// 从指定类型获取一个指定类型的自定义特性
		/// </summary>
		/// <param name="typeInfo">类型信息</param>
		/// <param name="attributeType">自定义特性类型，会找到此类型的派生类</param>
		public static Attribute GetCustomAttribute(this Type typeInfo, Type attributeType)
		{
			return Attribute.GetCustomAttribute(typeInfo, attributeType);
		}
	}
}
