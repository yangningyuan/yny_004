using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class BuyGoods : BasePage
    {
        protected List<Model.GoodCategory> listcate = new List<Model.GoodCategory>();



        protected override void SetPowerZone()
        {
            listcate = BLL.GoodCategory.GetList(" Status=1 ");
        }
    }
}