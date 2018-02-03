using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using CommonBLL;
using Newtonsoft.Json;

namespace yny_004.Web.SysManage.Language.Handler
{
    /// <summary>
    /// LanguageTypeList 的摘要说明
    /// </summary>
    public class LanguageTypeList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1'  ";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))//按照英文查询
            {
                strWhere += " and Name like '%" + context.Request["mKey"] + "%'";
            }
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))//按照中文查询
            {
                strWhere += " and Code like '%" + context.Request["txtKey"] + "%'";
            }
            int count = 0;
            StringBuilder sb = new StringBuilder();
            List<CommonModel.Sys_LanguageType> ListChangeMoney;
            ListChangeMoney = Sys_LanguageTypeBLL.GetList(strWhere, pageIndex, pageSize, out count);

            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                sb.Append(ListChangeMoney[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListChangeMoney[i].Code + "~");
                sb.Append(ListChangeMoney[i].Name + "~");
                sb.AppendFormat("<img alt=\"{0}\" src=\"{1}\" style=\"width:38px; height:24px;\" />~", ListChangeMoney[i].Name, ListChangeMoney[i].ImgUrl);
                sb.Append((ListChangeMoney[i].Status ? "已生效" : "未生效"));
                sb.Append("≌");
            }

            var info = new { PageData = sb.ToString(), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}