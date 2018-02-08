using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Member
{
    public partial class View : BasePage
    {
        protected override void SetPowerZone()
        {
            Model.Member model = TModel;
            MemberMode = model;
        }

        public Model.Member MemberMode
        {
            set
            {
                if (value != null)
                {
                    lbBank.Text = value.Bank;
                    lbBankCardName.Text = value.BankCardName;
                    lbBankNumber.Text = value.BankNumber;
                    lbBranch.Text = value.Branch;
                }
            }
        }

        public string ChangeString(string str)
        {
            return str.Replace("会员", "");
        }

        object obj = new object();
        protected override string btnOther_Click()
        {
            lock (obj)
            {
                Model.ChangeMoney cm = BLL.ChangeMoney.GetModel(int.Parse(Request.Form["countdate"]));
                if (cm != null && cm.CState == false)
                {
                    if (cm.ToMID != TModel.MID)
                    {
                        return "越权";
                    }
                    Hashtable MyHs = new Hashtable();
                    BLL.ChangeMoney.JDChangeTran(cm,MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                        return cm.Money.ToString();
                    else
                        return "出错啦...";
                }
                else {
                    return "已拆";
                }
            }
           
        }
    }
}