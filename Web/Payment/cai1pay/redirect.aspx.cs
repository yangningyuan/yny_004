using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using WFTSwiftpass;
using yny_004.Model;

namespace yny_004.Web.Payment.cai1pay
{
    public partial class redirect : BasePage
    {
        private HKModel HKModel
        {
            get
            {
                int type = 1;


                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = "";
                model.FromBank = Request.Form["yh"];
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.Form["txtValidMoney"]);
                model.ValidMoney = decimal.Parse(Request.Form["txtValidMoney"]);
                model.HKDate = DateTime.Now;
                model.HKState = false;
                model.HKType = type;
                model.ToBank = "";
                model.IsAuto = true;
                model.Sign = false;
                return model;
            }
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            HKModel hkModel = HKModel;
            BLL.HKModel.Insert(hkModel);
            //提交地址
            string form_url = "https://payment.cai1pay.com/gateway.aspx";
            //if (Request.Form["test"] == "1")
            //{
            //    form_url = "http://testpay.cai1pay.com/gateway.aspx"; //测试环境
            //}
            //else
            //{
            //    form_url = "https://payment.cai1pay.com/gateway.aspx"; //正式环境
            //}

            //交易账户号
            string Mer_code = "10114701";
            //string Mer_code = "10084901";

            //商户证书：登陆商户后台下载的商户证书内容
            string Mer_key = "OImSyZ94i8rQMoP0BvnY481nqPWAZBOX9FowJvd4uaKsuuiBGV0CqIZqqYC8dY57JuqgZ2GqsJD4NjTVGuUellGQFYgKI40w4n9adcBooku7e52hfGRIe1w7Dz0bwV7N";
            //string Mer_key = "MK3LaSgnNnb2qfZ6sDfP5wOZ3f6VsXm068Ieo3LNUps3qRfdMS2AMGLzW3rUwkUPaBVHwVrOSsUqeuJCa2j04BDQNsiLlQ1Ku23FWxGRBDI4L4vBKFUTb4vyXeUdM5Dc";

            //商户订单编号
            string Billno = hkModel.HKCode;

            //订单金额(保留2位小数)
            string Amount = hkModel.RealMoney.ToString("F2");

            //订单日期
            string BillDate = hkModel.HKCreateDate.ToString("yyyyMMdd");

            //币种
            string Currency_Type = "RMB";

            //支付卡种
            //01：网银支付
            //02：国际卡支付
            //03：快捷支付
            //04：微信支付
            //05：支付宝支付
            //06：预付卡支付

            string Gateway_Type = "";
            if (hkModel.FromBank == "03200")
            {
                Gateway_Type = "05";
            }
            else if (hkModel.FromBank == "03100")
            {
                Response.Write("参数错误！");
                //Gateway_Type = "04";
            }
            else {
                Gateway_Type = "01";
            }

            string BankCode = hkModel.FromBank;
            //语言
            string Lang = "GB";

            //支付结果成功返回的商户URL
            string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
            string Merchanturl = url + "/Payment/cai1pay/OrderReturn.aspx";

            ////支付结果失败返回的商户URL
            //string FailUrl = Request.Form["FailUrl"];

            ////支付结果错误返回的商户URL
            //string ErrorUrl = Request.Form["ErrorUrl"];

            //商户数据包
            string Attach = hkModel.HKCode;

            //显示金额
            //string DispAmount = Request.Form["DispAmount"];

            //订单支付接口加密方式
            string OrderEncodeType = "2";

            //交易返回接口加密方式
            string RetEncodeType = "12";

            //返回方式
            string Rettype = "1";

            //Server to Server 返回页面URL
            string ServerUrl = url + "/Payment/cai1pay/S2SReturn.aspx";

            //订单支付接口的Md5摘要，原文=订单号+金额+日期+支付币种+商户证书 
            string SignMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Billno + Amount + BillDate + Currency_Type + Mer_key, "MD5").ToLower();

            string DoCredit = "1";


            string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";

            postForm += "<input type=\"hidden\" name=\"MerCode\" value=\"" + Mer_code + "\" />";
            postForm += "<input type=\"hidden\" name=\"MerOrderNo\" value=\"" + Billno + "\" />";
            postForm += "<input type=\"hidden\" name=\"Amount\" value=\"" + Amount + "\" />";
            postForm += "<input type=\"hidden\" name=\"OrderDate\" value=\"" + BillDate + "\" />";
            postForm += "<input type=\"hidden\" name=\"Currency\" value=\"" + Currency_Type + "\" />";
            postForm += "<input type=\"hidden\" name=\"GatewayType\" value=\"" + Gateway_Type + "\" />";
            postForm += "<input type=\"hidden\" name=\"Language\" value=\"" + Lang + "\" />";
            postForm += "<input type=\"hidden\" name=\"ReturnUrl\" value=\"" + Merchanturl + "\" />";
            postForm += "<input type=\"hidden\" name=\"GoodsInfo\" value=\"" + Attach + "\" />";
            postForm += "<input type=\"hidden\" name=\"OrderEncodeType\" value=\"" + OrderEncodeType + "\" />";
            postForm += "<input type=\"hidden\" name=\"RetEncodeType\" value=\"" + RetEncodeType + "\" />";
            postForm += "<input type=\"hidden\" name=\"Rettype\" value=\"" + Rettype + "\" />";
            postForm += "<input type=\"hidden\" name=\"ServerUrl\" value=\"" + ServerUrl + "\" />";
            postForm += "<input type=\"hidden\" name=\"SignMD5\" value=\"" + SignMD5 + "\" />";
            postForm += "<input type=\"hidden\" name=\"DoCredit\" value=\"" + DoCredit + "\" />";
            postForm += "<input type=\"hidden\" name=\"BankCode\" value=\"" + BankCode + "\" />";
            postForm += "</form>";

            //自动提交该表单到测试网关
            postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

            Response.Write(postForm);
        }
        
    }
}