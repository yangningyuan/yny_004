using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class geren : BasePage
    {
        protected string noticecontent = "";
        protected override void SetPowerZone()
        {
            List<Model.Notice> listnotice = BLL.Notice.GetNoticeList(" IsFixed = 1 ");
            if (listnotice.Count > 0)
            {
                Model.Notice notice = listnotice[0];
                noticecontent = GetKeyName(notice.NContent);
            }
        }
    }
}