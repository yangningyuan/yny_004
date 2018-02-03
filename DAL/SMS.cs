using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace yny_004.DAL
{
    public class SMS
    {
        public static Model.SMS GetModel(object obj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from SMS ");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
            parameters[0].Value = obj;

            yny_004.Model.SMS model = new yny_004.Model.SMS();
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

        private static Model.SMS DataRowToModel(DataRow row)
        {
            yny_004.Model.SMS model = new yny_004.Model.SMS();
            if (row != null)
            {
                if (row["SID"] != null && row["SID"].ToString() != "")
                {
                    model.SID = int.Parse(row["SID"].ToString());
                }
                if (row["SType"] != null)
                {
                    model.SType = (Model.SMSType)Enum.Parse(typeof(Model.SMSType), row["SType"].ToString());
                }
                if (row["SContent"] != null)
                {
                    model.SContent = row["SContent"].ToString();
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["SMSKey"] != null)
                {
                    model.SMSKey = row["SMSKey"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["MID"] != null)
                {
                    model.MID = row["MID"].ToString();
                }
                if (row["SendState"] != null && row["SendState"].ToString() != "")
                {
                    model.SendState = bool.Parse(row["SendState"].ToString());
                }
            }
            return model;
        }

        public static System.Collections.Hashtable Insert(Model.SMS model, System.Collections.Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SMS(");
            strSql.Append("SType,SContent,Tel,SMSKey,CreateDate,MID,SendState,Email)");
            strSql.Append(" values (");
            strSql.Append("@SType,@SContent,@Tel,@SMSKey,@CreateDate,@MID,@SendState,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SType", SqlDbType.VarChar,10),
					new SqlParameter("@SContent", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@SMSKey", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@SendState", SqlDbType.Bit,1),
					new SqlParameter("@Email", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SType;
            parameters[1].Value = model.SContent;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.SMSKey;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.MID;
            parameters[6].Value = model.SendState;
            parameters[7].Value = model.Email;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Insert(Model.SMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SMS(");
            strSql.Append("SType,SContent,Tel,SMSKey,CreateDate,MID,SendState,Email)");
            strSql.Append(" values (");
            strSql.Append("@SType,@SContent,@Tel,@SMSKey,@CreateDate,@MID,@SendState,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SType", SqlDbType.VarChar,10),
					new SqlParameter("@SContent", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@SMSKey", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@SendState", SqlDbType.Bit,1),
					new SqlParameter("@Email", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SType;
            parameters[1].Value = model.SContent;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.SMSKey;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.MID;
            parameters[6].Value = model.SendState;
            parameters[7].Value = model.Email;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return true;
            }
            else
            {
                return Convert.ToInt32(obj) > 0;
            }
        }

        public static System.Collections.Hashtable Update(Model.SMS model, System.Collections.Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append("SType=@SType,");
            strSql.Append("SContent=@SContent,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Email=@Email,");
            strSql.Append("SMSKey=@SMSKey,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("MID=@MID");
            strSql.Append("SendState=@SendState");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SType", SqlDbType.VarChar,10),
					new SqlParameter("@SContent", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@SMSKey", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SendState", SqlDbType.Bit,1)};
            parameters[0].Value = model.SType;
            parameters[1].Value = model.SContent;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.SMSKey;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.MID;
            parameters[7].Value = model.SID;
            parameters[8].Value = model.SendState;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(Model.SMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append("SType=@SType,");
            strSql.Append("SContent=@SContent,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Email=@Email,");
            strSql.Append("SMSKey=@SMSKey,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("MID=@MID,");
            strSql.Append("SendState=@SendState");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SType", SqlDbType.VarChar,10),
					new SqlParameter("@SContent", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@SMSKey", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@MID", SqlDbType.VarChar,50),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SendState", SqlDbType.Bit,1)};
            parameters[0].Value = model.SType;
            parameters[1].Value = model.SContent;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.SMSKey;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.MID;
            parameters[7].Value = model.SID;
            parameters[8].Value = model.SendState;

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

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SMS ");
            strSql.Append(" where SID in (" + obj + ")  ");

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        public static bool Delete(object obj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SMS ");
            strSql.Append(" where SID in (" + obj + ")  ");
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

        public static System.Data.DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SMS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("SMS", "SID", "SID", strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.SMS> GetList(string strWhere)
        {
            List<Model.SMS> list = new List<Model.SMS>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        public static List<Model.SMS> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.SMS> list = new List<Model.SMS>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        public static int GetDayCount(DateTime dateTime)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle(string.Format("select count(1) from SMS where SendState='1' and Tel<>'' and CreateDate between '{0} 00:00:00' and '{0} 23:59:59'", dateTime.ToShortDateString())));
        }

        public static object CodeTimer(string code)
        {
            string sql = "select top 1 CreateDate from SMS where SMSKey = '" + code + "'";
            object obj = DBUtility.DbHelperSQL.GetSingle(sql);
            return obj;
        }
    }
}
