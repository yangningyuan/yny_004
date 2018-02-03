using System;
using System.Collections;
using System.Web;

namespace yny_004.Web.Module.Investment.Handler
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string result = "非法操作";
            if (!string.IsNullOrEmpty(context.Request["type"]))
                result = Operation(context.Request["type"]);

            context.Response.Write(result);
        }

        private string Operation(string type)
        {
            switch (type)
            {
                case "quit"://退本
                    return quit();
                case "Audit"://审核
                    return Audit();
                case "refuse"://拒绝
                    return refuse();
                case "GetBbin"://领取体验金
                    return GetBbin();
            }
            return "非法操作";
        }


        private object lockObj = new object();

        public string quit()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    Hashtable MyHs = new Hashtable();
                    var prams = _context.Request["pram"].Split(',');
                    foreach (string p in prams)
                    {
                        if (!string.IsNullOrEmpty(p))
                        {
                            Model.LuckyMoney lucky = BLL.LuckyMoney.GetModel(Convert.ToInt32(p));
                            if (lucky.MID != TModel.MID)
                            {
                                return "订单不存在";
                            }
                            if (lucky.isValid != 0)
                            {
                                return "该订单不能退本";
                            }
                            if (lucky.Type != 0)
                            {
                                return "体验金不能退本";
                            }
                            
                            Model.ConfigDictionary dic= BLL.ConfigDictionaryNew.GetConfigDictionary((DateTime.Now - lucky.CreateTime).Days,"TBFloat","");
                            decimal tbfloat =Convert.ToDecimal(dic.DValue);

                            lucky.isValid = 1;
                            lucky.EditTime = DateTime.Now;
                            lucky.TakeOffmoney = lucky.ApplyMoney * tbfloat;
                            BLL.LuckyMoney.Update(lucky, MyHs);
                        }
                    }
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        return "申请成功";
                    }
                    else
                    {
                        return "申请失败";
                    }
                }
                else
                {
                    result = "参数错误";
                }
                return result;
            }
        }

        public string GetBbin()
        {
            lock (lockObj)
            {
                //会员是否已经领取过
                Model.LuckyMoney lucky = BLL.LuckyMoney.GetModel(string.Format(" Type = 1 and MID = '{0}' ", TModel.MID));
                if (lucky == null)
                {
                    if (BLL.LuckyMoney.GetCount(" * ", " Type = 1 ") >= BLL.Configuration.Model.E_BbinMaxCount)
                    {
                        return "已达到最大体验金领取数量";
                    }
                    string result = BLL.LuckyMoney.InvestApply(TModel.MID, BLL.Configuration.Model.E_BbinMoney, 1);
                    if (result == "申请成功")
                    {
                        return "领取成功";
                    }
                    return "领取失败";
                }
                else
                {
                    return "您已经领取过体验金";
                }
            }
        }

        public string Audit()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    if (TModel.Role.IsAdmin)
                    {
                        Hashtable MyHs = new Hashtable();
                        var prams = _context.Request["pram"].Split(',');
                        foreach (string p in prams)
                        {
                            if (!string.IsNullOrEmpty(p))
                            {
                                Model.LuckyMoney lucky = BLL.LuckyMoney.GetModel(Convert.ToInt32(p));
                                if (lucky.isValid != 1)
                                {
                                    return "订单不能重复审核";
                                }
                                if ((DateTime.Now - lucky.CreateTime).Days < BLL.Configuration.Model.B_TBTJDate)
                                {
                                    Model.Member tbmodel = BLL.Member.GetModelByMID(lucky.MID);
                                    BLL.ChangeMoney.HBChangeTran(BLL.Configuration.Model.B_TBTJMoney, tbmodel.MTJ, BLL.Member.ManageMember.TModel.MID, "KF", null, "MHB", "退本烧伤，退本会员" + lucky.MID, MyHs);
                                }

                                lucky.isValid = 2;
                                BLL.ChangeMoney.HBChangeTran(lucky.ApplyMoney - lucky.TakeOffmoney, BLL.Member.ManageMember.TModel.MID, lucky.MID, "FHApply", null, "MHB", "", MyHs);
                                Model.Member mm = BLL.Member.GetModelByMID(lucky.MID);
                                BLL.ChangeMoney.YJCountTran(-lucky.ApplyMoney, mm, mm, MyHs);
                                BLL.LuckyMoney.Update(lucky, MyHs);
                            }
                        }
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            return "审核成功";
                        }
                        else
                        {
                            return "审核失败";
                        }
                    }
                    else
                    {
                        return "您不能审核";
                    }
                }
                else
                {
                    result = "参数错误";
                }
                return result;
            }
        }

        public string refuse()
        {
            lock (lockObj)
            {
                string result = "";
                if (!string.IsNullOrEmpty(_context.Request["pram"]))
                {
                    if (TModel.Role.IsAdmin)
                    {
                        Hashtable MyHs = new Hashtable();
                        var prams = _context.Request["pram"].Split(',');
                        foreach (string p in prams)
                        {
                            if (!string.IsNullOrEmpty(p))
                            {
                                Model.LuckyMoney lucky = BLL.LuckyMoney.GetModel(Convert.ToInt32(p));
                                if (lucky.isValid != 1)
                                {
                                    return "订单不能重复拒绝";
                                }

                                lucky.isValid = 0;
                                BLL.LuckyMoney.Update(lucky, MyHs);
                            }
                        }
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            return "拒绝成功";
                        }
                        else
                        {
                            return "拒绝失败";
                        }
                    }
                    else
                    {
                        return "您不能拒绝";
                    }
                }
                else
                {
                    result = "参数错误";
                }
                return result;
            }
        }
    }
}