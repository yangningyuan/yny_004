using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

namespace yny_004.Web.Member
{
    public partial class TJList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "<input name='txtKey' id='mTJKey' value='" + TModel.MID + "' style='display:none;' />";
            }
        }

        protected override string btnModify_Click()
        {
            var txtFromMID = Request.GetData("txtFromMID");
            Model.Member member = BLL.Member.GetModelByMID(txtFromMID);
            if (member == null)
            {
                return "转出会员不存在";
            }
            if (!TModel.Role.IsAdmin && TModel.MID != member.MTJ)
            {
                return "您没有权限对该会员操作";
            }
            string txtCurrencyType = Request.GetData("txtCurrencyType");
            if (txtCurrencyType != "MHB" && txtCurrencyType != "MJB" && txtCurrencyType != "MCW")
            {
                return "货币类型错误";
            }
            var txtMoney = Request.GetData("txtMoney");
            int money;
            if (!int.TryParse(txtMoney, out money))
            {
                return "转出金额错误";
            }
            var txtThrPwd = Request.GetData("txtThrPwd");
            if (string.IsNullOrEmpty(txtThrPwd))
            {
                return "资金密码不能为空";
            }
            if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(txtThrPwd + member.Salt, "MD5").ToUpper() != member.SecPsd)
            {
                return "转出会员的资金密码不正确";
            }

            return BLL.ChangeMoney.ZZMoneyChange(money, txtFromMID, TModel.MID, "ZZ", txtCurrencyType);
        }
    }
}