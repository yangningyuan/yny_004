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
    public class MConfigChange
    {
        public static Hashtable Add(Model.MConfigChange model, Hashtable MyHs)
        {
            return MyHs;

            StringBuilder sqlstr = new StringBuilder("insert into MConfigChange(MID,SHMID,ChangeDate,ConfigName,ConfigValue,DataType,IsValue) values (@MID,@SHMID,@ChangeDate,@ConfigName,@ConfigValue,@DataType,@IsValue);");
            sqlstr.Append("select '" + Guid.NewGuid().ToString() + "'");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MID", SqlDbType.VarChar,20),
                new SqlParameter("@SHMID",SqlDbType.VarChar,20),
                new SqlParameter("@ChangeDate", SqlDbType.DateTime),
                new SqlParameter("@ConfigName", SqlDbType.VarChar,20),
                new SqlParameter("@ConfigValue", SqlDbType.VarChar,20),
                new SqlParameter("@DataType", SqlDbType.VarChar,20),
                new SqlParameter("@IsValue", SqlDbType.Bit,1)
            };

            para[0].Value = model.MID;
            para[1].Value = model.SHMID;
            para[2].Value = model.ChangeDate;
            para[3].Value = model.ConfigName;
            para[4].Value = model.ConfigValue;
            para[5].Value = model.DataType;
            para[6].Value = model.IsValue;


            MyHs.Add(sqlstr.ToString(), para);
            return MyHs;
        }

        public static List<Model.MConfigChange> GetMConfigChangeEntityList(string strWhere)
        {
            List<Model.MConfigChange> MemberList = new List<Model.MConfigChange>();

            DataTable table = GetMConfigChangeList(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(TranEntity(table.Rows[i]));
            }

            return MemberList;
        }

        private static Model.MConfigChange TranEntity(DataRow dr)
        {
            yny_004.Model.MConfigChange model = new yny_004.Model.MConfigChange();
            if (dr["MID"].ToString() != "")
            {
                model.MID = dr["MID"].ToString();
            }
            if (dr["ChangeDate"].ToString() != "")
            {
                model.ChangeDate = DateTime.Parse(dr["ChangeDate"].ToString());
            }
            if (dr["ConfigName"] != null)
            {
                model.ConfigName = dr["ConfigName"].ToString();
            }
            if (dr["ConfigValue"] != null)
            {
                model.ConfigValue = dr["ConfigValue"].ToString();
            }
            if (dr["DataType"].ToString() != "")
            {
                model.DataType = (SqlDbType)Enum.Parse(typeof(SqlDbType), dr["DataType"].ToString());
            }
            if (dr["SHMID"].ToString() != "")
            {
                model.SHMID = dr["SHMID"].ToString();
            }
            if (dr["IsValue"].ToString() != "")
            {
                if ((dr["IsValue"].ToString() == "1") || (dr["IsValue"].ToString().ToLower() == "true"))
                {
                    model.IsValue = true;
                }
                else
                {
                    model.IsValue = false;
                }
            }

            return model;
        }

        private static DataTable GetMConfigChangeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM MConfigChange ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}
