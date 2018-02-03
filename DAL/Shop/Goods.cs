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
    //Goods
    public class Goods
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Goods GetModel(object GID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from Goods ");
            strSql.Append(" where GID=@GID");
            SqlParameter[] parameters = {
					new SqlParameter("@GID", SqlDbType.Int,4)
			};
            parameters[0].Value = GID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.Goods model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Goods(");
            strSql.Append("GroupPrice,GroupPV,ImageAddr,SelledCount,SellingCount,Unit,IsDeleted,Status,GoodsCode,GParentCode,GParentName,GName,CostPrice,CostPV,MemberPrice,MemberPV,Remark");
            strSql.Append(") values (");
            strSql.Append("@GroupPrice,@GroupPV,@ImageAddr,@SelledCount,@SellingCount,@Unit,@IsDeleted,@Status,@GoodsCode,@GParentCode,@GParentName,@GName,@CostPrice,@CostPV,@MemberPrice,@MemberPV,@Remark");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@GroupPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@GroupPV", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ImageAddr", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SelledCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellingCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GParentCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GParentName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CostPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostPV", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MemberPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MemberPV", SqlDbType.Decimal,9),
                         new SqlParameter("@Remark", SqlDbType.NVarChar,2000) 
              
            };

            parameters[0].Value = model.GroupPrice;
            parameters[1].Value = model.GroupPV;
            parameters[2].Value = model.ImageAddr;
            parameters[3].Value = model.SelledCount;
            parameters[4].Value = model.SellingCount;
            parameters[5].Value = model.Unit;
            parameters[6].Value = model.IsDeleted;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.GoodsCode;
            parameters[9].Value = model.GParentCode;
            parameters[10].Value = model.GParentName;
            parameters[11].Value = model.GName;
            parameters[12].Value = model.CostPrice;
            parameters[13].Value = model.CostPV;
            parameters[14].Value = model.MemberPrice;
            parameters[15].Value = model.MemberPV;
            parameters[16].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.Goods model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.Goods model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Goods set ");

            strSql.Append(" GroupPrice = @GroupPrice , ");
            strSql.Append(" GroupPV = @GroupPV , ");
            strSql.Append(" ImageAddr = @ImageAddr , ");
            strSql.Append(" SelledCount = @SelledCount , ");
            strSql.Append(" SellingCount = @SellingCount , ");
            strSql.Append(" Unit = @Unit , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" GoodsCode = @GoodsCode , ");
            strSql.Append(" GParentCode = @GParentCode , ");
            strSql.Append(" GParentName = @GParentName , ");
            strSql.Append(" GName = @GName , ");
            strSql.Append(" CostPrice = @CostPrice , ");
            strSql.Append(" CostPV = @CostPV , ");
            strSql.Append(" MemberPrice = @MemberPrice , ");
            strSql.Append(" MemberPV = @MemberPV,  ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where GID=@GID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@GID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GroupPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@GroupPV", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ImageAddr", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SelledCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellingCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@GoodsCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GParentCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GParentName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CostPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostPV", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MemberPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MemberPV", SqlDbType.Decimal,9)  ,
                            new SqlParameter("@Remark", SqlDbType.NVarChar,2000) 
              
            };

            parameters[0].Value = model.GID;
            parameters[1].Value = model.GroupPrice;
            parameters[2].Value = model.GroupPV;
            parameters[3].Value = model.ImageAddr;
            parameters[4].Value = model.SelledCount;
            parameters[5].Value = model.SellingCount;
            parameters[6].Value = model.Unit;
            parameters[7].Value = model.IsDeleted;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.GoodsCode;
            parameters[10].Value = model.GParentCode;
            parameters[11].Value = model.GParentName;
            parameters[12].Value = model.GName;
            parameters[13].Value = model.CostPrice;
            parameters[14].Value = model.CostPV;
            parameters[15].Value = model.MemberPrice;
            parameters[16].Value = model.MemberPV;
            parameters[17].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.Goods model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Goods ");
            strSql.AppendFormat(" where GID in ({0})", obj);

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
            strSql.Append(" FROM Goods ");
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
            strSql.Append(" FROM Goods ");
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
            return DAL.CommonBase.GetTable("Goods", "GID", "GID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.Goods> GetList(string strWhere)
        {
            List<Model.Goods> list = new List<Model.Goods>();

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
        public static List<Model.Goods> GetList(int top, string strWhere)
        {
            List<Model.Goods> list = new List<Model.Goods>();

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
        public static List<Model.Goods> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Goods> list = new List<Model.Goods>();

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
        private static Model.Goods TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.Goods model = new Model.Goods();

                if (!string.IsNullOrEmpty(dr["GID"].ToString()))
                {
                    model.GID = int.Parse(dr["GID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GroupPrice"].ToString()))
                {
                    model.GroupPrice = decimal.Parse(dr["GroupPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GroupPV"].ToString()))
                {
                    model.GroupPV = decimal.Parse(dr["GroupPV"].ToString());
                }
             

                if (!string.IsNullOrEmpty(dr["SelledCount"].ToString()))
                {
                    model.SelledCount = int.Parse(dr["SelledCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellingCount"].ToString()))
                {
                    model.SellingCount = int.Parse(dr["SellingCount"].ToString());
                }
                model.Unit = dr["Unit"].ToString();
                if (!string.IsNullOrEmpty(dr["IsDeleted"].ToString()))
                {
                    model.IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                {
                    model.Status = int.Parse(dr["Status"].ToString());
                }
                model.GoodsCode = dr["GoodsCode"].ToString();

                model.GoodsPic = DAL.GoodsPic.GetList("IsDeleted=0 and GId='"+model.GoodsCode+"'");

                model.GParentCode = dr["GParentCode"].ToString();
                model.GParentName = dr["GParentName"].ToString();
                model.GName = dr["GName"].ToString();
                model.Remark = dr["Remark"].ToString();
                if (!string.IsNullOrEmpty(dr["CostPrice"].ToString()))
                {
                    model.CostPrice = decimal.Parse(dr["CostPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CostPV"].ToString()))
                {
                    model.CostPV = decimal.Parse(dr["CostPV"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MemberPrice"].ToString()))
                {
                    model.MemberPrice = decimal.Parse(dr["MemberPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MemberPV"].ToString()))
                {
                    model.MemberPV = decimal.Parse(dr["MemberPV"].ToString());
                }

                var list = DAL.GoodsPic.GetList("IsDeleted=0 and IsMain=1 and GId='" + model.GoodsCode + "'").FirstOrDefault();
                if (list != null)
                {
                    model.ImageAddr = list.PicURL;
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
