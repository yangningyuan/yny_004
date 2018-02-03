using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class NoticeView : BasePage
    {
        protected Model.Notice notice = null;
        protected override void SetPowerZone()
        {
            string id= Request.QueryString["id"];
             notice= BLL.Notice.Select(Convert.ToInt32(id), false);
        }
    }
}