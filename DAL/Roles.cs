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
    public class Roles
    {
        private static Dictionary<string, Model.Roles> _rolsList = null;
        public static Dictionary<string, Model.Roles> RolsList
        {
            get
            {
                if (_rolsList == null || _rolsList.Count == 0)
                {
                    _rolsList = new Dictionary<string, Model.Roles>();
                    foreach (Model.Roles r in GetList(""))
                    {
                        if (!_rolsList.ContainsKey(r.RType))
                            _rolsList.Add(r.RType, r);
                    }
                }
                return _rolsList;
            }
            set
            {
                _rolsList = value;
            }
        }

        public static bool Insert(Model.Roles model)
        {
            string sb = "insert into Roles(RType,RName,CMessage,IsAdmin,CanSH,CanLogin,VState,Super,RColor,XingZheng,CaiWu,KeFu) values (@RType,@RName,@CMessage,@IsAdmin,@CanSH,@CanLogin,@VState,@Super,@RColor,@XingZheng,@CaiWu,@KeFu);";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,20),
                new SqlParameter("@RName",SqlDbType.VarChar,20),
                new SqlParameter("@CMessage", SqlDbType.Bit,1),
                new SqlParameter("@IsAdmin", SqlDbType.Bit,1),
                new SqlParameter("@CanSH", SqlDbType.Bit,1),
                new SqlParameter("@CanLogin", SqlDbType.Bit,1),
                new SqlParameter("@VState", SqlDbType.Bit,1),
                new SqlParameter("@Super", SqlDbType.Bit,1),
                new SqlParameter("@RColor", SqlDbType.VarChar,10),
                new SqlParameter("@XingZheng", SqlDbType.Bit,1),
                new SqlParameter("@CaiWu", SqlDbType.Bit,1),
                new SqlParameter("@KeFu", SqlDbType.Bit,1)
            };

            para[0].Value = model.RType;
            para[1].Value = model.RName;
            para[2].Value = model.CMessage;
            para[3].Value = model.IsAdmin;
            para[4].Value = model.CanSH;
            para[5].Value = model.CanLogin;
            para[6].Value = model.VState;
            para[7].Value = model.Super;
            para[8].Value = model.RColor;
            para[9].Value = model.XingZheng;
            para[10].Value = model.CaiWu;
            para[11].Value = model.KeFu;

            DAL.Roles.RolsList = null;
            return DbHelperSQL.ExecuteSql(sb, para) > 0;
        }

        public static bool Update(Model.Roles model)
        {
            StringBuilder sb = new StringBuilder("update Roles set ");
            sb.Append("RType=@RType,");
            sb.Append("RName=@RName,");
            sb.Append("CMessage=@CMessage,");
            sb.Append("IsAdmin=@IsAdmin,");
            sb.Append("CanSH=@CanSH,");
            sb.Append("CanLogin=@CanLogin,");
            sb.Append("VState=@VState,");
            sb.Append("Super=@Super,");
            sb.Append("CaiWu=@CaiWu,");
            sb.Append("XingZheng=@XingZheng,");
            sb.Append("KeFu=@KeFu,");
            sb.Append("RColor=@RColor");
            sb.Append(" where ");
            sb.Append("RType=@RType");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,20),
                new SqlParameter("@RName",SqlDbType.VarChar,20),
                new SqlParameter("@CMessage", SqlDbType.Bit,1),
                new SqlParameter("@IsAdmin", SqlDbType.Bit,1),
                new SqlParameter("@CanSH", SqlDbType.Bit,1),
                new SqlParameter("@CanLogin", SqlDbType.Bit,1),
                new SqlParameter("@VState", SqlDbType.Bit,1),
                new SqlParameter("@Super", SqlDbType.Bit,1),
                new SqlParameter("@RColor", SqlDbType.VarChar,10),
                new SqlParameter("@XingZheng", SqlDbType.Bit,1),
                new SqlParameter("@CaiWu", SqlDbType.Bit,1),
                new SqlParameter("@KeFu", SqlDbType.Bit,1)
            };

            para[0].Value = model.RType;
            para[1].Value = model.RName;
            para[2].Value = model.CMessage;
            para[3].Value = model.IsAdmin;
            para[4].Value = model.CanSH;
            para[5].Value = model.CanLogin;
            para[6].Value = model.VState;
            para[7].Value = model.Super;
            para[8].Value = model.RColor;
            para[9].Value = model.XingZheng;
            para[10].Value = model.CaiWu;
            para[11].Value = model.KeFu;

            DAL.Roles.RolsList = null;
            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }
        public static Model.Roles GetModel(string cid)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from Roles ");
            sb.AppendFormat("where RType='{0}'", cid);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }

        public static bool Delete(string idlist)
        {
            string sb = "delete from Contents Roles RType in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        private static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Roles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by RIndex ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        private static Model.Roles TranEntity(DataRow dr)
        {
            Model.Roles model = new Model.Roles();
            if (dr["RType"].ToString() != "")
            {
                model.RType = dr["RType"].ToString();
                model.PowersList = DAL.RolePowers.GetList("RType='" + model.RType + "'");
            }
            if (dr["RName"].ToString() != "")
            {
                model.RName = dr["RName"].ToString();
            }
            if (dr["CMessage"].ToString() != "")
            {
                model.CMessage = bool.Parse(dr["CMessage"].ToString());
            }
            if (dr["IsAdmin"].ToString() != "")
            {
                model.IsAdmin = bool.Parse(dr["IsAdmin"].ToString());
            }
            if (dr["CanSH"].ToString() != "")
            {
                model.CanSH = bool.Parse(dr["CanSH"].ToString());
            }
            if (dr["CanLogin"].ToString() != "")
            {
                model.CanLogin = bool.Parse(dr["CanLogin"].ToString());
            }
            if (dr["VState"].ToString() != "")
            {
                model.VState = bool.Parse(dr["VState"].ToString());
            }
            if (dr["Super"].ToString() != "")
            {
                model.Super = bool.Parse(dr["Super"].ToString());
            }
            if (dr["RColor"].ToString() != "")
            {
                model.RColor = dr["RColor"].ToString();
            }
            if (dr["KeFu"].ToString() != "")
            {
                model.KeFu = bool.Parse(dr["KeFu"].ToString());
            }
            if (dr["CaiWu"].ToString() != "")
            {
                model.CaiWu = bool.Parse(dr["CaiWu"].ToString());
            }
            if (dr["XingZheng"].ToString() != "")
            {
                model.XingZheng = bool.Parse(dr["XingZheng"].ToString());
            }
            return model;
        }

        /// <summary>
        /// 得到角色列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.Roles> GetList(string strWhere)
        {
            List<Model.Roles> RolesList = new List<Model.Roles>();
            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                RolesList.Add(TranEntity(table.Rows[i]));
            }
            return RolesList;
        }

        public static bool SetVerify(string cidList, string mType)
        {
            StringBuilder sb = new StringBuilder("update RolePowers set IFVerify=~IFVerify where RType=@RType and RID in (" + cidList + ");");

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,10)
            };
            para[0].Value = mType;
            DAL.Roles.RolsList = null;
            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }

        public static List<Model.Roles> GetRolesEntityList(string strWhere)
        {
            List<Model.Roles> RolesList = new List<Model.Roles>();
            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                RolesList.Add(TranEntity(table.Rows[i]));
            }
            return RolesList;
        }

        public static DataTable GetPowers(string strWhere, string mType)
        {
            StringBuilder sb = new StringBuilder("select Contents.CID,Contents.CTitle,RolePowers.RType,IsQuickMenu,CImage from Contents left join RolePowers on Contents.CID=RolePowers.CID");
            sb.Append(" and RType='" + mType + "'  where Contents.CState='1' ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.Append(strWhere);
            sb.Append(" ORDER BY SUBSTRING(Contents.CID, 0, 5), CIndex");
            return DbHelperSQL.Query(sb.ToString()).Tables[0];
        }

        public static string GrantPowers(string powers, string RType)
        {
            if (!DAL.Roles.RolsList.ContainsKey(RType))
                return "操作失败";
            StringBuilder sb = new StringBuilder("delete from RolePowers where RType=@RType;");
            if (powers != "")
            {
                string[] power = powers.Split(',');
                foreach (string s in power)
                    sb.Append("insert into RolePowers(RType,CID,IFVerify) values(@RType,'" + s + "','True');");
            }

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RType", SqlDbType.VarChar,10)
            };
            para[0].Value = RType;

            if (DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0)
            {
                DAL.Roles.RolsList = null;
                return "操作成功";
            }
            return "操作失败";
        }
    }
}
