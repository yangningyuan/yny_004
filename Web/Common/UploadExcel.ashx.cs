using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Data;


namespace Web.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class UploadExcel : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            //*******************************************
            //文件上传并保存
            HttpPostedFile file = context.Request.Files["Filedata"];
            string name = string.Empty;
            string uploadPath = string.Empty;
            if (file != null)
            {
                //string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                name = file.FileName;
                //如果上传的是图片，就是需要保存到logo文件夹中的
                string type = name.Substring(name.LastIndexOf('.')).ToLower();
                string filename = name.Substring(0, name.LastIndexOf('.'));
                filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();

                string typeXls = context.Request.QueryString["t"];
                if (!string.IsNullOrEmpty(typeXls) && typeXls == "xls")//上传的Excel文件
                {
                    uploadPath = HttpContext.Current.Server.MapPath("../Attachment/ImportExcel/");
                }
                else
                {
                    if (type == ".jpg" || type == ".jpeg" || type == ".gif" || type == ".png" || type == ".swf" || type == ".ico")
                        uploadPath = HttpContext.Current.Server.MapPath("../Attachment/");
                    else
                        uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\Attachment\\";
                }


                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + filename + type);
                context.Response.Write(filename + type);
            }
            else
            {
                context.Response.Write("0");
            }
            //***************************************
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
