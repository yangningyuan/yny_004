using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class InvestQuitList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = "  isvalid > 0 and MID='" + TModel.MID + "' ";

            string mkey = "";
            mkey = TModel.MID;

            List<Model.LuckyMoney> listchange = null;

            listchange = BLL.LuckyMoney.GetLuckyMoneyEntityListQ(where, CurrentPage, ItemsPerPage, out totalCount);

            var list = listchange.Select(item => new
            {
                Money = item.ApplyMoney,
                sstb= (item.ApplyMoney - item.TakeOffmoney).ToFixedString(),
                DayCount = item.FHTimes,
                LJMoney = item.TotalMoney,
                Date = item.CreateTime.ToString(),
                dhtml = html(item)
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
        protected string html(Model.LuckyMoney luck)
        {

            if (luck.isValid == 0)
            {
                    return "有效";
            }
            else if (luck.isValid == 1)
            {
                return "审核中";
            }
            else if (luck.isValid == 2)
            {
                return "已退本";
            }
            else 
            {
                return "异常单";
            }
            
        }
    }
}