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
    //Sys_SQ_Answer
    public class Sys_SQ_Answer
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Sys_SQ_Answer GetModel(object ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Status, MID, Code, Answer, CreatedBy, CreatedTime, LastUpdateBy, LastUpdateTime, IsDeleted  ");
            strSql.Append("  from Sys_SQ_Answer ");
            strSql.Append(" where ID=@ID");
         
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.Sys_SQ_Answer model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SQ_Answer(");
            strSql.Append("Status,MID,Code,Answer,CreatedBy,CreatedTime,LastUpdateBy,LastUpdateTime,IsDeleted,QId");
            strSql.Append(") values (");
            strSql.Append("@Status,@MID,@Code,@Answer,@CreatedBy,@CreatedTime,@LastUpdateBy,@LastUpdateTime,@IsDeleted,@QId");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@MID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@Answer", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastUpdateBy", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@LastUpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,
                        new SqlParameter("@QId", SqlDbType.BigInt,8) 
              
            };

            parameters[0].Value = model.Status;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.Answer;
            parameters[4].Value = model.CreatedBy;
            parameters[5].Value = model.CreatedTime;
            parameters[6].Value = model.LastUpdateBy;
            parameters[7].Value = model.LastUpdateTime;
            parameters[8].Value = model.IsDeleted;
            parameters[9].Value = model.QId;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.Sys_SQ_Answer model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.Sys_SQ_Answer model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SQ_Answer set ");

            strSql.Append(" Status = @Status , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" Answer = @Answer , ");
            strSql.Append(" CreatedBy = @CreatedBy , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" LastUpdateBy = @LastUpdateBy , ");
            strSql.Append(" LastUpdateTime = @LastUpdateTime , ");
            strSql.Append(" IsDeleted = @IsDeleted,  ");
            strSql.Append(" QId = @QId  ");
            strSql.Append(" where ID=@ID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@MID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@Answer", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastUpdateBy", SqlDbType.NVarChar,40) ,            
                        new SqlParameter("@LastUpdateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1),
                             new SqlParameter("@QId", SqlDbType.BigInt,8)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.MID;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Answer;
            parameters[5].Value = model.CreatedBy;
            parameters[6].Value = model.CreatedTime;
            parameters[7].Value = model.LastUpdateBy;
            parameters[8].Value = model.LastUpdateTime;
            parameters[9].Value = model.IsDeleted;
            parameters[10].Value = model.QId;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.Sys_SQ_Answer model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SQ_Answer ");
            strSql.AppendFormat(" where ID in ({0})", obj);

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
            strSql.Append(" FROM Sys_SQ_Answer ");
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
            strSql.Append(" FROM Sys_SQ_Answer ");
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
            return DAL.CommonBase.GetTable("Sys_SQ_Answer", "ID", "ID asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.Sys_SQ_Answer> GetList(string strWhere)
        {
            List<Model.Sys_SQ_Answer> list = new List<Model.Sys_SQ_Answer>();

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
        public static List<Model.Sys_SQ_Answer> GetList(int top, string strWhere)
        {
            List<Model.Sys_SQ_Answer> list = new List<Model.Sys_SQ_Answer>();

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
        public static List<Model.Sys_SQ_Answer> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Sys_SQ_Answer> list = new List<Model.Sys_SQ_Answer>();

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
        private static Model.Sys_SQ_Answer TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.Sys_SQ_Answer model = new Model.Sys_SQ_Answer();

                if (!string.IsNullOrEmpty(dr["ID"].ToString()))
                {
                    model.ID = long.Parse(dr["ID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = int.Parse(dr["Status"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MID"].ToString()))
                {
                    model.MID = long.Parse(dr["MID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["QId"].ToString()))
                {
                    model.QId = long.Parse(dr["QId"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.Answer = dr["Answer"].ToString();
                model.CreatedBy = dr["CreatedBy"].ToString();
                if (!string.IsNullOrEmpty(dr["CreatedTime"].ToString()))
                {
                    model.CreatedTime = DateTime.Parse(dr["CreatedTime"].ToString());
                }
                model.LastUpdateBy = dr["LastUpdateBy"].ToString();
                if (!string.IsNullOrEmpty(dr["LastUpdateTime"].ToString()))
                {
                    model.LastUpdateTime = DateTime.Parse(dr["LastUpdateTime"].ToString());
                }
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
