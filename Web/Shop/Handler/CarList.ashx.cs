using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace yny_004.Web.Shop.Handler
{
    /// <summary>
    /// CarList 的摘要说明
    /// </summary>
    public class CarList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string strWhere = " IsDeleted=0 and MID='" + memberModel.MID + "'  and Status=1";
            int count;
            List<Model.ShopCar> List = BLL.ShopCar.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                Model.Goods good = BLL.Goods.GetModel(List[i].GId);
                if (good != null)
                {
                    sb.Append("<img class='appImg' alt=\"" + good.GName + "\"  src='" + good.ImageAddr + "'/>");
                    sb.Append(good.GName + "<input type='hidden' value='" + List[i].Id + "' class='hidCId'/> ~");
                    sb.Append("<span class='spSprice'>" + good.CostPrice + "</span>/" + good.Unit + "~");

                    string str = @"<span class='goodNum numDesc' onclick='numDesc(this)'>&nbsp;-&nbsp;</span><input type='text' class='numVal' readonly='readonly' value='" + List[i].GCount + "'/> <span class='goodNum numAsc' onclick='numAsc(this)'>&nbsp;+&nbsp;</span>";

                    sb.Append(str + "~");
                    sb.Append("<span class='spTotal'>" + List[i].GCount * good.CostPrice + "</span>~");
                    sb.Append(good.SellingCount);
                    sb.Append("≌");
                }
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}