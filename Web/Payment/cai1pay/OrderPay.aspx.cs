using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace yny_004.Web.Payment.cai1pay
{
    public partial class OrderPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //订单日期
            Date.Value = DateTime.Now.ToString("yyyyMMdd");

            //产生订单号
            Random rand = new Random();
            Billno.Value = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999);

            //商户返回地址
            string url = "http://" + Request.ServerVariables["HTTP_HOST"].Replace("localhost", "127.0.0.1") + Request.ServerVariables["SCRIPT_NAME"].ToLower();
            Merchanturl.Value = url.Replace("orderpay.aspx", "OrderReturn.aspx");
            ServerUrl.Value = url.Replace("orderpay.aspx", "S2SReturn.aspx");
        }
    }
}