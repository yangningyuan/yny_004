using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using CommonDAL;

namespace yny_004.DAL
{
    /// <summary>
    /// 银行卡管理操作
    /// </summary>
    public class BankModel
    {
        public static Hashtable Insert(Model.BankModel model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("insert into BankModel (BankCode,Bank,Branch,BankNumber,BankCardName,MID,IsPrimary,BankCreateDate) ");
            sb.Append("values");
            sb.Append("(@BankCode,@Bank,@Branch,@BankNumber,@BankCardName,@MID,@IsPrimary,@BankCreateDate);");
            sb.AppendFormat("select '{0}'", guid);
            SqlParameter[] parameters = {
					new SqlParameter("@BankCode", SqlDbType.VarChar,36),
					new SqlParameter("@Bank", SqlDbType.VarChar,50),
					new SqlParameter("@Branch", SqlDbType.VarChar,50),
					new SqlParameter("@BankNumber", SqlDbType.VarChar,30),
					new SqlParameter("@BankCardName", SqlDbType.VarChar,20),
					new SqlParameter("@MID", SqlDbType.VarChar,20),
					new SqlParameter("@IsPrimary", SqlDbType.Bit,1),
					new SqlParameter("@BankCreateDate", SqlDbType.DateTime,8)};
            parameters[0].Value = model.BankCode;
            parameters[1].Value = model.Bank;
            parameters[2].Value = model.Branch;
            parameters[3].Value = model.BankNumber;
            parameters[4].Value = model.BankCardName;
            parameters[5].Value = model.MID;
            parameters[6].Value = model.IsPrimary;
            parameters[7].Value = model.BankCreateDate;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Update(Model.BankModel model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("update BankModel set ");
            sb.Append("Bank=@Bank,");
            sb.Append("Branch=@Branch,");
            sb.Append("BankNumber=@BankNumber,");
            sb.Append("BankCardName=@BankCardName,");
            sb.Append("MID=@MID,");
            sb.Append("IsPrimary=@IsPrimary,");
            sb.Append("BankCreateDate=@BankCreateDate");
            sb.Append(" where ");
            sb.AppendFormat("BankCode=@BankCode and '{0}'='{0}'", guid);
            SqlParameter[] parameters = {
					new SqlParameter("@BankCode", SqlDbType.VarChar,36),
					new SqlParameter("@Bank", SqlDbType.VarChar,50),
					new SqlParameter("@Branch", SqlDbType.VarChar,50),
					new SqlParameter("@BankNumber", SqlDbType.VarChar,30),
					new SqlParameter("@BankCardName", SqlDbType.VarChar,20),
					new SqlParameter("@MID", SqlDbType.VarChar,20),
					new SqlParameter("@IsPrimary", SqlDbType.Bit,1),
					new SqlParameter("@BankCreateDate", SqlDbType.DateTime,8)};
            parameters[0].Value = model.BankCode;
            parameters[1].Value = model.Bank;
            parameters[2].Value = model.Branch;
            parameters[3].Value = model.BankNumber;
            parameters[4].Value = model.BankCardName;
            parameters[5].Value = model.MID;
            parameters[6].Value = model.IsPrimary;
            parameters[7].Value = model.BankCreateDate;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Delete(string bankCodeList, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder("delete from BankModel ");
            sb.AppendFormat("where BankCode in ({0})", bankCodeList);
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }
        public static Model.BankModel GetModel(string lzCode)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from BankModel ");
            sb.AppendFormat("where BankCode='{0}'", lzCode);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }
        private static Model.BankModel TranEntity(DataRow dr)
        {
            Model.BankModel model = new Model.BankModel();
            if (!string.IsNullOrEmpty(dr["BankCreateDate"].ToString()))
            {
                model.BankCreateDate = DateTime.Parse(dr["BankCreateDate"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["Bank"].ToString()))
            {
                model.Bank = dr["Bank"].ToString();
                model.BankInfo = Sys_BankInfoDAL.GetModel(dr["Bank"]);
            }
            if (!string.IsNullOrEmpty(dr["BankCardName"].ToString()))
            {
                model.BankCardName = dr["BankCardName"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["BankCode"].ToString()))
            {
                model.BankCode = dr["BankCode"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["BankNumber"].ToString()))
            {
                model.BankNumber = dr["BankNumber"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["Branch"].ToString()))
            {
                model.Branch = dr["Branch"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["MID"].ToString()))
            {
                model.MID = dr["MID"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["IsPrimary"].ToString()))
            {
                model.IsPrimary = bool.Parse(dr["IsPrimary"].ToString());
            }
            return model;
        }
        public static List<Model.BankModel> GetList(string strWhere)
        {
            List<Model.BankModel> list = new List<Model.BankModel>();
            StringBuilder sb = new StringBuilder("select * from BankModel ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static List<Model.BankModel> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BankModel> list = new List<Model.BankModel>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        private static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 50),
                    new SqlParameter("@FieldList", SqlDbType.VarChar, 50),
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 50),
                    new SqlParameter("@Where", SqlDbType.VarChar, 500),
                    new SqlParameter("@Order", SqlDbType.VarChar, 50),
                    new SqlParameter("@SortType", SqlDbType.Int,4),
                    new SqlParameter("@RecorderCount", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@PageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@TotalPageCount", SqlDbType.Int,4)};
            parameters[0].Value = "BankModel";
            parameters[1].Value = "*";
            parameters[2].Value = "BankCode";
            parameters[3].Value = strWhere;
            parameters[4].Value = "IsPrimary desc,BankCreateDate asc,BankCode asc";
            parameters[5].Value = 3;
            parameters[6].Value = 0;
            parameters[7].Value = pageSize;
            parameters[8].Value = pageIndex;
            parameters[9].Direction = ParameterDirection.InputOutput;
            parameters[10].Direction = ParameterDirection.InputOutput;

            DataTable table = DbHelperSQL.RunProcedure("P_AspNetPage", parameters, "Table").Tables[0];
            count = Convert.ToInt32(parameters[9].Value);
            return table;
        }
    }
}
