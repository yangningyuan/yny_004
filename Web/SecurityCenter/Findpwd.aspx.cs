using System;

namespace yny_004.Web.SecurityCenter
{
    public partial class Findpwd : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
                {
                    if (Request.QueryString["Action"].ToUpper() == "ADD")
                    {
                        Response.Write(btnAdd_Click());
                        Response.End();
                        return;
                    }
                }
            }
        }

        protected string btnAdd_Click()
        {
            string mid = Request.Form["txtname"].Trim();
            string pwd1 = Request.Form["txtpwd"].Trim();
            string pwd2 = Request.Form["txtChangePwd"].Trim();
            string pwd12 = Request.Form["txtpwd2"].Trim();
            string pwd22 = Request.Form["txtChangePwd2"].Trim();
            string tel = Request.Form["txtTel"].Trim();
            string checkCode = Request.Form["checkCode"].Trim();
            if (string.IsNullOrEmpty(mid))
            {
                return "请输入要重置的账号";
            }
            if (pwd1 != pwd12)
            {
                return "两次输入的登录密码不一样";
            }
            if (pwd2 != pwd22)
            {
                return "两次输入的交易密码不一样";
            }
            if (pwd1 == pwd2)
            {
                return "登录密码与交易密码不能相同";
            }
            Model.Member mem = BLL.Member.GetModelByMID(mid);
            if (mem == null)
            {
                return "不存在该账号";
            }
            if (mem.Tel != tel)
            {
                return "该手机号与注册时手机不一样，请输入正确的手机号。";
            }
            string code = BLL.SMS.GetSKeyBuyTel(tel, Model.SMSType.CZMM);
            if ((string.IsNullOrEmpty(code) || code != checkCode))
            {
                return "手机验证码错误";
            }
            else
            {
                if (string.IsNullOrEmpty(mem.FMID))
                {
                    mem.Salt = new Random().Next(37251, 99999).ToString();
                    mem.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd1 + mem.Salt, "MD5").ToUpper();
                    mem.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd2 + mem.Salt, "MD5").ToUpper();
                    if (BLL.Member.ManageMember.Update(mem))
                    {
                        return "登录密码和交易密码重置成功，请妥善保管您的密码";
                    }
                }
            }
            return "修改失败";
        }
    }
}