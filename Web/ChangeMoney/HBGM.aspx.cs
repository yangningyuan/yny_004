using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.ChangeMoney
{
    public partial class HBGM : BasePage
    {
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
                    if (Request.Form["rdo"] == "MJB")
                        MType = "MJB";
                    if (BLL.ChangeMoney.EnoughChange(TModel.MID, int.Parse(Request.Form["txtMHB"]), MType))
                    {
                        Hashtable MyHs = new Hashtable();
                        BLL.ChangeMoney.CZMoneyChange(TModel.MID, Request.Form["txtMID"], int.Parse(Request.Form["txtMHB"]), MType, MyHs);
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_CZ, "充值[" + Request.Form["txtMID"] + "][" + MType + "][" + Request.Form["txtMHB"] + "]");
                            return "成功";
                        }
                        return "失败";
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