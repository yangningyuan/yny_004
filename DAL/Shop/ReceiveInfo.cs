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
    //ReceiveInfo
    public class ReceiveInfo
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.ReceiveInfo GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from ReceiveInfo ");
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.ReceiveInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReceiveInfo(");
            strSql.Append("IsDeleted,Status,IsMain,ZipCode,MID,Province,City,Zone,Tel,Receiver,Phone,Address");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@Status,@IsMain,@ZipCode,@MID,@Province,@City,@Zone,@Tel,@Receiver,@Phone,@Address");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsMain", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ZipCode", SqlDbType.NChar,10) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Province", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@City", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Zone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.IsMain;
            parameters[3].Value = model.ZipCode;
            parameters[4].Value = model.MID;
            parameters[5].Value = model.Province;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Zone;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Receiver;
            parameters[10].Value = model.Phone;
            parameters[11].Value = model.Address;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int InsertByID(Model.ReceiveInfo model)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReceiveInfo(");
            strSql.Append("IsDeleted,Status,IsMain,ZipCode,MID,Province,City,Zone,Tel,Receiver,Phone,Address");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@Status,@IsMain,@ZipCode,@MID,@Province,@City,@Zone,@Tel,@Receiver,@Phone,@Address");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@IsMain", SqlDbType.Bit,1) ,
                        new SqlParameter("@ZipCode", SqlDbType.NChar,10) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Province", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@City", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Zone", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Receiver", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Address", SqlDbType.NVarChar,500)

            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.IsMain;
            parameters[3].Value = model.ZipCode;
            parameters[4].Value = model.MID;
            parameters[5].Value = model.Province;
            parameters[6].Value = model.City;
            parameters[7].Value = model.Zone;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Receiver;
            parameters[10].Value = model.Phone;
            parameters[11].Value = model.Address;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.ReceiveInfo model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.ReceiveInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReceiveInfo set ");

            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsMain = @IsMain , ");
            strSql.Append(" ZipCode = @ZipCode , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" Province = @Province , ");
            strSql.Append(" City = @City , ");
            strSql.Append(" Zone = @Zone , ");
            strSql.Append(" Tel = @Tel , ");
            strSql.Append(" Receiver = @Receiver , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" Address = @Address  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsMain", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ZipCode", SqlDbType.NChar,10) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Province", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@City", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Zone", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Tel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Address", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.IsDeleted;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.IsMain;
            parameters[4].Value = model.ZipCode;
            parameters[5].Value = model.MID;
            parameters[6].Value = model.Province;
            parameters[7].Value = model.City;
            parameters[8].Value = model.Zone;
            parameters[9].Value = model.Tel;
            parameters[10].Value = model.Receiver;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.Address;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.ReceiveInfo model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReceiveInfo ");
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
            strSql.Append(" FROM ReceiveInfo ");
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
            strSql.Append(" FROM ReceiveInfo ");
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
            return DAL.CommonBase.GetTable("ReceiveInfo", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.ReceiveInfo> GetList(string strWhere)
        {
            List<Model.ReceiveInfo> list = new List<Model.ReceiveInfo>();

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
        public static List<Model.ReceiveInfo> GetList(int top, string strWhere)
        {
            List<Model.ReceiveInfo> list = new List<Model.ReceiveInfo>();

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
        public static List<Model.ReceiveInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.ReceiveInfo> list = new List<Model.ReceiveInfo>();

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
        private static Model.ReceiveInfo TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.ReceiveInfo model = new Model.ReceiveInfo();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["IsDeleted"].ToString()))
                {
                    model.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = int.Parse(dr["Status"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["IsMain"].ToString()))
                {
                    model.IsMain = bool.Parse(dr["IsMain"].ToString());
                }
                model.ZipCode = dr["ZipCode"].ToString();
                model.MID = dr["MID"].ToString();
                model.Province = dr["Province"].ToString();
                model.City = dr["City"].ToString();
                model.Zone = dr["Zone"].ToString();
                model.Tel = dr["Tel"].ToString();
                model.Receiver = dr["Receiver"].ToString();
                model.Phone = dr["Phone"].ToString();
                model.Address = dr["Address"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
