using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class Login : BasePageNoLogin
    {
        
        protected new void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookies = Request.Cookies["platform"];
            //判断是否有cookie值，有的话就读取出来
            if (cookies != null && cookies.HasKeys)
            {
                txtname.Value = cookies["Name"];
                //txtpwd.Value = cookies["Pwd"];
                txtpwd.Attributes.Add("value", cookies["Pwd"]);
                //Page.RegisterStartupScript("", "<script>document.getElementById('txtpwd').value='" + cookies["Pwd"] + "';</script>");
                //txtpwd.Attributes["value"]= cookies["Pwd"];
                this.reuserpsw.Value = "1";
                this.reuserpsw.Checked = true;
                this.inpwd.Value = cookies["Pwd"];
            }
        }
    }
}