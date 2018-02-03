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
    public class BCenter
    {
        public static Hashtable Insert(Model.BCenter model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BCenter(");
            strSql.Append("MID,MName,Type,AddDate,Status,ValidTime,Img)");
            strSql.Append(" values (");
            strSql.Append("@MID,@MName,@Type,@AddDate,@Status,@ValidTime,@Img)");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20),
					new SqlParameter("@MName", SqlDbType.VarChar,20),
					new SqlParameter("@Type", SqlDbType.VarChar,10),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@Img", SqlDbType.Text)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.MName;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.ValidTime;
            parameters[6].Value = model.Img;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static List<Model.BCenter> GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder("select * from BCenter ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            List<Model.BCenter> list = new List<Model.BCenter>();
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        private static Model.BCenter TranEntity(DataRow row)
        {
            Model.BCenter model = new Model.BCenter();
            if (row["MID"] != null)
            {
                model.MID = row["MID"].ToString();
            }
            if (row["MName"] != null)
            {
                model.MName = row["MName"].ToString();
            }
            if (row["Type"] != null)
            {
                model.Type = row["Type"].ToString();
            }
            if (row["AddDate"] != null && row["AddDate"].ToString() != "")
            {
                model.AddDate = DateTime.Parse(row["AddDate"].ToString());
            }
            if (row["Status"] != null && row["Status"].ToString() != "")
            {
                if ((row["Status"].ToString() == "1") || (row["Status"].ToString().ToLower() == "true"))
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }
            }
            if (row["ValidTime"] != null && row["ValidTime"].ToString() != "")
            {
                model.ValidTime = DateTime.Parse(row["ValidTime"].ToString());
            }
            if (row["Img"] != null)
            {
                model.Img = row["Img"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.BCenter> GetBCenterEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BCenter> BCenterList = new List<Model.BCenter>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                BCenterList.Add(DAL.BCenter.TranEntity(table.Rows[i]));
            }

            return BCenterList;
        }
        /// <summary>
        /// 得到分页会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回DataTable</returns>
        private static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("BCenter", "MID", "AddDate asc,MID asc", strWhere, pageIndex, pageSize, out count);
        }

        public static bool SHBCenter(string mid)
        {
            return DbHelperSQL.ExecuteSql(string.Format("Update BCenter set Status={0} where MID='{1}'", "1", mid)) > 0;
        }

        public static string DeleteBCenter(string midlist)
        {
            string[] arr = midlist.Split(',');
            int succ = 0;
            int erro = 0;
            foreach (string mid in arr)
            {
                if (DbHelperSQL.ExecuteSql(string.Format("delete from BCenter where Status={0} and  MID='{1}'", "0", mid)) > 0)
                {
                    succ++;
                }
                else
                {
                    erro++;
                }
            }
            return "成功：" + succ.ToString() + " , 失败：" + erro.ToString();
        }

        public static Model.BCenter GetModel(string mid)
        {
            StringBuilder sb = new StringBuilder("select * from BCenter where MID = '" + mid + "' ");
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
            {
                return TranEntity(table.Rows[0]);
            }
            return null;
        }
    }
}