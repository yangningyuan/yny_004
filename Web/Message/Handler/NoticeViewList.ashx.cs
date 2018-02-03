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
    public class NoticeViewList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "NState='1'";

            int count;
            List<Model.Notice> ListNotice = BllModel.GetNoticeEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('Message/NoticeView.aspx?id=" + ListNotice[i].ID + "','" + ListNotice[i].NTitle + "')\">" + ListNotice[i].NTitle + "</a>~");
                sb.Append(ListNotice[i].NCreateTime.ToShortDateString());
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}