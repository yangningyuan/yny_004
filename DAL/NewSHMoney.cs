/**  版本信息模板在安装目录下，可自行修改。
* NewSHMoney.cs
*
* 功 能： N/A
* 类 名： NewSHMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/1 17:49:03   N/A    初版
*
* Copyright (c) 2012 yny_004 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:NewSHMoney
    /// </summary>
    public partial class NewSHMoney
    {
        public NewSHMoney()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string NType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewSHMoney");
            strSql.Append(" where NType=@NType ");
            SqlParameter[] parameters = {
					new SqlParameter("@NType", SqlDbType.VarChar,10)			};
            parameters[0].Value = NType;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(yny_004.Model.NewSHMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewSHMoney(");
            strSql.Append("NType,NName,NJCFloat,NTotalYJ,NSmallSumYJ,NDCount,NMinYJ)");
            strSql.Append(" values (");
            strSql.Append("@NType,@NName,@NJCFloat,@NTotalYJ,@NSmallSumYJ,@NDCount,@NMinYJ)");
            SqlParameter[] parameters = {
					new SqlParameter("@NType", SqlDbType.VarChar,10),
					new SqlParameter("@NName", SqlDbType.VarChar,20),
					new SqlParameter("@NJCFloat", SqlDbType.Decimal,9),
					new SqlParameter("@NTotalYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NSmallSumYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NDCount", SqlDbType.Int,4),
					new SqlParameter("@NMinYJ", SqlDbType.Decimal,9)};
            parameters[0].Value = model.NType;
            parameters[1].Value = model.NName;
            parameters[2].Value = model.NJCFloat;
            parameters[3].Value = model.NTotalYJ;
            parameters[4].Value = model.NSmallSumYJ;
            parameters[5].Value = model.NDCount;
            parameters[6].Value = model.NMinYJ;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.NewSHMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewSHMoney set ");
            strSql.Append("NName=@NName,");
            strSql.Append("NJCFloat=@NJCFloat,");
            strSql.Append("NTotalYJ=@NTotalYJ,");
            strSql.Append("NSmallSumYJ=@NSmallSumYJ,");
            strSql.Append("NDCount=@NDCount,");
            strSql.Append("NMinYJ=@NMinYJ");
            strSql.Append(" where NType=@NType ");
            SqlParameter[] parameters = {
					new SqlParameter("@NName", SqlDbType.VarChar,20),
					new SqlParameter("@NJCFloat", SqlDbType.Decimal,9),
					new SqlParameter("@NTotalYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NSmallSumYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NDCount", SqlDbType.Int,4),
					new SqlParameter("@NMinYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NType", SqlDbType.VarChar,10)};
            parameters[0].Value = model.NName;
            parameters[1].Value = model.NJCFloat;
            parameters[2].Value = model.NTotalYJ;
            parameters[3].Value = model.NSmallSumYJ;
            parameters[4].Value = model.NDCount;
            parameters[5].Value = model.NMinYJ;
            parameters[6].Value = model.NType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string NType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewSHMoney ");
            strSql.Append(" where NType=@NType ");
            SqlParameter[] parameters = {
					new SqlParameter("@NType", SqlDbType.VarChar,10)			};
            parameters[0].Value = NType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string NTypelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewSHMoney ");
            strSql.Append(" where NType in (" + NTypelist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.NewSHMoney GetModel(string NType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NType,NName,NJCFloat,NTotalYJ,NSmallSumYJ,NDCount,NMinYJ from NewSHMoney ");
            strSql.Append(" where NType=@NType ");
            SqlParameter[] parameters = {
					new SqlParameter("@NType", SqlDbType.VarChar,10)			};
            parameters[0].Value = NType;

            yny_004.Model.NewSHMoney model = new yny_004.Model.NewSHMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.NewSHMoney DataRowToModel(DataRow row)
        {
            yny_004.Model.NewSHMoney model = new yny_004.Model.NewSHMoney();
            if (row != null)
            {
                if (row["NType"] != null)
                {
                    model.NType = row["NType"].ToString();
                }
                if (row["NName"] != null)
                {
                    model.NName = row["NName"].ToString();
                }
                if (row["NJCFloat"] != null && row["NJCFloat"].ToString() != "")
                {
                    model.NJCFloat = decimal.Parse(row["NJCFloat"].ToString());
                }
                if (row["NTotalYJ"] != null && row["NTotalYJ"].ToString() != "")
                {
                    model.NTotalYJ = decimal.Parse(row["NTotalYJ"].ToString());
                }
                if (row["NSmallSumYJ"] != null && row["NSmallSumYJ"].ToString() != "")
                {
                    model.NSmallSumYJ = decimal.Parse(row["NSmallSumYJ"].ToString());
                }
                if (row["NDCount"] != null && row["NDCount"].ToString() != "")
                {
                    model.NDCount = int.Parse(row["NDCount"].ToString());
                }
                if (row["NMinYJ"] != null && row["NMinYJ"].ToString() != "")
                {
                    model.NMinYJ = decimal.Parse(row["NMinYJ"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NType,NName,NJCFloat,NTotalYJ,NSmallSumYJ,NDCount,NMinYJ ");
            strSql.Append(" FROM NewSHMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" NType,NName,NJCFloat,NTotalYJ,NSmallSumYJ,NDCount,NMinYJ ");
            strSql.Append(" FROM NewSHMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM NewSHMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.NType desc");
            }
            strSql.Append(")AS Row, T.*  from NewSHMoney T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "NewSHMoney";
            parameters[1].Value = "NType";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.NewSHMoney> GetNewSHMoneyList(DataTable table)
        {
            Dictionary<string, Model.NewSHMoney> SHMoneyList = new Dictionary<string, Model.NewSHMoney>();

            if (table == null)
                table = GetNewSHMoneyListDataTable();

            foreach (DataRow dr in table.Rows)
            {
                Model.NewSHMoney model = DataRowToModel(dr);
                SHMoneyList.Add(model.NType, model);
            }

            return SHMoneyList;
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNewSHMoneyListDataTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM NewSHMoney order by NType ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(Dictionary<string, Model.NewSHMoney> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from NewSHMoney;");
            foreach (Model.NewSHMoney item in list.Values)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.NewSHMoney model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewSHMoney(");
            strSql.Append("NType,NName,NJCFloat,NTotalYJ,NSmallSumYJ,NDCount,NMinYJ)");
            strSql.Append(" values (");
            strSql.Append("@NType,@NName,@NJCFloat,@NTotalYJ,@NSmallSumYJ,@NDCount,@NMinYJ)");
            SqlParameter[] parameters = {
					new SqlParameter("@NType", SqlDbType.VarChar,10),
					new SqlParameter("@NName", SqlDbType.VarChar,20),
					new SqlParameter("@NJCFloat", SqlDbType.Decimal,9),
					new SqlParameter("@NTotalYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NSmallSumYJ", SqlDbType.Decimal,9),
					new SqlParameter("@NDCount", SqlDbType.Int,4),
					new SqlParameter("@NMinYJ", SqlDbType.Decimal,9)};
            parameters[0].Value = model.NType;
            parameters[1].Value = model.NName;
            parameters[2].Value = model.NJCFloat;
            parameters[3].Value = model.NTotalYJ;
            parameters[4].Value = model.NSmallSumYJ;
            parameters[5].Value = model.NDCount;
            parameters[6].Value = model.NMinYJ;

            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }



        #endregion  ExtensionMethod
    }
}

