using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace yny_004.BLL
{
    public class Email
    {
        private static List<string> _emails = new List<string>();
        private static List<string> Emails
        {
            get
            {
                if (_emails.Count == 0)
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        _emails.Add("kefu" + i + "@.com");
                    }
                }
                return _emails;
            }
        }
        public static bool Insert(Model.SMS model, ref string error)
        {
            if (BLL.WebBase.Model.EmailState && !string.IsNullOrEmpty(model.Email))
            {
                int level = 0;
                while (!model.SendState && level++ < 5)
                {
                    try
                    {
                        model.SendState = SendMessage(model, ref error);
                    }
                    catch (Exception ex)
                    {
                        //BLL.WebBase.Model.EmailName = Emails[new Random().Next(0, 100)];
                        //BLL.WebBase.Update(BLL.WebBase.Model);
                        error += "邮件发送失败！" + ex.Message;
                        model.SendState = false;
                    }
                }

                model.CreateDate = DateTime.Now;
                model.SMSKey = BLL.WebBase.Model.EmailName;
                DAL.SMS.Insert(model);
            }
            else
            {
                error += "邮箱功能已关闭！";
                return false;
            }
            return model.SendState;
        }
        private static bool SendMessage(Model.SMS model, ref string error)
        {
            SmtpClient client = new SmtpClient(BLL.WebBase.Model.EmailSmtp, 25);
            //出站方式设置为NetWork
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp服务器验证并制定账号密码
            client.Credentials = new NetworkCredential(BLL.WebBase.Model.EmailName, BLL.WebBase.Model.EmailPassword);
            MailMessage message = new MailMessage();
            //设置优先级
            message.Priority = MailPriority.Normal;
            //设置收件方看到的邮件来源为:发送方邮件地址、来源标题、编码
            message.From = new MailAddress(BLL.WebBase.Model.EmailName, "Vinci", Encoding.GetEncoding("gb2312"));
            //接收方
            if (!string.IsNullOrEmpty(model.Email))
                try
                {
                    message.To.Add(model.Email);
                }
                catch
                {
                    error += "邮箱设置不正确！";
                    return false;
                }
            else
            {
                error += "邮箱未设置！";
                return false;
            }
            //标题
            message.Subject = BLL.WebBase.Model.EmailTitle;
            message.SubjectEncoding = Encoding.GetEncoding("gb2312");
            //邮件正文是否支持HTML
            message.IsBodyHtml = true;
            //正文编码
            message.BodyEncoding = Encoding.GetEncoding("gb2312");
            message.Body = model.SContent;
            client.Send(message);
            return true;
        }
    }
}
