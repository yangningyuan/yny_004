using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Web.Common
{
    /// <summary>
    /// DeleteFile 的摘要说明
    /// </summary>
    public class DeleteUPFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["path"]))
            {
                string delFile = HttpContext.Current.Server.MapPath("../Attachment/ImportExcel/") + context.Request.QueryString["path"];
                if (File.Exists(delFile))
                {
                    try
                    {
                        File.Delete(delFile);
                        context.Response.Write("1");//删除成功
                    }
                    catch
                    {
                        context.Response.Write("-1");//删除失败
                    }
                }
                else
                {
                    context.Response.Write("0");//不存在
                }
            }
            else
                context.Response.Write("-2");//参数错误
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}