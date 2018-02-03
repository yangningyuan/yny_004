using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.SysManage
{
    public partial class GrantPowers : BasePage
    {
        protected override void SetPowerZone()
        {
            List<Model.Roles> list = BLL.Roles.RolsList.Values.Where(emp => emp.VState).ToList();
            foreach (Model.Roles item in list)
            {
                txtKey.Items.Add(new ListItem(item.RName, item.RType));
            }
        }
    }
}