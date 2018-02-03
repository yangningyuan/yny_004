using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;
using System.Collections;

namespace yny_004.DAL
{
    public class BonusGift
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.BonusGift model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BonusGift(");
            strSql.Append("GiftCode,GiftNum,GiftName,Probaly,GiftType,GiftCount,BonusPlan,GiftRemark,IsAuto,Points");
            strSql.Append(") values (");
            strSql.Append("@GiftCode,@GiftNum,@GiftName,@Probaly,@GiftType,@GiftCount,@BonusPlan,@GiftRemark,@IsAuto,@Points");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@GiftCode", SqlDbType.VarChar,32) ,
                        new SqlParameter("@GiftNum", SqlDbType.Int,4) ,
                        new SqlParameter("@GiftName", SqlDbType.VarChar,20) , 
                        new SqlParameter("@Probaly", SqlDbType.Int,4) ,
                        new SqlParameter("@GiftType", SqlDbType.VarChar,10) , 
                        new SqlParameter("@GiftCount", SqlDbType.Int,4) , 
                        new SqlParameter("@BonusPlan", SqlDbType.VarChar,10), 
                        new SqlParameter("@GiftRemark", SqlDbType.VarChar,50),
                        new SqlParameter("@IsAuto", SqlDbType.Bit,1) ,
                        new SqlParameter("@Points", SqlDbType.Int,4)
            };

            parameters[0].Value = model.GiftCode;
            parameters[1].Value = model.GiftNum;
            parameters[2].Value = model.GiftName;
            parameters[3].Value = model.Probaly;
            parameters[4].Value = model.GiftType;
            parameters[5].Value = model.GiftCount;
            parameters[6].Value = model.BonusPlan;
            parameters[7].Value = model.GiftRemark;
            parameters[8].Value = model.IsAuto;
            parameters[9].Value = model.Points;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }


        public static bool Insert(Model.BonusGift model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.BonusGift model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BonusGift set ");

            strSql.Append(" GiftCode = @GiftCode , ");
            strSql.Append(" GiftNum = @GiftNum , ");
            strSql.Append(" GiftName = @GiftName , ");
            strSql.Append(" Probaly = @Probaly , ");
            strSql.Append(" GiftType = @GiftType , ");
            strSql.Append(" GiftCount = @GiftCount , ");
            strSql.Append(" BonusPlan = @BonusPlan , ");
            strSql.Append(" IsAuto = @IsAuto , ");
            strSql.Append(" Points = @Points , ");
            strSql.Append(" GiftRemark = @GiftRemark  ");
            strSql.Append(" where GiftCode=@GiftCode  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@GiftCode", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@GiftNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@GiftName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Probaly", SqlDbType.Int,4) ,            
                        new SqlParameter("@GiftType", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@GiftCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@BonusPlan", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@IsAuto", SqlDbType.Bit,1) ,         
                        new SqlParameter("@Points", SqlDbType.Int,4) ,       
                        new SqlParameter("@GiftRemark", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.GiftCode;
            parameters[1].Value = model.GiftNum;
            parameters[2].Value = model.GiftName;
            parameters[3].Value = model.Probaly;
            parameters[4].Value = model.GiftType;
            parameters[5].Value = model.GiftCount;
            parameters[6].Value = model.BonusPlan;
            parameters[7].Value = model.IsAuto;
            parameters[8].Value = model.Points;
            parameters[9].Value = model.GiftRemark;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(Model.BonusGift model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BonusGift ");
            strSql.AppendFormat(" where Code in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.BonusGift GetModel(object GiftCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from BonusGift ");
            strSql.Append(" where GiftCode=@GiftCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@GiftCode", SqlDbType.VarChar,32)			};
            parameters[0].Value = GiftCode;


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
        /// 得到一个对象实体
        /// </summary>
        public static Model.BonusGift GetModel(string GiftNum, string BonusPlan)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *  ");
            strSql.Append("  from BonusGift ");
            strSql.Append(" where BonusPlan=@BonusPlan and GiftNum=@GiftNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@BonusPlan", SqlDbType.VarChar,10),
					new SqlParameter("@GiftNum", SqlDbType.Int,4)};
            parameters[0].Value = BonusPlan;
            parameters[1].Value = GiftNum;


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

        private static Model.BonusGift DataRowToModel(DataRow row)
        {
            if (row != null)
            {
                Model.BonusGift model = new Model.BonusGift();
                model.GiftCode = row["GiftCode"].ToString();
                if (row["GiftNum"].ToString() != "")
                {
                    model.GiftNum = int.Parse(row["GiftNum"].ToString());
                }
                model.GiftName = row["GiftName"].ToString();
                if (row["Probaly"].ToString() != "")
                {
                    model.Probaly = int.Parse(row["Probaly"].ToString());
                }
                model.GiftType = row["GiftType"].ToString();
                if (row["GiftCount"].ToString() != "")
                {
                    model.GiftCount = int.Parse(row["GiftCount"].ToString());
                }
                if (row["Points"].ToString() != "")
                {
                    model.Points = int.Parse(row["Points"].ToString());
                }
                if (row["IsAuto"].ToString() != "")
                {
                    model.IsAuto = bool.Parse(row["IsAuto"].ToString());
                }
                model.BonusPlan = row["BonusPlan"].ToString();
                model.GiftRemark = row["GiftRemark"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BonusGift ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("BonusGift", "Code", "ID asc,Code asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Model.BonusGift> GetList(string strWhere)
        {
            List<Model.BonusGift> list = new List<Model.BonusGift>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<Model.BonusGift> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BonusGift> list = new List<Model.BonusGift>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }
            return list;
        }
    }
}
