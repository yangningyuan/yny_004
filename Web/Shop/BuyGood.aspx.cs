using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Shop
{
    public partial class BuyGood : BasePage
    {
        protected override void SetPowerZone()
        {
            GParentCode.DataSource = BLL.GoodCategory.GetList("IsDeleted=0");
            GParentCode.DataTextField = "Name";
            GParentCode.DataValueField = "Code";
            GParentCode.DataBind();
            GParentCode.Items.Insert(0, new ListItem("--请选择--", ""));
        }
    }
}