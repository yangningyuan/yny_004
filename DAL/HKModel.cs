using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace yny_004.DAL
{
    /// <summary>
    /// 龙子基类操作
    /// </summary>
    public class HKModel
    {
        public static bool Exist(string code)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from HKModel ");
            sb.AppendFormat("where MajorKey='{0}'", code);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Hashtable Insert(Model.HKModel model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("insert into HKModel (BankName,FromBank,HKCode,HKCreateDate,HKDate,HKState,HKType,MID,RealMoney,ToBank,ValidMoney,IsAuto,Sign,Remark,MajorKey) ");
            sb.Append("values");
            sb.Append("(@BankName,@FromBank,@HKCode,@HKCreateDate,@HKDate,@HKState,@HKType,@MID,@RealMoney,@ToBank,@ValidMoney,@IsAuto,@Sign,@Remark,@MajorKey);");
            sb.AppendFormat("select '{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@BankName", SqlDbType.VarChar,20),
                    new SqlParameter("@FromBank", SqlDbType.VarChar,50),
                    new SqlParameter("@HKCode", SqlDbType.VarChar,36),
                    new SqlParameter("@HKCreateDate", SqlDbType.DateTime,8),
                    new SqlParameter("@HKDate", SqlDbType.DateTime,8),
                    new SqlParameter("@HKState", SqlDbType.Bit,1),
                    new SqlParameter("@HKType", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.VarChar,20),
                    new SqlParameter("@RealMoney", SqlDbType.Decimal),
                    new SqlParameter("@ToBank", SqlDbType.VarChar,50),
                    new SqlParameter("@ValidMoney", SqlDbType.Decimal),
                    new SqlParameter("@IsAuto", SqlDbType.Bit,1),
                    new SqlParameter("@Sign", SqlDbType.Bit,1),
                    new SqlParameter("@Remark", SqlDbType.VarChar,-1),
                    new SqlParameter("@MajorKey", SqlDbType.VarChar,50)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.FromBank;
            parameters[2].Value = model.HKCode;
            parameters[3].Value = model.HKCreateDate;
            parameters[4].Value = model.HKDate;
            parameters[5].Value = model.HKState;
            parameters[6].Value = model.HKType;
            parameters[7].Value = model.MID;
            parameters[8].Value = model.RealMoney;
            parameters[9].Value = model.ToBank;
            parameters[10].Value = model.ValidMoney;
            parameters[11].Value = model.IsAuto;
            parameters[12].Value = model.Sign;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.MajorKey;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Update(Model.HKModel model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("update HKModel set ");
            sb.Append("BankName=@BankName,");
            sb.Append("FromBank=@FromBank,");
            sb.Append("HKCreateDate=@HKCreateDate,");
            sb.Append("HKDate=@HKDate,");
            sb.Append("HKState=@HKState,");
            sb.Append("HKType=@HKType,");
            sb.Append("MID=@MID,");
            sb.Append("RealMoney=@RealMoney,");
            sb.Append("Remark=@Remark,");
            sb.Append("MajorKey=@MajorKey,");
            sb.Append("ToBank=@ToBank,");
            sb.Append("IsAuto=@IsAuto,");
            sb.Append("Sign=@Sign,");
            sb.Append("ValidMoney=@ValidMoney ");
            sb.Append(" where ");
            sb.AppendFormat("HKCode=@HKCode and '{0}'='{0}'", guid);
            SqlParameter[] parameters = {
                    new SqlParameter("@BankName", SqlDbType.VarChar,20),
                    new SqlParameter("@FromBank", SqlDbType.VarChar,50),
                    new SqlParameter("@HKCode", SqlDbType.VarChar,36),
                    new SqlParameter("@HKCreateDate", SqlDbType.DateTime,8),
                    new SqlParameter("@HKDate", SqlDbType.DateTime,8),
                    new SqlParameter("@HKState", SqlDbType.Bit,1),
                    new SqlParameter("@HKType", SqlDbType.Int,4),
                    new SqlParameter("@MID", SqlDbType.VarChar,20),
                    new SqlParameter("@RealMoney", SqlDbType.Decimal),
                    new SqlParameter("@ToBank", SqlDbType.VarChar,50),
                    new SqlParameter("@IsAuto", SqlDbType.Bit,1),
                    new SqlParameter("@Sign", SqlDbType.Bit,1),
                    new SqlParameter("@ValidMoney", SqlDbType.Decimal),
                    new SqlParameter("@Remark", SqlDbType.VarChar,-1),
                    new SqlParameter("@MajorKey", SqlDbType.VarChar,50)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.FromBank;
            parameters[2].Value = model.HKCode;
            parameters[3].Value = model.HKCreateDate;
            parameters[4].Value = model.HKDate;
            parameters[5].Value = model.HKState;
            parameters[6].Value = model.HKType;
            parameters[7].Value = model.MID;
            parameters[8].Value = model.RealMoney;
            parameters[9].Value = model.ToBank;
            parameters[10].Value = model.IsAuto;
            parameters[11].Value = model.Sign;
            parameters[12].Value = model.ValidMoney;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.MajorKey;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Delete(string lzCodeList, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder("delete from HKModel ");
            sb.AppendFormat("where HKCode in ({0})", lzCodeList);
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }
        public static List<Model.HKModel> GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder("select * from HKModel ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            List<Model.HKModel> list = new List<Model.HKModel>();
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static Model.HKModel GetModel(string lzCode)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from HKModel ");
            sb.AppendFormat("where HKCode='{0}'", lzCode);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }
        private static Model.HKModel TranEntity(DataRow dr)
        {
            Model.HKModel model = new Model.HKModel();
            if (!string.IsNullOrEmpty(dr["HKCreateDate"].ToString()))
            {
                model.HKCreateDate = DateTime.Parse(dr["HKCreateDate"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["HKDate"].ToString()))
            {
                model.HKDate = DateTime.Parse(dr["HKDate"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["BankName"].ToString()))
            {
                model.BankName = dr["BankName"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["FromBank"].ToString()))
            {
                model.FromBank = dr["FromBank"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["ToBank"].ToString()))
            {
                model.ToBank = dr["ToBank"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["HKCode"].ToString()))
            {
                model.HKCode = dr["HKCode"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["HKState"].ToString()))
            {
                model.HKState = bool.Parse(dr["HKState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["IsAuto"].ToString()))
            {
                model.IsAuto = bool.Parse(dr["IsAuto"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["Sign"].ToString()))
            {
                model.Sign = bool.Parse(dr["Sign"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["HKType"].ToString()))
            {
                model.HKType = int.Parse(dr["HKType"].ToString());
                if (model.HKType == 1)
                    model.HKTypeStr = DAL.Reward.List["MJB"].RewardName;
                else
                    model.HKTypeStr = "未知类型";
            }
            if (!string.IsNullOrEmpty(dr["Remark"].ToString()))
            {
                model.Remark = dr["Remark"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["MajorKey"].ToString()))
            {
                model.MajorKey = dr["MajorKey"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["MID"].ToString()))
            {
                model.MID = dr["MID"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["RealMoney"].ToString()))
            {
                model.RealMoney = decimal.Parse(dr["RealMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ValidMoney"].ToString()))
            {
                model.ValidMoney = decimal.Parse(dr["ValidMoney"].ToString());
            }
            return model;
        }
        public static List<Model.HKModel> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.HKModel> list = new List<Model.HKModel>();

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
            parameters[0].Value = "HKModel";
            parameters[1].Value = "*";
            parameters[2].Value = "HKCode";
            parameters[3].Value = strWhere;
            parameters[4].Value = "HKCreateDate desc,HKCode asc";
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
