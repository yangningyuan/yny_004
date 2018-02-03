using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace System
{
	/// <summary>
	/// 提供一组操作数据库的简洁方法，并自动管理事务
	/// </summary>
	public class SQLServerHelper : IDisposable
	{
		/// <summary>
		/// 使用此字段保证一个线程中只有一个数据库连接
		/// </summary>
		[ThreadStatic]
		private static SqlConnection connection;

		/// <summary>
		/// 使用此字段来判断当前线程中是否有数据库事务
		/// </summary>
		[ThreadStatic]
		private static bool hasTransaction;  //是否有事务

		/// <summary>
		/// 当前线程中的数据库事务,如果为null,代表当前线程没有数据库事务
		/// </summary>
		[ThreadStatic]
		private static SqlTransaction tran;

		/// <summary>
		/// 在内部使用此字段来保证每一个线程中同时只能有一个未调用Dispose方法的SQLServerHelp实例
		/// </summary>
		[ThreadStatic]
		private static bool? hasInstance;

		/// <summary>
		/// 使用此实例字段判断是否已经将该对象释放
		/// </summary>
		private bool isDispose;

		/// <summary>
		/// 获取连接字符串
		/// </summary>
		private static string ConnectionString
		{
			get
			{
				return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["connectionStringName"]].ConnectionString;
			}
		}

		/// <summary>
		/// 获取数据库连接
		/// </summary>
		private static SqlConnection Connection
		{
			get
			{
				if (connection == null)
				{
					connection = new SqlConnection(ConnectionString);
					connection.Open();
				}
				return connection;
			}
		}

		/// <summary>
		/// 开始事务
		/// </summary>
		private static void BeginTran()
		{
			hasTransaction = true;
			tran = Connection.BeginTransaction();
		}

		/// <summary>
		/// 提交事务
		/// </summary>
		private static void CommitTran()
		{
			if (hasTransaction && tran != null)
			{
				tran.Commit();
				tran.Dispose();
				tran = null;
				hasTransaction = false;
			}
		}

		/// <summary>
		/// 回滚事务
		/// </summary>
		private static void RollbackTran()
		{
			if (hasTransaction && tran != null)
			{
				try
				{
					tran.Rollback();
				}
				catch (Exception) { }
				try
				{
					tran.Dispose();
				}
				catch (Exception) { }

				tran = null;
				hasTransaction = false;
			}
		}

		/// <summary>
		/// 关闭数据库连接
		/// </summary>
		private static void Close()
		{
			if (hasTransaction)
			{
				return;
			}

			if (connection != null)
			{
				try
				{
					connection.Dispose();
				}
				catch (Exception) { }
				finally
				{
					connection = null;
				}
			}
		}

		/// <summary>
		/// 获取数据库命令对象
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="pms"></param>
		/// <returns></returns>
		private static SqlCommand GetCommand(string sql, params SqlParameter[] pms)
		{
			Debug.Print(sql);
			SqlCommand cmd;
			if (hasTransaction)
			{
				cmd = new SqlCommand(sql, Connection, tran);
			}
			else
			{
				cmd = new SqlCommand(sql, Connection);
			}
			if (pms != null)
			{
				foreach (var item in pms)
				{
					if (item.Value == null)
					{
						item.Value = DBNull.Value;
					}
				}
				cmd.Parameters.AddRange(pms);
			}

			return cmd;
		}

		/// <summary>
		/// 使用此方法执行非查询语句，不要用此方法执行需要返回值的存储过程
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="pms"></param>
		public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(sql, pms))
				{
					return cmd.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 实际执行的是ExecuteScaler方法，并将返回值转换为合适的类型
		/// </summary>
		/// <returns></returns>
		public static TValue Single<TValue>(string sql, params SqlParameter[] pms)
		{
			return GetSingle(sql, pms).To<TValue>();
		}

		/// <summary>
		/// 实际执行的是ExecuteScaler方法
		/// </summary>
		/// <returns></returns>
		public static object GetSingle(string sql, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(sql, pms))
				{
					return cmd.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行查询，并返回使用自定义转换的第一行的数据
		/// </summary>
		public static TEntity FirstOrDefault<TEntity>(Func<SqlDataReader, TEntity> expression, string sql, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(sql, pms))
				{
					using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
					{
						if (reader.Read())
						{
							return expression(reader);
						}
						else
						{
							return default(TEntity);
						}
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行查询，并使用自定义转换将所有行转换为list
		/// </summary>
		public static List<TEntity> GetMany<TEntity>(Func<SqlDataReader, TEntity> expression, string sql, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(sql, pms))
				{
					using (var reader = cmd.ExecuteReader())
					{
						List<TEntity> list = new List<TEntity>();

						while (reader.Read())
						{
							list.Add(expression(reader));
						}

						return list;
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行查询，并将查询返回到DataTable中(此方法仅返回查询内容，不返回任何其他内容)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="pms"></param>
		/// <param name="isProcedure">参数sql是否是存储过程的名称</param>
		/// <returns></returns>
		public static DataSet GetDataSet(string sql, bool isProcedure, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(sql, pms))
				{
					if (isProcedure)
					{
						cmd.CommandType = CommandType.StoredProcedure;
					}
					using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
					{
						DataSet dataSet = new DataSet();
						adapter.Fill(dataSet);
						return dataSet;
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行非查询存储过程的查询
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="pms">参数</param>
		/// <returns></returns>
		public static DataSet GetDataSet(string sql, params SqlParameter[] pms)
		{
			return GetDataSet(sql, false, pms);
		}

		/// <summary>
		/// 执行存储过程，并从使用expression参数从存储过程中返回值
		/// </summary>
		/// <param name="procedureName"></param>
		/// <param name="expression">如果不需要从存储过程的输出参数，则为null</param>
		/// <param name="timeoutSeconds">超时秒数</param>
		/// <param name="pms"></param>
		/// <returns></returns>
		public static int Procedure(Action<SqlParameterCollection> expression, string procedureName, int timeoutSeconds, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(procedureName, pms))
				{
					cmd.CommandTimeout = timeoutSeconds;
					cmd.CommandType = CommandType.StoredProcedure;
					var returnValueParam = new SqlParameter("@return", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
					cmd.ExecuteNonQuery();
					if (expression != null)
					{
						expression(cmd.Parameters);
					}
					cmd.Parameters.Add(returnValueParam);
					var returnValue = cmd.Parameters["@return"].Value;
					return returnValue.To<int>();
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行存储过程，并从使用expression参数从存储过程中返回值(默认超时60秒)
		/// </summary>
		/// <param name="procedureName"></param>
		/// <param name="expression">如果不需要从存储过程的输出参数，则为null</param>
		/// <param name="pms"></param>
		/// <returns></returns>
		public static int Procedure(Action<SqlParameterCollection> expression, string procedureName, params SqlParameter[] pms)
		{
			return Procedure(expression, procedureName, 60, pms);
		}

		/// <summary>
		/// 执行一个存储过程，并返回一个值，实际调用的是ExecuteScalar
		/// </summary>
		/// <param name="procedureName"></param>
		/// <param name="pms"></param>
		/// <returns></returns>
		public static object ProdecureSingle(string procedureName, params SqlParameter[] pms)
		{
			try
			{
				using (var cmd = GetCommand(procedureName, pms))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					return cmd.ExecuteScalar();
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}

		/// <summary>
		/// 执行一个查询数据的存储过程并将查询结果填充到DataSet中
		/// </summary>
		/// <param name="procedureName">存储过程的名字</param>
		/// <param name="tableName">DataSet中表的名字</param>
		/// <param name="pms">参数</param>
		/// <returns></returns>
		public static DataSet DataSetProcedure(string procedureName, string tableName, params SqlParameter[] pms)
		{
			DataSet dataSet = new DataSet();
			try
			{
				using (var cmd = GetCommand(procedureName, pms))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					using (var adapter = new SqlDataAdapter(cmd))
					{
						adapter.Fill(dataSet, tableName);
						return dataSet;
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				Close();
			}
		}


		/// <summary>
		/// 释放资源
		/// </summary>
		public void Dispose()
		{
			if (isDispose)
			{
				throw new Exception("已释放，不能使用");
			}
			RollbackTran();  //回滚事务
			Close();  //关闭数据库链接
			isDispose = true;  //已经释放
			hasInstance = null;
		}

		/// <summary>
		/// 指示事务可以提交了
		/// </summary>
		public void Complete()
		{
			CommitTran();   //提交事务
		}

		/// <summary>
		/// 使用该构造方法在当前线程上开始数据库事务，调用此方法后，本类的所有操作都具有数据库事务
		/// </summary>
		public SQLServerHelper()
		{
			if (hasInstance != null)
			{
				throw new Exception("一个线程上只能有一个SQLServerHelper实例");
			}
			else
			{
				hasInstance = true;
			}

			isDispose = false;
			BeginTran();  //开始事务
		}
	}
}
