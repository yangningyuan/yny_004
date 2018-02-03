using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class HKList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 and mid='"+TModel.MID+"' ";
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
            
            List<Model.HKModel> listchange = BLL.HKModel.GetList(where, CurrentPage, ItemsPerPage, out totalCount);
            var list = listchange.Select(item => new
            {

                MoneyType = item.HKTypeStr,
                Money = item.RealMoney,
                State = item.HKState?"已生效":"未生效",
                Date = item.HKCreateDate.ToString(),
                Type= item.IsAuto ? "在线充值" : "人工汇款"

        });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}