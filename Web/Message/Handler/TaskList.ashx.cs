using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// MemberList 的摘要说明
    /// </summary>
    public class TaskList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'"; string type = ""; string mkey = "";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                type = context.Request["tState"];
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!memberModel.Role.Super)
                mkey = memberModel.MID;

            if (type == "001")
            {
                strWhere += " and TType='001'";
                if (!string.IsNullOrEmpty(mkey))
                    strWhere += " and TToMID='" + mkey + "'";
            }
            else
            {
                if (type == "false")
                {
                    strWhere += " and IfRead='" + type + "'";
                    if (!string.IsNullOrEmpty(mkey))
                    {
                        strWhere += " and TToMID='" + mkey + "'";
                    }
                }
                else if (type == "to")
                {
                    if (!string.IsNullOrEmpty(mkey))
                    {
                        strWhere += " and TToMID='" + mkey + "'";
                    }
                }
                else if (type == "from")
                {
                    if (!string.IsNullOrEmpty(mkey))
                    {
                        strWhere += " and TFromMID='" + mkey + "'";
                    }
                }
                strWhere += " and TType<>'001' and TType<>'008' ";
            }

            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and TContent like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }

            string AgencyCode = "";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                if (context.Request["typeList"].Contains("true"))
                {
                    AgencyCode = "TState='1'";
                }
                if (context.Request["typeList"].Contains("false"))
                {
                    if (AgencyCode != "")
                        AgencyCode = "";
                    else
                        AgencyCode = "TState='0'";
                }
            }
            if (AgencyCode != "")
            {
                strWhere += " and " + AgencyCode;
            }

            int count;
            List<Model.Task> ListTask = BllModel.GetTaskEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListTask.Count; i++)
            {
                sb.Append(ListTask[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListTask[i].TFromMID + "~");
                sb.Append(ListTask[i].TToMID + "~");
                sb.Append(ListTask[i].TContent + "~");
                sb.Append(ListTask[i].TTypeStr + "~");
                sb.Append(ListTask[i].TDateTime.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}