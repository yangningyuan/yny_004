using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data;

namespace yny_004.BLL
{
    //EPList
    public class EPList
    {
        public static yny_004.Model.EPList GetModel(object obj)
        {
            return yny_004.DAL.EPList.GetModel(obj);
        }

        public static Hashtable Insert(yny_004.Model.EPList model, Hashtable MyHs)
        {
            return yny_004.DAL.EPList.Insert(model, MyHs);
        }

        public static string Insert(yny_004.Model.EPList model)
        {
            if (!BLL.ChangeMoney.EnoughChange(model.SellMID, model.Money, model.MoneyType))
            {
                return "您当前的" + BLL.Reward.List[model.MoneyType].RewardName + "余额不足";
            }

            if (DAL.EPList.Insert(model))
            {
                return "挂卖成功";
            }
            else
            {
                return "挂卖失败";
            }
        }

        public static Hashtable Update(yny_004.Model.EPList model, Hashtable MyHs)
        {
            return yny_004.DAL.EPList.Update(model, MyHs);
        }

        public static bool Update(yny_004.Model.EPList model)
        {
            return yny_004.DAL.EPList.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.EPList.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.EPList.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.EPList.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.EPList.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<yny_004.Model.EPList> GetList(string strWhere)
        {
            return yny_004.DAL.EPList.GetList(strWhere);
        }

        public static List<yny_004.Model.EPList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.EPList.GetList(strWhere, pageIndex, pageSize, out count);
        }

        # region add

        private static object obj = new object();

        /// <summary>
        /// 买方点击购买
        /// </summary>
        public static string EPbuy(string epid, string userid)
        {
            string result = "";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                if (eplist.SellState == 1)
                {
                    return "改记录已被锁定";
                }
                Model.Member mermber = DAL.Member.GetModel(userid);
                //if (mermber.MConfig.MJJ > eplist.Money)
                {
                    eplist.SellState = 1;
                    //eplist.SellType = mermber.RoleCode;
                    eplist.BuyMID = userid;
                    eplist.BuyDate = DateTime.Now;
                    Hashtable MyHs = new Hashtable();
                    //DAl.MemberConfig.UpdateConfigTran(userid, "MHB", (-eplist.Money).ToString(), null, false, SqlDbType.Int, MyHs);
                    Update(eplist, MyHs);
                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        result = "记录锁定成功，请联系会员进行支付";
                    }
                    else
                    {
                        result = "购买失败";
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 卖家违规(自动确认)
        /// </summary>
        public static string sellOut(string epid, Model.Member member)
        {
            string result = "订单不存在";
            lock (obj)
            {
                if (!member.Role.IsAdmin)
                {
                    return "您没有权限";
                }
                Model.EPList eplist = GetModel(epid);
                if (eplist != null)
                {
                    Hashtable MyHs = new Hashtable();

                    DAL.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHB", eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);//得到股权
                    eplist.SellState = 3;
                    eplist.LastSellDate = DateTime.Now;
                    Update(eplist, MyHs);
                    //冻结卖家
                    MyHs.Add(" update member set IsClock = 1, IsClose = 1 where MID = '" + eplist.SellMID + "' ", null);

                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        result = "处理成功";
                    }
                    else
                    {
                        result = "处理失败";
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 买家违规(重新匹配)
        /// </summary>
        public static string buyOut(string epid, Model.Member member)
        {
            string result = "订单不存在";
            lock (obj)
            {
                if (!member.Role.IsAdmin)
                {
                    return "您没有权限";
                }
                Model.EPList eplist = GetModel(epid);
                if (eplist != null)
                {
                    Hashtable MyHs = new Hashtable();

                    //冻结卖家
                    MyHs.Add(" update member set IsClock = 1, IsClose = 1 where MID = '" + eplist.BuyMID + "' ", null);

                    eplist.SellState = 0;
                    eplist.LastSellDate = null;
                    eplist.BuyMID = "";
                    eplist.BuyDate = null;
                    eplist.EPImg = "";
                    eplist.LastBuyDate = null;
                    eplist.LastSellDate = null;
                    eplist.Remark = "";
                    Update(eplist, MyHs);
                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        result = "处理成功";
                    }
                    else
                    {
                        result = "处理失败";
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 买方点击购买
        /// </summary>
        public static string EPComplain(string epid, Model.Member member)
        {
            string result = "订单不存在";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                if (eplist != null)
                {
                    if (eplist.SellState != 2)
                    {
                        return "当前状态不能投诉";
                    }
                    if (eplist.SellMID != member.MID)
                    {
                        return "该订单不是您的,请不要违规操作";
                    }
                    eplist.SellState = 99;
                    eplist.LastSellDate = DateTime.Now;
                    eplist.Remark = "未收到款";

                    Hashtable MyHs = new Hashtable();
                    Update(eplist, MyHs);
                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        result = "该订单已提交到管理员处，请等待处理结果";
                    }
                    else
                    {
                        result = "处理失败";
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 买方取消购买
        /// </summary>
        public static string EPcancel(string epid)
        {
            string result = "";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                Hashtable MyHs = new Hashtable();
                //DAl.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHB", eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);
                eplist.SellState = 0;
                eplist.BuyMID = "";
                eplist.BuyDate = null;
                eplist.EPImg = "";
                eplist.LastSellDate = null;
                eplist.LastBuyDate = null;
                Update(eplist, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    result = "取消成功";
                }
                else
                {
                    result = "取消失败";
                }

                return result;
            }
        }

        /// <summary>
        /// 买方确认付款
        /// </summary>
        public static string EPpay(string epid, Model.Member member)
        {
            string result = "";
            lock (obj)
            {
                var list = epid.Split('@');
                Model.EPList eplist = GetModel(list[0]);
                if (eplist.SellState > 1)
                {
                    return "已确认付款";
                }
                if (eplist.BuyMID != member.MID)
                {
                    return "该订单不属于您";
                }
                eplist.EPImg = list[1];
                eplist.SellState = 2;
                eplist.LastBuyDate = DateTime.Now;
                if (Update(eplist))
                {
                    result = "确认付款成功";
                }
                else
                {
                    result = "确认付款失败";
                }

                return result;
            }
        }

        /// <summary>
        /// 卖方确认收款
        /// </summary>
        public static string EPsellLast(string epid)
        {
            string result = "";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                if (eplist.SellState == 3)
                {
                    return "已确认收款";
                }
                Hashtable MyHs = new Hashtable();
                //if (eplist.SellType == "Nomal")
                //{
                //    //DAl.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHB", (eplist.Money - eplist.TakeOffMoney).ToString(), null, false, SqlDbType.Int, MyHs);//买方增加奖金币
                //    DAl.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHB", (eplist.Money).ToString(), null, false, SqlDbType.Int, MyHs);//买方商务中心增加奖金币
                //}
                //else
                //{
                //    DAl.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHZ", eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);//买方会员注册币
                //}
                //DAl.MemberConfig.UpdateConfigTran(eplist.SellMID, "MHB", eplist.MHGFloat.ToString(), null, false, SqlDbType.Int, MyHs);
                DAL.MemberConfig.UpdateConfigTran(eplist.BuyMID, "MHB", eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);//得到股权

                eplist.SellState = 3;
                eplist.LastSellDate = DateTime.Now;
                Update(eplist, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    result = "确认收款成功";
                }
                else
                {
                    result = "确认收款失败";
                }
                return result;
            }
        }

        /// <summary>
        /// 卖方取消挂卖
        /// </summary>
        public static string EPDelete(string epid)
        {
            string result = "";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                if (eplist == null)
                {
                    return "交易已撤销";
                }
                Hashtable MyHs = new Hashtable();
                DAL.MemberConfig.UpdateConfigTran(eplist.SellMID, eplist.MoneyType, (eplist.Money + eplist.MHGMoney).ToString(), null, false, SqlDbType.Int, MyHs);
                Delete(epid, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    result = "撤销成功";
                }
                else
                {
                    result = "撤销失败";
                }
                return result;
            }
        }

        /// <summary>
        /// 卖方关闭交易
        /// </summary>
        public static string EPClose(string epid)
        {
            string result = "";
            lock (obj)
            {
                Model.EPList eplist = GetModel(epid);
                if (eplist.SellState == 4)
                {
                    return "交易已关闭";
                }
                Hashtable MyHs = new Hashtable();
                DAL.MemberConfig.UpdateConfigTran(eplist.SellMID, eplist.MoneyType, (eplist.Money + eplist.MHGMoney).ToString(), null, false, SqlDbType.Int, MyHs);
                eplist.SellState = 4;
                eplist.LastSellDate = DateTime.Now;
                Update(eplist, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    result = "关闭成功";
                }
                else
                {
                    result = "关闭失败";
                }
                return result;
            }
        }

        public static string EPValid(string id, string pwd)
        {
            string result = "1";
            lock (obj)
            {
                Model.EPList eplist = GetModel(id);
                if (eplist != null)
                {
                    //if (eplist.epPwd != pwd)
                    //{
                    //    result = "交易密码错误";
                    //}
                }
                else
                {
                    result = "非法操作";
                }

                return result;
            }
        }

        public bool isTradeTime()
        {
            DateTime startTime = BLL.EPConfig.EPConfigModel.EPStartTime;//获取开始时间
            DateTime endTime = BLL.EPConfig.EPConfigModel.EPEndTime;//获取结束时间
            DateTime current = DateTime.Now;//当前时间
            //DateTime start = new DateTime(current.Year, current.Month, current.Day, startTime.Hour, startTime.Minute, startTime.Second);
            //DateTime end = new DateTime(current.Year, current.Month, current.Day, endTime.Hour, endTime.Minute, endTime.Second);

            //if (current >= start && current <= end)
            if ((DateTime.Now.TimeOfDay - BLL.EPConfig.EPConfigModel.EPStartTime.TimeOfDay).TotalSeconds > 0 && (DateTime.Now.TimeOfDay - BLL.EPConfig.EPConfigModel.EPEndTime.TimeOfDay).TotalSeconds < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PayOverTime()
        {
            string sql = " SellDate = 1 and DATEDIFF(MI,BuyDate,getdate()) > " + BLL.EPConfig.EPConfigModel.PayTime + " ";
            List<Model.EPList> list = BLL.EPList.GetList(sql);
            if (list != null && list.Any())
            {
                Hashtable MyHs = new Hashtable();
                foreach (Model.EPList model in list)
                {
                    MyHs.Add(" update member set IsClock = 1, IsClose = 1 where MID = '" + model.BuyMID + "' ", null);
                    model.SellState = 0;
                    model.BuyDate = null;
                    model.BuyMID = null;
                    //封号，订单重新匹配
                    BLL.EPList.Update(model, MyHs);
                }
                return CommonBase.RunHashtable(MyHs);
            }
            return true;
        }

        public static bool ConfirmOverTime()
        {
            string sql = " SellDate = 2 and DATEDIFF(MI,LastBuyDate,getdate()) > " + BLL.EPConfig.EPConfigModel.ConfirmTime + " ";
            List<Model.EPList> list = BLL.EPList.GetList(sql);
            if (list != null && list.Any())
            {
                Hashtable MyHs = new Hashtable();
                foreach (Model.EPList model in list)
                {
                    //MyHs.Add(" update member set IsClock = 1, IsClose = 1 where MID = '" + model.BuyMID + "' ", null);
                    model.SellState = 99;
                    model.LastSellDate = DateTime.Now;
                    model.Remark = "超时未付款";
                    //封号，订单重新匹配
                    BLL.EPList.Update(model, MyHs);
                }
                return CommonBase.RunHashtable(MyHs);
            }
            return true;
        }

        # endregion
    }
}
