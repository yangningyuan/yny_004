using System;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonModel;

namespace yny_004.Web.Language
{
    public partial class DownLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }


        protected void BindGridView()
        {

            //IList<Sys_Language> list = Sys_LanguageBLL.GetList("IsDeleted=0");
            //dbGridView.DataSource = list;
            //dbGridView.DataBind();
            //if (list.Count > 0)
            //{
            //ExportByApplication(dbGridView, "LanguageMatch");
            ExportExcel();
            Response.Write("<script>javascript:window.close();</script>");
            //}

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
                    var list = CommonBLL.Sys_LanguageBLL.GetList("IsDeleted=0  order by LEN(ZHName) desc");

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

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }
        //这种方式导出的不是标准的Excel格式，不能再次导入，要修改，暂时不做修改
        public void ExportByApplication(System.Web.UI.Control ctl, string fileName)
        {
            string style = @"<style type='text/css'> .text { mso-number-format:\@; } </style> ";
            Response.ClearContent();
            Response.Charset = "GB2312";

            //  Response.ContentEncoding = System.Text.Encoding.UTF8;

            //Response.ContentType = "application/ms-excel";
            Response.ContentType = "application/vnd.ms-excel ";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=GB2312\">");
            if (Request.Browser.Browser.ToLower() == "ie")
            {
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + HttpUtility.UrlEncode(fileName + ".xls", Encoding.UTF8));
            }
            else
            {
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            }

            ctl.Page.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            ctl.RenderControl(hw);

            Response.Write(style);

            Response.Write(tw.ToString());

            Response.End();

        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("class", "text");
                }
            }
        }


        /// <summary>
        /// 导出标准格式Excel
        /// </summary>
        /// <param name="InsertSql"></param>
        /// <param name="filename"></param>
        //public void ExportOut(string filename)
        //{
        //    //复制模板名称
        //    string filePath = Server.MapPath("~/UploadExcel/" + Guid.NewGuid().ToString() + DateTime.Now.Millisecond + ".xls");
        //    //导出文件名称
        //    filename = filename + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xls";
        //    //复制模板
        //    File.Copy(Server.MapPath("~/UploadExcel/模板(请勿删除).xls"), filePath);
        //    //连接字符串
        //    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=2;'");
        //    using (conn)
        //    {
        //        conn.Open();
        //        OleDbCommand cmd = null;
        //        // 增加记录
        //        string sql = " INSERT INTO [Sheet1$] ([中文名称], [外文名称], [是否启用],[语种]) VALUES('" + 001 + "', '" + xxx + "','" + 001 + "','" + 5 + "','" + 5 + "','" + 00 + "'); ";
        //        cmd = new OleDbCommand(sql, conn);
        //        cmd.ExecuteNonQuery();

        //    }
        //    // 输出副本的二进制字节流
        //    HttpContext.Current.Response.Clear();
        //    Response.ContentType = "application/ms-excel";
        //    //设置导出标题
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) + "\"");
        //    Response.BinaryWrite(File.ReadAllBytes(filePath));
        //    // 删除副本
        //    File.Delete(filePath);
        //}

    }
}