using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class Cars : BasePage
    {
        protected List<Model.ShopCar> listshop = new List<Model.ShopCar>();
        protected override void SetPowerZone()
        {
            listshop = BLL.ShopCar.GetList(" IsDeleted=0 and MID='" + TModel.MID + "'  and Status=1");
            repReceiveList.DataSource = BLL.ReceiveInfo.GetList("IsDeleted=0 and Status=1 and MID='" + TModel.MID + "'");
            repReceiveList.DataBind();
        }

        protected override string btnModify_Click()
        {
            if (!string.IsNullOrEmpty(Request.Form["del_id"]))
            {
                if (BLL.ShopCar.Delete(Request.Form["del_id"]))
                {
                    return "删除成功";
                }
                else {
                    return "删除失败，请重试";
                }
            }
            else {
                return "请选中再次删除";
            }
        }
    }
}