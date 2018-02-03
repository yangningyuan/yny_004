using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.SecurityCenter
{
    public partial class ModifyPwd : BasePage
    {
        protected override void SetPowerZone()
        {
            //List<Model.Sys_SQ_Answer> listAns = new BLL.Sys_SQ_Answer().GetList(" MID=" + TModel.ID + " and IsDeleted=0");
            //if (listAns != null && listAns.Count > 0)
            //{
            //    string orgAns = listAns[0].Answer;
            //    Model.Sys_SecurityQuestion objQ = new BLL.Sys_SecurityQuestion().GetModel(listAns[0].QId);
            //    if (objQ != null)
            //    {
            //        hidQuesId.Value = objQ.ID.ToString();
            //    }
            //}
            //BindDdlPwdQuestion(ddl_PwdQuestion);
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            //if (Check_SQ_Answer())
            {
                Model.Member model = TModel;
                if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["lbOPassword"].Trim() + model.Salt, "MD5").ToUpper() == model.Password)
                {
                    model.Password = Request.Form["lbNPassword"].Trim();
                    model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                    if (BllModel.Update(model))
                        return "操作成功";
                    return "操作失败";
                }
                else
                {
                    return "原密码不正确";
                }
            }
            //else
            //    return "密保问题错误";
        }

    }
}