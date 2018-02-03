using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CommonModel;
using System.Text;

namespace yny_004.Web
{
    public class BaseHandler : BasePage, IHttpHandler, IRequiresSessionState
    {
        protected int pageIndex = 0;
        protected int pageSize = 0;
        protected int count;
        protected HttpContext _context = null;
        public new virtual void ProcessRequest(HttpContext context)
        {
            if (!BLL.CommonBase.TestSql(context.Request.QueryString.ToString() + context.Request.Form.ToString()))
            {
                Response.Write("非法字符");
                return;
            }
            //TModel = BllModel.TModel;
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request["pageIndex"]))
            {
                pageIndex = int.Parse(context.Request["pageIndex"]);
            }
            if (!string.IsNullOrEmpty(context.Request["pageSize"]))
            {
                pageSize = int.Parse(context.Request["pageSize"]);
            }
            _context = context;
        }

        public string Traditionalized(StringBuilder sb)
        {
            if (Session["lan_EN"] != null && Session["lan_EN"].ToString() == "TRUE")
            {
                string zhNames = "", enNames = "";
                var list = CommonBLL.Sys_LanguageBLL.GetList("IsDeleted=0 and Status=1  order by LEN(ZHName) desc");
                foreach (Sys_Language obj in list)
                {
                    zhNames += obj.ZHName + "*";
                    enNames += obj.ENName + "*";
                }
                string[] zhs = zhNames.Split('*');
                string[] ens = enNames.Split('*');
                string cc = sb.ToString();
                for (var i = 0; i < zhs.Length; i++)
                {
                    if (cc.IndexOf(zhs[i]) != -1)
                    {
                        if (!string.IsNullOrEmpty(zhs[i]) && !string.IsNullOrEmpty(ens[i]))
                            cc = cc.Replace(zhs[i], ens[i]);
                    }
                }
                return cc;
            }
            else
                return sb.ToString();
        }

        public string ShowMemberInfo(string mid)
        {
            return "<a href=\"javascript:void(0)\" onclick=\"ShowMemberInof('" + mid + "')\">" + mid + "</a>";
        }
    }
}