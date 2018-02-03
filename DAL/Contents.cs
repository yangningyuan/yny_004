using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;

namespace yny_004.DAL
{
    public class Contents
    {

        public static List<Model.Contents> _list = null;
        public static List<Model.Contents> List
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = GetList("");
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public static bool Insert(Model.Contents model)
        {
            StringBuilder sb = new StringBuilder("insert into Contents");
            sb.Append("([CID],[CTitle],[CLevel],[CAddress],[CFID],[CState],[CIndex],[CImage],[VState],[IsQuickMenu],[Remark],IsOuterLink,OuterAddress)");
            sb.Append("values");
            sb.Append("(@CID,@CTitle,@CLevel,@CAddress,@CFID,@CState,@CIndex,@CImage,@VState,@IsQuickMenu,@Remark,@IsOuterLink,@OuterAddress)");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CID",SqlDbType.VarChar,10),
                new SqlParameter("@CTitle",SqlDbType.VarChar,20),
                new SqlParameter("@CLevel",SqlDbType.Int,4),
                new SqlParameter("@CAddress",SqlDbType.VarChar,100),
                new SqlParameter("@CFID",SqlDbType.VarChar,10),
                new SqlParameter("@CState",SqlDbType.Bit,1),
                new SqlParameter("@CIndex",SqlDbType.Int,4),
                new SqlParameter("@CImage",SqlDbType.VarChar,100),
                new SqlParameter("@VState",SqlDbType.Bit,1),
                     new SqlParameter("@IsQuickMenu",SqlDbType.Bit,1),
                     new SqlParameter("@Remark",SqlDbType.VarChar,150),
                        new SqlParameter("@IsOuterLink",SqlDbType.Bit,1),
                      new SqlParameter("@OuterAddress",SqlDbType.VarChar,150)
            };
            para[0].Value = model.CID;
            para[1].Value = model.CTitle;
            para[2].Value = model.CLevel;
            para[3].Value = model.CAddress;
            para[4].Value = model.CFID;
            para[5].Value = model.CState;
            para[6].Value = model.CIndex;
            para[7].Value = model.CImage;
            para[8].Value = model.VState;
            para[9].Value = model.IsQuickMenu;
            para[10].Value = model.Remark;
            para[11].Value = model.IsOuterLink;
            para[12].Value = model.OuterAddress;
            List = null;
            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }

        public static bool Update(Model.Contents model)
        {
            StringBuilder sb = new StringBuilder("update Contents set ");
            sb.Append("CTitle=@CTitle,");
            sb.Append("CLevel=@CLevel,");
            sb.Append("CAddress=@CAddress,");
            sb.Append("CFID=@CFID,");
            sb.Append("CState=@CState,");
            sb.Append("CIndex=@CIndex,");
            sb.Append("CImage=@CImage,");
            sb.Append("VState=@VState,");
            sb.Append("IsQuickMenu=@IsQuickMenu,");
            sb.Append("Remark=@Remark,");
            sb.Append("IsOuterLink=@IsOuterLink,");
            sb.Append("OuterAddress=@OuterAddress");
            sb.Append(" where ");
            sb.Append("CID=@CID");
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CID",SqlDbType.VarChar,10),
                new SqlParameter("@CTitle",SqlDbType.VarChar,20),
                new SqlParameter("@CLevel",SqlDbType.Int,4),
                new SqlParameter("@CAddress",SqlDbType.VarChar,100),
                new SqlParameter("@CFID",SqlDbType.VarChar,10),
                new SqlParameter("@CState",SqlDbType.Bit,1),
                new SqlParameter("@CIndex",SqlDbType.Int,4),
                new SqlParameter("@CImage",SqlDbType.VarChar,100),
                new SqlParameter("@VState",SqlDbType.Bit,1),
                  new SqlParameter("@IsQuickMenu",SqlDbType.Bit,1),
                      new SqlParameter("@Remark",SqlDbType.VarChar,150),
                        new SqlParameter("@IsOuterLink",SqlDbType.Bit,1),
                      new SqlParameter("@OuterAddress",SqlDbType.VarChar,150)
            };
            para[0].Value = model.CID;
            para[1].Value = model.CTitle;
            para[2].Value = model.CLevel;
            para[3].Value = model.CAddress;
            para[4].Value = model.CFID;
            para[5].Value = model.CState;
            para[6].Value = model.CIndex;
            para[7].Value = model.CImage;
            para[8].Value = model.VState;
            para[9].Value = model.IsQuickMenu;
            para[10].Value = model.Remark;
            para[11].Value = model.IsOuterLink;
            para[12].Value = model.OuterAddress;
            List = null;
            return DbHelperSQL.ExecuteSql(sb.ToString(), para) > 0;
        }

        public static bool Delete(string idlist)
        {
            string sb = "delete from Contents where CID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static Model.Contents GetModel(string cid)
        {
            StringBuilder sb = new StringBuilder("select top 1 * from Contents ");
            sb.AppendFormat("where CID='{0}'", cid);
            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            if (table.Rows.Count > 0)
                return TranEntity(table.Rows[0]);
            return null;
        }

        /// <summary>
        /// 得到权限资源列表
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM [Contents] ");
            if (strWhere != "")
                strSql.Append(" where " + strWhere);
            strSql.Append(" order by CLevel,CIndex ");
            DataTable table = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return table;
        }

        /// <summary>
        /// 得到权限资源实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.Contents> GetList(string strWhere)
        {
            List<Model.Contents> MemberList = new List<Model.Contents>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MemberList.Add(TranEntity(table.Rows[i]));
            }

            return MemberList;
        }
        public static List<Model.Contents> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Contents> list = new List<Model.Contents>();

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
            parameters[0].Value = "Contents";
            parameters[1].Value = "*";
            parameters[2].Value = "CID";
            parameters[3].Value = strWhere;
            parameters[4].Value = "CIndex asc,CID asc";
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

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.Contents TranEntity(DataRow dr)
        {
            Model.Contents model = new Model.Contents();

            if (dr["CID"] != null)
            {
                model.CID = dr["CID"].ToString();
            }
            if (dr["CTitle"] != null)
            {
                model.CTitle = dr["CTitle"].ToString();
            }
            if (dr["CLevel"] != null)
            {
                model.CLevel = int.Parse(dr["CLevel"].ToString());
            }
            if (dr["CIndex"] != null)
            {
                model.CIndex = int.Parse(dr["CIndex"].ToString());
            }
            if (dr["CAddress"] != null)
            {
                model.CAddress = dr["CAddress"].ToString();
            }
            if (dr["CFID"] != null)
            {
                model.CFID = dr["CFID"].ToString();
            }
            if (dr["CImage"] != null)
            {
                model.CImage = dr["CImage"].ToString();
            }
            if (dr["CState"].ToString() != "")
            {
                model.CState = bool.Parse(dr["CState"].ToString());
            }
            if (dr["VState"].ToString() != "")
            {
                model.VState = bool.Parse(dr["VState"].ToString()); ;
            }
            if (dr["IsQuickMenu"].ToString() != "")
            {
                model.IsQuickMenu = bool.Parse(dr["IsQuickMenu"].ToString()); ;
            }
            model.Remark = dr["Remark"].ToString();

            if (dr["IsOuterLink"].ToString() != "")
            {
                model.IsOuterLink = bool.Parse(dr["IsOuterLink"].ToString()); ;
            }
            model.OuterAddress = dr["OuterAddress"].ToString(); 

            return model;
        }
    }
}
