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
    //EPList
    public class EPList
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.EPList GetModel(object EPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from EPList ");
            strSql.Append(" where EPID=@EPID");
            SqlParameter[] parameters = {
					new SqlParameter("@EPID", SqlDbType.Int,4)
			};
            parameters[0].Value = EPID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(yny_004.Model.EPList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EPList(");
            strSql.Append("SellMID,SellDate,MoneyType,Money,SellState,BuyMID,BuyDate,LastBuyDate,LastSellDate,TakeOffMoney,SellType,epPwd,MHGMoney,EPImg,Remark)");
            strSql.Append(" values (");
            strSql.Append("@SellMID,@SellDate,@MoneyType,@Money,@SellState,@BuyMID,@BuyDate,@LastBuyDate,@LastSellDate,@TakeOffMoney,@SellType,@epPwd,@MHGMoney,@EPImg,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SellMID", SqlDbType.VarChar,50),
					new SqlParameter("@SellDate", SqlDbType.DateTime),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,20),
					new SqlParameter("@Money", SqlDbType.Int,4),
					new SqlParameter("@SellState", SqlDbType.Int,4),
					new SqlParameter("@BuyMID", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@LastBuyDate", SqlDbType.DateTime),
					new SqlParameter("@LastSellDate", SqlDbType.DateTime),
					new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SellType", SqlDbType.VarChar,50),
					new SqlParameter("@epPwd", SqlDbType.VarChar,50),
					new SqlParameter("@MHGMoney", SqlDbType.Int,4),
					new SqlParameter("@EPImg", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.SellMID;
            parameters[1].Value = model.SellDate;
            parameters[2].Value = model.MoneyType;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.SellState;
            parameters[5].Value = model.BuyMID;
            parameters[6].Value = model.BuyDate;
            parameters[7].Value = model.LastBuyDate;
            parameters[8].Value = model.LastSellDate;
            parameters[9].Value = model.TakeOffMoney;
            parameters[10].Value = model.SellType;
            parameters[11].Value = model.epPwd;
            parameters[12].Value = model.MHGMoney;
            parameters[13].Value = model.EPImg;
            parameters[14].Value = model.Remark;
            strSql.AppendFormat(";select '{0}'", guid);
            //挂卖减少钱数
            DAL.MemberConfig.UpdateConfigTran(model.SellMID, model.MoneyType, (-model.Money - model.MHGMoney).ToString(), null, false, SqlDbType.Int, MyHs);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(yny_004.Model.EPList model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_004.Model.EPList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EPList set ");
            strSql.Append("SellMID=@SellMID,");
            strSql.Append("SellDate=@SellDate,");
            strSql.Append("MoneyType=@MoneyType,");
            strSql.Append("Money=@Money,");
            strSql.Append("SellState=@SellState,");
            strSql.Append("BuyMID=@BuyMID,");
            strSql.Append("BuyDate=@BuyDate,");
            strSql.Append("LastBuyDate=@LastBuyDate,");
            strSql.Append("LastSellDate=@LastSellDate,");
            strSql.Append("TakeOffMoney=@TakeOffMoney,");
            strSql.Append("SellType=@SellType,");
            strSql.Append("epPwd=@epPwd,");
            strSql.Append("MHGMoney=@MHGMoney,");
            strSql.Append("EPImg=@EPImg,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where EPID=@EPID");
            SqlParameter[] parameters = {
					new SqlParameter("@SellMID", SqlDbType.VarChar,50),
					new SqlParameter("@SellDate", SqlDbType.DateTime),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,20),
					new SqlParameter("@Money", SqlDbType.Int,4),
					new SqlParameter("@SellState", SqlDbType.Int,4),
					new SqlParameter("@BuyMID", SqlDbType.VarChar,50),
					new SqlParameter("@BuyDate", SqlDbType.DateTime),
					new SqlParameter("@LastBuyDate", SqlDbType.DateTime),
					new SqlParameter("@LastSellDate", SqlDbType.DateTime),
					new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SellType", SqlDbType.VarChar,50),
					new SqlParameter("@epPwd", SqlDbType.VarChar,50),
					new SqlParameter("@MHGMoney", SqlDbType.Int,4),
					new SqlParameter("@EPImg", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@EPID", SqlDbType.Int,4)};
            parameters[0].Value = model.SellMID;
            parameters[1].Value = model.SellDate;
            parameters[2].Value = model.MoneyType;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.SellState;
            parameters[5].Value = model.BuyMID;
            parameters[6].Value = model.BuyDate;
            parameters[7].Value = model.LastBuyDate;
            parameters[8].Value = model.LastSellDate;
            parameters[9].Value = model.TakeOffMoney;
            parameters[10].Value = model.SellType;
            parameters[11].Value = model.epPwd;
            parameters[12].Value = model.MHGMoney;
            parameters[13].Value = model.EPImg;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.EPID;
            strSql.AppendFormat(" ;select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.EPList model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EPList ");
            strSql.AppendFormat(" where EPID in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new Hashtable()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM EPList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM EPList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("EPList", "EPID", "SellDate desc,EPID asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.EPList> GetList(string strWhere)
        {
            List<yny_004.Model.EPList> list = new List<yny_004.Model.EPList>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.EPList> GetList(int top, string strWhere)
        {
            List<yny_004.Model.EPList> list = new List<yny_004.Model.EPList>();

            DataTable table = GetTable(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.EPList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<yny_004.Model.EPList> list = new List<yny_004.Model.EPList>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        ///  实体转换
        /// <summary>
        private static yny_004.Model.EPList TranEntity(DataRow row)
        {
            if (row != null)
            {
                yny_004.Model.EPList model = new yny_004.Model.EPList();

                if (row["EPID"] != null && row["EPID"].ToString() != "")
                {
                    model.EPID = int.Parse(row["EPID"].ToString());
                }
                if (row["SellMID"] != null)
                {
                    model.SellMID = row["SellMID"].ToString();
                }
                if (row["SellDate"] != null && row["SellDate"].ToString() != "")
                {
                    model.SellDate = DateTime.Parse(row["SellDate"].ToString());
                }
                if (row["MoneyType"] != null)
                {
                    model.MoneyType = row["MoneyType"].ToString();
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = int.Parse(row["Money"].ToString());
                }
                if (row["SellState"] != null && row["SellState"].ToString() != "")
                {
                    model.SellState = int.Parse(row["SellState"].ToString());
                }
                if (row["BuyMID"] != null)
                {
                    model.BuyMID = row["BuyMID"].ToString();
                }
                if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                }
                if (row["LastBuyDate"] != null && row["LastBuyDate"].ToString() != "")
                {
                    model.LastBuyDate = DateTime.Parse(row["LastBuyDate"].ToString());
                }
                if (row["LastSellDate"] != null && row["LastSellDate"].ToString() != "")
                {
                    model.LastSellDate = DateTime.Parse(row["LastSellDate"].ToString());
                }
                if (row["TakeOffMoney"] != null && row["TakeOffMoney"].ToString() != "")
                {
                    model.TakeOffMoney = decimal.Parse(row["TakeOffMoney"].ToString());
                }
                if (row["SellType"] != null)
                {
                    model.SellType = row["SellType"].ToString();
                }
                if (row["epPwd"] != null)
                {
                    model.epPwd = row["epPwd"].ToString();
                }
                if (row["MHGMoney"] != null && row["MHGMoney"].ToString() != "")
                {
                    model.MHGMoney = int.Parse(row["MHGMoney"].ToString());
                }
                if (row["EPImg"] != null)
                {
                    model.EPImg = row["EPImg"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
