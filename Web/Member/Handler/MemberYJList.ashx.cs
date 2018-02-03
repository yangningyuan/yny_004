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
    /// MemberList 的摘要说明
    /// </summary>
    public class MemberYJList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            string strWhere = "MState='1' and RoleCode in (" + RoleCode + ")";
            List<string> typeList = new List<string>();
            List<string> needTakeOff = new List<string>();
            string startDate = "", endDate = "", mKey = "";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                typeList = new List<string>(types.Split('|'));
            }
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                needTakeOff = new List<string>(types.Split('|'));
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", context.Request["mKey"]);
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                startDate = context.Request["startDate"];
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                endDate = context.Request["endDate"];
            }
            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);


            Dictionary<string, decimal> JJInfo;
            StringBuilder sb = new StringBuilder();
            int sumCount = 0; decimal sumMoney = 0;
            for (int i = 0; i < ListMember.Count; i++)
            {
                sumCount = 0; sumMoney = 0;
                JJInfo = BllModel.GetJJInfo(ListMember[i].MID, typeList, needTakeOff, startDate, endDate);
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('ChangeMoney/JJJLList.aspx?id=" + ListMember[i].MID + "');\">" + ListMember[i].MID + "</a>~");
                //sb.Append(ListMember[i].MName + "~");
                sb.Append(GetMemberType(ListMember[i]) + "~");
                foreach (string item in typeList)
                {
                    sb.Append(JJInfo[item + "Money"].ToFixedDecimal() + "~");
                    sumCount += Convert.ToInt32(JJInfo[item + "Count"]);
                    sumMoney += JJInfo[item + "Money"];
                }
                sb.Append("<span style='color:Red;font-weight:bold;'>" + sumMoney.ToFixedDecimal() + "</span>");
                //sb.Append(Convert.ToDecimal(sumMoney - JJInfo["ReBuyMoney"] - JJInfo["MCWMoney"] - JJInfo["TakeOffMoney"]).ToFixedDecimal());
                //sb.Append(Convert.ToDecimal(JJInfo["TakeOffMoney"]).ToFixedDecimal() + "~");
                //sb.Append(Convert.ToDecimal(JJInfo["ReBuyMoney"]).ToFixedDecimal());
                //sb.Append(Convert.ToDecimal(JJInfo["MCWMoney"]).ToFixedDecimal());

                //sb.Append(Convert.ToDecimal(JJInfo["TakeOffMoney"]).ToFixedDecimal() + "~");
                //sb.Append("<span style='color:Red;font-weight:bold;'>" + (sumMoney - JJInfo["TakeOffMoney"] - JJInfo["ReBuyMoney"] - JJInfo["MCWMoney"]).ToFixedDecimal() + "</span>");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}