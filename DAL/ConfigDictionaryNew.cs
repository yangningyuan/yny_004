using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DBUtility;

namespace yny_004.DAL
{
    public class ConfigDictionaryNew
    {
        public ConfigDictionaryNew()
        { }
        #region  ExtensionMethod
        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<Model.ConfigDictionaryNew>> GetDicList()
        {
            Dictionary<string, List<Model.ConfigDictionaryNew>> list = new Dictionary<string, List<Model.ConfigDictionaryNew>>();
            foreach (Model.ConfigDictionaryNew item in GetList())
            {
                if (list.Keys.Contains(item.Code))
                    list[item.Code].Add(item);
                else
                    list.Add(item.Code, new List<Model.ConfigDictionaryNew> { item });
            }

            return list;
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.ConfigDictionaryNew> GetDic()
        {
            Dictionary<string, Model.ConfigDictionaryNew> list = new Dictionary<string, Model.ConfigDictionaryNew>();
            foreach (Model.ConfigDictionaryNew item in GetList())
            {
                if (!list.Keys.Contains(item.Code))
                    list.Add(item.Code, item);
            }

            return list;
        }

        public static List<Model.ConfigDictionaryNew> GetList()
        {
            List<Model.ConfigDictionaryNew> list = new List<Model.ConfigDictionaryNew>();
            foreach (DataRow dr in GetTable().Rows)
            {
                list.Add(TranEntity(dr));
            }
            return list;
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ConfigDictionaryNew order by Code ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.ConfigDictionaryNew TranEntity(DataRow row)
        {
            Model.ConfigDictionaryNew model = new Model.ConfigDictionaryNew();
            if (row != null)
            {
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Dkey"] != null)
                {
                    model.Dkey = row["Dkey"].ToString();
                }
                if (row["TJCount"] != null && row["TJCount"].ToString() != "")
                {
                    model.TJCount = int.Parse(row["TJCount"].ToString());
                }
                if (row["SubTJCount"] != null && row["SubTJCount"].ToString() != "")
                {
                    model.SubTJCount = int.Parse(row["SubTJCount"].ToString());
                }
                if (row["GJCount"] != null && row["GJCount"].ToString() != "")
                {
                    model.GJCount = int.Parse(row["GJCount"].ToString());
                }
                if (row["CJCount"] != null && row["CJCount"].ToString() != "")
                {
                    model.CJCount = int.Parse(row["CJCount"].ToString());
                }
                if (row["FHMoney"] != null && row["FHMoney"].ToString() != "")
                {
                    model.FHMoney = decimal.Parse(row["FHMoney"].ToString());
                }
                if (row["OutFloat"] != null && row["OutFloat"].ToString() != "")
                {
                    model.OutFloat = decimal.Parse(row["OutFloat"].ToString());
                }
                if (row["HBFHFloat"] != null && row["HBFHFloat"].ToString() != "")
                {
                    model.HBFHFloat = decimal.Parse(row["HBFHFloat"].ToString());
                }
                if (row["FHDays"] != null && row["FHDays"].ToString() != "")
                {
                    model.FHDays = int.Parse(row["FHDays"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(List<Model.ConfigDictionaryNew> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from ConfigDictionaryNew;");
            foreach (Model.ConfigDictionaryNew item in list)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.ConfigDictionaryNew model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("insert into ConfigDictionaryNew(");
            strSql.Append("Code,Dkey,TJCount,SubTJCount,GJCount,CJCount,FHMoney,OutFloat,HBFHFloat,FHDays)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Dkey,@TJCount,@SubTJCount,@GJCount,@CJCount,@FHMoney,@OutFloat,@HBFHFloat,@FHDays)");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,10),
					new SqlParameter("@Dkey", SqlDbType.VarChar,10),
					new SqlParameter("@TJCount", SqlDbType.Int,4),
					new SqlParameter("@SubTJCount", SqlDbType.Int,4),
					new SqlParameter("@GJCount", SqlDbType.Int,4),
					new SqlParameter("@CJCount", SqlDbType.Int,4),
					new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
					new SqlParameter("@OutFloat", SqlDbType.Decimal,9),
					new SqlParameter("@HBFHFloat", SqlDbType.Decimal,9),
					new SqlParameter("@FHDays", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Dkey;
            parameters[2].Value = model.TJCount;
            parameters[3].Value = model.SubTJCount;
            parameters[4].Value = model.GJCount;
            parameters[5].Value = model.CJCount;
            parameters[6].Value = model.FHMoney;
            parameters[7].Value = model.OutFloat;
            parameters[8].Value = model.HBFHFloat;
            parameters[9].Value = model.FHDays;
            strSql.AppendFormat("; select '{0}';", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 得到见点奖
        /// </summary>
        public static Model.ConfigDictionaryNew GetConfigDictionary(int Level, int TJCount, int SubTJCount)
        {
            var list = DAL.ConfigDictionaryNew.GetList();
            foreach (Model.ConfigDictionaryNew item in list)
            {
                if (item.GJCount <= Level && (Level <= item.CJCount || item.CJCount == -1) && item.TJCount <= TJCount && item.SubTJCount <= SubTJCount)
                {
                    return item;
                }
            }
            return null;
        }

        #endregion  ExtensionMethod
    }
}
