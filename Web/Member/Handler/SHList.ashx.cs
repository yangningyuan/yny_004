using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// SHList 的摘要说明
    /// </summary>
    public class SHList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            string strWhere = "RoleCode in (" + RoleCode + ")";

            string sh = " and AgencyCode='001' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                {
                    sh = " and AgencyCode<>'001' ";

                    if (!TModel.Role.Super)
                    {
                        sh += " and MSH = '" + TModel.MID + "'";
                    }
                }
                else
                {
                    sh = " and AgencyCode='001' ";
                }
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and MCreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and MCreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrWhiteSpace(context.Request["ddlRegion"]))
            {
                strWhere += " and Country = ('" + context.Request["ddlRegion"] + "') ";
            }
            if (!string.IsNullOrWhiteSpace(context.Request["ddlProvince"]))
            {
                strWhere += " and Province = ('" + context.Request["ddlProvince"] + "') ";
            }
            if (!string.IsNullOrWhiteSpace(context.Request["ddlCity"]))
            {
                strWhere += " and City = ('" + context.Request["ddlCity"] + "') ";
            }
            if (!string.IsNullOrWhiteSpace(context.Request["ddlZone"]))
            {
                strWhere += " and Zone = ('" + context.Request["ddlZone"] + "') ";
            }
            //strWhere += " and RegistAgency = 0 ";

            //Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!TModel.Role.Super)
                strWhere += string.Format(" and MSH='{0}' ", TModel.MID);
            else
            {
                if (!string.IsNullOrEmpty(context.Request["mSHKey"]))
                {
                    strWhere += string.Format(" and MSH='{0}' ", context.Request["mSHKey"]);
                }
            }

            //if (!TModel.Role.Super)
            //{
            //    strWhere += " and MID in (select * from dbo.GetAllSubBDMember('" + TModel.MID + "'))";
            //}

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere + sh, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].Tel + "~");
                //sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                sb.Append(ListMember[i].MTJ + "~");
                //sb.Append((ListMember[i].MState ? ListMember[i].MSH : "") + "~");
                //sb.Append(ListMember[i].MSH + "~");
                sb.Append(ListMember[i].NumID + "~");
                if (!string.IsNullOrEmpty(ListMember[i].Address))
                {
                    foreach (var pic in ListMember[i].Address.Split('≌'))
                    {
                        if (!string.IsNullOrEmpty(pic))
                        {
                            sb.Append("<a href=\"" + pic + "\" target=\"_blank\"><img alt=\"图片\" src=\"" + pic + "\" style=\"width: 60px;height: 60px\" /></a>");
                        }
                    }
                }
                sb.Append("~");
                sb.Append((ListMember[i].MState ? "已审核" : "未审核") + "~");
                sb.Append(ListMember[i].MDate.Year == DateTime.MaxValue.Year ? ListMember[i].MCreateDate.ToString("yyyy-MM-dd HH:mm") : ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}