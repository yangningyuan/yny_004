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
    public class MyTJBDList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            string strWhere = " RoleCode in (" + RoleCode + ")";
            strWhere += " and '1'='1' ";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "001")
                {
                    strWhere += " and AgencyCode='" + context.Request["tState"] + "' and MTJ='" + memberModel.MID + "' ";
                }
                else
                {
                    strWhere += " and AgencyCode<>'001' and MTJ='" + memberModel.MID + "' ";
                }
            }

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                sb.Append(ListMember[i].NewSHMoney.NName + "~");
                sb.Append(ListMember[i].QQ + "~");
                //sb.Append(ListMember[i].Email + "~");
                sb.Append(ListMember[i].Tel + "~");
                sb.Append(ListMember[i].MCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(ListMember[i].MDate.Year == DateTime.MaxValue.Year ? "未升级" : ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}