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
    //IPClick
    public class IPClick
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.IPClick GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, MID, IP, ClickTime, Money  ");
            strSql.Append("  from IPClick ");
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
        public static Hashtable Insert(Model.IPClick model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into IPClick(");
            strSql.Append("MID,IP,ClickTime,Money");
            strSql.Append(") values (");
            strSql.Append("@MID,@IP,@ClickTime,@Money");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IP", SqlDbType.VarChar,20) ,
                        new SqlParameter("@ClickTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Money", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.ClickTime;
            parameters[3].Value = model.Money;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.IPClick model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.IPClick model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IPClick set ");

            strSql.Append(" MID = @MID , ");
            strSql.Append(" IP = @IP , ");
            strSql.Append(" ClickTime = @ClickTime , ");
            strSql.Append(" Money = @Money  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IP", SqlDbType.VarChar,20) ,
                        new SqlParameter("@ClickTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Money", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.IP;
            parameters[3].Value = model.ClickTime;
            parameters[4].Value = model.Money;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.IPClick model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IPClick ");
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
            strSql.Append(" FROM IPClick ");
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
            strSql.Append(" FROM IPClick ");
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
            return DAL.CommonBase.GetTable("IPClick", "Id", "Id asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.IPClick> GetList(string strWhere)
        {
            List<Model.IPClick> list = new List<Model.IPClick>();

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
        public static List<Model.IPClick> GetList(int top, string strWhere)
        {
            List<Model.IPClick> list = new List<Model.IPClick>();

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
        public static List<Model.IPClick> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.IPClick> list = new List<Model.IPClick>();

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
        private static Model.IPClick TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.IPClick model = new Model.IPClick();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.MID = dr["MID"].ToString();
                model.IP = dr["IP"].ToString();
                if (!string.IsNullOrEmpty(dr["ClickTime"].ToString()))
                {
                    model.ClickTime = DateTime.Parse(dr["ClickTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Money"].ToString()))
                {
                    model.Money = decimal.Parse(dr["Money"].ToString());
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
