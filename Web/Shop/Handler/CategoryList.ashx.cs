using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace yny_004.Web.Shop.Handler
{
    /// <summary>
    /// CategoryList 的摘要说明
    /// </summary>
    public class CategoryList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string strWhere = " IsDeleted=0 ";
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                strWhere += " and Name like '%" + context.Request["txtKey"] + "%'";
            }
            int count;
            List<Model.GoodCategory> List = BLL.GoodCategory.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                //sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].Code + "~");
                sb.Append(List[i].Name);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}