using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class HBChange : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                txtFromMID.Value = TModel.MID;
                txtFromMID.Attributes.Add("readonly", "readonly");
                if (!TModel.MConfig.ZZStatus)
                {
                    //不能提现
                    btnOK.Visible = false;
                }
                else
                {
                    divTips.Visible = false;
                }
            }
        }
    }
}