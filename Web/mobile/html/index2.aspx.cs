using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
	public partial class index2 : BasePage
	{
		protected Model.Notice notice = null;
		protected string noticecontent = ""; 
		protected List<Model.GoodCategory> listcate = new List<Model.GoodCategory>();
		protected override void SetPowerZone()
		{
			List<Model.Notice> listnotice = BLL.Notice.GetNoticeList(" IsFixed = 1 ");
			if (listnotice.Count > 0)
			{
				notice = listnotice[0];
				noticecontent = GetKeyName(notice.NContent);
			}
			MyLink.Value = GetPromoteLinkTel();

			listcate = BLL.GoodCategory.GetList(" Status=1 ");
		}
	}
}