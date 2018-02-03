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
    public class BonusList
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.BonusList model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BonusList(");
            strSql.Append("BonusCode,MID,BonusDate,IsValid,GiftCode,ValidDate,BonusRemark");
            strSql.Append(") values (");
            strSql.Append("@BonusCode,@MID,@BonusDate,@IsValid,@GiftCode,@ValidDate,@BonusRemark");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@BonusCode", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BonusDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsValid", SqlDbType.Bit,1) ,            
                        new SqlParameter("@GiftCode", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ValidDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BonusRemark", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.BonusCode;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.BonusDate;
            parameters[3].Value = model.IsValid;
            parameters[4].Value = model.GiftCode;
            parameters[5].Value = model.ValidDate;
            parameters[6].Value = model.BonusRemark;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }


        public static bool Insert(Model.BonusList model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.BonusList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BonusList set ");

            strSql.Append(" BonusCode = @BonusCode , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" BonusDate = @BonusDate , ");
            strSql.Append(" IsValid = @IsValid , ");
            strSql.Append(" GiftCode = @GiftCode , ");
            strSql.Append(" ValidDate = @ValidDate , ");
            strSql.Append(" BonusRemark = @BonusRemark  ");
            strSql.Append(" where BonusCode=@BonusCode  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@BonusCode", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BonusDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsValid", SqlDbType.Bit,1) ,            
                        new SqlParameter("@GiftCode", SqlDbType.VarChar,32) ,            
                        new SqlParameter("@ValidDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BonusRemark", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.BonusCode;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.BonusDate;
            parameters[3].Value = model.IsValid;
            parameters[4].Value = model.GiftCode;
            parameters[5].Value = model.ValidDate;
            parameters[6].Value = model.BonusRemark;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(Model.BonusList model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BonusList ");
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
        public static Model.BonusList GetModel(string BonusCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BonusCode, MID, BonusDate, IsValid, GiftCode, ValidDate, BonusRemark  ");
            strSql.Append("  from BonusList ");
            strSql.Append(" where BonusCode=@BonusCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@BonusCode", SqlDbType.VarChar,32)			};
            parameters[0].Value = BonusCode;


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

        private static Model.BonusList DataRowToModel(DataRow row)
        {
            if (row != null)
            {
                Model.BonusList model = new Model.BonusList();
                model.BonusCode = row["BonusCode"].ToString();
                model.MID = row["MID"].ToString();
                if (row["BonusDate"].ToString() != "")
                {
                    model.BonusDate = DateTime.Parse(row["BonusDate"].ToString());
                }
                if (row["IsValid"].ToString() != "")
                {
                    model.IsValid = bool.Parse(row["IsValid"].ToString());
                }
                model.GiftCode = row["GiftCode"].ToString();
                if (row["ValidDate"].ToString() != "")
                {
                    model.ValidDate = DateTime.Parse(row["ValidDate"].ToString());
                }
                model.BonusRemark = row["BonusRemark"].ToString();

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
            strSql.Append(" FROM BonusList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("BonusList", "Code", "ID desc,BonusCode desc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Model.BonusList> GetList(string strWhere)
        {
            List<Model.BonusList> list = new List<Model.BonusList>();

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
        public static List<Model.BonusList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BonusList> list = new List<Model.BonusList>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

    }
}
