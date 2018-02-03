using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.ChangeMoney
{
    public partial class JJJLList : BasePage
    {
        protected string list = "";
        protected string titles = "";
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "";
            foreach (KeyValuePair<string, Model.Reward> item in BLL.Reward.List)
            {
                if (item.Value.NeedProcess)
                {
                    list += item.Value.RewardType + "|";
                    titles += item.Value.RewardName + "|";
                }
            }
        }

        protected override void SetValue(string id)
        {
            txtKey.Value = id;
        }
    }
}