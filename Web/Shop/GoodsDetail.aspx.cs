using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Shop
{
    public partial class GoodsDetail :  BasePage
    {
        protected Model.Goods model;
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            hidId.Value = mid;
            model = BLL.Goods.GetModel(mid);
            var list = BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + model.GoodsCode + "'");
            rep_PicList.DataSource = list;
            rep_PicList.DataBind();

        }
        protected override void SetPowerZone()
        {

        }
        protected string GetCategory(string code)
        {
            return "生活用品";
        }
    }
}