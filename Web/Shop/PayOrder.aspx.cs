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

        protected string mtype = "";
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

            if (!string.IsNullOrEmpty(orderModel.Remarks))
            {
                mtype = "<input id=\"rdoXFB\" value=\"MGP\" type=\"radio\" name=\"rdo\" checked=\"checked\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MGP"].RewardName + "</label><input id=\"rdoXFB\" value=\"MJB\" type=\"radio\" name=\"rdo\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MJB"].RewardName + "</label>";
            }
            else {
                mtype = "<input id=\"rdoXFB\" value=\"MGP\" type=\"radio\" name=\"rdo\" checked=\"checked\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MGP"].RewardName + "</label><input id=\"rdoXFB\" value=\"MHB\" type=\"radio\" name=\"rdo\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MHB"].RewardName + "</label>";
            }
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
                        if (Request.Form["rdo"] == "MJB")
                            MType = "MJB";
                        if (Request.Form["rdo"] == "MGP")
                            MType = "MGP";

                        if (string.IsNullOrEmpty(model.Remarks))
                        {
                            if (MType == "MJB")
                                return "支付失败，请重新选择支付币种";
                        }
                        else {
                            if (MType == "MHB")
                                return "支付失败，请重新选择支付币种";
                        }

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
                                //if (!string.IsNullOrEmpty(model.Remarks))//公排区商品
                                //{
                                    //BLL.ChangeMoney.MymemberAdd(TModel);
                                //}

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
                            return "您的" + yny_004.BLL.Reward.List[MType].RewardName + "不足，请充值后购买！";
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

        protected override string btnAdd_Click()
        {
            lock (lockObj)
            {
                string gid = Request.Form["hidId"];
                int recount = Convert.ToInt32(BLL.CommonBase.GetSingle(" select COUNT(*) from ReceiveInfo where MID='" + TModel.MID + "' and IsDeleted=0 and Status=1 and IsMain=1; "));
                Hashtable MyHs = new Hashtable();
                Model.ReceiveInfo reinfo = new Model.ReceiveInfo();
                int reid = 0;//收货地址

                if (recount <= 0)//如果没收货地址
                {
                    reinfo.MID = TModel.MID;
                    //reinfo.Tel = Request.Form["txtPhone"];
                    reinfo.Province = Request.Form["ddlProvince"];
                    reinfo.City = Request.Form["ddlCity"];
                    reinfo.Zone = Request.Form["ddlZone"];
                    reinfo.Address = Request.Form["txtAddress"];
                    reinfo.Phone = Request.Form["txtPhone"];
                    reinfo.IsDeleted = false;
                    reinfo.IsMain = true;
                    reinfo.Status = 1;
                    reid = BLL.ReceiveInfo.InsertByID(reinfo);
                }
                else {
                    reid = BLL.ReceiveInfo.GetList(" MID='" + TModel.MID + "' and IsDeleted=0 and Status=1 and IsMain=1;")[0].Id;
                }
                //使用币种


                //查看订单信息
                if (!string.IsNullOrEmpty(gid))
                {
                    Model.Goods model = BLL.Goods.GetModel(gid);
                    if (model != null)
                    {
                        string MType = "MGP";//币种
                        if (Request.Form["rdoXFB"] == "MJB")
                            MType = "MJB";
                        if (Request.Form["rdoXFB"] == "MGP")
                            MType = "MGP";



                        decimal totaoPay = model.CostPrice;
                        if (BLL.ChangeMoney.EnoughChange(TModel.MID, totaoPay, MType))
                        {
                            //货币转换
                            BLL.ChangeMoney.HBChangeTran(totaoPay, TModel.MID, BLL.Member.ManageMember.TModel.MID, "GW", null, MType, "支付订单", MyHs);
                            //库存减少
                            if (model != null)
                            {
                                model.SelledCount = model.SelledCount + 1;
                                model.SellingCount = model.SellingCount - 1;
                                if (model.SellingCount < 0)
                                {
                                    return "库存不足";
                                }
                                BLL.Goods.Update(model, MyHs);
                            }

                            //生成订单主从表
                            Model.Order order = new Model.Order();
                            DateTime dt = DateTime.Now;
                            string code = dt.ToString("yyyyMMddHHmmssfff");// dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
                            order.Code = code;
                            order.ReceiveId = reid;
                            order.CreatedBy = TModel.MID;
                            order.CreatedTime = DateTime.Now;
                            order.PayTime = DateTime.MaxValue;
                            //order.GoodCount
                            int count = 0; decimal totalMoney = 0;
                            string error = string.Empty;

                            string isgongpai = "";


                            Model.OrderDetail od = new Model.OrderDetail();
                            od.BuyPrice = model.CostPrice;
                            od.Code = GetGuid();
                            od.CreatedBy = TModel.MID;
                            od.CreatedTime = DateTime.Now;
                            od.GCount = 1;
                            count += 1;
                            od.GId = model.GID;
                            //查看库存数量是否足够，不够的话暂时不能提交订单
                            
                            if (model.GParentCode == "001")
                            {
                                isgongpai += "公排";
                                if (od.GCount > 1)
                                {
                                    error = "公排区商品一次只能买入一个";
                                }
                            }
                            od.IsDeleted = false;
                            od.OrderCode = order.Code;
                            od.Status = 1;
                            od.TotalMoney = od.GCount * od.BuyPrice;
                            totalMoney += od.TotalMoney;
                            BLL.OrderDetail.Insert(od, MyHs);
                            order.GoodCount = count;
                            order.Remarks = isgongpai;
                            if (!string.IsNullOrEmpty(order.Remarks))
                            {
                                if (order.GoodCount > 1)
                                {
                                    error = "公排区商品一次只能买入一个，且与普通区商品不能同时提交订单";
                                }
                            }
                            order.IsDeleted = false;
                            order.MID = TModel.MID;
                            order.OrderTime = DateTime.Now;
                            order.Status = 2;
                            order.TotalPrice = totalMoney;
                            order.PayTime = DateTime.Now;
                            order.MoneyType = MType;
                            BLL.Order.Insert(order, MyHs);
                            if (BLL.CommonBase.RunHashtable(MyHs))
                            {
                                if (!string.IsNullOrEmpty(order.Remarks))//公排区商品
                                {
                                    if (TModel.MState)
                                    {
                                        BLL.ChangeMoney.MymemberAdd(TModel);
                                    }
                                    else {
                                        Model.SHMoney shmodel= BLL.Configuration.Model.SHMoneyList["002"];
                                        BllModel.ShopUpMAgencyType(shmodel, TModel.MID, "MHB", TModel, shmodel.Money);
                                        return "升级成功";
                                    }
                                }
                                return "支付成功！";
                            }
                            else
                            {
                                return "支付失败，请重试！";
                            }
                        }
                        else
                        {
                            return "您的" + yny_004.BLL.Reward.List[MType].RewardName + "不足，请充值后购买！";
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