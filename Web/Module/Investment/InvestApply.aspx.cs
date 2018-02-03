using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Module.Investment
{
    public partial class InvestApply : BasePage
    {
        protected override void SetPowerZone()
        {
            bankauto.Value = string.IsNullOrEmpty(TModel.BankNumber) ? "0" : "1";
        }
        protected override string btnAdd_Click()
        {
            string error = GetBank(TModel);
            if (!string.IsNullOrEmpty(error))
            {
                return "请先完善资料";
            }
            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                Hashtable MyHs = new Hashtable();
                decimal money = 0;
                try
                {
                    money = decimal.Parse(Request.Form["txtMHB"]);
                }
                catch
                {
                    return "投资金额格式不正确";
                }


                string bz = Request.Form["rdo"];

                if (money % BLL.Configuration.Model.E_TZBase != 0 || money < BLL.Configuration.Model.E_TZMin || money > BLL.Configuration.Model.E_TZMax)
                {
                    return string.Format("投资范围为{0}-{1},并且必须为{2}的倍数", BLL.Configuration.Model.E_TZMin, BLL.Configuration.Model.E_TZMax, BLL.Configuration.Model.E_TZBase);
                }

                return BLL.LuckyMoney.InvestApply(TModel.MID, money);
            }
            else
            {
                return "投资金额不能为空";
            }
        }
    }
}