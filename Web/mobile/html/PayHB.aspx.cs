using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class PayHB : BasePage
    {
        protected override void SetPowerZone()
        {
            //bankauto.Value = string.IsNullOrEmpty(TModel.BankNumber) ? "0" : "1";
            tmid.Value = TModel.MID;
        }
    }
}