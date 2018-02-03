using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using WFTSwiftpass;
using yny_004.Model;

namespace yny_004.Web.Payment.WFT
{
    public partial class WFTPayIndex : BasePage
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
            if (hkModel.FromBank == "03100") //微信扫码支付
            {
                ClientResponseHandler resHandler = new ClientResponseHandler();
                var pay = new PayHttpClient();
                RequestHandler reqHandler = new RequestHandler(null);
                var cfg = new Dictionary<string, string>();

                var payMoney = Convert.ToInt32(hkModel.RealMoney * 100).ToString(); //以分为单位

                //支付结果成功返回的商户URL
                string url = "http://" + HttpContext.Current.Request.Url.Authority.ToString();
                string Merchanturl = url + "/Payment/WFT/WFTPayOrderReturn.aspx";

                reqHandler = new RequestHandler(null);
                //加载配置数据
                cfg = Utils.loadCfg();
                //初始化数据 
                reqHandler.setGateUrl(cfg["req_url"].ToString()); //接口请求地址
                reqHandler.setKey(cfg["key"].ToString()); //密钥
                reqHandler.setParameter("mch_id", cfg["mch_id"].ToString());//必填项，商户号，由平台分配
                reqHandler.setParameter("version", cfg["version"].ToString());//接口版本号
                reqHandler.setParameter("service", "pay.weixin.native");//接口类型：pay.weixin.native
                reqHandler.setParameter("notify_url", Merchanturl);
                //通知地址，必填项，接收平台通知的URL，需给绝对路径，255字符内;此URL要保证外网能访问   
                reqHandler.setParameter("out_trade_no", hkModel.HKCode);//商户订单号
                reqHandler.setParameter("body", "在线充值");//商品描述
                reqHandler.setParameter("attach", "微信扫码支付");//附加信息
                reqHandler.setParameter("total_fee", payMoney);//总金额
                reqHandler.setParameter("mch_create_ip", Request.UserHostAddress);//终端IP
                reqHandler.setParameter("time_start", hkModel.HKCreateDate.ToString("yyyyMMddHHssmm")); //订单生成时间
                reqHandler.setParameter("time_expire", "");//订单超时时间
                reqHandler.setParameter("nonce_str", Utils.random());//随机字符串，必填项，不长于 32 位
                reqHandler.createSign();//创建签名
                                        //以上参数进行签名
                string data = Utils.toXml(reqHandler.getAllParameters());//生成XML报文
                Dictionary<string, string> reqContent = new Dictionary<string, string>();
                reqContent.Add("url", reqHandler.getGateUrl());
                reqContent.Add("data", data);
                pay.setReqContent(reqContent);

                if (pay.call())
                {
                    resHandler.setContent(pay.getResContent());
                    resHandler.setKey(cfg["key"].ToString());
                    Hashtable param = resHandler.getAllParameters();
                    if (resHandler.isTenpaySign())
                    {
                        //当返回状态与业务结果都为0时才返回支付二维码，其它结果请查看接口文档
                        if (int.Parse(param["status"].ToString()) == 0 && int.Parse(param["result_code"].ToString()) == 0)
                        {
                            this.QRcode.Src = param["code_img_url"].ToString();
                            this.orderno.Text = hkModel.HKCode;
                            this.orderno2.Text = hkModel.HKCode;
                            this.shopdesc.Text = "在线充值";
                            this.attach.Text = "微信扫码支付";
                            this.money.Text = Convert.ToString(float.Parse(payMoney) / 100);
                            this.totalmoney.Text = Convert.ToString(float.Parse(payMoney) / 100);
                        }
                        else
                        {
                            Response.Write("<script>alert('错误代码：" + param["err_code"] + ",错误信息：" + param["err_msg"] + "')</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('错误代码：" + param["status"] + ",错误信息：" + param["message"] + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('错误代码：" + pay.getResponseCode() + ",错误信息：" + pay.getErrInfo() + "')</script>");
                }
            }
            else
            {
                Response.Write("参数错误!");
            }

        }
    }
}