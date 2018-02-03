using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class InvestList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = "  isvalid < 4 and MID='" + TModel.MID + "' ";

            string mkey = "";
            mkey = TModel.MID;

            List<Model.LuckyMoney> listchange = null;

            listchange = BLL.LuckyMoney.GetLuckyMoneyEntityList(where, CurrentPage, ItemsPerPage, out totalCount);

            var list = listchange.Select(item => new
            {
                Money = item.ApplyMoney,
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
                if (luck.Type == 0)
                {
                    return "<a class=\"button button-fill button-success\" href=\"javascript:layer.confirm('确定退本吗？', {btn: ['确定', '再想想']}, function () {InvestOperate('quit'," + luck.ID + ");}, function () {});\">退本</a>";
                }
                else
                {
                    return "有效";
                }
            }
            else if (luck.isValid == 1)
            {
                return "审核中";
            }
            else if (luck.isValid == 2)
            {
                return "已退本";
            }
            else if (luck.isValid == 3)
            {
                return "已失效";
            }
            else {
                return "异常单";
            }
        }
    }
}