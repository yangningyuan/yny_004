using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class SMS
    {
        public int SID { get; set; }
        public SMSType SType { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string SContent { get; set; }
        public string SMSKey { get; set; }
        public DateTime CreateDate { get; set; }
        public string MID { get; set; }
        public bool SendState { get; set; }
    }
    /// <summary>
    /// 注册验证，密码验证,重置密码，测试短信
    /// </summary>
    public enum SMSType { ZCYZ, MMYZ, CZMM, CSDX, CSYX, QT }
}
