using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// TXList 的摘要说明
    /// </summary>
    public class GMList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mKey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
                mKey = memberModel.MID;
            if (!string.IsNullOrEmpty(mKey))
            {
                strWhere += " and (ToMID='" + mKey + "' or ToMName like '%" + mKey + "%') ";
            }
            int count = 0;
            StringBuilder sb = new StringBuilder();
            List<Model.ChangeMoney> ListChangeMoney;
            if (!TModel.Role.Super)
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList("", TModel.MID, "", "true", new List<string> { "CZ" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, pageIndex, pageSize, strWhere, out count);
            }
            else
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList("", mKey, "", "true", new List<string> { "CZ" }, new List<string> { "MHB", "MJB", "MGP", "MCW", "TotalYFHMoney" }, pageIndex, pageSize, strWhere, out count);
            }

            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                if (member == null)
                    continue;
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(member.MID + "~");
                sb.Append(member.MName + "~");
                sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].MoneyTypeStr + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }

            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}