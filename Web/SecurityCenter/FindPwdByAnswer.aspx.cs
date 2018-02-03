using System;
using System.Collections.Generic;
using System.Linq;

namespace yny_004.Web.SecurityCenter
{
    public partial class FindPwdByAnswer : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<Model.Sys_SecurityQuestion> list = new BLL.Sys_SecurityQuestion().GetList("IsDeleted=0 and Status=1");
                ddlQuestion.DataSource = list;
                ddlQuestion.DataValueField = "Id";
                ddlQuestion.DataTextField = "Question";
                ddlQuestion.DataBind();
            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            Model.Member model = BLL.Member.ManageMember.GetModel(txtMemberMID.Value);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(ddlQuestion.Value))
                {
                    Model.Sys_SQ_Answer objA = new BLL.Sys_SQ_Answer().GetList("MID='" + model.ID + "' and IsDeleted=0").FirstOrDefault();
                    if (objA == null)
                    {
                        Label1.Text = "操作失败";
                        return;
                    }
                    if (objA.QId == long.Parse(ddlQuestion.Value) && objA.Answer == txtAnswer.Value)
                    {
                        model.Password = new Random().Next(475393, 999999).ToString();
                        model.SecPsd = new Random().Next(268372, 999999).ToString();
                        model.Salt = new Random().Next(37251, 99999).ToString();
                        string pass = "一级密码：" + model.Password + ",资金密码：" + model.SecPsd;
                        model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                        model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
                        if (BLL.Member.ManageMember.Update(model))
                            Label1.Text = "操作成功！" + pass;
                        else
                            Label1.Text = "操作失败";
                    }
                    else
                    {
                        Label1.Text = "密保问题不正确";
                    }
                }
                else
                {
                    Label1.Text = "请选择密保问题";
                }
            }
            else
            {
                Label1.Text = "不存在该账号";
            }
        }
    }
}