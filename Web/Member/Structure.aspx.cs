using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Member
{
    public partial class Structure : BasePage
    {
        protected string MAgencyTypeColor;
        protected string RoleColor;
        protected override void SetPowerZone()
        {
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values)
            {
                if (item.MAgencyType == "001")
                    continue;
                MAgencyTypeColor += "<td><label style='background: " + item.MColor + "'>" + item._MAgencyName + "</label></td>";
            }
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleColor += "<td><label style='background: " + item.RColor + "'>" + item.RName + "</label></td>";


            //if (!TModel.Role.Super)
            //    DivSearch.InnerHtml = "<input id='txtMid' value='" + TModel.MID + "' type='text' style='display:none;'/> ";
        }
    }
}