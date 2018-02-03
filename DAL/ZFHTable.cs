/**  版本信息模板在安装目录下，可自行修改。
* ZFHTable.cs
*
* 功 能： N/A
* 类 名： ZFHTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/1/23 15:29:02   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
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
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:ZFHTable
    /// </summary>
    public partial class ZFHTable
    {
        public ZFHTable()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(yny_004.Model.ZFHTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZFHTable(");
            strSql.Append("AllRewardStr,E_JQFHFloat,beginTime,FHMoney,FHState)");
            strSql.Append(" values (");
            strSql.Append("@AllRewardStr,@E_JQFHFloat,@beginTime,@FHMoney,@FHState)");
            SqlParameter[] parameters = {
                    new SqlParameter("@AllRewardStr", SqlDbType.VarChar,-1),
                    new SqlParameter("@E_JQFHFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@beginTime", SqlDbType.DateTime),
                    new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@FHState", SqlDbType.Int,4)};
            parameters[0].Value = model.AllRewardStr;
            parameters[1].Value = model.E_JQFHFloat;
            parameters[2].Value = model.beginTime;
            parameters[3].Value = model.FHMoney;
            parameters[4].Value = model.FHState;

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
        public bool Update(yny_004.Model.ZFHTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZFHTable set ");
            strSql.Append("AllRewardStr=@AllRewardStr,");
            strSql.Append("E_JQFHFloat=@E_JQFHFloat,");
            strSql.Append("beginTime=@beginTime,");
            strSql.Append("FHMoney=@FHMoney,");
            strSql.Append("FHState=@FHState");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AllRewardStr", SqlDbType.VarChar,-1),
                    new SqlParameter("@E_JQFHFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@beginTime", SqlDbType.DateTime),
                    new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@FHState", SqlDbType.Int,4)};
            parameters[0].Value = model.AllRewardStr;
            parameters[1].Value = model.E_JQFHFloat;
            parameters[2].Value = model.beginTime;
            parameters[3].Value = model.FHMoney;
            parameters[4].Value = model.FHState;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZFHTable ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

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
        /// 得到一个对象实体
        /// </summary>
        public yny_004.Model.ZFHTable GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from ZFHTable ");

            yny_004.Model.ZFHTable model = new yny_004.Model.ZFHTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public yny_004.Model.ZFHTable DataRowToModel(DataRow row)
        {
            yny_004.Model.ZFHTable model = new yny_004.Model.ZFHTable();
            if (row != null)
            {
                if (row["AllRewardStr"] != null)
                {
                    model.AllRewardStr = row["AllRewardStr"].ToString();
                }
                if (row["E_JQFHFloat"] != null && row["E_JQFHFloat"].ToString() != "")
                {
                    model.E_JQFHFloat = decimal.Parse(row["E_JQFHFloat"].ToString());
                }
                if (row["beginTime"] != null && row["beginTime"].ToString() != "")
                {
                    model.beginTime = DateTime.Parse(row["beginTime"].ToString());
                }
                if (row["FHMoney"] != null && row["FHMoney"].ToString() != "")
                {
                    model.FHMoney = decimal.Parse(row["FHMoney"].ToString());
                }
                if (row["FHState"] != null && row["FHState"].ToString() != "")
                {
                    model.FHState = int.Parse(row["FHState"].ToString());
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
            strSql.Append("select AllRewardStr,E_JQFHFloat,beginTime,FHMoney,FHState ");
            strSql.Append(" FROM ZFHTable ");
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
            strSql.Append(" AllRewardStr,E_JQFHFloat,beginTime,FHMoney,FHState ");
            strSql.Append(" FROM ZFHTable ");
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
            strSql.Append("select count(1) FROM ZFHTable ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from ZFHTable T ");
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
			parameters[0].Value = "ZFHTable";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

