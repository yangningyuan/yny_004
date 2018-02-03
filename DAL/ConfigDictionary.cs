using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace yny_004.DAL
{
    public class ConfigDictionary
    {
        public static string GetXJ(int money, string DType = "BJJB")
        {
            var dic = GetConfigDictionary(money, DType, "");
            if (dic != null)
            {
                return dic.Remark;
            }
            return "";
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<Model.ConfigDictionary>> GetDicList()
        {
            Dictionary<string, List<Model.ConfigDictionary>> list = new Dictionary<string, List<Model.ConfigDictionary>>();
            foreach (Model.ConfigDictionary item in GetList())
            {
                if (list.Keys.Contains(item.DType))
                    list[item.DType].Add(item);
                else
                    list.Add(item.DType, new List<Model.ConfigDictionary> { item });
            }

            return list;
        }

        private static List<Model.ConfigDictionary> GetList()
        {
            List<Model.ConfigDictionary> list = new List<Model.ConfigDictionary>();
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
            strSql.Append(" FROM ConfigDictionary order by DType,DKey,StartLevel ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.ConfigDictionary TranEntity(DataRow dr)
        {
            yny_004.Model.ConfigDictionary model = new yny_004.Model.ConfigDictionary();

            if (dr["StartLevel"].ToString() != "")
            {
                model.StartLevel = int.Parse(dr["StartLevel"].ToString());
            }
            if (dr["EndLevel"].ToString() != "")
            {
                model.EndLevel = int.Parse(dr["EndLevel"].ToString());
            }
            if (dr["DValue"] != null)
            {
                model.DValue = dr["DValue"].ToString();
            }
            if (dr["DType"] != null)
            {
                model.DType = dr["DType"].ToString();
            }
            if (dr["DKey"].ToString() != "")
            {
                model.DKey = dr["DKey"].ToString();
            }
            if (dr["Remark"].ToString() != "")
            {
                model.Remark = dr["Remark"].ToString();
            }

            return model;
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(List<Model.ConfigDictionary> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from ConfigDictionary;");
            foreach (Model.ConfigDictionary item in list)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.ConfigDictionary model, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            sb.Append("insert into ConfigDictionary(StartLevel,EndLevel,DValue,DType,DKey,Remark)");
            sb.Append("values");
            sb.Append("(@StartLevel,@EndLevel,@DValue,@DType,@DKey,@Remark)");
            sb.AppendFormat("; select '{0}';", guid);
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@StartLevel",SqlDbType.Int,4),
                new SqlParameter("@EndLevel",SqlDbType.Int,4),
                new SqlParameter("@DValue",SqlDbType.VarChar,10),
                new SqlParameter("@DType",SqlDbType.VarChar,10),
                new SqlParameter("@DKey",SqlDbType.VarChar,10),
                new SqlParameter("@Remark",SqlDbType.VarChar,10)
            };
            para[0].Value = model.StartLevel;
            para[1].Value = model.EndLevel;
            para[2].Value = model.DValue;
            para[3].Value = model.DType;
            para[4].Value = model.DKey;
            para[5].Value = model.Remark;
            MyHs.Add(sb.ToString(), para);
            return MyHs;
        }

        /// <summary>
        /// 得到见点奖
        /// </summary>
        /// <param name="mid">推荐会员账号</param>
        /// <returns></returns>
        public static Model.ConfigDictionary GetConfigDictionary(int Level, string DType, string DKey)
        {
            if (!string.IsNullOrEmpty(DKey))
            {
                foreach (Model.ConfigDictionary item in DAL.Configuration.TModel.ConfigDictionaryList[DType].Where(emp => emp.DKey == DKey))
                {
                    if (item.StartLevel <= Level && (Level <= item.EndLevel || item.EndLevel == -1))
                    {
                        return item;
                    }
                }
            }
            else
            {
                foreach (Model.ConfigDictionary item in DAL.Configuration.TModel.ConfigDictionaryList[DType])
                {
                    if (item.StartLevel <= Level && (Level <= item.EndLevel || item.EndLevel == -1))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 得到见点奖
        /// </summary>
        /// <param name="mid">推荐会员账号</param>
        /// <returns></returns>
        public static Model.ConfigDictionary GetAgentsDictionary(string DType, string DKey)
        {
            foreach (Model.ConfigDictionary item in DAL.Configuration.TModel.ConfigDictionaryList[DType].Where(emp => emp.DKey == DKey))
            {
                return item;
            }
            return null;
        }
    }
}
