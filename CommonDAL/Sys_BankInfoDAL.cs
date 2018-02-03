using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBUtility;
using CommonModel;

namespace CommonDAL
{
    //Sys_BankInfo
    public class Sys_BankInfoDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Sys_BankInfo GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from Sys_BankInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt)
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
        public static Hashtable Insert(Sys_BankInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_BankInfo(");
            strSql.Append("Status,Code,Name,PicUrl,CreatedTime,CreatedBy,UpdatedTime,UpdatedBy,IsDeleted,LinkUrl,Remark");
            strSql.Append(") values (");
            strSql.Append("@Status,@Code,@Name,@PicUrl,@CreatedTime,@CreatedBy,@UpdatedTime,@UpdatedBy,@IsDeleted,@LinkUrl,@Remark");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,40) ,             
                        new SqlParameter("@UpdatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdatedBy", SqlDbType.VarChar,40) ,        
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1),
                          new SqlParameter("@LinkUrl", SqlDbType.VarChar,100) ,
                            new SqlParameter("@Remark", SqlDbType.VarChar,1000)
              
            };

            parameters[0].Value = model.Status;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.PicUrl;
            parameters[4].Value = model.CreatedTime;
            parameters[5].Value = model.CreatedBy;
            parameters[6].Value = model.UpdatedTime;
            parameters[7].Value = model.UpdatedBy;
            parameters[8].Value = model.IsDeleted;
            parameters[9].Value = model.LinkUrl;
            parameters[10].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Sys_BankInfo model)
        {
            return CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Sys_BankInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_BankInfo set ");

            strSql.Append(" Status = @Status , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" PicUrl = @PicUrl , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" CreatedBy = @CreatedBy , ");
            strSql.Append(" UpdatedTime = @UpdatedTime , ");
            strSql.Append(" UpdatedBy = @UpdatedBy , ");
            strSql.Append(" IsDeleted = @IsDeleted,  ");
            strSql.Append(" LinkUrl = @LinkUrl , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Status", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,40) ,             
                        new SqlParameter("@UpdatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UpdatedBy", SqlDbType.VarChar,40) ,              
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,
                           new SqlParameter("@LinkUrl", SqlDbType.VarChar,100) ,
                            new SqlParameter("@Remark", SqlDbType.VarChar,1000)
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.PicUrl;
            parameters[5].Value = model.CreatedTime;
            parameters[6].Value = model.CreatedBy;
            parameters[7].Value = model.UpdatedTime;
            parameters[8].Value = model.UpdatedBy;
            parameters[9].Value = model.IsDeleted;
            parameters[10].Value = model.LinkUrl;
            parameters[11].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Sys_BankInfo model)
        {
            return CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_BankInfo ");
            strSql.AppendFormat(" where Id in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(object obj)
        {
            return CommonBase.RunHashtable(Delete(obj, new Hashtable()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Sys_BankInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
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
            strSql.Append(" FROM Sys_BankInfo ");
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
            return CommonBase.GetTable("Sys_BankInfo", "Id", "Id asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Sys_BankInfo> GetList(string strWhere)
        {
            List<Sys_BankInfo> list = new List<Sys_BankInfo>();

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
        public static List<Sys_BankInfo> GetList(int top, string strWhere)
        {
            List<Sys_BankInfo> list = new List<Sys_BankInfo>();

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
        public static List<Sys_BankInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Sys_BankInfo> list = new List<Sys_BankInfo>();

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
        private static Sys_BankInfo TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Sys_BankInfo model = new Sys_BankInfo();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = long.Parse(dr["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = bool.Parse(dr["Status"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.Name = dr["Name"].ToString();
                model.PicUrl = dr["PicUrl"].ToString();
                model.LinkUrl = dr["LinkUrl"].ToString();
                model.Remark = dr["Remark"].ToString();
                if (!string.IsNullOrEmpty(dr["CreatedTime"].ToString()))
                {
                    model.CreatedTime = DateTime.Parse(dr["CreatedTime"].ToString());
                }

                model.CreatedBy = dr["CreatedBy"].ToString();

                if (!string.IsNullOrEmpty(dr["UpdatedTime"].ToString()))
                {
                    model.UpdatedTime = DateTime.Parse(dr["UpdatedTime"].ToString());
                }

                model.UpdatedBy = dr["UpdatedBy"].ToString();

                if (!string.IsNullOrEmpty(dr["IsDeleted"].ToString()))
                {
                    model.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
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
