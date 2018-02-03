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
    }
}