using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace yny_004.Web.ChangeMoney.Handler
{
    /// <summary>
    /// KFList 的摘要说明
    /// </summary>
    public class KFList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
                mkey = memberModel.MID;
            int count;
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", "", new List<string> { "KF" }, new List<string> { "MHB", "MJB", "MGP" }, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                //Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListChangeMoney[i].FromMID + "~");
                sb.Append("" + ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(ListChangeMoney[i].CRemarks);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}