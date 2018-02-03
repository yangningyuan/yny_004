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
    //EPJX
    public class EPJX
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.EPJX GetModel(object JXID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EPJXTime, JXID, EPJXRemark, EPJXMID  ");
            strSql.Append("  from EPJX ");
            strSql.Append(" where JXID=@JXID ");
            SqlParameter[] parameters = {
					new SqlParameter("@JXID", SqlDbType.Int,4)			};
            parameters[0].Value = JXID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(yny_004.Model.EPJX model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EPJX(");
            strSql.Append("EPJXTime,EPJXRemark,EPJXMID)");
            strSql.Append(" values (");
            strSql.Append("@EPJXTime,@EPJXRemark,@EPJXMID)");
            strSql.AppendFormat(" ;select '{0}'", guid);
            SqlParameter[] parameters = {
					new SqlParameter("@EPJXTime", SqlDbType.DateTime),
					new SqlParameter("@EPJXRemark", SqlDbType.VarChar,200),
					new SqlParameter("@EPJXMID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.EPJXTime;
            parameters[1].Value = model.EPJXRemark;
            parameters[2].Value = model.EPJXMID;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(yny_004.Model.EPJX model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_004.Model.EPJX model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EPJX set ");
            strSql.Append("EPJXTime=@EPJXTime,");
            strSql.Append("EPJXRemark=@EPJXRemark,");
            strSql.Append("EPJXMID=@EPJXMID");
            strSql.Append(" where JXID=@JXID");
            SqlParameter[] parameters = {
					new SqlParameter("@EPJXTime", SqlDbType.DateTime),
					new SqlParameter("@EPJXRemark", SqlDbType.VarChar,200),
					new SqlParameter("@EPJXMID", SqlDbType.VarChar,50),
					new SqlParameter("@JXID", SqlDbType.Int,4)};
            parameters[0].Value = model.EPJXTime;
            parameters[1].Value = model.EPJXRemark;
            parameters[2].Value = model.EPJXMID;
            parameters[3].Value = model.JXID;

            strSql.AppendFormat(" ;select '{0}'", guid);

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.EPJX model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EPJX ");
            strSql.AppendFormat(" where JXID in ({0})", obj);

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
            strSql.Append(" FROM EPJX ");
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
            strSql.Append(" FROM EPJX ");
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
            return DAL.CommonBase.GetTable("EPJX", "JXID", "JXID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<yny_004.Model.EPJX> GetList(string strWhere)
        {
            List<yny_004.Model.EPJX> list = new List<yny_004.Model.EPJX>();

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
        public static List<yny_004.Model.EPJX> GetList(int top, string strWhere)
        {
            List<yny_004.Model.EPJX> list = new List<yny_004.Model.EPJX>();

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
        public static List<yny_004.Model.EPJX> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<yny_004.Model.EPJX> list = new List<yny_004.Model.EPJX>();

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
        private static yny_004.Model.EPJX TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                yny_004.Model.EPJX model = new yny_004.Model.EPJX();

                if (!string.IsNullOrEmpty(dr["EPJXTime"].ToString()))
                {
                    model.EPJXTime = DateTime.Parse(dr["EPJXTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["JXID"].ToString()))
                {
                    model.JXID = int.Parse(dr["JXID"].ToString());
                }
                model.EPJXRemark = dr["EPJXRemark"].ToString();
                model.EPJXMID = dr["EPJXMID"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
