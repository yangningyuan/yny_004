/**  版本信息模板在安装目录下，可自行修改。
* StockRight.cs
*
* 功 能： N/A
* 类 名： StockRight
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:09   N/A    初版
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
using System.Collections;
using System.Collections.Generic;//Please add references
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:StockRight
    /// </summary>
    public partial class StockRight
    {
        public StockRight()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "StockRight");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockRight");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public static Hashtable Add(yny_004.Model.StockRight model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockRight(");
            strSql.Append("MID,BuyDate,BuyMoney,BuyCount,StockType,FHCount,FHMoney,IsValid,OutDate)");
            strSql.Append(" values (");
            strSql.Append("@MID,@BuyDate,@BuyMoney,@BuyCount,@StockType,@FHCount,@FHMoney,@IsValid,@OutDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@BuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BuyCount", SqlDbType.Int,4),
					new SqlParameter("@StockType", SqlDbType.VarChar,20),
					new SqlParameter("@FHCount", SqlDbType.Int,4),
					new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OutDate", SqlDbType.DateTime)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.BuyDate;
            parameters[2].Value = model.BuyMoney;
            parameters[3].Value = model.BuyCount;
            parameters[4].Value = model.StockType;
            parameters[5].Value = model.FHCount;
            parameters[6].Value = model.FHMoney;
            parameters[7].Value = model.IsValid;
            parameters[8].Value = model.OutDate;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(yny_004.Model.StockRight model)
        {
            return CommonBase.RunHashtable(Add(model, new Hashtable()));
        }

        public static Hashtable Update(yny_004.Model.StockRight model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockRight set ");
            strSql.Append("MID=@MID,");
            strSql.Append("BuyDate=@BuyDate,");
            strSql.Append("BuyMoney=@BuyMoney,");
            strSql.Append("BuyCount=@BuyCount,");
            strSql.Append("StockType=@StockType,");
            strSql.Append("FHCount=@FHCount,");
            strSql.Append("FHMoney=@FHMoney,");
            strSql.Append("IsValid=@IsValid,");
            strSql.Append("OutDate=@OutDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@BuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BuyCount", SqlDbType.Int,4),
					new SqlParameter("@StockType", SqlDbType.VarChar,20),
					new SqlParameter("@FHCount", SqlDbType.Int,4),
					new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsValid", SqlDbType.Bit,1),
					new SqlParameter("@OutDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.BuyDate;
            parameters[2].Value = model.BuyMoney;
            parameters[3].Value = model.BuyCount;
            parameters[4].Value = model.StockType;
            parameters[5].Value = model.FHCount;
            parameters[6].Value = model.FHMoney;
            parameters[7].Value = model.IsValid;
            parameters[8].Value = model.OutDate;
            parameters[9].Value = model.ID;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.StockRight model)
        {
            return CommonBase.RunHashtable(Update(model, new Hashtable()));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockRight ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockRight ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public static yny_004.Model.StockRight GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MID,BuyDate,BuyMoney,BuyCount,StockType,FHCount,FHMoney,IsValid,OutDate from StockRight ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            yny_004.Model.StockRight model = new yny_004.Model.StockRight();
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
        public static yny_004.Model.StockRight DataRowToModel(DataRow row)
        {
            yny_004.Model.StockRight model = new yny_004.Model.StockRight();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MID"] != null)
                {
                    model.MID = row["MID"].ToString();
                }
                if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                }
                if (row["BuyMoney"] != null && row["BuyMoney"].ToString() != "")
                {
                    model.BuyMoney = decimal.Parse(row["BuyMoney"].ToString());
                }
                if (row["BuyCount"] != null && row["BuyCount"].ToString() != "")
                {
                    model.BuyCount = int.Parse(row["BuyCount"].ToString());
                }
                if (row["StockType"] != null)
                {
                    model.StockType = row["StockType"].ToString();
                }
                if (row["FHCount"] != null && row["FHCount"].ToString() != "")
                {
                    model.FHCount = int.Parse(row["FHCount"].ToString());
                    model.RemainFHCount = DAL.StockRightConfiguration.StockRightCf.stockRightConfigDic[model.StockType].FHCount - model.FHCount;
                }
                if (row["FHMoney"] != null && row["FHMoney"].ToString() != "")
                {
                    model.FHMoney = decimal.Parse(row["FHMoney"].ToString());
                }
                if (row["IsValid"] != null && row["IsValid"].ToString() != "")
                {
                    if ((row["IsValid"].ToString() == "1") || (row["IsValid"].ToString().ToLower() == "true"))
                    {
                        model.IsValid = true;
                    }
                    else
                    {
                        model.IsValid = false;
                    }
                }
                if (row["OutDate"] != null && row["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(row["OutDate"].ToString());
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
            strSql.Append("select ID,MID,BuyDate,BuyMoney,BuyCount,StockType,FHCount,FHMoney,IsValid,OutDate ");
            strSql.Append(" FROM StockRight ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.StockRight> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<yny_004.Model.StockRight> list = new List<yny_004.Model.StockRight>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("StockRight", "ID", "ID desc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,MID,BuyDate,BuyMoney,BuyCount,StockType,FHCount,FHMoney,IsValid,OutDate ");
            strSql.Append(" FROM StockRight ");
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
            strSql.Append("select count(1) FROM StockRight ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from StockRight T ");
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
            parameters[0].Value = "StockRight";
            parameters[1].Value = "ID";
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
        /// 获取购买金额
        /// </summary>
        public static decimal GetBuyMoney(string strWhere)
        {
            string sql = string.Format(@" select sum(BuyMoney) from StockRight where 1 = 1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += strWhere;
            }
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0.00M;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 获取收益
        /// </summary>
        public static decimal GetPutMoney(string strWhere)
        {
            string sql = string.Format(@" select sum((BuyMoney + FHMoney)*FHFloat) from View_StockRight where 1 = 1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += strWhere;
            }
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0.00M;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 获取总收益
        /// </summary>
        public static decimal GetTotalPutMoney(string strWhere)
        {
            string sql = string.Format(@" select sum(BuyMoney + FHMoney) from View_StockRight where 1 = 1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += strWhere;
            }
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0.00M;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 卖出数量
        /// </summary>
        public static int GetSellCount(string strWhere)
        {
            string sql = string.Format(@" select sum(BuyCount) from StockRight where 1 = 1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql += strWhere;
            }
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion  ExtensionMethod
    }
}