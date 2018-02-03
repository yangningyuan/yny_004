using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace yny_004.DAL
{
    public static class WebBase
    {
        private static Model.WebBase _model;
        public static Model.WebBase Model
        {
            get
            {
                if (_model == null)
                    _model = GetModel("");
                return _model;
            }
        }
        public static Model.WebBase GetModel(object obj)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SMSState,SMSName,SMSPassword,TelVerify,SMSTitle,MonitorTel,SMSMinCount,EmailSmtp,EmailName,EmailPassword,EmailTitle,EmailVerify,EmailState,DaySMSCount,RandPassword,MonitorEmail,AutoID from WebBase ");

            yny_004.Model.WebBase model = new yny_004.Model.WebBase();
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

        private static yny_004.Model.WebBase DataRowToModel(DataRow row)
        {
            yny_004.Model.WebBase model = new yny_004.Model.WebBase();
            if (row != null)
            {
                if (row["SMSState"] != null && row["SMSState"].ToString() != "")
                {
                    if ((row["SMSState"].ToString() == "1") || (row["SMSState"].ToString().ToLower() == "true"))
                    {
                        model.SMSState = true;
                    }
                    else
                    {
                        model.SMSState = false;
                    }
                }
                if (row["SMSName"] != null)
                {
                    model.SMSName = row["SMSName"].ToString();
                }
                if (row["SMSPassword"] != null)
                {
                    model.SMSPassword = row["SMSPassword"].ToString();
                }
                if (row["TelVerify"] != null && row["TelVerify"].ToString() != "")
                {
                    if ((row["TelVerify"].ToString() == "1") || (row["TelVerify"].ToString().ToLower() == "true"))
                    {
                        model.TelVerify = true;
                    }
                    else
                    {
                        model.TelVerify = false;
                    }
                }
                if (row["AutoID"] != null && row["AutoID"].ToString() != "")
                {
                    if ((row["AutoID"].ToString() == "1") || (row["AutoID"].ToString().ToLower() == "true"))
                    {
                        model.AutoID = true;
                    }
                    else
                    {
                        model.AutoID = false;
                    }
                }
                if (row["SMSTitle"] != null)
                {
                    model.SMSTitle = row["SMSTitle"].ToString();
                }
                if (row["MonitorTel"] != null)
                {
                    model.MonitorTel = row["MonitorTel"].ToString();
                }
                if (row["SMSMinCount"] != null && row["SMSMinCount"].ToString() != "")
                {
                    model.SMSMinCount = int.Parse(row["SMSMinCount"].ToString());
                }
                if (row["EmailSmtp"] != null)
                {
                    model.EmailSmtp = row["EmailSmtp"].ToString();
                }
                if (row["EmailName"] != null)
                {
                    model.EmailName = row["EmailName"].ToString();
                }
                if (row["EmailPassword"] != null)
                {
                    model.EmailPassword = row["EmailPassword"].ToString();
                }
                if (row["EmailTitle"] != null)
                {
                    model.EmailTitle = row["EmailTitle"].ToString();
                }
                if (row["EmailVerify"] != null && row["EmailVerify"].ToString() != "")
                {
                    if ((row["EmailVerify"].ToString() == "1") || (row["EmailVerify"].ToString().ToLower() == "true"))
                    {
                        model.EmailVerify = true;
                    }
                    else
                    {
                        model.EmailVerify = false;
                    }
                }
                if (row["EmailState"] != null && row["EmailState"].ToString() != "")
                {
                    if ((row["EmailState"].ToString() == "1") || (row["EmailState"].ToString().ToLower() == "true"))
                    {
                        model.EmailState = true;
                    }
                    else
                    {
                        model.EmailState = false;
                    }
                }
                if (row["DaySMSCount"] != null && row["DaySMSCount"].ToString() != "")
                {
                    model.DaySMSCount = int.Parse(row["DaySMSCount"].ToString());
                }
                if (row["RandPassword"] != null && row["RandPassword"].ToString() != "")
                {
                    if ((row["RandPassword"].ToString() == "1") || (row["RandPassword"].ToString().ToLower() == "true"))
                    {
                        model.RandPassword = true;
                    }
                    else
                    {
                        model.RandPassword = false;
                    }
                }
                if (row["MonitorEmail"] != null)
                {
                    model.MonitorEmail = row["MonitorEmail"].ToString();
                }
            }
            return model;
        }

        public static bool Update(Model.WebBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebBase set ");
            strSql.Append("SMSState=@SMSState,");
            strSql.Append("SMSName=@SMSName,");
            strSql.Append("SMSPassword=@SMSPassword,");
            strSql.Append("TelVerify=@TelVerify,");
            strSql.Append("SMSTitle=@SMSTitle,");
            strSql.Append("MonitorTel=@MonitorTel,");
            strSql.Append("SMSMinCount=@SMSMinCount,");
            strSql.Append("EmailSmtp=@EmailSmtp,");
            strSql.Append("EmailName=@EmailName,");
            strSql.Append("EmailPassword=@EmailPassword,");
            strSql.Append("EmailTitle=@EmailTitle,");
            strSql.Append("EmailVerify=@EmailVerify,");
            strSql.Append("EmailState=@EmailState,");
            strSql.Append("DaySMSCount=@DaySMSCount,");
            strSql.Append("RandPassword=@RandPassword,");
            strSql.Append("AutoID=@AutoID,");
            strSql.Append("MonitorEmail=@MonitorEmail");
            SqlParameter[] parameters = {
					new SqlParameter("@SMSState", SqlDbType.Bit,1),
					new SqlParameter("@SMSName", SqlDbType.VarChar,50),
					new SqlParameter("@SMSPassword", SqlDbType.VarChar,50),
					new SqlParameter("@TelVerify", SqlDbType.Bit,1),
					new SqlParameter("@SMSTitle", SqlDbType.VarChar,50),
					new SqlParameter("@MonitorTel", SqlDbType.VarChar,50),
					new SqlParameter("@SMSMinCount", SqlDbType.Int,4),
					new SqlParameter("@EmailSmtp", SqlDbType.VarChar,50),
					new SqlParameter("@EmailName", SqlDbType.VarChar,50),
					new SqlParameter("@EmailPassword", SqlDbType.VarChar,50),
					new SqlParameter("@EmailTitle", SqlDbType.VarChar,50),
					new SqlParameter("@EmailVerify", SqlDbType.Bit,1),
					new SqlParameter("@EmailState", SqlDbType.Bit,1),
					new SqlParameter("@DaySMSCount", SqlDbType.Int,4),
					new SqlParameter("@RandPassword", SqlDbType.Bit,1),
					new SqlParameter("@AutoID", SqlDbType.Bit,1),
					new SqlParameter("@MonitorEmail", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SMSState;
            parameters[1].Value = model.SMSName;
            parameters[2].Value = model.SMSPassword;
            parameters[3].Value = model.TelVerify;
            parameters[4].Value = model.SMSTitle;
            parameters[5].Value = model.MonitorTel;
            parameters[6].Value = model.SMSMinCount;
            parameters[7].Value = model.EmailSmtp;
            parameters[8].Value = model.EmailName;
            parameters[9].Value = model.EmailPassword;
            parameters[10].Value = model.EmailTitle;
            parameters[11].Value = model.EmailVerify;
            parameters[12].Value = model.EmailState;
            parameters[13].Value = model.DaySMSCount;
            parameters[14].Value = model.RandPassword;
            parameters[15].Value = model.AutoID;
            parameters[16].Value = model.MonitorEmail;

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
    }
}
