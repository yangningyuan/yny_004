using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.ChangeMoney
{
    public partial class HBJL : BasePage
    {
        protected override void SetValue()
        {
            foreach (Model.Reward item in BLL.Reward.List.Values.Where(emp => emp.NeedProcess && emp.RewardState))
            {
                ddlChangeType.Items.Add(new ListItem(item.RewardName, item.RewardType));
            }
        }
        /// <summary>
        /// 货币购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            if (TModel.Role.IsAdmin)
            {
                if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
                {
                    string MType = "MHB";
                    if (BLL.ChangeMoney.EnoughChange(TModel.MID, decimal.Parse(Request.Form["txtMHB"]), MType))
                    {
                        Model.Member model = BLL.Member.ManageMember.GetModel(Request.Form["txtMID"]);
                        if (model != null)
                        {
                            if (BLL.Reward.List.ContainsKey(Request.Form["ddlChangeType"]))
                            {
                                if (BLL.ChangeMoney.HBJLChangeTran(model, decimal.Parse(Request.Form["txtMHB"]), Request.Form["ddlChangeType"]))
                                    return "成功";
                                return "失败";
                            }
                            else
                            {
                                return "奖励类型不存在";
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        return "您的账户余额不足!";
                    }
                }
                else
                {
                    return "充值金额不能为空";
                }
            }
            return "您没有权限";
        }
    }
}