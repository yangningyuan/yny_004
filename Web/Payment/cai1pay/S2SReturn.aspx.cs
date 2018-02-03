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
using System.IO;

namespace yny_004.Web.Payment.cai1pay
{
    public partial class S2SReturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //接收数据
            string billno = Request.Form["MerOrderNo"];
            string amount = Request.Form["Amount"];
            string currency_type = Request.Form["Currency"];
            string mydate = Request.Form["OrderDate"];
            string succ = Request.Form["Succ"];
            string msg = Request.Form["Msg"];
            string attach = Request.Form["GoodsInfo"];
            string ipsbillno = Request.Form["SysOrderNo"];
            string retEncodeType = Request.Form["RetencodeType"];
            string signature = Request.Form["Signature"];

            //签名原文（商户订单号+交易金额+交易时间+成功标志+IPS交易号+交易币种）<要按照这个先后顺序>
            string content = billno + amount + mydate + succ + ipsbillno + currency_type;

            //签名是否正确
            Boolean verify = false;

            //验证方式：12-md5
            if (retEncodeType == "12")
            {
                //Md5摘要（商户证书在商户后台可下载）
                string merchant_key = "OImSyZ94i8rQMoP0BvnY481nqPWAZBOX9FowJvd4uaKsuuiBGV0CqIZqqYC8dY57JuqgZ2GqsJD4NjTVGuUellGQFYgKI40w4n9adcBooku7e52hfGRIe1w7Dz0bwV7N";
                //string merchant_key = "MK3LaSgnNnb2qfZ6sDfP5wOZ3f6VsXm068Ieo3LNUps3qRfdMS2AMGLzW3rUwkUPaBVHwVrOSsUqeuJCa2j04BDQNsiLlQ1Ku23FWxGRBDI4L4vBKFUTb4vyXeUdM5Dc";
                string signature1 = FormsAuthentication.HashPasswordForStoringInConfigFile(content + merchant_key, "MD5").ToLower();

                if (signature1 == signature)
                {
                    verify = true;
                }

            }

            //判断签名验证是否通过
            if (verify == true)
            {
                //判断交易是否成功
                if (succ != "Y")
                {
                    FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\s2s.txt", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine("交易失败！");
                    writer.Close();

                    //#############################################################
                    //以上代码仅作参考，此处可增加商户逻辑
                    //#############################################################
                }
                else
                {
                    FileStream file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\s2s.txt", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine("商户订单号：" + billno + "， IPS订单号：" + ipsbillno + "， 币种：" + currency_type + "， 金额：" + amount + "， 订单日期：" + mydate + "， 标识：" + succ);
                    writer.Close();

                    //#############################################################
                    //以上代码仅作参考，此处可增加商户逻辑
                    //#############################################################
                }
            }
            else
            {
                Response.Write("签名不正确！");
            }
        }
    }
}