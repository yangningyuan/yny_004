using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class TaskList : BasePage
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

            string state = Request.Form["state"];
            if (!string.IsNullOrEmpty(state))
            {
                if (state == "FJ")
                {
                    where += " and TFromMID='" + TModel.MID + "' ";
                }
                else
                {
                    where += " and TToMID='"+TModel.MID+"' ";
                }
            }
            else {
                where += " and TFromMID='" + TModel.MID + "' ";
            }

            mkey = TModel.MID;
            //if (!string.IsNullOrEmpty(Request["begin_time"]))
            //{
            //    where += " and ChangeDate>'" + Request["begin_time"] + " 00:00:00' ";
            //}
            //if (!string.IsNullOrEmpty(Request["end_time"]))
            //{
            //    where += " and ChangeDate<'" + Request["end_time"] + " 23:59:59' ";
            //}
            
            List<Model.Task> listchange = BllModel.GetTaskEntityList(where, CurrentPage, ItemsPerPage, out totalCount);

            var list = listchange.Select(item => new
            {
                content = item.TContent,
                //type = item.TTypeStr,
                date = item.TDateTime.ToString()
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}