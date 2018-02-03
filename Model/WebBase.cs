using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class WebBase
    {
        public string SMSName { get; set; }//短信用户
        public string SMSPassword { get; set; }//短信密码
        public bool SMSState { get; set; }//短信状态
        public bool TelVerify { get; set; }//开启手机验证;
        public string SMSTitle { get; set; }//短信后辍
        public int SMSMinCount { get; set; }//余额警报
        public string EmailSmtp { get; set; }//邮箱服务器
        public string EmailName { get; set; }//邮箱用户
        public string EmailPassword { get; set; }//邮箱密码
        public string EmailTitle { get; set; }//邮箱后辍
        public bool EmailVerify { get; set; }//开启邮箱验证
        public bool EmailState { get; set; }//邮箱状态
        public int DaySMSCount { get; set; }//每日发送短信量
        public bool RandPassword { get; set; }//随机密码
        public string MonitorTel { get; set; }//监控手机
        public string MonitorEmail { get; set; }//监控邮箱
        public bool AutoID { get; set; }//监控邮箱
        public int EmailCount = 1;
    }
}
