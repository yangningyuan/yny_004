using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.ChangeMoney
{
    public partial class KFChange : BasePage
    {
        protected override string btnAdd_Click()
        {
            if (!TModel.Role.IsAdmin)
            {
                return "您没有权限";
            }
            Model.Member model = BllModel.GetModel(Request.Form["txtMID"]);
            if (model == null)
            {
                return "会员帐号不存在";
            }
            string moneyType = "MHB";
            switch (Request.Form["kfType"])
            {
                case "MJB":
                    moneyType = "MJB";
                    break;
                case "MHB":
                    moneyType = "MHB";
                    break;
                default:
                    return "参数异常";
            }

            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                int money = int.Parse(Request.Form["txtMHB"]);
                if (money > 0)
                {
                    Hashtable MyHs = new Hashtable();
                    BLL.ChangeMoney.HBChangeTran(money, model.MID, BLL.Member.ManageMember.TModel.MID, "KF", null, moneyType, Request.Form["txtRemark"], MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        return "扣费成功";
                    }
                    else
                    {
                        return "扣费失败";
                    }
                }
                else
                {
                    return "扣费金额必须大于0";
                }
            }
            else
            {
                return "参数异常";
            }
        }
    }
}