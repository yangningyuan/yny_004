using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace yny_004.Web.MQL
{
    public partial class Login : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            //Session["Member"] = BLL.Member.ManageMember;
            //if (BllModel != null)
            //    Response.Write("<script>window.top.location.href='/Default.aspx'</script>");

            if (BllModel != null)
            {
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
                Response.Expires = 0;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "No-Cache");
                Session.Clear();
                FormsAuthentication.SignOut();
            }
        }
    }
}