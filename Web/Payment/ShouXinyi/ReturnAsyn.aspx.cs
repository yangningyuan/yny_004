using DBUtility;
using System;
using System.Web;

namespace yny_004.Web.Payment.ShouXinyi
{
    public partial class ReturnAsyn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LogHelper.Log("数据回调", "kjhkjhkj");
            //异步返回
            string strvoid = HttpContext.Current.Request.QueryString.Get("v_oid");
            string strpmode = HttpContext.Current.Request.QueryString.Get("v_pmode");
            string strpastatus = HttpContext.Current.Request.QueryString.Get("v_pstatus");
            string strpstring = HttpContext.Current.Request.QueryString.Get("v_pstring");
            string strcount = HttpContext.Current.Request.QueryString.Get("v_count");
            string strmac = HttpContext.Current.Request.QueryString.Get("v_mac");
            string stramount = HttpContext.Current.Request.QueryString.Get("v_amount");
            string strmoneytype = HttpContext.Current.Request.QueryString.Get("v_moneytype");
            string strmd5money = HttpContext.Current.Request.QueryString.Get("v_md5money");
            string strsign = HttpContext.Current.Request.QueryString.Get("v_sign");

            /*异步返回MD5验签mac*/
            ClassHmac2003.ClassHmac cc1 = new ClassHmac2003.ClassHmac();
            LogHelper.Log("订单号", string.Format("strvoid={0};strpmode={1};strpastatus={2}", strvoid, strpmode, strpastatus));

            string mac1 = strvoid + HttpUtility.UrlEncode(strpmode, System.Text.Encoding.UTF8).ToUpper() + strpastatus + HttpUtility.UrlEncode(strpstring, System.Text.Encoding.UTF8).ToUpper() + strcount;
            string mac = cc1.hex_hmac_md5(mac1, ShouXinYi.MD5Key);

            /*异步返回MD5验签md5money*/
            ClassHmac2003.ClassHmac md1 = new ClassHmac2003.ClassHmac();
            string md51 = stramount + strmoneytype;
            string md5money = md1.hex_hmac_md5(md51, ShouXinYi.MD5Key);

            if (mac == strmac && md5money == strmd5money)
            {//成功
                if (strpastatus != "1")
                {
                    Response.Write("sent");
                    Response.End();
                }
                else
                {
                    if (!BLL.HKModel.tempList.Contains(strvoid))
                    {
                        BLL.HKModel.tempList.Add(strvoid);
                        try
                        {
                            if (yny_004.BLL.Member.ManageMember.SHPayHB(strvoid))
                            {
                                Response.Write("sent");
                                Response.End();
                            }
                            else
                            {
                                Response.Write("error");
                                Response.End();
                            }
                        }
                        finally
                        {
                            if (BLL.HKModel.tempList.Contains(strvoid))
                                BLL.HKModel.tempList.Remove(strvoid);
                        }
                    }
                }
            }
            else
            {
                Response.Write("error");
            }
        }
    }
}