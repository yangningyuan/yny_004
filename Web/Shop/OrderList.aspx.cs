using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Shop
{
    public partial class OrderList : BasePage
    {
        protected string status = "";
        protected override void SetValue(string id)
        {
            status = id;
        }

        protected override void SetPowerZone()
        {
            if (TModel.Role.IsAdmin)
            {
                divOperator.Visible = true;
            }
        }
    }
}