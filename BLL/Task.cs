using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace yny_004.BLL
{
    public class Task
    {
        public static void ManageSend(Model.Member to, string msg)
        {
            DAL.Task.SendTask(BLL.Member.ManageMember.TModel, to, "001", msg);
        }
        public static void SendManage(Model.Member from, string ttype, string msg)
        {
            DAL.Task.SendTask(from, BLL.Member.ManageMember.TModel, ttype, msg);
        }
        public static string Add(Model.Task model)
        {
            return DAL.Task.Add(model);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="MID">会员账号</param>
        /// <param name="TaskAction">对话方向，T发送方，F接收方</param>
        /// <returns></returns>
        public static List<Model.Task> SelectNewTasks(string TToMID, string TFromMID, int ID)
        {
            return DAL.Task.SelectNewTasks(TToMID, TFromMID, ID);
        }

        public static DataTable GetTaskList(string strWhere)
        {
            return DAL.Task.GetTaskList(strWhere);
        }

        public static List<Model.Task> GetTaskList(int top, string strWhere)
        {
            return DAL.Task.GetTaskList(top, strWhere);
        }

        public static string EndTask(string TFromMID, string TToMID)
        {
            return DAL.Task.EndTask(TFromMID, TToMID);
        }
    }
}
