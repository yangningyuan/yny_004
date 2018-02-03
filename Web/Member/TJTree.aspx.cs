using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Member
{
    public partial class TJTree : BasePage
    {
        protected string MAgencyTypeColor;
        protected override void SetPowerZone()
        {
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.ToList())
                MAgencyTypeColor += "<td><label style='background: " + item.MColor + "'>" + item._MAgencyName + "</label></td>";

            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "<input id='txtMid' value='" + TModel.MID + "' type='text' style='display:none;'/> ";
        }
    }
}