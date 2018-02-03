using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Shop
{
    public partial class Cars : BasePage
    {
        protected override void SetValue(string id)
        {
             
        }
        protected override void SetPowerZone()
        {
            repReceiveList.DataSource = BLL.ReceiveInfo.GetList("IsDeleted=0 and Status=1 and MID='"+TModel.MID+"'");
            repReceiveList.DataBind();
        }
    }
}