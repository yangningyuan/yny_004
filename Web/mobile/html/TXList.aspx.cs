using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class TXList : BasePage
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

            listchange = BllModel.GetChangeMoneyEntityList(TModel.MID, BLL.Member.ManageMember.TModel.MID, "", "", new List<string> { "TX" }, new List<string> { "MHB", "MCW" }, CurrentPage, ItemsPerPage, where, out totalCount);

            var list = listchange.Select(item => new
            {

                Money = item.Money,
                sfMoney = (item.Money - item.TakeOffMoney).ToFixedDecimal(2),
                State = item.CState ? "已批准" : "未批准",
                ChangeDate = item.ChangeDate.ToString(),
                cdetails = item.CState ? "" : "<a class=\"button button-fill button-success\" href=\"javascript:delTX(" + item.CID + ")\">删除</a>"

            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

        protected override string btnModify_Click()
        {
            string cid = Request.QueryString["cid"];

            return BLL.ChangeMoney.Cancel_TX(cid, TModel);

        }
    }
}