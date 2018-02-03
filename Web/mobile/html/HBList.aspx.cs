using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class HBList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1  ";
            //string where = string.Format(" MID = '{0}'   ", TModel.MID);
            //var txtCode = Request["txtCode"];
            //if (!string.IsNullOrEmpty(txtCode))
            //{
            //    where += string.Format(" and Code = '{0}'", txtCode);
            //}
            string mkeyfrom = "";
            string mkeyto = "";

            string state = Request.Form["state"];
            if (!string.IsNullOrEmpty(state))
            {
                if (state == "ZC")
                {
                    where += " and FromMID='" + TModel.MID + "' AND CHANGETYPE='ZZ' ";
                    mkeyfrom = TModel.MID;
                }
                else if (state == "ZR")
                {
                    where += " and ToMID='" + TModel.MID + "' AND CHANGETYPE='ZZ' ";
                    mkeyto = TModel.MID;
                }
                else {
                    where += " and FromMID='" + TModel.MID + "' AND CHANGETYPE='DH' ";
                    mkeyfrom = TModel.MID;
                }
            }
            else {
                where += " and FromMID='" + TModel.MID + "' ";
                mkeyfrom = TModel.MID;
            }
            List<Model.ChangeMoney> listchange = null;
            listchange = BllModel.GetChangeMoneyEntityList(mkeyfrom, mkeyto, "", "true", new List<string> { "ZZ","DH" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, CurrentPage, ItemsPerPage, where, out totalCount);
            var list = listchange.Select(item => new
            {
                MID=!string.IsNullOrEmpty(mkeyfrom)?item.ToMID:item.FromMID,
                Money = item.Money,
                MoneyType = item.MoneyTypeStr,
                ChangeDate = item.ChangeDate.ToString()
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}