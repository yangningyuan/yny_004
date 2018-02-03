using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class OrderList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = string.Format(" MID = '{0}'   ", TModel.MID);

            string tState = Request["state"];
            if (!string.IsNullOrEmpty(tState))
            {
                where += " and Status = " + tState;
            }

            if (!string.IsNullOrEmpty(Request["begin_time"]))
            {
                where += " and SQDate>'" + Request["begin_time"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(Request["end_time"]))
            {
                where += " and SQDate<'" + Request["end_time"] + " 23:59:59' ";
            }
            var list = BLL.Order.GetList(where, CurrentPage, ItemsPerPage, out totalCount).Select(item => new
            {
                ID = item.Id,
                Code = item.Code,
                MID = item.MID,
                Money = item.TotalPrice,
                GCount = item.GoodCount,
                Date = item.OrderTime.ToString("yyyy-MM-dd HH:mm:ss"),
                State = item.Status.ToString().Replace("1", "未付款").Replace("2", "未发货").Replace("3", "已发货").Replace("4", "已完成"),
                wuliutype = item.ExpressCompany,
                wuliucode = item.ExpressCode,
                op = getStringCZ(item)
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

        private string getStringCZ(Model.Order offer)
        {
            string op = "";
            if (offer.Status == 1)
            {
                if (offer.MID == TModel.MID)
                {
                    op += "<a href='javascript:void(0)'  class='xiangqing' onclick='payOrder(" + offer.Id + ")' >付款</a>";
                }
            }
            if (offer.Status == 3)
            {
                op += "<a style='color:green;' href='javascript:wuliu(\"快递公司："+offer.ExpressCompany+"<br/>快递单号："+offer.ExpressCode+"\");'>查看物流</a>";
                if (offer.MID == TModel.MID)
                {
                    op += "<br/><a href='javascript:void(0)'  class='del_xiangqing' onclick='receiveOrder(" + offer.Id + ")'>确认收货</a>";
                }
            }
            if (offer.Status == 4)
            {
                op += "已完成";
            }

            return op;
        }
    }
}