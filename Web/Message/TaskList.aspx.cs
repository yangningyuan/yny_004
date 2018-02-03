using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Message
{
    public partial class TaskList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "<input name='txtKey' id='mKey' value='" + TModel.MID + "' style='display:none;' />";
                DivChk.InnerHtml = "<input type='checkbox' id='chktrue' checked='checked' value='true' name='chkType' style='display:none;'/>";
            }
        }
    }
}