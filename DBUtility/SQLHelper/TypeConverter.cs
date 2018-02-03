using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace System
{
	public class JsonTypeConverter : TypeConverter
	{
		private static readonly JavaScriptSerializer jss = new JavaScriptSerializer();

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				try
				{
					return jss.Serialize(value);
				}
				catch (Exception)
				{
					return jss.Serialize(DefaultValue());
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			try
			{
				if (value == DBNull.Value)
				{
					return DefaultValue();
				}
				return jss.Deserialize(value.ToString(), PropertyType);
			}
			catch (Exception)
			{
				return DefaultValue();
			}
		}

		public Type PropertyType { get; private set; }
		protected JsonTypeConverter(Type propertyType)
		{
			PropertyType = propertyType;
		}

		public virtual object DefaultValue()
		{
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// 类型转换扩展
	/// </summary>
	public static class DataConverterExtension
	{
		private static Type nullableType;

		/// <summary>
		/// Nullable<> 或 int? 泛型类型
		/// </summary>
		public static Type NullableType
		{
			get
			{
				if (nullableType == null)
				{
					nullableType = typeof(Nullable<>).GetGenericTypeDefinition();
				}
				return nullableType;
			}
		}

		/// <summary>
		/// 从SqlDataReader中获取指定列的值并将值转换为指定的类型
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="reader">SqlDataReader</param>
		/// <param name="columnName">列的名字</param>
		/// <returns></returns>
		public static TValue Field<TValue>(this SqlDataReader reader, string columnName)
		{
			var columnValue = reader[columnName];
			var destinationType = typeof(TValue);
			return (TValue)ConvertValue(columnValue, destinationType);
		}

		/// <summary>
		/// 从SqlDataReader中获取指定列的值并将值转换为指定的类型
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="reader">SqlDataReader</param>
		/// <param name="columnIndex">列的索引</param>
		/// <returns></returns>
		public static TValue Field<TValue>(this SqlDataReader reader, int columnIndex)
		{
			var columnValue = reader[columnIndex];
			var destinationType = typeof(TValue);
			return (TValue)ConvertValue(columnValue, destinationType);
		}

		/// <summary>
		/// (提供泛型方法)将一个对象转换为指定的类型，通常用于String与.net 基础类型之间的转换
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static TValue To<TValue>(this object source)
		{
			return (TValue)ConvertValue(source, typeof(TValue));
		}

		/// <summary>
		/// 将一个对象转换为指定的类型，通常用于String与.net 基础类型之间的转换
		/// </summary>
		/// <param name="source"></param>
		/// <param name="destinationType"></param>
		/// <returns></returns>
		public static object To(this object source, Type destinationType)
		{
			return ConvertValue(source, destinationType);
		}

		/// <summary>
		/// 提供一种类型的值转换为另一种类型的值的核心功能
		/// </summary>
		/// <param name="source">要转换的值</param>
		/// <param name="destinationType">要转换为的类型</param>
		/// <returns></returns>
		public static object ConvertValue(object source, Type destinationType)
		{
			if (source is string && string.IsNullOrEmpty(source as string) && destinationType != typeof(string))
			{
				source = DBNull.Value;
			}

			if (destinationType == typeof(object))  //如果类型相同
			{
				return source;
			}

			if (destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == NullableType)   //如果是Nullable<>类型
			{
				if (null == source || DBNull.Value == source)  //源是null
				{
					return Default(destinationType);  //返回默认值
				}
				else
				{
					destinationType = destinationType.GetGenericArguments()[0];  //Nullable<T> 中T的类型
				}
			}

			if (destinationType.IsEnum)  //如果是枚举
			{
				if (DBNull.Value == source || null == source)  //如果是null
				{
					return Enum.GetValues(destinationType).Cast<object>().First(); //枚举的第一个值
				}
				try
				{
					return Enum.Parse(destinationType, source.ToString());  //解析
				}
				catch (Exception)
				{
					return Enum.GetValues(destinationType).Cast<object>().First();  //枚举的第一个值
				}

			}

			var typecode = Type.GetTypeCode(destinationType);
			if (typecode != TypeCode.Empty && typecode != TypeCode.Object && typecode != TypeCode.DBNull && typecode != TypeCode.String)  //如果是基本类型
			{
				try
				{
					if (DBNull.Value == source)
					{
						return Default(destinationType);
					}
					return Convert.ChangeType(source, destinationType);    //用这个方法转换
				}
				catch (Exception)
				{
					return Default(destinationType);
				}
			}
			else
			{
				if (typecode == TypeCode.String)  //如果是字符串
				{
					if (DBNull.Value == source || null == source)
					{
						return Default(destinationType);
					}
					return source.ToString();
				}
				return Default(destinationType);
			}
		}


		private static MethodInfo _getDefaultMethod = null;

		/// <summary>
		/// 获取本类中的 _GetDefault方法
		/// </summary>
		public static MethodInfo GetDefaultMethod
		{
			get
			{
				if (_getDefaultMethod == null)
				{
					_getDefaultMethod = typeof(DataConverterExtension).GetMethod("_GetDefault", BindingFlags.NonPublic | BindingFlags.Static);
				}
				return _getDefaultMethod;
			}
		}

		/// <summary>
		/// 获取一个类型的默认值，与default(指定类型)的作用相同
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		private static object Default(Type t)
		{
			return GetDefaultMethod.MakeGenericMethod(t).Invoke(null, null);
		}

		/// <summary>
		/// 获取泛型类型的默认值，与default(TValue)的作用仙童
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <returns></returns>
		private static TValue Default<TValue>()
		{
			return _GetDefault<TValue>();
		}

		/// <summary>
		/// 获取 默认值的核心功能
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <returns></returns>
		private static TValue _GetDefault<TValue>()
		{
			return default(TValue);
		}

		/// <summary>
		/// 从HttpRequest中获取不会为null的数据
		/// </summary>
		/// <param name="self"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static String GetData(this HttpRequest self, String key)
		{
			var value = self[key];
			if (value == null)
			{
				//throw new Exception(string.Format("请求中未找到[{0}]", key));
				return string.Empty;
			}
			else
			{
				value = value.Trim();
				if (value == string.Empty)
				{
					return string.Empty;
				}
				return value;
			}
		}

		/// <summary>
		/// 将HttpRequest中指定键的值转换为想要的值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static T To<T>(this HttpRequest self, string key)
		{
			return self.GetData(key).To<T>();
		}

		/// <summary>
		/// 把decimal类型转换为没有后缀0的字符串
		/// </summary>
		/// <returns></returns>
		public static string ToNoZero(this decimal self)
		{
			var str = self.ToString();
			var parts = str.Split('.');
			if (parts.Length == 1 || self % 1 == 0)
			{
				return parts[0];
			}
			return parts[0] + "." + parts[1].TrimEnd('0');
		}

		public static string P(this decimal self)
		{
			return (self * 100m).ToNoZero() + "%";
		}
	}
}
