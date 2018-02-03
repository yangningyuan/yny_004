using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace yny_004.DAL
{
    public class RolePowers
    {
        public static bool Insert(Model.RolePowers model)
        {
            string sb = "insert into RolePowers(RType,CID,IFVerify) values (@RType,@CID,@IFVerify);";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,10),
                new SqlParameter("@CID",SqlDbType.VarChar,10),
                new SqlParameter("@IFVerify", SqlDbType.Bit,1)
            };

            para[0].Value = model.RType;
            para[1].Value = model.CID;
            para[2].Value = model.IFVerify;

            return DbHelperSQL.ExecuteSql(sb, para) > 0;
        }

        public static bool Update(Model.RolePowers model)
        {
            StringBuilder sb = new StringBuilder("update RolePowers set ");
            sb.Append("IFVerify=@IFVerify,");
            sb.Append("RType=@RType,");
            sb.Append("CID=@CID");
            sb.Append(" where ");
            sb.Append("RID=@RID");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,20),
                new SqlParameter("@CID",SqlDbType.VarChar,20),
                new SqlParameter("@IFVerify", SqlDbType.Bit,1),
                new SqlParameter("@RID", SqlDbType.Int,4)
            };

            para[0].Value = model.RType;
            para[1].Value = model.CID;
            para[2].Value = model.IFVerify;
            para[3].Value = model.RID;

            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }
        public static Model.RolePowers GetModel(string cid)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from RolePowers ");
            sb.AppendFormat("where RID={0}", cid);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }

        public static bool Delete(string idlist)
        {
            string sb = "delete from Contents RolePowers RType in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool DeleteByCID(string CID)
        {
            string sb = "delete from  RolePowers where CID='" + CID + "'";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        private static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RolePowers.* ");
            strSql.Append(" FROM RolePowers inner join Contents a on RolePowers.CID=a.CID left join Contents b on a.CFID=b.CID where a.CState='1'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by case when(b.CIndex IS NULL) then a.CIndex else b.CIndex end,a.CFID,a.CIndex ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        private static Model.RolePowers TranEntity(DataRow dr)
        {
            Model.RolePowers model = new Model.RolePowers();
            if (dr["RType"].ToString() != "")
            {
                model.RType = dr["RType"].ToString();
            }
            if (dr["CID"].ToString() != "")
            {
                model.CID = dr["CID"].ToString();
                model.Content = DAL.Contents.List.Single(emp => emp.CID == model.CID);
            }
            if (dr["IFVerify"].ToString() != "")
            {
                model.IFVerify = bool.Parse(dr["IFVerify"].ToString());
            }
            if (dr["RID"].ToString() != "")
            {
                model.RID = int.Parse(dr["RID"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 得到角色列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.RolePowers> GetList(string strWhere)
        {
            List<Model.RolePowers> RolesList = new List<Model.RolePowers>();
            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                RolesList.Add(TranEntity(table.Rows[i]));
            }
            return RolesList;
        }

        public static bool SetVerify(string ridList)
        {
            StringBuilder sb = new StringBuilder("update RolePowers set IFVerify=~IFVerify where RID in (" + ridList + ");");

            return DbHelperSQL.ExecuteSql(sb.ToString()) > 0;
        }
    }
}
