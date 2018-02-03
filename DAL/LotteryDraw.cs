/**  版本信息模板在安装目录下，可自行修改。
* LotteryDraw.cs
*
* 功 能： N/A
* 类 名： LotteryDraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/8 18:39:53   N/A    初版
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
    /// 数据访问类:LotteryDraw
    /// </summary>
    public partial class LotteryDraw
    {
        public LotteryDraw()
        { }

        # region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "LotteryDraw");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LotteryDraw");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_004.Model.LotteryDraw model)
        {
            return CommonBase.RunHashtable(Add(model, new Hashtable()));
        }

        public static Hashtable Add(yny_004.Model.LotteryDraw model, Hashtable MyHs)
        {
            model.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LotteryDraw(");
            strSql.Append("Code,CreateTime,LMoney,State,GetMID,PointMID,CostMoney,GetTime)");
            strSql.Append(" values (");
            strSql.Append("@Code,@CreateTime,@LMoney,@State,@GetMID,@PointMID,@CostMoney,@GetTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LMoney", SqlDbType.Decimal,9),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@GetMID", SqlDbType.VarChar,50),
					new SqlParameter("@PointMID", SqlDbType.VarChar,50),
					new SqlParameter("@CostMoney", SqlDbType.Decimal,9),
					new SqlParameter("@GetTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.LMoney;
            parameters[3].Value = model.State;
            parameters[4].Value = model.GetMID;
            parameters[5].Value = model.PointMID;
            parameters[6].Value = model.CostMoney;
            parameters[7].Value = model.GetTime;

            strSql.AppendFormat(" ; select '{0}';", Guid.NewGuid());
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.LotteryDraw model)
        {
            return CommonBase.RunHashtable(Update(model, new Hashtable()));
        }

        public static Hashtable Update(yny_004.Model.LotteryDraw model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LotteryDraw set ");
            strSql.Append("Code=@Code,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("LMoney=@LMoney,");
            strSql.Append("State=@State,");
            strSql.Append("GetMID=@GetMID,");
            strSql.Append("PointMID=@PointMID,");
            strSql.Append("CostMoney=@CostMoney,");
            strSql.Append("GetTime=@GetTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LMoney", SqlDbType.Decimal,9),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@GetMID", SqlDbType.VarChar,50),
					new SqlParameter("@PointMID", SqlDbType.VarChar,50),
					new SqlParameter("@CostMoney", SqlDbType.Decimal,9),
					new SqlParameter("@GetTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.LMoney;
            parameters[3].Value = model.State;
            parameters[4].Value = model.GetMID;
            parameters[5].Value = model.PointMID;
            parameters[6].Value = model.CostMoney;
            parameters[7].Value = model.GetTime;
            parameters[8].Value = model.ID;

            strSql.AppendFormat(" ; select '{0}'; ", Guid.NewGuid().ToString());
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LotteryDraw ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
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
        public static bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LotteryDraw ");
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
        public yny_004.Model.LotteryDraw GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from LotteryDraw ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            yny_004.Model.LotteryDraw model = new yny_004.Model.LotteryDraw();
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
        public static yny_004.Model.LotteryDraw DataRowToModel(DataRow row)
        {
            yny_004.Model.LotteryDraw model = new yny_004.Model.LotteryDraw();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["LMoney"] != null && row["LMoney"].ToString() != "")
                {
                    model.LMoney = decimal.Parse(row["LMoney"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    if ((row["State"].ToString() == "1") || (row["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (row["GetMID"] != null)
                {
                    model.GetMID = row["GetMID"].ToString();
                }
                if (row["PointMID"] != null)
                {
                    model.PointMID = row["PointMID"].ToString();
                }
                if (row["CostMoney"] != null && row["CostMoney"].ToString() != "")
                {
                    model.CostMoney = decimal.Parse(row["CostMoney"].ToString());
                }
                if (row["GetTime"] != null && row["GetTime"].ToString() != "")
                {
                    model.GetTime = DateTime.Parse(row["GetTime"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM LotteryDraw ");
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
            strSql.Append(" FROM LotteryDraw ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.LotteryDraw> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<yny_004.Model.LotteryDraw> list = new List<yny_004.Model.LotteryDraw>();

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
            return DAL.CommonBase.GetTable("LotteryDraw", "ID", "CreateTime desc,ID asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM LotteryDraw ");
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
            strSql.Append(")AS Row, T.*  from LotteryDraw T ");
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
            parameters[0].Value = "LotteryDraw";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        # endregion  BasicMethod

        # region  ExtensionMethod

        public static Model.LotteryDraw RobDraw(string mid)
        {
            //拆红包
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 *, NewID() as random from LotteryDraw where State = 0 and PointMID = '" + mid + "' order by random ");

            yny_004.Model.LotteryDraw model = null;
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
            }
            if (model != null)
            {
                return model;
            }
            strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 *, NewID() as random from LotteryDraw where State = 0 and (PointMID = '' or PointMID is null) order by random ");
            ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return model;
        }

        # endregion  ExtensionMethod
    }
}

