using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DBUtility;
using yny_004.Model;

namespace yny_004.DAL
{
    public class BaseParameter
    {
        /// <summary>
        /// 生成参数列表
        /// </summary>
        private static List<Model.BaseParameter> GetBaseParameterList<T>(T _thisT)
        {
            Type _thisType = _thisT.GetType();
            string _className = _thisType.Name;
            List<Model.BaseParameter> baseParameterList = new List<Model.BaseParameter>();
            //遍历类中的属性
            foreach (PropertyInfo property in _thisType.GetProperties())
            {
                if (!IsIgnore(property))
                {//当前表
                    baseParameterList.Add(
                        new Model.BaseParameter()
                        {
                            OwnClass = _className,//类名
                            IdentifyName = property.Name,//属性名
                            PValue = property.GetValue(_thisT, null) + "",//属性值
                            PType = property.PropertyType.Name//属性类型
                        }
                            );
                }
            }
            return baseParameterList;
        }

        /// <summary>
        /// 是否忽略此属性
        /// </summary>
        private static bool IsIgnore(PropertyInfo property)
        {
            return (Attribute.GetCustomAttribute(property, typeof(IgnoreThisAttribute)) as IgnoreThisAttribute) != null;
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns>返回保存结果</returns>
        public static bool SaveChange<T>(T _thisT)
        {
            List<Model.BaseParameter> baseParameterList = GetBaseParameterList<T>(_thisT);
            if (baseParameterList != null && baseParameterList.Count > 0)
            {
                return SaveData(baseParameterList);
            }
            return false;
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns>返回保存结果</returns>
        public static Hashtable SaveChange<T>(T _thisT, Hashtable MyHs)
        {
            List<Model.BaseParameter> baseParameterList = GetBaseParameterList<T>(_thisT);
            if (baseParameterList != null && baseParameterList.Count > 0)
            {
                return SaveData(baseParameterList, MyHs);
            }
            return null;
        }

        /// <summary>
        /// 存储到数据库
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool SaveData(List<Model.BaseParameter> list)
        {
            Hashtable MyHs = new Hashtable();
            SaveData(list, MyHs);
            return CommonBase.RunHashtable(MyHs);
        }

        public static Hashtable SaveData(List<Model.BaseParameter> list, Hashtable MyHs)
        {
            MyHs.Add(string.Format(" delete from [BaseParameter] where [OwnClass] = '{0}' ", list.First().OwnClass), null);
            foreach (Model.BaseParameter model in list)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BaseParameter(");
                strSql.Append("OwnClass,IdentifyName,PValue,PType)");
                strSql.Append(" values (");
                strSql.Append("@OwnClass,@IdentifyName,@PValue,@PType)");
                SqlParameter[] parameters = {
					new SqlParameter("@OwnClass", SqlDbType.VarChar,50),
					new SqlParameter("@IdentifyName", SqlDbType.VarChar,50),
					new SqlParameter("@PValue", SqlDbType.VarChar,50),
					new SqlParameter("@PType", SqlDbType.VarChar,50)};
                parameters[0].Value = model.OwnClass;
                parameters[1].Value = model.IdentifyName;
                parameters[2].Value = model.PValue;
                parameters[3].Value = model.PType;
                string guid = Guid.NewGuid().ToString();
                strSql.AppendFormat(" ;select '{0}'", guid);
                MyHs.Add(strSql.ToString(), parameters);
            }
            return MyHs;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>返回数据</returns>
        private static DataTable GetDataTable<T>(T _thisT)
        {
            //根据类名获取数据
            Type _thisType = _thisT.GetType();
            string _className = _thisType.Name;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select * from [BaseParameter] where [OwnClass] = '{0}' ", _className);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">类名</typeparam>
        public static T GetEntity<T>() where T : class
        {
            T _thisT = System.Activator.CreateInstance<T>();
            DataTable dt = GetDataTable<T>(_thisT);
            Type _thisType = _thisT.GetType();
            foreach (DataRow row in dt.Rows)
            {
                //获取指定名称的属性
                PropertyInfo propertyInfo = _thisType.GetProperty(row["IdentifyName"].ToString());
                if (propertyInfo != null && !IsIgnore(propertyInfo))
                {
                    propertyInfo.SetValue(_thisT, Convert.ChangeType(row["PValue"].ToString(), propertyInfo.PropertyType), null);
                }
            }

            return _thisT;
        }
    }
}
