using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Collections;
using System.Data.SqlClient;

namespace yny_004.DAL
{
    //GoodCategory
    public class GoodCategory
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.GoodCategory GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from GoodCategory ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }
        public static Model.GoodCategory GetModelByCode(object Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from GoodCategory ");
            strSql.Append(" where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,40)
			};
            parameters[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.GoodCategory model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodCategory(");
            strSql.Append("Code,Name,ParentCode,Remark,IsDeleted,Status");
            strSql.Append(") values (");
            strSql.Append("@Code,@Name,@ParentCode,@Remark,@IsDeleted,@Status");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParentCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ParentCode;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.IsDeleted;
            parameters[5].Value = model.Status;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.GoodCategory model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.GoodCategory model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodCategory set ");

            strSql.Append(" Code = @Code , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" ParentCode = @ParentCode , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParentCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.ParentCode;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.IsDeleted;
            parameters[6].Value = model.Status;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.GoodCategory model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodCategory ");
            strSql.AppendFormat(" where Id in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new Hashtable()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM GoodCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM GoodCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("GoodCategory", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.GoodCategory> GetList(string strWhere)
        {
            List<Model.GoodCategory> list = new List<Model.GoodCategory>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.GoodCategory> GetList(int top, string strWhere)
        {
            List<Model.GoodCategory> list = new List<Model.GoodCategory>();

            DataTable table = GetTable(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.GoodCategory> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.GoodCategory> list = new List<Model.GoodCategory>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        ///  实体转换
        /// <summary>
        private static Model.GoodCategory TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.GoodCategory model = new Model.GoodCategory();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.Name = dr["Name"].ToString();
                model.ParentCode = dr["ParentCode"].ToString();
                model.Remark = dr["Remark"].ToString();
                if (!string.IsNullOrEmpty(dr["IsDeleted"].ToString()))
                {
                    model.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = int.Parse(dr["Status"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
