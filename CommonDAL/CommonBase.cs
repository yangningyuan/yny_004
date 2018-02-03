
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CommonDAL
{
    public class CommonBase
    {
        private static List<string> SqlKey = new List<string>
        {
            "select",",","，","--","－","order","delete","update","insert","drop","table","create","declare","exec"
        };
        /// <summary>
        /// 执行事物
        /// </summary>
        /// <param name="SQLStringList"></param>
        /// <returns></returns>
        public static bool RunHashtable(Hashtable hashtable)
        {
            //foreach (DictionaryEntry myDE in hashtable)
            //    hashtable.Add(myDE.Key, myDE.Value);
            //DAl.Configuration.TModel = null;
            if (DbHelperSQL.ExecuteSqlTranWithIndentity(hashtable) != -1)
                return true;
            return false;
        }

        public static bool TestSql(string mkey)
        {
            foreach (string str in SqlKey)
            {
                if (mkey.ToUpper().Contains(str.ToUpper()) || mkey.ToUpper().Contains(str.ToUpper()))
                    return false;
            }
            return true;
        }

        public static DataTable GetTable(string tableName, string primaryKey, string orderBy, string strWhere, int pageIndex, int pageSize, out int count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 50),
                    new SqlParameter("@FieldList", SqlDbType.VarChar, 50),
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 50),
                    new SqlParameter("@Where", SqlDbType.VarChar, 500),
                    new SqlParameter("@Order", SqlDbType.VarChar, 50),
                    new SqlParameter("@SortType", SqlDbType.Int,4),
                    new SqlParameter("@RecorderCount", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@PageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@TotalPageCount", SqlDbType.Int,4)};
            parameters[0].Value = tableName;
            parameters[1].Value = "*";
            parameters[2].Value = primaryKey;
            parameters[3].Value = strWhere;
            parameters[4].Value = orderBy;
            parameters[5].Value = 3;
            parameters[6].Value = 0;
            parameters[7].Value = pageSize;
            parameters[8].Value = pageIndex;
            parameters[9].Direction = ParameterDirection.InputOutput;
            parameters[10].Direction = ParameterDirection.InputOutput;

            DataTable table = DbHelperSQL.RunProcedure("P_AspNetPage", parameters, "txTable").Tables[0];
            count = Convert.ToInt32(parameters[9].Value);
            return table;
        }

        public static object GetSingle(string strSql)
        {
            return DbHelperSQL.GetSingle(strSql);
        }

        public static DataTable GetTable(string strSql)
        {
            return DbHelperSQL.Query(strSql).Tables[0];
        }

        public static void RunSql(string strSql)
        {
            DbHelperSQL.ExecuteSql(strSql);
        }
    }
}
