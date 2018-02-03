using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace yny_004.Web.Shop.Handler
{
    /// <summary>
    /// HKList 的摘要说明
    /// </summary>
    public class GoodsList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            string state = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                strWhere += " and GParentCode ='" + context.Request["txtKey"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                state = context.Request["tState"];
            }
            int count;
            List<Model.Goods> List = BLL.Goods.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].GID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                Model.GoodCategory cst = BLL.GoodCategory.GetModelByCode(List[i].GParentCode);
                if (cst != null)
                    sb.Append(cst.Name + "~");
                else
                    sb.Append(List[i].GParentCode + "~");

                //if (state == "1")
                //{
                //查询到主图片
                //Model.GoodsPic pic = List[i].GoodsPic.FirstOrDefault(c => c.IsMain == true);
                //if (pic != null)
                sb.Append("<img class='appImg' alt=\"" + List[i].GName + "\" src='" + List[i].ImageAddr + "'/>");
                sb.Append(List[i].GName + "~");
                //}
                //else
                //{
                //    sb.Append(List[i].GName + "~");
                //}

                sb.Append(List[i].CostPrice + "/" + List[i].Unit + "~");
                sb.Append(List[i].SellingCount + "~");
                if (state == "1")
                {
                    sb.Append(List[i].SelledCount + "~");
                    sb.Append("<input type='button' value='详细' class='btn btn-danger btn-small' onclick='lookMoreInfo(" + List[i].GID + ")'/>");
                    sb.Append("≌");
                }
                else
                {
                    sb.Append(List[i].SelledCount);
                    sb.Append("≌");
                }

            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}