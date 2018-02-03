/**  版本信息模板在安装目录下，可自行修改。
* NConfigDictionary.cs
*
* 功 能： N/A
* 类 名： NConfigDictionary
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/26 16:03:47   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
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
    /// <summary>
    /// 数据访问类:NConfigDictionary
    /// </summary>
    public partial class NConfigDictionary
    {
        public NConfigDictionary()
        { }
        #region  ExtensionMethod
        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<Model.NConfigDictionary>> GetDicList()
        {
            Dictionary<string, List<Model.NConfigDictionary>> list = new Dictionary<string, List<Model.NConfigDictionary>>();
            foreach (Model.NConfigDictionary item in GetList())
            {
                if (list.Keys.Contains(item.NDTpye))
                    list[item.NDTpye].Add(item);
                else
                    list.Add(item.NDTpye, new List<Model.NConfigDictionary> { item });
            }

            return list;
        }

        private static List<Model.NConfigDictionary> GetList()
        {
            List<Model.NConfigDictionary> list = new List<Model.NConfigDictionary>();
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
            strSql.Append(" FROM NConfigDictionary order by NDTpye,DKey,StartLevel ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.NConfigDictionary TranEntity(DataRow row)
        {
            Model.NConfigDictionary model = new Model.NConfigDictionary();
            if (row != null)
            {
                if (row["NDTpye"] != null)
                {
                    model.NDTpye = row["NDTpye"].ToString();
                }
                if (row["DKey"] != null)
                {
                    model.DKey = row["DKey"].ToString();
                }
                if (row["StartLevel"] != null && row["StartLevel"].ToString() != "")
                {
                    model.StartLevel = int.Parse(row["StartLevel"].ToString());
                }
                if (row["EndLevel"] != null && row["EndLevel"].ToString() != "")
                {
                    model.EndLevel = int.Parse(row["EndLevel"].ToString());
                }
                if (row["StartRec"] != null && row["StartRec"].ToString() != "")
                {
                    model.StartRec = int.Parse(row["StartRec"].ToString());
                }
                if (row["EndRec"] != null && row["EndRec"].ToString() != "")
                {
                    model.EndRec = int.Parse(row["EndRec"].ToString());
                }
                if (row["DValue"] != null)
                {
                    model.DValue = row["DValue"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(List<Model.NConfigDictionary> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from NConfigDictionary;");
            foreach (Model.NConfigDictionary item in list)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.NConfigDictionary model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("insert into NConfigDictionary(");
            strSql.Append("NDTpye,DKey,StartLevel,EndLevel,StartRec,EndRec,DValue,Remark)");
            strSql.Append(" values (");
            strSql.Append("@NDTpye,@DKey,@StartLevel,@EndLevel,@StartRec,@EndRec,@DValue,@Remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@NDTpye", SqlDbType.VarChar,50),
					new SqlParameter("@DKey", SqlDbType.VarChar,10),
					new SqlParameter("@StartLevel", SqlDbType.Int,4),
					new SqlParameter("@EndLevel", SqlDbType.Int,4),
					new SqlParameter("@StartRec", SqlDbType.Int,4),
					new SqlParameter("@EndRec", SqlDbType.Int,4),
					new SqlParameter("@DValue", SqlDbType.VarChar,10),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.NDTpye;
            parameters[1].Value = model.DKey;
            parameters[2].Value = model.StartLevel;
            parameters[3].Value = model.EndLevel;
            parameters[4].Value = model.StartRec;
            parameters[5].Value = model.EndRec;
            parameters[6].Value = model.DValue;
            parameters[7].Value = model.Remark;
            strSql.AppendFormat("; select '{0}';", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 得到见点奖
        /// </summary>
        /// <param name="mid">推荐会员账号</param>
        /// <returns></returns>
        public static Model.NConfigDictionary GetConfigDictionary(int Level, int Rec, string DType, string DKey)
        {
            if (!string.IsNullOrEmpty(DKey))
            {
                foreach (Model.NConfigDictionary item in DAL.Configuration.TModel.NConfigDictionaryList[DType].Where(emp => emp.DKey == DKey))
                {
                    if (item.StartLevel <= Level && (Level <= item.EndLevel || item.EndLevel == -1) && item.StartRec <= Rec && (Rec <= item.EndRec || item.EndRec == -1))
                    {
                        return item;
                    }
                }
            }
            else
            {
                foreach (Model.NConfigDictionary item in DAL.Configuration.TModel.NConfigDictionaryList[DType])
                {
                    if (item.StartLevel <= Level && (Level <= item.EndLevel || item.EndLevel == -1) && item.StartRec <= Rec && (Rec <= item.EndRec || item.EndRec == -1))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        #endregion  ExtensionMethod
    }
}

