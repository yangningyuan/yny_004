using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.ChangeMoney
{
    public partial class HBList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "";
            if (!TModel.Role.IsAdmin)
                DivDelete.InnerHtml = "";
        }
    }
}