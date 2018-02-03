/**  版本信息模板在安装目录下，可自行修改。
* StockRightConfig.cs
*
* 功 能： N/A
* 类 名： StockRightConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections;
using System.Collections.Generic;//Please add references
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:StockRightConfig
    /// </summary>
    public partial class StockRightConfig
    {
        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.StockRightConfig> GetStockRightConfigDic(DataTable table = null)
        {
            Dictionary<string, Model.StockRightConfig> List = new Dictionary<string, Model.StockRightConfig>();

            if (table == null)
                table = GetListDataTable();

            foreach (DataRow dr in table.Rows)
            {
                Model.StockRightConfig model = DataRowToModel(dr);
                List.Add(model.Code, model);
            }

            return List;
        }

        public static List<Model.StockRightConfig> GetStockRightConfigList()
        {
            List<Model.StockRightConfig> list = new List<Model.StockRightConfig>();
            DataTable dt = GetListDataTable();

            foreach (DataRow dr in dt.Rows)
            {
                Model.StockRightConfig model = DataRowToModel(dr);
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListDataTable(string strWhere = "", string order = "Code")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  FROM StockRightConfig");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere + " ");
            }
            strSql.Append(" order by " + order + " ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.StockRightConfig DataRowToModel(DataRow row)
        {
            yny_004.Model.StockRightConfig model = new yny_004.Model.StockRightConfig();
            if (row != null)
            {
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["FHCount"] != null && row["FHCount"].ToString() != "")
                {
                    model.FHCount = int.Parse(row["FHCount"].ToString());
                }
                if (row["FHFloat"] != null && row["FHFloat"].ToString() != "")
                {
                    model.FHFloat = decimal.Parse(row["FHFloat"].ToString());
                }
                if (row["BuyMoney"] != null && row["BuyMoney"].ToString() != "")
                {
                    model.BuyMoney = decimal.Parse(row["BuyMoney"].ToString());
                }
                if (row["LimitCount"] != null && row["LimitCount"].ToString() != "")
                {
                    model.LimitCount = int.Parse(row["LimitCount"].ToString());
                }
                model.SellCount = GetSellCount(model.Code, 0);
            }
            return model;
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(Dictionary<string, Model.StockRightConfig> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from StockRightConfig;");
            foreach (Model.StockRightConfig item in list.Values)
            {
                Add(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_004.Model.StockRightConfig model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockRightConfig(");
            strSql.Append("Code,FHCount,FHFloat,BuyMoney,LimitCount)");
            strSql.Append(" values (");
            strSql.Append("@Code,@FHCount,@FHFloat,@BuyMoney,@LimitCount)");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,10),
					new SqlParameter("@FHCount", SqlDbType.Int,4),
					new SqlParameter("@FHFloat", SqlDbType.Decimal,9),
					new SqlParameter("@BuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@LimitCount", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.FHCount;
            parameters[2].Value = model.FHFloat;
            parameters[3].Value = model.BuyMoney;
            parameters[4].Value = model.LimitCount;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 获取卖出数量
        /// </summary>
        public static int GetSellCount(string type, int? day)
        {
            string sql = string.Format(@" select count(1) from StockRight 
                                                            where StockType = '{0}' ", type);
            if (day != null)
            {
                sql += " and DATEDIFF(DAY,BuyDate,GETDATE())=" + day.Value + " ";
            }

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj != null)
                return Convert.ToInt32(obj);
            return 0;
        }
    }
}

