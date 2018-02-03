using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yny_004.Web.Payment.ShouXinyi
{
    /// <summary>
    /// 后台回调地址需要联系第三方设置
    /// 加密密钥需要联系第三方设置
    /// </summary>
    public class ShouXinYi
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public static string v_mid
        {
            get
            {
                return "12953";
            }
        }

        /// <summary>
        /// 提交地址
        /// </summary>
        public static string form_url
        {
            get
            {
                return "https://pay.yizhifubj.com/prs/user_payment.checkit";
            }
        }

        /// <summary>
        /// 直连地址(v_pmode必传)
        /// </summary>
        public static string directUrl
        {
            get
            {
                return "https://pay.yizhifubj.com/customer/gb/pay_bank.jsp";
            }
        }

        /// <summary>
        ///  test为默认秘钥,正式上线时联系客服人员修改
        /// </summary>
        public static string MD5Key
        {
            get
            {
                return "WDGX85wrpS213QMH";
            }
        }
    }
}