using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;
using CommonModel;

namespace yny_004.Web.ChangeMoney
{
    public partial class TXChange : BasePage
    {
        protected override void SetPowerZone()
        {
            Model.Member model = TModel;
            if (!TModel.MConfig.TXStatus)
            {
                //不能提现
                Button1.Visible = false;
            }
            else
            {
                divTips.Visible = false;
            }
            //Sys_BankInfoBLL BLL = new Sys_BankInfoBLL();
            //txtBank.DataSource = BLL.GetList(" 1=1 and  IsDeleted=0 order by ID desc");
            //txtBank.DataTextField = "Name";
            //txtBank.DataValueField = "Id";
            //txtBank.DataBind();
        }

        ///// <summary>
        ///// 获取银行
        ///// </summary>
        ///// <param name="member"></param>
        ///// <returns></returns>
        //public string GetBank(Model.Member member)
        //{
        //    string error = "";
        //    member.Bank = Request.Form["txtBank"];
        //    member.BankCardName = Request.Form["txtBankCardName"];
        //    member.BankNumber = Request.Form["txtBankNumber"];
        //    member.Branch = Request.Form["txtBranch"];
        //    if (string.IsNullOrEmpty(member.Bank))
        //    {
        //        error = "开户银行不能为空";
        //    }
        //    else if (string.IsNullOrEmpty(member.BankCardName))
        //    {
        //        error = "开户姓名不能为空";
        //    }
        //    else if (string.IsNullOrEmpty(member.BankNumber))
        //    {
        //        error = "银行卡号不能为空";
        //    }
        //    else if (string.IsNullOrEmpty(member.Branch))
        //    {
        //        error = "开户支行不能为空";
        //    }
        //    else if (member.BankCardName != member.MName)
        //    {
        //        error = "开户姓名必须和会员姓名一直";
        //    }

        //    return error;
        //}

        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            Model.Member model = TModel;
            string error = GetBank(model);
            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }
            string moneyType = "MHB";
            //if (Request.Form["ddlFrom"] == "MHB")
            //{
            //    moneyType = "MHB";
            //}
            //else if (Request.Form["ddlFrom"] == "MCW")
            //{
            //    moneyType = "MCW";
            //}
            
            

            if (model.IsClock)
                return "您已被冻结账户，不可提现或转移";
            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                int money = int.Parse(Request.Form["txtMHB"]);
                if (money > 0)
                {
                    return BLL.ChangeMoney.TXChange(int.Parse(Request.Form["txtMHB"]), model, moneyType);
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

        protected Sys_BankInfo GetBank(string id)
        {
            Sys_BankInfoBLL BLL = new Sys_BankInfoBLL();
            Sys_BankInfo model = BLL.GetModel(id);
            if (model != null)
            {
                return model;
            }
            return new Sys_BankInfo();
        }

        protected Model.BankModel GetBankModel(string mid)
        {
            List<Model.BankModel> list = BLL.BankModel.GetList("MID='" + mid + "' and IsPrimary=1");
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else return null;
        }
    }
}