using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace yny_004.DAL
{
    //OrderDetail
    public class OrderDetail
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.OrderDetail GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from OrderDetail ");
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
        public static Hashtable Insert(Model.OrderDetail model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderDetail(");
            strSql.Append("IsDeleted,Status,Code,OrderCode,GId,GCount,BuyPrice,TotalMoney,CreatedTime,CreatedBy");
            strSql.Append(") values (");
            strSql.Append("@IsDeleted,@Status,@Code,@OrderCode,@GId,@GCount,@BuyPrice,@TotalMoney,@CreatedTime,@CreatedBy");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.OrderCode;
            parameters[4].Value = model.GId;
            parameters[5].Value = model.GCount;
            parameters[6].Value = model.BuyPrice;
            parameters[7].Value = model.TotalMoney;
            parameters[8].Value = model.CreatedTime;
            parameters[9].Value = model.CreatedBy;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.OrderDetail model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.OrderDetail model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderDetail set ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" OrderCode = @OrderCode , ");
            strSql.Append(" GId = @GId , ");
            strSql.Append(" GCount = @GCount , ");
            strSql.Append(" BuyPrice = @BuyPrice , ");
            strSql.Append(" TotalMoney = @TotalMoney , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" CreatedBy = @CreatedBy  ");
            strSql.Append(" where Id=@Id  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.IsDeleted;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.OrderCode;
            parameters[4].Value = model.GId;
            parameters[5].Value = model.GCount;
            parameters[6].Value = model.BuyPrice;
            parameters[7].Value = model.TotalMoney;
            parameters[8].Value = model.CreatedTime;
            parameters[9].Value = model.CreatedBy;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.OrderDetail model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderDetail ");
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
            strSql.Append(" FROM OrderDetail ");
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
            strSql.Append(" FROM OrderDetail ");
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
            return DAL.CommonBase.GetTable("OrderDetail", "Id", "Id asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.OrderDetail> GetList(string strWhere)
        {
            List<Model.OrderDetail> list = new List<Model.OrderDetail>();

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
        public static List<Model.OrderDetail> GetList(int top, string strWhere)
        {
            List<Model.OrderDetail> list = new List<Model.OrderDetail>();

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
        public static List<Model.OrderDetail> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.OrderDetail> list = new List<Model.OrderDetail>();

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
        private static Model.OrderDetail TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.OrderDetail model = new Model.OrderDetail();

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
                model.Code = dr["Code"].ToString();
                model.OrderCode = dr["OrderCode"].ToString();
                if (!string.IsNullOrEmpty(dr["GId"].ToString()))
                {
                    model.GId = int.Parse(dr["GId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GCount"].ToString()))
                {
                    model.GCount = int.Parse(dr["GCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyPrice"].ToString()))
                {
                    model.BuyPrice = decimal.Parse(dr["BuyPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TotalMoney"].ToString()))
                {
                    model.TotalMoney = decimal.Parse(dr["TotalMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CreatedTime"].ToString()))
                {
                    model.CreatedTime = DateTime.Parse(dr["CreatedTime"].ToString());
                }
                model.CreatedBy = dr["CreatedBy"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
