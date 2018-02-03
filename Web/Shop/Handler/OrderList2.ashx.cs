using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace yny_004.Web.Shop.Handler
{
    /// <summary>
    /// OrderList2 的摘要说明
    /// </summary>
    public class OrderList2 : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string strWhere = " IsDeleted=0 ";
            if (!memberModel.Role.IsAdmin)
            {
                strWhere += " and MID='" + memberModel.MID + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and Status = " + context.Request["tState"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                if (memberModel.Role.IsAdmin)
                {
                    strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
                }
                else
                {
                    strWhere += " and MID='" + memberModel.MID + "'";
                }
            }
            else
            {
                if (!memberModel.Role.IsAdmin)
                {
                    strWhere += " and MID='" + memberModel.MID + "'";
                }

            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and CreatedTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and CreatedTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }


            int count;
            List<Model.Order> List = BLL.Order.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].Code + "~");
                sb.Append(List[i].MID + "~");
                Model.Member member= BLL.Member.GetModelByMID(List[i].MID);
                if (member != null)
                {
                    sb.Append(member.MCreateDate.ToString() + "~");
                }
                else
                {
                    sb.Append("~");
                }

                sb.Append(List[i].TotalPrice + "~");
                
                string strgoods = "";
                List<Model.OrderDetail> listdetail = BLL.OrderDetail.GetList(" OrderCode='" + List[i].Code + "';");
                foreach (Model.OrderDetail item in listdetail)
                {
                    Model.Goods gs = BLL.Goods.GetModel(item.GId);
                    if (gs != null)
                    {
                        strgoods += gs.GName + "&nbsp;&nbsp;&nbsp;" + item.GCount + gs.Unit + ";<br/>";
                    }
                }
                sb.Append(strgoods + "~");
                sb.Append(List[i].GoodCount + "~");
                sb.Append(List[i].OrderTime.ToString("yyyy-MM-dd HH:mm") + "~");

                Model.ReceiveInfo rece = BLL.ReceiveInfo.GetModel(List[i].ReceiveId);
                if (rece != null)
                {
                    sb.Append("收货人:" + rece.Receiver + ";电话:" + rece.Phone + ";<br/>地址:" + rece.DetailAddress + ";" + "~");
                }
                else
                {
                    sb.Append("~");
                }


                int status = List[i].Status;
                string resu = string.Empty;
                switch (status)
                {
                    case 1:
                        resu = "已提交未付款~";
                        if (List[i].MID == memberModel.MID)
                        {
                            resu += "<input type='button' value='付款' class='btn btn-success btn-sm' onclick='payOrder(" + List[i].Id + ")' />";
                        }
                        if (TModel.Role.IsAdmin)
                            resu += "<input type='button' value='删除' class='btn btn-success btn-sm' onclick=\"v5.confirm('是否删除此订单？',function(){delOrder('" + List[i].Id + "')},true)\" />";
                        break;
                    case 2:
                        resu = "已付款未发货~";
                        if (memberModel.Role.IsAdmin)
                        {
                            resu += "<input type='button' value='发货' class='btn btn-success btn-sm' onclick='sendOrder(" + List[i].Id + ")' />";

                            resu += "<input type='button' value='删除' class='btn btn-success btn-sm' onclick=\"v5.confirm('是否删除此订单？',function(){delOrder('" + List[i].Id + "')},true)\" />";
                        }
                        break;
                    case 3:
                        resu = "已发货&nbsp;&nbsp;<span class='seeExpress' onclick='seeExpress(" + List[i].Id + ")'>查看物流</span>~";
                        if (List[i].MID == memberModel.MID)
                        {
                            resu += "<input type='button' value='确认收货' class='btn btn-success btn-sm' onclick='receiveOrder(" + List[i].Id + ")' />";
                        }
                        break;
                    case 4:
                        resu = "已完成~";
                        break;
                }
                sb.Append(resu);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}