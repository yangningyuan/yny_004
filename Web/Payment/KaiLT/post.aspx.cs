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
using System.Text;
using yny_004.Model;
namespace yny_004.Web.Payment.KaiLT
{
    public partial class post : System.Web.UI.Page
    {
        private HKModel HKModel
        {
            get
            {
                int type = 1;

                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = Request.QueryString["yh"];
                model.FromBank = Request.QueryString["yh"];
                model.MID = Request.QueryString["tmid"];
                model.RealMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                model.ValidMoney = decimal.Parse(Request.QueryString["txtValidMoney"]);
                model.HKDate = DateTime.Now;
                model.HKState = false;
                model.HKType = type;
                model.ToBank = "";
                model.IsAuto = true;
                model.Sign = false;
                return model;
            }
        }

        public String srcMsg = null;
        public String signMsg = null;
        public String serverUrl;
        public String key;
        public String version;
        public String language;
        public String inputCharset;
        public String merchantId;
        public String pickupUrl;
        public String receiveUrl;
        public String signType;

        public String orderNo;
        public String orderAmount;
        public String orderDatetime;
        public String orderCurrency;
        public String orderExpireDatetime;

        public String payerTelephone;
        public String payerEmail;
        public String payerName;

        public String productName;
        public String productId;
        public String productNum;
        public String productPrice;
        public String productDesc;

        public String ext1;
        public String ext2;
        public String extTL;

        public String payType;
        public String issuerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            HKModel hkModel = HKModel;
            yny_004.BLL.HKModel.Insert(hkModel);
            //serverUrl = "https://pg.openepay.com/gateway/index.do";//正式地址
            serverUrl = "http://pay.slfth.top/Payment.aspx";
            key = "yny123456";
            merchantId = "101000180103009";
            //serverUrl = "http://opsweb.koolyun.cn/gateway/index.do";//测试地址
            //merchantId = "100020091219001";
            //key = "1234567890";
            version = "v1.0";
            language = "1";
            inputCharset = "1";

            string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
            pickupUrl = url + "/Payment/KaiLT/OrderReturn.aspx";//客户取货地址
            receiveUrl = url + "/Payment/KaiLT/ServerReturn.aspx";//地址
            signType = "0";
            orderNo = hkModel.HKCode;
            orderAmount = (hkModel.ValidMoney * 100).ToString();//分为单位
            orderCurrency = "156";//币种
            orderDatetime = hkModel.HKCreateDate.ToString("yyyyMMddHHmmss");
            orderExpireDatetime = "10";
            productName = "mjb";
            //payerTelephone = Request.Form["payerTelephone"];
            //payerEmail = Request.Form["payerEmail"];
            //payerName = Request.Form["payerName"];
            //productId = Request.Form["productId"];
            //productNum = Request.Form["productNum"];
            //productPrice = Request.Form["productPrice"];
            //productDesc = Request.Form["productDesc"];
            //ext1 = Request.Form["ext1"];
            //ext2 = Request.Form["ext2"];
            //extTL = Request.Form["extTL"];
            issuerId = hkModel.FromBank;
            payType = "1";
            if (string.IsNullOrEmpty(hkModel.FromBank))
            {
                payType = "99";//0全部  1网银 ,99快捷
            }
            

            StringBuilder bufSignSrc = new StringBuilder();
            appendSignPara(bufSignSrc, "inputCharset", inputCharset);
            appendSignPara(bufSignSrc, "pickupUrl", pickupUrl);
            appendSignPara(bufSignSrc, "receiveUrl", receiveUrl);
            appendSignPara(bufSignSrc, "version", version);
            appendSignPara(bufSignSrc, "language", language);
            appendSignPara(bufSignSrc, "signType", signType);
            appendSignPara(bufSignSrc, "merchantId", merchantId);
            //appendSignPara(bufSignSrc, "payerName", payerName);
            //appendSignPara(bufSignSrc, "payerEmail", payerEmail);
            //appendSignPara(bufSignSrc, "payerTelephone", payerTelephone);
            appendSignPara(bufSignSrc, "orderNo", orderNo);
            appendSignPara(bufSignSrc, "orderAmount", orderAmount);
            appendSignPara(bufSignSrc, "orderCurrency", orderCurrency);
            appendSignPara(bufSignSrc, "orderDatetime", orderDatetime);
            appendSignPara(bufSignSrc, "orderExpireDatetime", orderExpireDatetime);
            appendSignPara(bufSignSrc, "productName", productName);
            //appendSignPara(bufSignSrc, "productPrice", productPrice);
            //appendSignPara(bufSignSrc, "productNum", productNum);
            //appendSignPara(bufSignSrc, "productId", productId);
            //appendSignPara(bufSignSrc, "productDesc", productDesc);
            //appendSignPara(bufSignSrc, "ext1", ext1);
            //appendSignPara(bufSignSrc, "ext2", ext2);
            //appendSignPara(bufSignSrc, "extTL", extTL);
            appendSignPara(bufSignSrc, "payType", payType);
            appendSignPara(bufSignSrc, "issuerId", issuerId);
            appendLastSignPara(bufSignSrc, "key", key);
            srcMsg = bufSignSrc.ToString();
            signMsg = FormsAuthentication.HashPasswordForStoringInConfigFile(srcMsg, "MD5");


            string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + serverUrl + "\">";
            postForm += "<input type=\"hidden\" name=\"inputCharset\" value=\"" + inputCharset + "\" />";
            postForm += "<input type=\"hidden\" name=\"pickupUrl\" value=\"" + pickupUrl + "\" />";
            postForm += "<input type=\"hidden\" name=\"receiveUrl\" value=\"" + receiveUrl + "\" />";
            postForm += "<input type=\"hidden\" name=\"version\" value=\"" + version + "\" />";
            postForm += "<input type=\"hidden\" name=\"language\" value=\"" + language + "\" />";
            postForm += "<input type=\"hidden\" name=\"signType\" value=\"" + signType + "\" />";
            postForm += "<input type=\"hidden\" name=\"merchantId\" value=\"" + merchantId + "\" />";
            postForm += "<input type=\"hidden\" name=\"orderNo\" value=\"" + orderNo + "\" />";
            postForm += "<input type=\"hidden\" name=\"orderAmount\" value=\"" + orderAmount + "\" />";
            postForm += "<input type=\"hidden\" name=\"orderCurrency\" value=\"" + orderCurrency + "\" />";
            postForm += "<input type=\"hidden\" name=\"orderDatetime\" value=\"" + orderDatetime + "\" />";
            postForm += "<input type=\"hidden\" name=\"orderExpireDatetime\" value=\"" + orderExpireDatetime + "\" />";
            postForm += "<input type=\"hidden\" name=\"productName\" value=\"" + productName + "\" />";
            postForm += "<input type=\"hidden\" name=\"payType\" value=\"" + payType + "\" />";
            postForm += "<input type=\"hidden\" name=\"issuerId\" value=\"" + issuerId + "\" />";
            postForm += "<input type=\"hidden\" name=\"key\" value=\"" + key + "\" />";
            postForm += "<input type=\"hidden\" name=\"signMsg\" value=\"" + signMsg + "\" />";
            //postForm += "<input type=\"hidden\" name=\"BankCode\" value=\"" + BankCode + "\" />";
            postForm += "</form>";

            //自动提交该表单到测试网关
            postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

            Response.Write(postForm);
        }


        //---------------------------------------以下代码请勿更动------------------------------------------------------------

        private bool isEmpty(String src)
        {
            if (null == src || "".Equals(src) || "-1".Equals(src))
            {
                return true;
            }
            return false;
        }

        private void appendSignPara(System.Text.StringBuilder buf, String key, String value)
        {
            if (!isEmpty(value))
            {
                buf.Append(key).Append('=').Append(value).Append('&');
            }
        }

        private void appendLastSignPara(System.Text.StringBuilder buf, String key,
                String value)
        {
            if (!isEmpty(value))
            {
                buf.Append(key).Append('=').Append(value);
            }
        }
    }
}