using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace yny_004.DAL
{
    public class Accounts
    {
        public static Hashtable Insert(Model.Accounts model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("insert into Accounts (PCode,AccountsDate,TotalFHMoney,IsAuto,FHCount,ACode,CreateDate,IfAccount,ARemark) ");
            sb.Append("values");
            sb.Append("(@PCode,@AccountsDate,@TotalFHMoney,@IsAuto,@FHCount,@ACode,@CreateDate,@IfAccount,@ARemark)");
            sb.AppendFormat(" ;select '{0}';", guid);
            SqlParameter[] parameters = {
			        new SqlParameter("@PCode",SqlDbType.VarChar,10),
                    new SqlParameter("@AccountsDate",SqlDbType.DateTime,8),
                    new SqlParameter("@TotalFHMoney",SqlDbType.Decimal),
                    new SqlParameter("@IsAuto",SqlDbType.Bit,1),
                    new SqlParameter("@FHCount",SqlDbType.Int,4),
			        new SqlParameter("@ACode",SqlDbType.VarChar,32),
			        new SqlParameter("@CreateDate",SqlDbType.DateTime,8),
			        new SqlParameter("@IfAccount",SqlDbType.Bit,1),
			        new SqlParameter("@ARemark",SqlDbType.VarChar,20)};
            parameters[0].Value = model.PCode;
            parameters[1].Value = model.AccountsDate;
            parameters[2].Value = model.TotalFHMoney;
            parameters[3].Value = model.IsAuto;
            parameters[4].Value = model.FHCount;
            parameters[5].Value = model.ACode;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.IfAccount;
            parameters[8].Value = model.ARemark;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Update(Model.Accounts model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder sb = new StringBuilder("update Accounts set ");
            sb.Append("ACode=@ACode,");
            sb.Append("PCode=@PCode,");
            sb.Append("AccountsDate=@AccountsDate,");
            sb.Append("TotalFHMoney=@TotalFHMoney,");
            sb.Append("IsAuto=@IsAuto,");
            sb.Append("FHCount=@FHCount,");
            sb.Append("CreateDate=@CreateDate,");
            sb.Append("IfAccount=@IfAccount,");
            sb.Append("ARemark=@ARemark");
            sb.Append(" where ");
            sb.Append("ACode=@ACode");
            sb.AppendFormat(" and '{0}'='{0}'", guid);
            SqlParameter[] parameters = {
			        new SqlParameter("@PCode",SqlDbType.VarChar,10),
                    new SqlParameter("@AccountsDate",SqlDbType.DateTime,8),
                    new SqlParameter("@TotalFHMoney",SqlDbType.Decimal),
                    new SqlParameter("@IsAuto",SqlDbType.Bit,1),
                    new SqlParameter("@FHCount",SqlDbType.Int,4),
			        new SqlParameter("@ACode",SqlDbType.VarChar,32),
			        new SqlParameter("@CreateDate",SqlDbType.DateTime,8),
			        new SqlParameter("@IfAccount",SqlDbType.Bit,1),
			        new SqlParameter("@ARemark",SqlDbType.VarChar,20)};
            parameters[0].Value = model.PCode;
            parameters[1].Value = model.AccountsDate;
            parameters[2].Value = model.TotalFHMoney;
            parameters[3].Value = model.IsAuto;
            parameters[4].Value = model.FHCount;
            parameters[5].Value = model.ACode;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.IfAccount;
            parameters[8].Value = model.ARemark;
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }
        public static bool Delete(string lzTypeCodeList)
        {
            StringBuilder sb = new StringBuilder("delete from Accounts ");
            sb.AppendFormat("where ACode in ({0})", lzTypeCodeList);
            return DbHelperSQL.ExecuteSql(sb.ToString()) > 0;
        }
        public static Hashtable Delete(string lzTypeCodeList, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder("delete from Accounts ");
            sb.AppendFormat("where ID in ({0})", lzTypeCodeList);
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }
        public static List<Model.Accounts> GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder("select * from Accounts ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            List<Model.Accounts> list = new List<Model.Accounts>();
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static List<Model.Accounts> GetList(int top, string strWhere)
        {
            StringBuilder sb = new StringBuilder("select * from ((select top " + top + " * from Accounts ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            sb.Append(" order by CreateDate desc)) as a order by createdate");
            List<Model.Accounts> list = new List<Model.Accounts>();
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        public static List<Model.Accounts> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Accounts> list = new List<Model.Accounts>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("[Accounts]", "ACode", "CreateDate asc,ACode asc", strWhere, pageIndex, pageSize, out count);
        }
        public static Model.Accounts GetModel(string aCode)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from Accounts ");
            sb.AppendFormat("where ACode='{0}'", aCode);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }

        public static Model.Accounts GetTopModel(string pCode, string remark)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from Accounts ");
            sb.AppendFormat(" where PCode='{0}' ", pCode);
            if (!string.IsNullOrEmpty(remark))
                sb.AppendFormat(" and ARemark='{0}' ", remark);
            sb.Append(" and IfAccount='1' order by CreateDate desc");
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }

        private static Model.Accounts TranEntity(DataRow dr)
        {
            Model.Accounts model = new Model.Accounts();
            if (!string.IsNullOrEmpty(dr["ID"].ToString()))
            {
                model.ID = int.Parse(dr["ID"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ACode"].ToString()))
            {
                model.ACode = dr["ACode"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["PCode"].ToString()))
            {
                model.PCode = dr["PCode"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["AccountsDate"].ToString()))
            {
                model.AccountsDate = DateTime.Parse(dr["AccountsDate"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalFHMoney"].ToString()))
            {
                model.TotalFHMoney = decimal.Parse(dr["TotalFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["IsAuto"].ToString()))
            {
                model.IsAuto = bool.Parse(dr["IsAuto"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["FHCount"].ToString()))
            {
                model.FHCount = int.Parse(dr["FHCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["CreateDate"].ToString()))
            {
                model.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["IfAccount"].ToString()))
            {
                model.IfAccount = bool.Parse(dr["IfAccount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ARemark"].ToString()))
            {
                model.ARemark = dr["ARemark"].ToString();
            }
            return model;
        }

        public static string GetFHInfo(string pCode, string remark)
        {
            if (pCode == "003")
            {
                DataTable mcw = DAL.CommonBase.GetTable("select COUNT(1),sum(b.GQCount),SUM(CONVERT(int,dvalue)) from Member a inner join MemberConfig b on a.MID=b.MID left join ConfigDictionary on DType='DFHMoney' and TJCount between StartLevel and EndLevel inner join SHMoney c on a.AgencyCode=c.MAgencyType where CHARINDEX('DFH',JJTypeList)>0 and MState='1' and JTFHState='1' and IsClock<>'1' and RoleCode in ('VIP','Nomal') and TotalDFHMoney<CONVERT(int,DKey) and datediff(dd,isnull((select top 1 changedate from changemoney where changetype='dfh' and ToMID=a.mid order by changedate desc),dateadd(dd,-1,mdate)),getdate())>=1");
                return mcw.Rows[0][0] + "," + mcw.Rows[0][1].ToString() + "," + mcw.Rows[0][2].ToString();//总人数，股权数量，总计金额
            }
            if (pCode == "007")//基金结算
            {
                DataTable mcw = DAL.CommonBase.GetTable("select isnull(SUM(hlgqcount),0) from Member a inner join MemberConfig b on a.MID=b.MID inner join SHMoney c on a.AgencyCode=c.MAgencyType where CHARINDEX('JDFH',JJTypeList)>0 and MState='1' and JTFHState='1' and IsClock<>'1' and RoleCode in ('VIP','Nomal')");
                return mcw.Rows[0][0].ToString();//总人数，购买的基金总额
            }
            return "0,0,0";
        }
    }
}
