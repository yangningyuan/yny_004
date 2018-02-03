using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Member
{
    public partial class List : BasePage
    {
        protected string RoleListStr;
        protected int OnLineCount;
        protected string AgencyListStr;
        protected string NAgencyListStr;

        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                editMember.Visible = false;
            }
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleListStr += "<option value='" + item.RType + "'>" + item.RName + "</option>";
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.ToList())
                AgencyListStr += "<option value='" + item.MAgencyType + "'>" + item.MAgencyName + "</option>";
            //foreach (Model.NewSHMoney item in BLL.Configuration.Model.NewSHMoneyList.Values.ToList())
            //    NAgencyListStr += "<option value='" + item.NType + "'>" + item.NName + "</option>";
            OnLineCount = BLL.Member.OnLineCount;
        }
    }
}