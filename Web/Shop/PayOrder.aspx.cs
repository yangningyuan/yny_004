using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.Shop
{
    public partial class PayOrder : BasePage
    {
        protected Model.Order orderModel;
        protected Model.ReceiveInfo ReceiveInfoModel;
        protected string moneytype = "<input id='Radio1' value='MHB' type='radio' name='rdo' />奖金币<br />";
        protected override void SetValue(string id)
        {

            string oid = HttpUtility.UrlDecode(Request["id"].Trim());//订单Id
            hidId.Value = oid;
            orderModel = BLL.Order.GetModel(oid);
            ReceiveInfoModel = BLL.ReceiveInfo.GetModel(orderModel.ReceiveId);
            ViewState["OrderInfo"] = orderModel;
            Session["OrderId"] = oid;
            string gids = "";
            foreach (Model.OrderDetail od in orderModel.OrderDetail)
            {
                gids += od.GId + ",";
            }
            gids = gids.TrimEnd(',');
            var listGood = BLL.Goods.GetList("GID in (" + gids + ")");
            repGoodList.DataSource = listGood;
            repGoodList.DataBind();
        }
        protected override void SetPowerZone()
        {

        }
        protected string GetCategory(string code)
        {
            return "生活用品";
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

        private object lockObj = new object();
        protected override string btnModify_Click()
        {
            lock (lockObj)
            {
                string oid = Session["OrderId"] != null ? Session["OrderId"].ToString() : "";
                //查看订单信息
                if (!string.IsNullOrEmpty(oid))
                {
                    Model.Order model = BLL.Order.GetModel(oid);
                    if (model != null)
                    {
                        string MType = "MHB";//币种
                        //if (Request.Form["rdo"] == "MJJ")
                        //    MType = "MJJ";
                        //if (Request.Form["rdo"] == "XFB")
                        //    MType = "XFB";

                        decimal totaoPay = model.TotalPrice;
                        if (BLL.ChangeMoney.EnoughChange(model.MID, totaoPay, MType))
                        {
                            Hashtable MyHs = new Hashtable();
                            //货币转换
                            BLL.ChangeMoney.HBChangeTran(totaoPay, TModel.MID, BLL.Member.ManageMember.TModel.MID, "GW", null, MType, "支付订单" + model.Code, MyHs);
                            //库存减少
                            foreach (Model.OrderDetail od in model.OrderDetail)
                            {
                                Model.Goods good = BLL.Goods.GetModel(od.GId);
                                if (good != null)
                                {
                                    good.SelledCount = good.SelledCount + od.GCount;
                                    good.SellingCount = good.SellingCount - od.GCount;
                                    BLL.Goods.Update(good, MyHs);
                                }
                            }
                            //修改订单状态
                            model.Status = 2;
                            model.PayTime = DateTime.Now;
                            model.MoneyType = MType;
                            BLL.Order.Update(model);
                            if (BLL.CommonBase.RunHashtable(MyHs))
                            {
                                Session["OrderId"] = null;
                                return "支付成功！";
                            }
                            else
                            {
                                return "支付失败，请重试！";
                            }
                        }
                        else
                        {
                            Session["OrderId"] = null;
                            return "您的"+ yny_004.BLL.Reward.List["MHB"].RewardName + "不足，请充值后购买！";
                        }
                    }
                }
                else
                {
                    return "该订单信息出现异常，请重新进入该页面支付";
                }
                return "操作失败";
            }
        }
    }
}