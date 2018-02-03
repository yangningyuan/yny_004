using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace yny_004.Web.Shop.Handler
{
    /// <summary>
    /// ReceiveList 的摘要说明
    /// </summary>
    public class ReceiveList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "IsDeleted=0 and MID='"+TModel.MID+"' ";
            string state = string.Empty;
        
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += " and  Receiver like '%" + context.Request["mKey"] + "%'";
            }
           
            int count;
            List<Model.ReceiveInfo> List = BLL.ReceiveInfo.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].Receiver + "~");
                sb.Append(List[i].Phone + "~");
                sb.Append(List[i].Province + List[i].City + List[i].Zone + List[i].Address+"~");
                sb.Append(List[i].IsMain?"是":"否");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}