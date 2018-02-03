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
    /// MemberList 的摘要说明
    /// </summary>
    public class GrantPowers : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            pageSize = 200;
            string strWhere = "";
            string mType = "";
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                mType = context.Request["txtKey"];
            }
            else
                return;
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and Contents.CTitle like '%" + context.Request["startDate"] + "%' ";
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (bool.Parse(context.Request["tState"]))
                    strWhere += " and RType is not null";
                else
                    strWhere += " and RType is null";
            }

            DataTable ListContents = BllModel.GetPowers(strWhere, mType);

            StringBuilder sb = new StringBuilder();

            for (int i = (pageIndex - 1) * pageSize; i < pageIndex * pageSize && i < ListContents.Rows.Count; i++)
            {
                sb.Append(ListContents.Rows[i]["CID"].ToString() + "~");
                sb.Append(i + 1 + "~");
                sb.Append(ListContents.Rows[i]["CID"].ToString() + "~");
                sb.Append(ListContents.Rows[i]["CTitle"].ToString() + "~");
                if (!string.IsNullOrEmpty(ListContents.Rows[i]["RType"].ToString()))
                    sb.Append("<span style='color:Blue;'>已授权</span>#T" + "~");
                else
                    sb.Append("<span style='color:Red;'>未授权</span>" + "~");

                //sb.Append(Convert.ToBoolean(ListContents.Rows[i]["IsQuickMenu"]) ? "<span style='color:Blue;'>是</span>~" : "<span style='color:Red;'>否</span>~");
                //sb.Append("<i class='fa "+ListContents.Rows[i]["CImage"]+"'></i>" + "~");
                sb.Append("<a href='javascript:void(0)' onclick=\"callhtml('SysManage/MenuEdit.aspx?Id=" + ListContents.Rows[i]["CID"] + "','菜单编辑')\">修改</a>");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = 0 };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}