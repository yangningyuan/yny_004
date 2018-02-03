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

    //ShopCar
    public class ShopCar
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.ShopCar GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from ShopCar ");
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
        public static Hashtable Insert(Model.ShopCar model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ShopCar(");
            strSql.Append("IsDeleted,Status,BuyPrice,Code,MID,GId,GType,GCount,AddTime,AddBy,Remark");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@Status,@BuyPrice,@Code,@MID,@GId,@GType,@GCount,@AddTime,@AddBy,@Remark");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000)             
              
            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.BuyPrice;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.MID;
            parameters[5].Value = model.GId;
            parameters[6].Value = model.GType;
            parameters[7].Value = model.GCount;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.AddBy;
            parameters[10].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.ShopCar model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.ShopCar model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopCar set ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" BuyPrice = @BuyPrice , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" GId = @GId , ");
            strSql.Append(" GType = @GType , ");
            strSql.Append(" GCount = @GCount , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" AddBy = @AddBy , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AddBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000) ,
                           new SqlParameter("@Id", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.BuyPrice;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.MID;
            parameters[5].Value = model.GId;
            parameters[6].Value = model.GType;
            parameters[7].Value = model.GCount;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.AddBy;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Id;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.ShopCar model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShopCar ");
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
            strSql.Append(" FROM ShopCar ");
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
            strSql.Append(" FROM ShopCar ");
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
            return DAL.CommonBase.GetTable("ShopCar", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.ShopCar> GetList(string strWhere)
        {
            List<Model.ShopCar> list = new List<Model.ShopCar>();

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
        public static List<Model.ShopCar> GetList(int top, string strWhere)
        {
            List<Model.ShopCar> list = new List<Model.ShopCar>();

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
        public static List<Model.ShopCar> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.ShopCar> list = new List<Model.ShopCar>();

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
        private static Model.ShopCar TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.ShopCar model = new Model.ShopCar();

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
                if (!string.IsNullOrEmpty(dr["BuyPrice"].ToString()))
                {
                    model.BuyPrice = decimal.Parse(dr["BuyPrice"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.MID = dr["MID"].ToString();
                if (!string.IsNullOrEmpty(dr["GId"].ToString()))
                {
                    model.GId = int.Parse(dr["GId"].ToString());
                }
                model.GType = dr["GType"].ToString();
                if (!string.IsNullOrEmpty(dr["GCount"].ToString()))
                {
                    model.GCount = int.Parse(dr["GCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["AddTime"].ToString()))
                {
                    model.AddTime = DateTime.Parse(dr["AddTime"].ToString());
                }
                model.AddBy = dr["AddBy"].ToString();
                model.Remark = dr["Remark"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
