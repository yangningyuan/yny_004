using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace yny_004.Web.Admin.pop.Handler
{
    /// <summary>
    /// Language 的摘要说明
    /// </summary>
    public class Language : IHttpHandler, IRequiresSessionState
    {
        HttpContext _context = null;
        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            context.Response.ContentType = "text/plain";
            switch (context.Request["type"])
            {
                case "LanguageType":
                    SelectLanguage();
                    break;
            }
        }

        private void SelectLanguage()
        {
            _context.Session["lan_EN"] = _context.Request["lan_EN"];
            _context.Response.Write("1");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}