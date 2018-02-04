using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class Register : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                {
                    Model.Member tjmodel = BLL.Member.ManageMember.GetModel(Request.QueryString["mid"]);
                    if (tjmodel != null)
                    {
                        txtMTJ.Value = Request.QueryString["mid"];
                        txtMTJ.Attributes["readonly"] = "readonly";
                    }
                }
            }
           
        }
    }
}