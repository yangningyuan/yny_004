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
    public class RolePowers : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string iFVerify = "";
            string mType = "";
            if (!string.IsNullOrEmpty(context.Request["RoleCode"]))
            {
                mType = context.Request["RoleCode"];
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                iFVerify = context.Request["tState"];
            }

            List<Model.RolePowers> ListContents;
            if (!string.IsNullOrEmpty(iFVerify))
            {
                bool v = bool.Parse(iFVerify);
                ListContents = BLL.Roles.RolsList[mType].PowersList.Where(emp => emp.Content.CState && emp.IFVerify == v && emp.CID != "000").ToList();
            }
            else
                ListContents = BLL.Roles.RolsList[mType].PowersList.Where(emp => emp.Content.CState && emp.CID != "000").ToList();

            StringBuilder sb = new StringBuilder();

            int tempCount = pageIndex * pageSize < ListContents.Count ? pageIndex * pageSize : ListContents.Count;

            for (int i = (pageIndex - 1) * pageSize; i < tempCount; i++)
            {
                sb.Append(ListContents[i].RID + "~");
                sb.Append(i + 1 + "~");
                sb.Append(ListContents[i].CID + "~");
                sb.Append(ListContents[i].Content.CTitle + "~");
                sb.Append(ListContents[i].IFVerify ? "是" : "否");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = ListContents.Count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}