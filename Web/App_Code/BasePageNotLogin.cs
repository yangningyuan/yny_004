using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.HtmlControls;
using NPOI.SS.UserModel;

namespace yny_004.Web
{
    public class BasePageNoLogin : System.Web.UI.Page
    {
        protected string zhNames = "";
        protected string enNames = "";
        protected string lng = "<a lng=\"CH\"><span class=\"icon-user\"><img src=\"/Admin/images/ZH.jpg\"></span>中文</a>";
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;

        protected string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "");
        }

        protected void SetLanguage()
        {
            {
                lng = "<a lng=\"EN\"><span class=\"icon-user\"><img src=\"/Admin/images/EN.jpg\"></span>EN</a>";
                var list = yg_dll.BLL.Language.GetList("LanguageCode = '" + GetLanguage() + "' and IsDeleted=0 and Status=1 order by LEN(ZHName) desc");
                foreach (yg_dll.Model.Language obj in list)
                {
                    zhNames += obj.ZHName + "*";
                    enNames += obj.ENName.Replace("\n", "").Replace("\t", "").Replace("\r", "") + "*";
                }
            }
        }

        protected string GetLanguage()
        {
            if (Session["lan_EN"] != null)
            {
                return Session["lan_EN"].ToString();
            }
            else
            {
                return "";
            }
        }

        protected bool IsEnglish()
        {
            if (Session["lan_EN"] != null && Session["lan_EN"].ToString() == "EN")
            {
                return true;
            }
            return false;
        }

        protected void BindDdlPwdQuestion(System.Web.UI.HtmlControls.HtmlSelect ddl_PwdQuestion)
        {
            BLL.Sys_SecurityQuestion BLL = new BLL.Sys_SecurityQuestion();
            string whereStr = " IsDeleted=0 and Status=1";
            IList<Model.Sys_SecurityQuestion> list = BLL.GetList(whereStr);
            ddl_PwdQuestion.DataSource = list;
            ddl_PwdQuestion.DataTextField = "Question";
            ddl_PwdQuestion.DataValueField = "ID";
            ddl_PwdQuestion.DataBind();
        }

        /// <summary>
        /// 直接写入一个WorkBook
        /// </summary>
        /// <param name="book"></param>
        /// <param name="fileName"></param>
        public void WriteWorkbook(IWorkbook book, string fileName)
        {
            var context = HttpContext.Current;

            context.Response.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            context.Response.ContentType = "application/octet-stream";

            book.Write(context.Response.OutputStream);
            context.Response.End();
        }
    }
}