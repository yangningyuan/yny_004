using DBUtility;
using System;
using System.Web;

namespace yny_004.Web.Payment.ShouXinyi
{
    public partial class ReturnSyn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string v_oid1 = Request.Form["v_oid"];

            Model.HKModel model = BLL.HKModel.GetModel(v_oid1);
            if (model != null)
            {
                if (model.HKState)
                {
                    Response.Write("交易成功！");
                    Response.End();
                }
                else
                {
                    Response.Write("交易失败！");
                    Response.End();
                }
            }
            Response.Write("交易失败！");
            Response.End();
        }
    }
}