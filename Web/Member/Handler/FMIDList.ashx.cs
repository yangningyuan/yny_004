using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace yny_004.Web.Member.Handler
{
    /// <summary>
    /// FMIDList 的摘要说明
    /// </summary>
    public class FMIDList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            string strWhere = " RoleCode in (" + RoleCode + ")  ";
            string mkey = "", mtjkey = "";
           
            if (!string.IsNullOrEmpty(context.Request["mBDKey"]))
            {
                strWhere += " and FMID='" + context.Request["mBDKey"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and MState='" + context.Request["tState"] + "' ";
            }
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.Super)
            {
                //if (!string.IsNullOrEmpty(mkey))
                    //mkey = memberModel.MID;
                mtjkey = memberModel.MID;
            }
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and FMID='" + mkey + "' ";
            }
            else {
                strWhere += " and FMID!='' ";
            }
            //if (!string.IsNullOrEmpty(mtjkey))
            //{
            //    strWhere += " and FMID='" + mtjkey + "' ";
            //}

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].Role.RName + "~");
                sb.Append(ListMember[i].FMID + "~");
               
                sb.Append((ListMember[i].MState ? "已激活" : "未激活") + "~");
                if (ListMember[i].MState)
                    sb.Append(ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm"));
                else
                    sb.Append(ListMember[i].MCreateDate.ToString("yyyy-MM-dd HH:mm"));
                //sb.Append("~");
                //sb.Append("<input class=\"btn btn-primary\" value=\"转出货币\" onclick=\"transferForm('" + ListMember[i].MID + "')\" type=\"button\">");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}