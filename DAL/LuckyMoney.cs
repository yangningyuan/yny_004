/**  版本信息模板在安装目录下，可自行修改。
* LuckyMoney.cs
*
* 功 能： N/A
* 类 名： LuckyMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/12 10:09:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections;//Please add references
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:LuckyMoney
    /// </summary>
    public partial class LuckyMoney
    {
        public LuckyMoney()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "LuckyMoney");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LuckyMoney");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public static bool Add(yny_004.Model.LuckyMoney model)
        {
            return DAL.CommonBase.RunHashtable(Add(model, new Hashtable()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_004.Model.LuckyMoney model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LuckyMoney(");
            strSql.Append("MID,CreateTime,FHTimes,FHMoney,isValid,TotalMoney,EditTime,ApplyMoney,TakeOffmoney,Type)");
            strSql.Append(" values (");
            strSql.Append("@MID,@CreateTime,@FHTimes,@FHMoney,@isValid,@TotalMoney,@EditTime,@ApplyMoney,@TakeOffmoney,@Type)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MID", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@FHTimes", SqlDbType.Int,4),
                    new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@isValid", SqlDbType.Int,4),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@EditTime", SqlDbType.DateTime),
                    new SqlParameter("@ApplyMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@TakeOffmoney", SqlDbType.Decimal,9),
                    new SqlParameter("@Type", SqlDbType.Int,4)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.FHTimes;
            parameters[3].Value = model.FHMoney;
            parameters[4].Value = model.isValid;
            parameters[5].Value = model.TotalMoney;
            parameters[6].Value = model.EditTime;
            parameters[7].Value = model.ApplyMoney;
            parameters[8].Value = model.TakeOffmoney;
            parameters[9].Value = model.Type;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat("; select '{0}'", guid);

            MyHs.Add(strSql.ToString(), parameters);

            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.LuckyMoney model)
        {
            return CommonBase.RunHashtable(Update(model, new Hashtable()));
        }

        public static Hashtable Update(yny_004.Model.LuckyMoney model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LuckyMoney set ");
            strSql.Append("MID=@MID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("FHTimes=@FHTimes,");
            strSql.Append("FHMoney=@FHMoney,");
            strSql.Append("isValid=@isValid,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("ApplyMoney=@ApplyMoney,");
            strSql.Append("Type=@Type,");
            strSql.Append("TakeOffmoney=@TakeOffmoney,");
            strSql.Append("TotalMoney=@TotalMoney");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MID", SqlDbType.VarChar,20),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@FHTimes", SqlDbType.Int,4),
                    new SqlParameter("@FHMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@isValid", SqlDbType.Int,4),
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@EditTime", SqlDbType.DateTime),
                    new SqlParameter("@ApplyMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@TakeOffmoney", SqlDbType.Decimal,9),
                    new SqlParameter("@Type", SqlDbType.Int,4)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.FHTimes;
            parameters[3].Value = model.FHMoney;
            parameters[4].Value = model.isValid;
            parameters[5].Value = model.TotalMoney;
            parameters[6].Value = model.ID;
            parameters[7].Value = model.EditTime;
            parameters[8].Value = model.ApplyMoney;
            parameters[9].Value = model.TakeOffmoney;
            parameters[10].Value = model.Type;
            strSql.AppendFormat(" ;select '{0}'", Guid.NewGuid().ToString());

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LuckyMoney ");
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
            strSql.Append("delete from LuckyMoney ");
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
        public static yny_004.Model.LuckyMoney GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from LuckyMoney");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            yny_004.Model.LuckyMoney model = new yny_004.Model.LuckyMoney();
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
        public static yny_004.Model.LuckyMoney GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from LuckyMoney");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0} ", strWhere);
            }

            yny_004.Model.LuckyMoney model = new yny_004.Model.LuckyMoney();
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
        public static yny_004.Model.LuckyMoney DataRowToModel(DataRow row)
        {
            yny_004.Model.LuckyMoney model = new yny_004.Model.LuckyMoney();
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
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["EditTime"] != null && row["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(row["EditTime"].ToString());
                }
                if (row["FHTimes"] != null && row["FHTimes"].ToString() != "")
                {
                    model.FHTimes = int.Parse(row["FHTimes"].ToString());
                }
                if (row["FHMoney"] != null && row["FHMoney"].ToString() != "")
                {
                    model.FHMoney = decimal.Parse(row["FHMoney"].ToString());
                }
                if (row["isValid"] != null && row["isValid"].ToString() != "")
                {
                    model.isValid = int.Parse(row["isValid"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["TotalMoney"] != null && row["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = decimal.Parse(row["TotalMoney"].ToString());
                }
                if (row["ApplyMoney"] != null && row["ApplyMoney"].ToString() != "")
                {
                    model.ApplyMoney = decimal.Parse(row["ApplyMoney"].ToString());
                }
                if (row["TakeOffmoney"] != null && row["TakeOffmoney"].ToString() != "")
                {
                    model.TakeOffmoney = decimal.Parse(row["TakeOffmoney"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LuckyMoney ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM LuckyMoney ");
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
            strSql.Append("select count(1) FROM LuckyMoney ");
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
            strSql.Append(")AS Row, T.*  from LuckyMoney T ");
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
            parameters[0].Value = "LuckyMoney";
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
        /// 获取分红会员
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDFHMember()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@" select COUNT(*) number ,MID from LuckyMoney
                                    where FHMoney < {0} and isValid = 1 
                                    group by MID", 0);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 得到分页会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("View_LuckyMoney", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 得到分页会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetTableQ(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("View_LuckyMoney", "ID", "EditTime desc, ID asc", strWhere, pageIndex, pageSize, out count);
        }

        public static bool GetDayRecord(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(*) from LuckyMoney where MID = '" + mid + "' and DATEDIFF(DD,CreateTime,GETDATE()) = 0  ");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static decimal GetTotalMoney(string fileName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(" select SUM({0}) from luckyMoney ", fileName);
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0} ", strWhere);
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }

        }

        public static decimal GetTotalMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(" select SUM(ApplyMoney) from luckyMoney where MID = '" + mid + "' and isvalid = 0 ");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }

        }

        public static int GetCount(string fileName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.AppendFormat(" select count({0}) from luckyMoney ", fileName);
            if (!string.IsNullOrEmpty(strWhere))
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

        #endregion  ExtensionMethod
    }
}

