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
    public class HBList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string type = "";
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                type = context.Request["tState"];
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
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
                mkey = memberModel.MID;
            int count = 0;
            StringBuilder sb = new StringBuilder();
            List<Model.ChangeMoney> ListChangeMoney;
            if (type == "zc")
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, "", "", "true", new List<string> { "ZZ" }, new List<string> { "MHB", "MJB" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                    Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].ToMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member2.MName + "~");
                    sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                    sb.Append(ListChangeMoney[i].ToMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                    sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                    sb.Append("≌");
                }
            }
            else if (type == "zr")
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList("", mkey, "", "true", new List<string> { "ZZ" }, new List<string> { "MHB", "MJB" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                    Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].ToMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].ToMID + "~");
                    sb.Append(member2.MName + "~");
                    sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                    sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate);
                    sb.Append("≌");
                }
            }
            else if (type == "dh")
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, BLL.Member.ManageMember.TModel.MID, "", "true", new List<string> { "DH" }, new List<string> { "MHB", "MJB" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                    sb.Append(BLL.Reward.List[ListChangeMoney[i].MoneyType].RewardName + "-" + ListChangeMoney[i].CRemarks + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate);
                    sb.Append("≌");
                }
            }
            else
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList(BLL.Member.ManageMember.TModel.MID, mkey, "", "true", new List<string> { "GM" }, new List<string> { "MCW" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].ToMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                    sb.Append((ListChangeMoney[i].CState ? "购买成功" : "购买失败") + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate);
                    sb.Append("≌");
                }
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}