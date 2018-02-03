using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;
using CommonBLL;
using CommonModel;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// LanguageList 的摘要说明
    /// </summary>
    public class LanguageList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1'  and IsDeleted=0 ";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))//按照英文查询
            {
                strWhere += " and ENName like '%" + context.Request["mKey"] + "%'";
            }
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))//按照中文查询
            {
                strWhere += " and ZHName like '%" + context.Request["txtKey"] + "%'";
            }
            int count = 0;
            StringBuilder sb = new StringBuilder();
            List<CommonModel.Sys_Language> ListChangeMoney;
            ListChangeMoney = Sys_LanguageBLL.GetList(strWhere, pageIndex, pageSize, out count);
            Sys_LanguageTypeBLL lanTypeBll = new Sys_LanguageTypeBLL();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                sb.Append(ListChangeMoney[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListChangeMoney[i].ZHName + "~");
                sb.Append(ListChangeMoney[i].ENName + "~");
                //sb.Append(ListChangeMoney[i].LanguageCode + "~");
                Sys_LanguageType lng = lanTypeBll.GetModelByCode(ListChangeMoney[i].LanguageCode);
                if (lng != null)
                {
                    sb.Append(lng.Name);
                }
                sb.Append("~");
                sb.Append((ListChangeMoney[i].Status ? "已生效" : "未生效"));
                sb.Append("≌");
            }

            var info = new { PageData = sb.ToString(), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}