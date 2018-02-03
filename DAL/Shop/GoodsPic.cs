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
    public class GoodsPic
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.GoodsPic GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from GoodsPic ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
        public static Hashtable Insert(Model.GoodsPic model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodsPic(");
            strSql.Append("GId,Code,PicURL,PicSize,IsMain,Decription,IsDeleted,Status");
            strSql.Append(") values (");
            strSql.Append("@GId,@Code,@PicURL,@PicSize,@IsMain,@Decription,@IsDeleted,@Status");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
                        new SqlParameter("@GId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PicURL", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@PicSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsMain", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Decription", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.GId;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.PicURL;
            parameters[3].Value = model.PicSize;
            parameters[4].Value = model.IsMain;
            parameters[5].Value = model.Decription;
            parameters[6].Value = model.IsDeleted;
            parameters[7].Value = model.Status;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.GoodsPic model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.GoodsPic model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodsPic set ");
            strSql.Append(" GId = @GId , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" PicURL = @PicURL , ");
            strSql.Append(" PicSize = @PicSize , ");
            strSql.Append(" IsMain = @IsMain , ");
            strSql.Append(" Decription = @Decription , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where Id=@Id  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                     new SqlParameter("@GId", SqlDbType.VarChar,50) ,      
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PicURL", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@PicSize", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsMain", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Decription", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.GId;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.PicURL;
            parameters[4].Value = model.PicSize;
            parameters[5].Value = model.IsMain;
            parameters[6].Value = model.Decription;
            parameters[7].Value = model.IsDeleted;
            parameters[8].Value = model.Status;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.GoodsPic model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsPic ");
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
            strSql.Append(" FROM GoodsPic ");
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
            strSql.Append(" FROM GoodsPic ");
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
            return DAL.CommonBase.GetTable("GoodsPic", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.GoodsPic> GetList(string strWhere)
        {
            List<Model.GoodsPic> list = new List<Model.GoodsPic>();

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
        public static List<Model.GoodsPic> GetList(int top, string strWhere)
        {
            List<Model.GoodsPic> list = new List<Model.GoodsPic>();

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
        public static List<Model.GoodsPic> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.GoodsPic> list = new List<Model.GoodsPic>();

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
        private static Model.GoodsPic TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.GoodsPic model = new Model.GoodsPic();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }

                model.GId = dr["GId"].ToString();

                model.Code = dr["Code"].ToString();
                model.PicURL = dr["PicURL"].ToString();
                if (!string.IsNullOrEmpty(dr["PicSize"].ToString()))
                {
                    model.PicSize = int.Parse(dr["PicSize"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["IsMain"].ToString()))
                {
                    model.IsMain = bool.Parse(dr["IsMain"].ToString());
                }
                model.Decription = dr["Decription"].ToString();
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
