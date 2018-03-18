using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class index : BasePage
    {

        protected Model.Notice notice = null;
        protected string noticecontent = "";
        protected override void SetPowerZone()
        {
            List<Model.Notice> listnotice = BLL.Notice.GetNoticeList(" IsFixed = 1 ");
            if (listnotice.Count > 0)
            {
                notice = listnotice[0];
                noticecontent = GetKeyName(notice.NContent);
            }
            MyLink.Value = GetPromoteLinkTel();


			if (string.IsNullOrEmpty(TModel.SecPsd))//当天第一次登陆
			{
				isnotice2.Value = "1";
			}
			else {
				isnotice2.Value = "0";
			}

		}

        
    }
}