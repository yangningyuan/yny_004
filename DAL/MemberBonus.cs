using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBUtility;

namespace yny_004.DAL
{
    public class MemberBonus
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.MemberBonus model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberBonus(");
            strSql.Append("MID,TotalPoints,ValidPoints,TotalBonus,ValidBonus");
            strSql.Append(") values (");
            strSql.Append("@MID,@TotalPoints,@ValidPoints,@TotalBonus,@ValidBonus");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TotalPoints", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidPoints", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidBonus", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.TotalPoints;
            parameters[2].Value = model.ValidPoints;
            parameters[3].Value = model.TotalBonus;
            parameters[4].Value = model.ValidBonus;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }


        public static bool Insert(Model.MemberBonus model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(string mid, string fieldName, int fieldValue, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberBonus set ");
            strSql.Append(string.Format("{0} = {0} + {1} ", fieldName, fieldValue));
            strSql.Append(" where MID=@MID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20)            
            };

            parameters[0].Value = mid;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(Model.MemberBonus model)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberBonus set ");

            strSql.Append(" MID = @MID , ");
            strSql.Append(" TotalPoints = @TotalPoints , ");
            strSql.Append(" ValidPoints = @ValidPoints , ");
            strSql.Append(" TotalBonus = @TotalBonus , ");
            strSql.Append(" ValidBonus = @ValidBonus  ");
            strSql.Append(" where MID=@MID  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TotalPoints", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidPoints", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidBonus", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.TotalPoints;
            parameters[2].Value = model.ValidPoints;
            parameters[3].Value = model.TotalBonus;
            parameters[4].Value = model.ValidBonus;
            System.Collections.Hashtable MyHs = new System.Collections.Hashtable();
            MyHs.Add(strSql.ToString(), parameters);
            return DAL.CommonBase.RunHashtable(MyHs);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MemberBonus ");
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
        public static Model.MemberBonus GetModel(string MID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MID, TotalPoints, ValidPoints, TotalBonus, ValidBonus  ");
            strSql.Append("  from MemberBonus ");
            strSql.Append(" where MID=@MID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20)			};
            parameters[0].Value = MID;


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

        private static Model.MemberBonus DataRowToModel(DataRow row)
        {
            if (row != null)
            {
                Model.MemberBonus model = new Model.MemberBonus();
                model.MID = row["MID"].ToString();
                if (row["TotalPoints"].ToString() != "")
                {
                    model.TotalPoints = int.Parse(row["TotalPoints"].ToString());
                }
                if (row["ValidPoints"].ToString() != "")
                {
                    model.ValidPoints = int.Parse(row["ValidPoints"].ToString());
                }
                if (row["TotalBonus"].ToString() != "")
                {
                    model.TotalBonus = int.Parse(row["TotalBonus"].ToString());
                }
                if (row["ValidBonus"].ToString() != "")
                {
                    model.ValidBonus = int.Parse(row["ValidBonus"].ToString());
                }

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
            strSql.Append(" FROM MemberBonus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("MemberBonus", "Code", "ID asc,Code asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<Model.MemberBonus> GetList(string strWhere)
        {
            List<Model.MemberBonus> list = new List<Model.MemberBonus>();

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
        public static List<Model.MemberBonus> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MemberBonus> list = new List<Model.MemberBonus>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }


    }
}

