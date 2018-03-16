using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Shop
{
    public partial class GoodsList : BasePage
    {
        protected override void SetPowerZone()
        {
            txtKey.DataSource = BLL.GoodCategory.GetList("IsDeleted=0");
            txtKey.DataTextField = "Name";
            txtKey.DataValueField = "Code";
            txtKey.DataBind();
            txtKey.Items.Insert(0, new ListItem("--请选择--", ""));
        }

		protected override string btnModify_Click()
		{
			try
			{
				string req = Request.Form["gid"];
				Model.Goods cc = BLL.Goods.GetModel(int.Parse(req));
				cc.IsDeleted = true;
				if (BLL.Goods.Update(cc))
				{
					return "删除成功";
				}
				else {
					return "删除失败";
				}
			}
			catch (Exception e)
			{
				return "-1";
			}
		}
	}
}