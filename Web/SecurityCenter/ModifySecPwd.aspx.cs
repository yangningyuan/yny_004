using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.SecurityCenter
{
    public partial class ModifySecPwd : BasePage
    {
        protected override void SetPowerZone()
        {
            //if (Session["PwdProtection"] == null || Session["PwdProtection"].ToString() != "pass")
            //{
            //    Response.Write("<script>callhtml('SecurityCenter/PwdProtection.aspx?id=ModifySecPwd');</script>");
            //    Response.End();
            //}
            //else 
            if (!BLL.WebBase.Model.EmailVerify && !BLL.WebBase.Model.TelVerify)
            {
                VerifyCode.Style.Add("display", "none");
            }
            //List<Model.Sys_SQ_Answer> listAns = new BLL.Sys_SQ_Answer().GetList(" MID=" + TModel.ID + " and IsDeleted=0");
            //if (listAns != null && listAns.Count > 0)
            //{
            //    string orgAns = listAns[0].Answer;
            //    Model.Sys_SecurityQuestion objQ = new BLL.Sys_SecurityQuestion().GetModel(listAns[0].QId);
            //    if (objQ != null)
            //    {
            //        sp_Question.InnerText = objQ.Question;
            //        hidQuesId.Value = objQ.ID.ToString();
            //    }
            //}
            BindDdlPwdQuestion();
        }
        protected void BindDdlPwdQuestion()
        {
            //BLL.Sys_SecurityQuestion BLL = new BLL.Sys_SecurityQuestion();
            //string whereStr = " IsDeleted=0 and Status=1";
            //IList<Model.Sys_SecurityQuestion> list = BLL.GetList(whereStr);
            //ddl_PwdQuestion.DataSource = list;
            //ddl_PwdQuestion.DataTextField = "Question";
            //ddl_PwdQuestion.DataValueField = "ID";
            //ddl_PwdQuestion.DataBind();
        }

        protected override string btnModify_Click()
        {
            //if (Check_SQ_Answer())
            {
                Model.Member model = TModel;
                string code = BLL.SMS.GetSKeyBuyTel(model.Tel, Model.SMSType.MMYZ);
                if ((!BLL.WebBase.Model.EmailVerify && !BLL.WebBase.Model.TelVerify) || (!string.IsNullOrEmpty(code) && code == Request.Form["txtTelCode"]))
                {
                    model.SecPsd = Request.Form["lbNSecPsd"].Trim();
                    model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
                    if (BllModel.Update(model))
                        return "操作成功";
                    return "操作失败";
                }
                else
                {
                    return "验证码不正确";
                }
            }
            //else
            //    return "密保问题错误";
        }
    }
}