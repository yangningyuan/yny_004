using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// JJList 的摘要说明
    /// </summary>
    public class JJList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MCW" };
            string mKey = "", shmKey = "", cState = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                cTypeList = new List<string>(types.Split('|'));
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                cState = context.Request["tState"];
            }
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                shmKey = context.Request["txtKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["moneyType"]))
            {
                mTypeList = new List<string> { context.Request["moneyType"] };
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
            {
                mKey = memberModel.MID;
                //cState = "true";
            }
            int count;
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(BLL.Member.ManageMember.TModel.MID, mKey, shmKey, cState, cTypeList, mTypeList, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                if (TModel.Role.Super)
                {
                    sb.Append(member.MID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append(GetMemberType(member) + "~");
                }
                sb.Append(ListChangeMoney[i].Money.ToFixedDecimal() + "~");
                //sb.Append((ListChangeMoney[i].Money - ListChangeMoney[i].ReBuyMoney - ListChangeMoney[i].MCWMoney - ListChangeMoney[i].TakeOffMoney).ToFixedDecimal() + "~");//MHB
                //sb.Append((ListChangeMoney[i].TakeOffMoney).ToFixedDecimal() + "~");//MJB资金池
                //sb.Append((ListChangeMoney[i].ReBuyMoney).ToFixedDecimal() + "~");//MGP红包
                //sb.Append("0.00~");//MJB
                //sb.Append(ListChangeMoney[i].ReBuyMoney.ToFixedDecimal() + "~");//MCW
                //sb.Append(ListChangeMoney[i].MCWMoney.ToFixedDecimal() + "~");//MGP
                //sb.Append((ListChangeMoney[i].Money.ToFixedDecimal() - ListChangeMoney[i].ReBuyMoney.ToFixedDecimal()) + "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney.ToFixedDecimal() + "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney + "~");
                sb.Append(ListChangeMoney[i].ChangeTypeStr + "~");
                string JJsource = (ListChangeMoney[i].ChangeType == "DFH" || ListChangeMoney[i].ChangeType == "PY" || ListChangeMoney[i].ChangeType == "TJ" || ListChangeMoney[i].ChangeType == "DP") ? ListChangeMoney[i].CRemarks + "~" : ListChangeMoney[i].SHMID + "~";
                sb.Append(JJsource);
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}