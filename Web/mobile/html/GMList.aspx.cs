using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class GMList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 ";
            //string where = string.Format(" MID = '{0}'   ", TModel.MID);
            //var txtCode = Request["txtCode"];
            //if (!string.IsNullOrEmpty(txtCode))
            //{
            //    where += string.Format(" and Code = '{0}'", txtCode);
            //}
            string mkey = "";
            mkey = TModel.MID;
            //if (!string.IsNullOrEmpty(Request["begin_time"]))
            //{
            //    where += " and ChangeDate>'" + Request["begin_time"] + " 00:00:00' ";
            //}
            //if (!string.IsNullOrEmpty(Request["end_time"]))
            //{
            //    where += " and ChangeDate<'" + Request["end_time"] + " 23:59:59' ";
            //}
            List<Model.ChangeMoney> listchange = null;

            listchange = BllModel.GetChangeMoneyEntityList("", TModel.MID, "", "true", new List<string> { "CZ" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, CurrentPage, ItemsPerPage, where, out totalCount);

            var list = listchange.Select(item => new
            {

                MID = item.ToMID,
                Money = item.Money,
                MoneyType = item.MoneyTypeStr,
                ChangeDate = item.ChangeDate.ToString()

            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}