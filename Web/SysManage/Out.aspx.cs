using System;
using System.Web.Security;

namespace yny_004.Web.SysManage
{
    public partial class Out : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BllModel == null || !TModel.Role.Super)
                {
                    Response.Write(RetUrlStr("/Login.aspx", "/Error.aspx"));
                }
                else
                {
                    Response.Write(RetUrlStr("/MQL/Login.aspx", "/MQL/Login.aspx"));
                }
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
                Response.Expires = 0;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "No-Cache");
                Session.Clear();
                FormsAuthentication.SignOut();
                Response.End();
            }
        }

        private string RetUrlStr(string OutUrl, string ErrorUrl)
        {
            if (!WebModel.WebState || !TestCloseTime())
            {
                return "<script>window.top.location.href='" + ErrorUrl + "'</script>";
            }
            else
            {
                return "<script>window.top.location.href='" + OutUrl + "'</script>";
            }
        }

        private bool TestCloseTime()
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in WebModel.OpenTimeList)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}