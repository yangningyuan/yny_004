using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
	public partial class shopindex : BasePage
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
			//MyLink.Value = GetPromoteLinkTel();

			listcate = BLL.GoodCategory.GetList(" Status=1 ");

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