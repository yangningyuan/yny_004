using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.ChangeMoney
{
    public partial class HBChange : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                txtFromMID.Value = TModel.MID;
                txtFromMID.Attributes.Add("readonly", "readonly");
                if (!TModel.MConfig.ZZStatus)
                {
                    //不能提现
                    btnOK.Visible = false;
                }
                else
                {
                    divTips.Visible = false;
                }
            }
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            string MType = "MHB";
            //MType = Request.Form["RioHK"];
            //if (MType == "MJB")
            //{
            //    MType = "MJB";
            //}
            //else if (MType == "MHB")
            //{
            //    MType = "MHB";
            //}
            //else
            //{
            //    return "转账币种错误";
            //}
            Model.Member fmodel = null;
            Model.Member tmodel = null;
            if (!TModel.Role.Super)
                fmodel = TModel;
            else
                fmodel = BllModel.GetModel(Request.Form["txtFromMID"]);
            tmodel = BllModel.GetModel(Request.Form["txtMID"]);
            //if (MType == "MHB")
            //{
            //    if (tmodel.AgencyCode != "003" && tmodel.AgencyCode != "004" && tmodel.AgencyCode != "005" && tmodel.AgencyCode != "006")
            //    {
            //        return "奖金币只能转给领导人";
            //    }
            //}

            if (fmodel == null || tmodel == null)
            {
                return "转入或转出会员不存在！";
            }
            if (fmodel.IsClock)
            {
                return "转出会员账户冻结,不能转账";
            }
            if (tmodel.IsClock)
            {
                return "转入会员账户冻结,不能转账";
            }
            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                int money = int.Parse(Request.Form["txtMHB"]);
                return BLL.ChangeMoney.ZZMoneyChange(money, fmodel.MID, Request.Form["txtMID"], "ZZ", MType);
            }
            else
            {
                return "转账金额不能为空";
            }
        }
    }
}