using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.ChangeMoney
{
    public partial class HBToJBChange : BasePage
    {

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            Dictionary<string, List<string>> MoneyType = new Dictionary<string, List<string>>();
            MoneyType.Add("MHB", new List<string> { "MJB" });
            Model.Member model = TModel;
            if (model.IsClock)
                return "您已被冻结账户";
            if (model.AgencyCode == "001" || model.AgencyCode == "002")
            {
                return "普通会员不能兑换";
            }
            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                int money = int.Parse(Request.Form["txtMHB"]);
                if (money > 0)
                {
                    string from = Request.Form["ddlFrom"];
                    string to = Request.Form["ddlTo"];
                    if (MoneyType.ContainsKey(from) && MoneyType[from].Contains(to))
                    {
                        if (money < BLL.Configuration.Model.B_ZZMinMoney)
                            return "转换金额最小为" + BLL.Configuration.Model.B_ZZMinMoney;
                        else if ((money - BLL.Configuration.Model.B_ZZMinMoney) % BLL.Configuration.Model.B_ZZBaseMoney != 0)
                            return "转换金额应是" + BLL.Configuration.Model.B_ZZBaseMoney + "的倍数";

                        Hashtable MyHs = new Hashtable();
                        if (BLL.ChangeMoney.EnoughChange(model.MID, money, from))
                        {
                            BLL.ChangeMoney.HBChangeTran(money, TModel.MID, BLL.Member.ManageMember.TModel.MID, "DH", null, from, BLL.Reward.List[to].RewardName, MyHs);
                            BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, TModel.MID, "DH", null, to, "", MyHs);
                            if (BLL.CommonBase.RunHashtable(MyHs))
                                return "货币转换成功";
                            return "货币转换失败";
                        }
                        else
                        {
                            return "您的" + BLL.Reward.List[from].RewardName + "不足";
                        }
                    }
                    else
                    {
                        return "禁止该类型账户转换！";
                    }
                }
                else
                {
                    return "参数异常";
                }
            }
            else
            {
                return "参数异常";
            }
        }
    }
}