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
    /// FHPlan 的摘要说明
    /// </summary>
    public class Finance : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string jjtype = "'";
            foreach (Model.Reward item in BLL.Reward.List.Values)
            {
                if (item.NeedProcess)
                    jjtype += item.RewardType + "','";
            }
            jjtype = jjtype.Substring(0, jjtype.LastIndexOf(",'"));

            string strWhere = " select " +
                            " isnull((select SUM(SHMoney) from MemberConfig where MID in (select ACode from Accounts where AccountsDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59')),0) as 'yj'," +
                            " SUM(case when ChangeType in ('sj','sh') then money else 0 end) 'sj'," +
                            " SUM(case when ChangeType in (" + jjtype + ") then money else 0 end) 'bc'," +
                            " SUM(case when ChangeType in (" + jjtype + ") then MCWMoney else 0 end) 'cw'," +
                            " SUM(case when ChangeType in (" + jjtype + ") then ReBuyMoney else 0 end) 'fx'," +
                            " SUM(case when ChangeType in (" + jjtype + ") then TakeOffMoney else 0 end) 'ks'," +
                            " SUM(case when ChangeType in ('cz') then money else 0 end) 'cz'," +
                            " SUM(case when ChangeType in ('tx') and CState='1' then money else 0 end) 'tx'," +
                            " SUM(case when ChangeType in ('gm') and MoneyType='mcw' then money else 0 end) 'jj'," +
                            " CONVERT(varchar(100), ChangeDate, 23) as 'date' from ChangeMoney a where '1'='1' ";

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            else
            {
                strWhere += " and changedate>'" + DateTime.Now.ToShortDateString() + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            strWhere += " group by CONVERT(varchar(100), ChangeDate, 23) order by CONVERT(varchar(100), ChangeDate, 23) desc ";

            StringBuilder sb = new StringBuilder();
            DataTable table = BLL.CommonBase.GetTable(strWhere);

            int count = pageIndex * pageSize < table.Rows.Count ? pageIndex * pageSize : table.Rows.Count;
            for (int i = (pageIndex - 1) * pageSize; i < count; i++)
            {
                //decimal ks = Convert.ToDecimal(table.Rows[i]["cw"]) + Convert.ToDecimal(table.Rows[i]["fx"]) + Convert.ToDecimal(table.Rows[i]["ks"]);
                sb.Append(i + "~");
                sb.Append((i + 1) + "~");
                sb.Append((Convert.ToDecimal(table.Rows[i]["sj"])).ToFixedDecimal() + "~");
                //sb.Append((Convert.ToDecimal(table.Rows[i]["jj"])) + "~");
                sb.Append(Convert.ToDecimal(table.Rows[i]["cz"]).ToFixedDecimal() + "~");
                sb.Append(Convert.ToDecimal(table.Rows[i]["bc"]).ToFixedDecimal() + "~");
                sb.Append(Convert.ToDecimal(table.Rows[i]["ks"]).ToFixedDecimal() + "~");
                sb.Append(Convert.ToDecimal(table.Rows[i]["fx"]).ToFixedDecimal() + "~");
                //sb.Append(table.Rows[i]["cw"] + "~");
                //sb.Append(table.Rows[i]["fx"] + "~");
                //sb.Append(ks + "~");
                sb.Append(Convert.ToDecimal(table.Rows[i]["tx"]).ToFixedDecimal() + "~");
                if ((Convert.ToDecimal(table.Rows[i]["yj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) > 0)
                    sb.AppendFormat("{0:N2}%~", (Convert.ToDecimal(table.Rows[i]["bc"])) / (Convert.ToDecimal(table.Rows[i]["yj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) * 100);
                else
                    sb.Append("~");
                sb.Append(table.Rows[i]["date"]);
                sb.Append("≌");
            }
            var info = new { PageData = sb.ToString(), TotalCount = table.Rows.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}