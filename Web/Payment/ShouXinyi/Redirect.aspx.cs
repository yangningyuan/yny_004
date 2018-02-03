using System;
using System.Web;
using yny_004.Model;

namespace yny_004.Web.Payment.ShouXinyi
{
    public partial class Redirect : BasePage
    {
        private HKModel HKModel
        {
            get
            {
                int type = 1;

                HKModel model = new HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = "";
                //model.FromBank = Request.Form["yh"];
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
            //商户号
            string v_mid = ShouXinYi.v_mid;
            HKModel hkModel = HKModel;


            hkModel.HKCode = DateTime.Now.ToString("yyyyMMdd") + "-" + v_mid + "-" + (new Random().Next(100000, 999999)).ToString();
            BLL.HKModel.Insert(hkModel);

            //支付结果成功返回的商户URL
            string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
            string Merchanturl = url + "/Payment/ShouXinyi/ReturnSyn.aspx";

            //提交地址
            string form_url = ShouXinYi.form_url;
            //姓名
            string v_rcvname = v_mid;
            //地址
            string v_rcvaddr = v_mid;
            //电话
            string v_rcvtel = v_mid;
            //邮编
            string v_rcvpost = v_mid;
            //商户配货状态
            string v_orderstatus = "1";
            //订货人姓名
            string v_ordername = v_mid;
            //支付币种//0为人民币，1为美元，2为欧元
            string v_moneytype = "0";
            //订单号
            string v_oid = hkModel.HKCode;
            //金额
            string v_amount = hkModel.RealMoney.ToString("F2");
            //订单生产日期
            string v_ymd = hkModel.HKCreateDate.ToString("yyyyMMdd");
            //支付完成后返回的页面地址
            string v_url = Merchanturl;
            //加密方式1:MD5,2:SHA(可空)
            string v_md5info = "";

            ClassHmac2003.ClassHmac mac = new ClassHmac2003.ClassHmac();
            string key = v_moneytype + v_ymd + v_amount + v_rcvname + v_oid + v_mid + v_url;
            v_md5info = mac.hex_hmac_md5(key, ShouXinYi.MD5Key);//test为默认秘钥。 正式上线时联系客服人员修改

            string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";
            postForm += "<input type=\"hidden\" name=\"v_mid\" value=\"" + v_mid + "\" />";//商户号
            postForm += "<input type=\"hidden\" name=\"v_oid\" value=\"" + v_oid + "\" />";//订单号
            postForm += "<input type=\"hidden\" name=\"v_rcvname\" value=\"" + v_rcvname + "\" />";//姓名
            postForm += "<input type=\"hidden\" name=\"v_rcvaddr\" value=\"" + v_rcvaddr + "\" />";//地址
            postForm += "<input type=\"hidden\" name=\"rcvtel\" value=\"" + v_rcvtel + "\" />";//电话
            postForm += "<input type=\"hidden\" name=\"v_rcvpost\" value=\"" + v_rcvpost + "\" />";//邮编
            postForm += "<input type=\"hidden\" name=\"v_amount\" value=\"" + v_amount + "\" />";//金额
            postForm += "<input type=\"hidden\" name=\"v_ymd\" value=\"" + v_ymd + "\" />";//订单生产日期
            postForm += "<input type=\"hidden\" name=\"v_orderstatus\" value=\"" + v_orderstatus + "\" />";//商户配货状态
            postForm += "<input type=\"hidden\" name=\"v_ordername\" value=\"" + v_ordername + "\" />";//订货人姓名
            postForm += "<input type=\"hidden\" name=\"v_moneytype\" value=\"" + v_moneytype + "\" />";//支付币种//0为人民币，1为美元，2为欧元。。详见参考文档
            postForm += "<input type=\"hidden\" name=\"v_md5info\" value=\"" + v_md5info + "\" />";//加密方式1:MD5,2:SHA(可空)
            postForm += "<input type=\"hidden\" name=\"v_url\" value=\"" + v_url + "\" />";//支付完成后返回的页面地址

            postForm += "</form>";

            //自动提交该表单到测试网关
            postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

            Response.Write(postForm);
        }

    }
}