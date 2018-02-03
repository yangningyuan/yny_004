using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using CommonModel;

namespace yny_004.Web.Language
{
    public partial class List : BasePage
    {
        protected override string btnModify_Click()
        {
            if (ExportExcel())
            {
                return "导入成功";
            }
            else
            {
                return "导出失败";
            }
        }

        //Asp.net 导出EXCEL
        private bool ExportExcel()
        {
            bool flag = true;
            try
            {
                //临时文件
                 //Server.MapPath("../Attachment/ImportExcel/");
                 //string tempFile =  string.Format("{0}/{1}.xls", Server.MapPath("../Attachment/ImportExcel"), Guid.NewGuid());
                 string tempFile = string.Format("{0}/{1}.xls", System.Environment.GetEnvironmentVariable("TEMP"), Guid.NewGuid());
                 //File.Create(tempFile);
                //使用OleDb连接
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + tempFile + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=0;'");
                using (con)
                {
                    con.Open();
                    //创建Sheet
                    OleDbCommand cmdCreate = new OleDbCommand("CREATE TABLE Sheet1 ([中文名称] VarChar,[外文名称] VarChar,[是否可用] VarChar)", con);
                    cmdCreate.ExecuteNonQuery();
                    var list = CommonBLL.Sys_LanguageBLL.GetList("IsDeleted=0 and Status=1  order by LEN(ZHName) desc");

                    foreach (Sys_Language obj in list)
                    {
                        //插入数据
                        OleDbCommand cmd = new OleDbCommand(@"INSERT INTO [Sheet1$] VALUES(@中文名称, @外文名称, @是否可用)", con);
                        cmd.Parameters.AddWithValue("@中文名称", obj.ZHName);
                        cmd.Parameters.AddWithValue("@外文名称", obj.ENName);
                        cmd.Parameters.AddWithValue("@是否可用", obj.Status ? "是" : "否");
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
                con.Dispose();

                Response.ContentType = "application/ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment;filename=info.xls");
                Response.BinaryWrite(File.ReadAllBytes(tempFile));
                File.Delete(tempFile);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}