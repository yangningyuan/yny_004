using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.autoaspx
{
    public partial class minute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["minute"]) || Request.QueryString["minute"] != "yny_004")
                    return;
                //if (yny_004.BLL.Configuration.Model.AutoDFH)
                {
                    string error = "";
                    try
                    {
                        //if (BLL.ChangeMoney.ListMyAdd())
                        //{
                        //    error += "操作成功！";
                        //}
                        //else
                        {
                            error += "操作失败！";
                        }
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", error);
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", ex.ToString());
                    }
                    Response.Write(error);
                }
            }
        }
    }
}