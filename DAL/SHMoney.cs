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
    public class SHMoney
    {
        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.SHMoney> GetSHMoneyList(DataTable table)
        {
            Dictionary<string, Model.SHMoney> SHMoneyList = new Dictionary<string, Model.SHMoney>();

            if (table == null)
                table = GetSHMoneyListDataTable();

            foreach (DataRow dr in table.Rows)
            {
                Model.SHMoney model = TranEntity(dr);
                SHMoneyList.Add(model.MAgencyType, model);
            }

            return SHMoneyList;
        }

        public static List<Model.SHMoney> GetSHMoneyList()
        {
            List<Model.SHMoney> list = new List<Model.SHMoney>();
            DataTable dt = GetSHMoneyListDataTable();

            foreach (DataRow dr in dt.Rows)
            {
                Model.SHMoney model = TranEntity(dr);
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns>+ ' (' + MAgencyName + ')' as 'MoneyMAgencyName' </returns>
        public static DataTable GetSHMoneyListDataTable(string strWhere = "", string order = "MAgencyType")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,Money  FROM SHMoney");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere + " ");
            }
            strSql.Append(" order by " + order + " ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static Model.SHMoney GetModelByStr(string strWhere)
        {
            Model.SHMoney model = null;
            if (!string.IsNullOrEmpty(strWhere))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *,Money + ' (' + MAgencyName + ')' as 'MoneyMAgencyName' ");
                strSql.AppendFormat(" FROM SHMoney where {0} ", strWhere);
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    model = TranEntity(dt.Rows[0]);
                }
            }
            return model;
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.SHMoney TranEntity(DataRow row)
        {
            if (row != null)
            {
                Model.SHMoney model = new Model.SHMoney();

                if (row["MAgencyType"] != null)
                {
                    model.MAgencyType = row["MAgencyType"].ToString();
                }
                if (row["MAgencyName"] != null)
                {
                    model._MAgencyName = row["MAgencyName"].ToString();
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["BTFloat"] != null && row["BTFloat"].ToString() != "")
                {
                    model.BTFloat = decimal.Parse(row["BTFloat"].ToString());
                }
                if (row["TJFloat"] != null && row["TJFloat"].ToString() != "")
                {
                    model.TJFloat = decimal.Parse(row["TJFloat"].ToString());
                }
                if (row["TXFloat"] != null && row["TXFloat"].ToString() != "")
                {
                    model.TXFloat = decimal.Parse(row["TXFloat"].ToString());
                }
                if (row["TakeOffFloat"] != null && row["TakeOffFloat"].ToString() != "")
                {
                    model.TakeOffFloat = decimal.Parse(row["TakeOffFloat"].ToString());
                }
                if (row["ReBuyFloat"] != null && row["ReBuyFloat"].ToString() != "")
                {
                    model.ReBuyFloat = decimal.Parse(row["ReBuyFloat"].ToString());
                }
                if (row["MCWFloat"] != null && row["MCWFloat"].ToString() != "")
                {
                    model.MCWFloat = decimal.Parse(row["MCWFloat"].ToString());
                }
                if (row["MColor"] != null)
                {
                    model.MColor = row["MColor"].ToString();
                }
                if (row["ViewLevel"] != null && row["ViewLevel"].ToString() != "")
                {
                    model.ViewLevel = int.Parse(row["ViewLevel"].ToString());
                }
                if (row["TJCount"] != null && row["TJCount"].ToString() != "")
                {
                    model.TJCount = int.Parse(row["TJCount"].ToString());
                }
                if (row["YJMoney"] != null && row["YJMoney"].ToString() != "")
                {
                    model.YJMoney = decimal.Parse(row["YJMoney"].ToString());
                }
                if (row["TeamCount"] != null && row["TeamCount"].ToString() != "")
                {
                    model.TeamCount = int.Parse(row["TeamCount"].ToString());
                }
                if (row["teamPer"] != null && row["teamPer"].ToString() != "")
                {
                    model.teamPer = decimal.Parse(row["teamPer"].ToString());
                }
                if (row["MinTeamMoney"] != null && row["MinTeamMoney"].ToString() != "")
                {
                    model.MinTeamMoney = decimal.Parse(row["MinTeamMoney"].ToString());
                }
                if (row["SubCount"] != null && row["SubCount"].ToString() != "")
                {
                    model.SubCount = int.Parse(row["SubCount"].ToString());
                }
                if (row["DPFloat"] != null && row["DPFloat"].ToString() != "")
                {
                    model.DPFloat = decimal.Parse(row["DPFloat"].ToString());
                }
                if (row["DPTopMoney"] != null && row["DPTopMoney"].ToString() != "")
                {
                    model.DPTopMoney = decimal.Parse(row["DPTopMoney"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(Dictionary<string, Model.SHMoney> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SHMoney;");
            foreach (Model.SHMoney item in list.Values)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.SHMoney model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SHMoney(");
            strSql.Append("MAgencyType,MAgencyName,Money,BTFloat,TJFloat,TXFloat,TakeOffFloat,ReBuyFloat,MCWFloat,MColor,ViewLevel,TJCount,YJMoney,TeamCount,teamPer,MinTeamMoney,SubCount,DPFloat,DPTopMoney)");
            strSql.Append(" values (");
            strSql.Append("@MAgencyType,@MAgencyName,@Money,@BTFloat,@TJFloat,@TXFloat,@TakeOffFloat,@ReBuyFloat,@MCWFloat,@MColor,@ViewLevel,@TJCount,@YJMoney,@TeamCount,@teamPer,@MinTeamMoney,@SubCount,@DPFloat,@DPTopMoney)");
            SqlParameter[] parameters = {
					new SqlParameter("@MAgencyType", SqlDbType.VarChar,10),
					new SqlParameter("@MAgencyName", SqlDbType.VarChar,20),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@BTFloat", SqlDbType.Decimal,9),
					new SqlParameter("@TJFloat", SqlDbType.Decimal,9),
					new SqlParameter("@TXFloat", SqlDbType.Decimal,9),
					new SqlParameter("@TakeOffFloat", SqlDbType.Decimal,9),
					new SqlParameter("@ReBuyFloat", SqlDbType.Decimal,9),
					new SqlParameter("@MCWFloat", SqlDbType.Decimal,9),
					new SqlParameter("@MColor", SqlDbType.VarChar,10),
					new SqlParameter("@ViewLevel", SqlDbType.Int,4),
					new SqlParameter("@TJCount", SqlDbType.Int,4),
					new SqlParameter("@YJMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TeamCount", SqlDbType.Int,4),
					new SqlParameter("@teamPer", SqlDbType.Decimal,9),
					new SqlParameter("@MinTeamMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SubCount", SqlDbType.Int,4),
                    new SqlParameter("@DPFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@DPTopMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.MAgencyType;
            parameters[1].Value = model._MAgencyName;
            parameters[2].Value = model.Money;
            parameters[3].Value = model.BTFloat;
            parameters[4].Value = model.TJFloat;
            parameters[5].Value = model.TXFloat;
            parameters[6].Value = model.TakeOffFloat;
            parameters[7].Value = model.ReBuyFloat;
            parameters[8].Value = model.MCWFloat;
            parameters[9].Value = model.MColor;
            parameters[10].Value = model.ViewLevel;
            parameters[11].Value = model.TJCount;
            parameters[12].Value = model.YJMoney;
            parameters[13].Value = model.TeamCount;
            parameters[14].Value = model.teamPer;
            parameters[15].Value = model.MinTeamMoney;
            parameters[16].Value = model.SubCount;
            parameters[17].Value = model.DPFloat;
            parameters[18].Value = model.DPTopMoney;

            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
    }
}
