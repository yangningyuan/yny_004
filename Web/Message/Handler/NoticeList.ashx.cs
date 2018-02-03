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
    public class NoticeList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and NState='" + context.Request["tState"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            {
                strWhere += " and NTitle like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            }
            int count;
            List<Model.Notice> ListNotice = BllModel.GetNoticeEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].NTitle + "~");
                sb.Append(ListNotice[i].NCreateTime.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append((ListNotice[i].IsFixed ? "是" : "否") + "~");
                sb.Append(ListNotice[i].NClicks + "~");
                if (ListNotice[i].NState)
                    sb.Append("正常");
                else
                    sb.Append("已作废");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}