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
    public class Order
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Order GetModel(object Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from [Order] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Code;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.Order model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Order](");
            strSql.Append("Status,IsDeleted,CreatedTime,CreatedBy,ReceiveId,ExpressCompany,ExpressCode,Code,TotalPrice,GoodCount,OrderTime,MID,PayTime,SendTime,ReceiveTime,Remarks,DisCountTotalPrice");
            strSql.Append(") values (");
            strSql.Append("@Status,@IsDeleted,@CreatedTime,@CreatedBy,@ReceiveId,@ExpressCompany,@ExpressCode,@Code,@TotalPrice,@GoodCount,@OrderTime,@MID,@PayTime,@SendTime,@ReceiveTime,@Remarks,@DisCountTotalPrice");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ReceiveId", SqlDbType.Int,4) ,
                        new SqlParameter("@ExpressCompany", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@ExpressCode", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@GoodCount", SqlDbType.Int,4) ,
                        new SqlParameter("@OrderTime", SqlDbType.DateTime) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ReceiveTime", SqlDbType.DateTime),
                        new SqlParameter("@Remarks", SqlDbType.VarChar,100),
                        new SqlParameter("@DisCountTotalPrice", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.Status;
            parameters[1].Value = model.IsDeleted;
            parameters[2].Value = model.CreatedTime;
            parameters[3].Value = model.CreatedBy;
            parameters[4].Value = model.ReceiveId;
            parameters[5].Value = model.ExpressCompany;
            parameters[6].Value = model.ExpressCode;
            parameters[7].Value = model.Code;
            parameters[8].Value = model.TotalPrice;
            parameters[9].Value = model.GoodCount;
            parameters[10].Value = model.OrderTime;
            parameters[11].Value = model.MID;
            parameters[12].Value = model.PayTime;
            parameters[13].Value = model.SendTime;
            parameters[14].Value = model.ReceiveTime;
            parameters[15].Value = model.Remarks;
            parameters[16].Value = model.DisCountTotalPrice;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.Order model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.Order model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Order] set ");

            strSql.Append(" Status = @Status , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" CreatedTime = @CreatedTime , ");
            strSql.Append(" CreatedBy = @CreatedBy , ");
            strSql.Append(" ReceiveId = @ReceiveId , ");
            strSql.Append(" ExpressCompany = @ExpressCompany , ");
            strSql.Append(" ExpressCode = @ExpressCode , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" TotalPrice = @TotalPrice , ");
            strSql.Append(" GoodCount = @GoodCount , ");
            strSql.Append(" OrderTime = @OrderTime , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" PayTime = @PayTime , ");
            strSql.Append(" SendTime = @SendTime , ");
            strSql.Append(" Remarks = @Remarks , ");
            strSql.Append(" DisCountTotalPrice = @DisCountTotalPrice , ");
            strSql.Append(" ReceiveTime = @ReceiveTime  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@Status", SqlDbType.Int,4) ,
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,
                        new SqlParameter("@CreatedTime", SqlDbType.DateTime) ,
                        new SqlParameter("@CreatedBy", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ReceiveId", SqlDbType.Int,4) ,
                        new SqlParameter("@ExpressCompany", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@ExpressCode", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@GoodCount", SqlDbType.Int,4) ,
                        new SqlParameter("@OrderTime", SqlDbType.DateTime) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ReceiveTime", SqlDbType.DateTime),
                        new SqlParameter("@Remarks", SqlDbType.VarChar,100),
                        new SqlParameter("@DisCountTotalPrice", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.IsDeleted;
            parameters[3].Value = model.CreatedTime;
            parameters[4].Value = model.CreatedBy;
            parameters[5].Value = model.ReceiveId;
            parameters[6].Value = model.ExpressCompany;
            parameters[7].Value = model.ExpressCode;
            parameters[8].Value = model.Code;
            parameters[9].Value = model.TotalPrice;
            parameters[10].Value = model.GoodCount;
            parameters[11].Value = model.OrderTime;
            parameters[12].Value = model.MID;
            parameters[13].Value = model.PayTime;
            parameters[14].Value = model.SendTime;
            parameters[15].Value = model.ReceiveTime;
            parameters[16].Value = model.Remarks;
            parameters[17].Value = model.DisCountTotalPrice;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.Order model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Order] ");
            strSql.AppendFormat(" where Code in ({0})", obj);

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
            strSql.Append(" FROM [Order] ");
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
            strSql.Append(" FROM [Order] ");
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
            return DAL.CommonBase.GetTable("[Order]", "ID", "ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.Order> GetList(string strWhere)
        {
            List<Model.Order> list = new List<Model.Order>();

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
        public static List<Model.Order> GetList(int top, string strWhere)
        {
            List<Model.Order> list = new List<Model.Order>();

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
        public static List<Model.Order> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Order> list = new List<Model.Order>();

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
        private static Model.Order TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.Order model = new Model.Order();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = int.Parse(dr["Status"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["IsDeleted"].ToString()))
                {
                    model.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CreatedTime"].ToString()))
                {
                    model.CreatedTime = DateTime.Parse(dr["CreatedTime"].ToString());
                }
                model.ExpressCompany = dr["ExpressCompany"].ToString();
                model.ExpressCode = dr["ExpressCode"].ToString();

                model.CreatedBy = dr["CreatedBy"].ToString();
                if (!string.IsNullOrEmpty(dr["ReceiveId"].ToString()))
                {
                    model.ReceiveId = int.Parse(dr["ReceiveId"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.OrderDetail = DAL.OrderDetail.GetList("IsDeleted=0 and OrderCode='" + model.Code + "'");
                if (!string.IsNullOrEmpty(dr["TotalPrice"].ToString()))
                {
                    model.TotalPrice = decimal.Parse(dr["TotalPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["DisCountTotalPrice"].ToString()))
                {
                    model.DisCountTotalPrice = decimal.Parse(dr["DisCountTotalPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GoodCount"].ToString()))
                {
                    model.GoodCount = int.Parse(dr["GoodCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["OrderTime"].ToString()))
                {
                    model.OrderTime = DateTime.Parse(dr["OrderTime"].ToString());
                }
                model.MID = dr["MID"].ToString();
                model.Remarks = dr["Remarks"].ToString();
                if (!string.IsNullOrEmpty(dr["PayTime"].ToString()))
                {
                    model.PayTime = DateTime.Parse(dr["PayTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SendTime"].ToString()))
                {
                    model.SendTime = DateTime.Parse(dr["SendTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ReceiveTime"].ToString()))
                {
                    model.ReceiveTime = DateTime.Parse(dr["ReceiveTime"].ToString());
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
