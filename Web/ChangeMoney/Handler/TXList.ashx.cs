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
    public class TXList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            bool state = false;
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                state = bool.Parse(context.Request["tState"]);
            }
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
            if (!string.IsNullOrEmpty(context.Request["ddlCRemarks"]))
            {
                strWhere += " and CRemarks='" + context.Request["ddlCRemarks"] + "' ";
            }
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
                mkey = memberModel.MID;
            int count;
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", state.ToString(), new List<string> { "TX" }, new List<string> { "MHB", "MCW" }, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append("<span id='" + ListChangeMoney[i].CID + "_span'>" + ListChangeMoney[i].FromMID + "</span>~");
                sb.Append(ListChangeMoney[i].FromMID + "~");
                //sb.Append(member.Bank + "~");
                //sb.Append(member.Branch + "~");
                //sb.Append(member.BankCardName + "~");
                //sb.Append(member.BankNumber + "~");
                sb.Append(ListChangeMoney[i].CRemarks + "~");
                sb.Append("" + ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                sb.Append("" + ((ListChangeMoney[i].Money - ListChangeMoney[i].TakeOffMoney-ListChangeMoney[i].ReBuyMoney).ToFixedDecimal()) + "~");
                sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "~");
                //sb.Append("" + ((ListChangeMoney[i].Money.ToFixedDecimal()) * BLL.Configuration.Model.OutFloat).ToFixedDecimal() + "~");
                //sb.Append(ListChangeMoney[i].TakeOffMoney * 6 + "~");
                //sb.Append((ListChangeMoney[i].Money - ListChangeMoney[i].TakeOffMoney) * 6 + "~");
                //sb.Append(ListChangeMoney[i].BeforeChangeFrom + "~");
                //sb.Append(ListChangeMoney[i].EndChangeFrom + "~");
                sb.Append((ListChangeMoney[i].CState ? "已批准" : "未批准") + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}