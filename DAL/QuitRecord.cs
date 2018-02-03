/**  版本信息模板在安装目录下，可自行修改。
* QuitRecord.cs
*
* 功 能： N/A
* 类 名： QuitRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/9 11:38:00   N/A    初版
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
using System.Collections.Generic;
using System.Collections;//Please add references
namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:QuitRecord
    /// </summary>
    public partial class QuitRecord
    {
        public QuitRecord()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "QuitRecord");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from QuitRecord");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(yny_004.Model.QuitRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QuitRecord(");
            strSql.Append("MID,CreateTime,EnterTime,State,TXMoney,InvestMoney,CompleteTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@MID,@CreateTime,@EnterTime,@State,@TXMoney,@InvestMoney,@CompleteTime,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EnterTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@TXMoney", SqlDbType.Decimal,9),
					new SqlParameter("@InvestMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CompleteTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.EnterTime;
            parameters[3].Value = model.State;
            parameters[4].Value = model.TXMoney;
            parameters[5].Value = model.InvestMoney;
            parameters[6].Value = model.CompleteTime;
            parameters[7].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.QuitRecord model)
        {
            return CommonBase.RunHashtable(Update(model, new Hashtable()));
        }

        public static Hashtable Update(yny_004.Model.QuitRecord model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QuitRecord set ");
            strSql.Append("MID=@MID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("EnterTime=@EnterTime,");
            strSql.Append("State=@State,");
            strSql.Append("TXMoney=@TXMoney,");
            strSql.Append("InvestMoney=@InvestMoney,");
            strSql.Append("CompleteTime=@CompleteTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@EnterTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@TXMoney", SqlDbType.Decimal,9),
					new SqlParameter("@InvestMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CompleteTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.EnterTime;
            parameters[3].Value = model.State;
            parameters[4].Value = model.TXMoney;
            parameters[5].Value = model.InvestMoney;
            parameters[6].Value = model.CompleteTime;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.ID;

            strSql.AppendFormat(" ; select '{0}'; ", Guid.NewGuid());
            MyHs.Add(strSql, parameters);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from QuitRecord ");
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
            strSql.Append("delete from QuitRecord ");
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
        public yny_004.Model.QuitRecord GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from QuitRecord ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            yny_004.Model.QuitRecord model = new yny_004.Model.QuitRecord();
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
        public static yny_004.Model.QuitRecord DataRowToModel(DataRow row)
        {
            yny_004.Model.QuitRecord model = new yny_004.Model.QuitRecord();
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
                if (row["EnterTime"] != null && row["EnterTime"].ToString() != "")
                {
                    model.EnterTime = DateTime.Parse(row["EnterTime"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["TXMoney"] != null && row["TXMoney"].ToString() != "")
                {
                    model.TXMoney = decimal.Parse(row["TXMoney"].ToString());
                }
                if (row["InvestMoney"] != null && row["InvestMoney"].ToString() != "")
                {
                    model.InvestMoney = decimal.Parse(row["InvestMoney"].ToString());
                }
                if (row["CompleteTime"] != null && row["CompleteTime"].ToString() != "")
                {
                    model.CompleteTime = DateTime.Parse(row["CompleteTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append(" FROM QuitRecord ");
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
            strSql.Append(" FROM QuitRecord ");
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
            strSql.Append("select count(1) FROM QuitRecord ");
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
            strSql.Append(")AS Row, T.*  from QuitRecord T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("QuitRecord", "ID", "CreateTime desc,ID asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.QuitRecord> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<yny_004.Model.QuitRecord> list = new List<yny_004.Model.QuitRecord>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        #endregion  ExtensionMethod
    }
}

