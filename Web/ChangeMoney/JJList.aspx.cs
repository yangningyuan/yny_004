using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.ChangeMoney
{
    public partial class JJList : BasePage
    {
        protected List<Model.Reward> list = new List<Model.Reward>();
        protected override void SetPowerZone()
        {
            //if (!TModel.Role.IsAdmin)
            //    DivSearch.InnerHtml = "";
            if (!TModel.Role.IsAdmin)
                DivDelete.InnerHtml = "";

            foreach (KeyValuePair<string, Model.Reward> item in BLL.Reward.List)
            {
                if (item.Value.NeedProcess)
                    list.Add(item.Value);
            }
        }
        protected override void SetValue(string id)
        {
            txtKey.Value = id;
        }
    }
}