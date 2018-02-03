/**  版本信息模板在安装目录下，可自行修改。
* Agents.cs
*
* 功 能： N/A
* 类 名： Agents
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/10 12:00:24   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using System.Collections.Generic;

namespace yny_004.DAL
{
    /// <summary>
    /// 数据访问类:Agents
    /// </summary>
    public partial class Agents
    {
        public Agents()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Agents");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Agents");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_004.Model.Agents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Agents(");
            strSql.Append("MID,Province,City,Zone,Type,FHFloat,CreateTime,IsValid,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@MID,@Province,@City,@Zone,@Type,@FHFloat,@CreateTime,@IsValid,@Remarks)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MID", SqlDbType.VarChar,50),
                    new SqlParameter("@Province", SqlDbType.VarChar,50),
                    new SqlParameter("@City", SqlDbType.VarChar,50),
                    new SqlParameter("@Zone", SqlDbType.VarChar,50),
                    new SqlParameter("@Type", SqlDbType.VarChar,50),
                    new SqlParameter("@FHFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsValid", SqlDbType.Int,4),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.Province;
            parameters[2].Value = model.City;
            parameters[3].Value = model.Zone;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.FHFloat;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.IsValid;
            parameters[8].Value = model.Remarks;

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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.Agents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Agents set ");
            strSql.Append("MID=@MID,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Zone=@Zone,");
            strSql.Append("Type=@Type,");
            strSql.Append("FHFloat=@FHFloat,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("IsValid=@IsValid");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MID", SqlDbType.VarChar,50),
                    new SqlParameter("@Province", SqlDbType.VarChar,50),
                    new SqlParameter("@City", SqlDbType.VarChar,50),
                    new SqlParameter("@Zone", SqlDbType.VarChar,50),
                    new SqlParameter("@Type", SqlDbType.VarChar,50),
                    new SqlParameter("@FHFloat", SqlDbType.Decimal,9),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsValid", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.Province;
            parameters[2].Value = model.City;
            parameters[3].Value = model.Zone;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.FHFloat;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.IsValid;
            parameters[8].Value = model.ID;
            parameters[9].Value = model.Remarks;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Agents ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

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

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Agents ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.Agents GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Agents ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            yny_004.Model.Agents model = new yny_004.Model.Agents();
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

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.Agents> GetBCenterEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Agents> BCenterList = new List<Model.Agents>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                BCenterList.Add(DataRowToModel(table.Rows[i]));
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
            return CommonBase.GetTable("Agents", "ID", "ID desc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.Agents DataRowToModel(DataRow row)
        {
            yny_004.Model.Agents model = new yny_004.Model.Agents();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MID"] != null)
                {
                    model.MID = row["MID"].ToString();
                }
                if (row["Province"] != null)
                {
                    model.Province = row["Province"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["Zone"] != null)
                {
                    model.Zone = row["Zone"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["FHFloat"] != null && row["FHFloat"].ToString() != "")
                {
                    model.FHFloat = decimal.Parse(row["FHFloat"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["IsValid"] != null && row["IsValid"].ToString() != "")
                {
                    model.IsValid = (Model.AgentValidEnum)int.Parse(row["IsValid"].ToString());
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Model.Agents> GetModelList(string strWhere)
        {
            List<Model.Agents> list = new List<Model.Agents>();
            DataTable table = table = GetList(strWhere).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Agents ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Agents ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Agents ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Agents T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Agents";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod


        #endregion  ExtensionMethod
    }
}

