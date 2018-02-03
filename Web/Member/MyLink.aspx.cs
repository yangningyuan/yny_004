using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Member
{
    public partial class MyLink : BasePage
    {
        protected override void SetPowerZone()
        {
            txtTuiGuang.Value = "http://" + HttpContext.Current.Request.Url.Authority.ToString() + "/Regedit/Index.aspx?mid=" + TModel.MID;
        }
    }
}