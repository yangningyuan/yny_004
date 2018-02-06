using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
	public partial class LuckList : BasePage
	{
		protected override string btnOther_Click()
		{
			string where = "  isvalid < 4 and MID='" + TModel.MID + "' ";

			string mkey = "";
			mkey = TModel.MID;

			List<Model.LuckyMoney> listchange = null;

			listchange = BLL.LuckyMoney.GetLuckyMoneyEntityList(where, CurrentPage, ItemsPerPage, out totalCount);

			var list = listchange.Select(item => new
			{
				MID = item.MID,
				Money = item.ApplyMoney,
				CreateDate = item.CreateTime.ToString(),
				
			});
			return jss.Serialize(new { Items = list, TotalCount = totalCount });
		}
		
	}
}