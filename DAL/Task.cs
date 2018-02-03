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
    public class Task
    {
        public static void SendTask(Model.Member from, Model.Member to, string ttype, string msg)
        {
            Model.Task model = new Model.Task
            {
                TContent = msg,
                TDateTime = DateTime.Now,
                TFromMID = from.MID,
                TFromMName = from.MName,
                TToMID = to.MID,
                TToMName = to.MName,
                TType = ttype
            };
            Add(model);
        }
        public static string Add(Model.Task model)
        {
            if (CommonBase.RunHashtable(Add(model, new Hashtable())))
                return "操作成功";
            return "操作失败";
        }

        public static Hashtable Add(Model.Task model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            string sb = "insert into Task(TFromMID,TFromMName,TToMID,TToMName,TDateTime,TContent,TState,TType) values (@TFromMID,@TFromMName,@TToMID,@TToMName,@TDateTime,@TContent,'1',@TType);select '" + guid + "';";
            sb += " update Task set IfRead='1' where TFromMID=@TToMID and  TToMID=@TFromMID and TDateTime < @TDateTime and TState='1'";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TFromMID", SqlDbType.VarChar,20),
                new SqlParameter("@TFromMName",SqlDbType.VarChar,20),
                new SqlParameter("@TToMID", SqlDbType.VarChar,20),
                new SqlParameter("@TToMName",SqlDbType.VarChar,20),
                new SqlParameter("@TDateTime", SqlDbType.DateTime),
                new SqlParameter("@TContent",SqlDbType.NVarChar,500),
                new SqlParameter("@TType",SqlDbType.VarChar,10)
            };

            para[0].Value = model.TFromMID;
            para[1].Value = model.TFromMName;
            para[2].Value = model.TToMID;
            para[3].Value = model.TToMName;
            para[4].Value = DateTime.Now;
            para[5].Value = model.TContent.Replace(',', '，');
            para[6].Value = model.TType;

            MyHs.Add(sb, para);
            return MyHs;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="MID">会员账号</param>
        /// <returns></returns>
        public static List<Model.Task> SelectNewTasks(string TToMID, string TFromMID, int ID)
        {
            List<Model.Task> TaskList = new List<Model.Task>();
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TToMID",SqlDbType.VarChar,20),
                new SqlParameter("@TFromMID",SqlDbType.VarChar,20),
                new SqlParameter("@ID",SqlDbType.Int,4)
            };

            para[0].Value = TToMID;
            para[1].Value = TFromMID;
            para[2].Value = ID;

            DataTable table = DbHelperSQL.RunProcedure("GetTask", para, "Message").Tables[0];

            foreach (DataRow dr in table.Rows)
            {
                TaskList.Add(TranEntity(dr));
            }
            return TaskList;
        }

        public static DataTable GetTaskList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Task ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static List<Model.Task> GetTaskList(int top, string strWhere)
        {
            List<Model.Task> TaskList = new List<Model.Task>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM Task ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable table = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TaskList.Add(TranEntity(table.Rows[i]));
            }
            return TaskList;
        }

        private static Model.Task TranEntity(DataRow dr)
        {
            Model.Task model = new Model.Task();
            if (dr["ID"] != null)
            {
                model.ID = int.Parse(dr["ID"].ToString());
            }
            if (dr["TFromMID"] != null)
            {
                model.TFromMID = dr["TFromMID"].ToString();
            }
            if (dr["TFromMName"] != null)
            {
                model.TFromMName = dr["TFromMName"].ToString();
            }
            if (dr["TToMID"] != null)
            {
                model.TToMID = dr["TToMID"].ToString();
            }
            if (dr["TContent"] != null)
            {
                model.TContent = dr["TContent"].ToString();
            }
            if (dr["TToMName"] != null)
            {
                model.TToMName = dr["TToMName"].ToString();
            }
            if (dr["TType"] != null)
            {
                model.TType = dr["TType"].ToString();
            }
            if (dr["TState"] != null)
            {
                model.TState = bool.Parse(dr["TState"].ToString());
            }
            if (dr["TDateTime"] != null)
            {
                model.TDateTime = DateTime.Parse(dr["TDateTime"].ToString());
                model.TDataStr = model.TDateTime.ToString("yyyy-MM-dd");
            }
            return model;
        }

        public static string EndTask(string TFromMID, string TToMID)
        {
            string sb = " update Task set IfRead='1' where TFromMID = @TFromMID and TToMID=@TToMID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TFromMID",SqlDbType.VarChar,20),
                new SqlParameter("@TToMID",SqlDbType.VarChar,20)
            };

            para[0].Value = TFromMID;
            para[1].Value = TToMID;

            if (DbHelperSQL.ExecuteSql(sb, para) > 0)
            {
                return "结束成功";
            }
            return "";
        }

        public static List<Model.Task> GetTaskEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Task> TaskList = new List<Model.Task>();
            DataTable table = GetTaskList(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                TaskList.Add(TranEntity(table.Rows[i]));
            }
            return TaskList;
        }

        private static DataTable GetTaskList(string strWhere, int pageIndex, int pageSize, out int count, params string[] order)
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
            parameters[0].Value = "Task";
            parameters[1].Value = "*";
            parameters[2].Value = "ID";
            parameters[3].Value = strWhere;
            if (order.Length == 0)
                parameters[4].Value = "ID desc";
            else
                parameters[4].Value = order[0];
            parameters[5].Value = 3;
            parameters[6].Value = 0;
            parameters[7].Value = pageSize;
            parameters[8].Value = pageIndex;
            parameters[9].Direction = ParameterDirection.InputOutput;
            parameters[10].Direction = ParameterDirection.InputOutput;

            DataTable table = DbHelperSQL.RunProcedure("P_AspNetPage", parameters, "taskTable").Tables[0];
            count = Convert.ToInt32(parameters[9].Value);
            return table;
        }

        public static bool DeleteTask(string idlist)
        {
            string sb = "delete from Task where ID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool HideTask(string idlist)
        {
            string sb = "update Task set TState='0' where ID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool ShowTask(string idlist)
        {
            string sb = "update Task set TState='1' where ID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool ReadTask(string idlist)
        {
            string sb = "update Task set IfRead='1' where ID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }

        public static bool NoReadTask(string idlist)
        {
            string sb = "update Task set IfRead='0' where ID in (" + idlist + ")";
            return DbHelperSQL.ExecuteSql(sb) > 0;
        }
    }
}
