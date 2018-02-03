using System;
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
    }
}