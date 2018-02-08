﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class LuckTJList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " '1'='1' ";

            string mkey = "";
            mkey = TModel.MID;
            string shmid = "";
            List<string> cTypeList = new List<string> {  "R_TJ" };
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MCW" };

            if (!string.IsNullOrEmpty(Request["begin_time"]))
            {
                where += " and ChangeDate>'" + Request["begin_time"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(Request["end_time"]))
            {
                where += " and ChangeDate<'" + Request["end_time"] + " 23:59:59' ";
            }


            List<Model.ChangeMoney> listchange = null;
            listchange = BllModel.GetChangeMoneyEntityList(BLL.Member.ManageMember.TModel.MID, TModel.MID, shmid, "", cTypeList, mTypeList, CurrentPage, ItemsPerPage, where, out totalCount);
            var list = listchange.Select(item => new
            {
                Money = item.Money,
                ChangeType = item.ChangeTypeStr,
                SHMID = item.SHMID,
                ChangeDate = item.ChangeDate.ToString(),
                caozuo=item.CState?"已拆":("<a class=\"button button-fill button-success\" href=\"javascript:jjqhb('"+item.CID+"')\">拆</a>")
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}