using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class NoticeList : BasePage
    {
        
        protected override void SetPowerZone()
        {
            repNoticeList.DataSource = BLL.Notice.GetNoticeList("  ");
            repNoticeList.DataBind();
        }
    }
}