using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Data;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// JJList 的摘要说明
    /// </summary>
    public class JJJLList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MCW" };
            string strWhere = " and '1'='1' and CState = 1 ";
            string TypeLength = "100";
            string mKey = "";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                cTypeList = new List<string>(types.Split('|'));
            }
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                mKey = context.Request["txtKey"];
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
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                TypeLength = context.Request["tState"];
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
                mKey = memberModel.MID;

            if (!string.IsNullOrEmpty(mKey))
            {
                strWhere += " and tomid='" + mKey + "' ";
            }

            StringBuilder sqlstr = new StringBuilder("select tomid,");
            foreach (string CType in cTypeList)
            {
                sqlstr.AppendFormat("sum(case when changetype='{0}' then money else 0 end) as '{0}',", CType);
            }
            sqlstr.Append("sum(TakeOffMoney) as 'Take',");
            sqlstr.Append("sum(ReBuyMoney) as 'ReBuy',");
            sqlstr.Append("sum(MCWMoney) as 'MCW',");
            sqlstr.Append("sum(money) as 'HeJi',");
            sqlstr.Append("sum(money-TakeOffMoney-ReBuyMoney-MCWMoney) as 'JJ'");
            sqlstr.AppendFormat(",CONVERT(varchar(" + TypeLength + "), changedate, 23) as 'Date' from changemoney a where ");
            sqlstr.AppendFormat(" changetype in ('{0}') ", String.Join("','", cTypeList.ToArray()));
            sqlstr.Append(strWhere);
            sqlstr.Append("group by CONVERT(varchar(" + TypeLength + "), changedate, 23),tomid order by CONVERT(varchar(" + TypeLength + "), changedate, 23) desc");
            DataTable table = BLL.CommonBase.GetTable(sqlstr.ToString());

            StringBuilder sb = new StringBuilder();
            decimal[] heji = new decimal[cTypeList.Count + 4];
            for (int i = (pageIndex - 1) * pageSize; i < table.Rows.Count && i < pageSize * (pageIndex); i++)
            {
                Model.Member member = BllModel.GetModel(table.Rows[i]["ToMID"].ToString());
                sb.Append(i + 1 + "~");
                sb.Append(i + 1 + "~");
                //if (TModel.Role.Super)
                //{
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('ChangeMoney/JJJLList.aspx?id=" + member.MID + "');\">" + member.MID + "</a>~");
                //sb.Append(member.MName + "~");
                sb.Append(member.MAgencyType.MAgencyName + "~");
                //}
                int j = 0;
                for (; j < cTypeList.Count; j++)
                {
                    sb.Append(Convert.ToDecimal(table.Rows[i][cTypeList[j]]).ToFixedDecimal() + "~");
                    heji[j] += Convert.ToDecimal(table.Rows[i][cTypeList[j]]);
                }
                //sb.Append(table.Rows[i]["MCW"] + "~");
                //sb.Append(Convert.ToDecimal(table.Rows[i]["ReBuy"]).ToFixedDecimal() + "~");
                //heji[j++] += Convert.ToDecimal("-" + table.Rows[i]["ReBuy"]);
                //heji[j++] += Convert.ToDecimal("-" + table.Rows[i]["Take"]);
                //sb.Append(Convert.ToDecimal(table.Rows[i]["Take"]).ToFixedDecimal() + "~");

                //heji[j++] += Convert.ToDecimal(table.Rows[i]["HeJi"]);
                sb.Append(Convert.ToDecimal(table.Rows[i]["HeJi"]).ToFixedDecimal() + "~");

                //sb.Append(Convert.ToDecimal(table.Rows[i]["JJ"]).ToFixedDecimal() + "~");//MHB
                //sb.Append(Convert.ToDecimal(table.Rows[i]["Take"]).ToFixedDecimal() + "~");//MJB
                //sb.Append(Convert.ToDecimal(table.Rows[i]["ReBuy"]).ToFixedDecimal() + "~");//MCW
                //sb.Append(Convert.ToDecimal(table.Rows[i]["MCW"]).ToFixedDecimal() + "~");//MGP

                //sb.Append(Convert.ToDecimal(table.Rows[i]["JJ"]).ToFixedDecimal() + "~");
                heji[j++] += Convert.ToDecimal(table.Rows[i]["JJ"]);
                sb.Append(table.Rows[i]["Date"]);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = table.Rows.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}