using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class PayOrder : BasePage
    {
        protected Model.Order orderModel;
        protected Model.ReceiveInfo ReceiveInfoModel;
        protected string strgoods = "";
        protected override void SetValue(string id)
        {

            string oid = HttpUtility.UrlDecode(Request["id"].Trim());//订单Id
            hidId.Value = oid;
            orderModel = BLL.Order.GetModel(oid);
            ReceiveInfoModel = BLL.ReceiveInfo.GetModel(orderModel.ReceiveId);
            ViewState["OrderInfo"] = orderModel;
            Session["OrderId"] = oid;

            List<Model.OrderDetail> listdetail = BLL.OrderDetail.GetList(" OrderCode='" + orderModel.Code + "';");
            foreach (Model.OrderDetail item in listdetail)
            {
                Model.Goods gs = BLL.Goods.GetModel(item.GId);
                if (gs != null)
                {
                    strgoods += gs.GName + "&nbsp;&nbsp;&nbsp;" + item.GCount + gs.Unit + ";<br/>";
                }
            }
        }
        protected override void SetPowerZone()
        {

        }

        protected int GetOrderDetailCount(object gid)
        {
            Model.Order objOrder = (Model.Order)ViewState["OrderInfo"];
            if (objOrder != null)
            {
                int goodId = Convert.ToInt32(gid);
                Model.OrderDetail od = objOrder.OrderDetail.Where(c => c.GId == goodId).FirstOrDefault();
                if (od != null)
                {
                    return od.GCount;
                }
            }
            return 0;
        }
    }
}