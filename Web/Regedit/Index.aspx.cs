using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CommonBLL;

namespace yny_004.Web.Regedit
{
    public partial class Index : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                {
                    Model.Member tjmodel = BLL.Member.ManageMember.GetModel(Request.QueryString["mid"]);
                    if (tjmodel != null)
                    {
                        txtMTJ.Value = Request.QueryString["mid"];
                        //txtMTJ.Attributes["readonly"] = "readonly";
                    }
                }
            }
            Sys_BankInfoBLL sbiBLL = new Sys_BankInfoBLL();
            txtBank.DataSource = sbiBLL.GetList(" 1=1 and IsDeleted=0 order by Code");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Name";
            txtBank.DataBind();
            BindDdlPwdQuestion();
        }

        protected void BindDdlPwdQuestion()
        {
            BLL.Sys_SecurityQuestion BLL = new BLL.Sys_SecurityQuestion();
            string whereStr = " IsDeleted=0 and Status=1";
            IList<Model.Sys_SecurityQuestion> list = BLL.GetList(whereStr);
            ddlQuestion.DataSource = list;
            ddlQuestion.DataTextField = "Question";
            ddlQuestion.DataValueField = "ID";
            ddlQuestion.DataBind();
        }

        public Model.Member MemberMode
        {
            get
            {
                Model.Member model = new Model.Member();
                model.MID = Request.Form["txtMID"].Trim();
                model.MName = Request.Form["txtMName"].Trim();
                model.Password = Request.Form["txtPassword"].Trim();
                model.SecPsd = Request.Form["txtSecPsd"].Trim();
                model.Tel = Request.Form["txtTel"].Trim();
                model.MID = Request.Form["txtMID"].Trim();
                model.RoleCode = "Notactive";
                model.AgencyCode = "001";
                model.MAgencyType = BLL.Configuration.Model.SHMoneyList[model.AgencyCode];
                model.IsClock = false;
                model.IsClose = false;
                model.MState = false;
                model.MTJ = Request.Form["txtMTJ"];
                //if (model.MTJ == "0")
                //{
                //    model.MTJ = BLL.Member.ManageMember.TModel.MID;
                //}
                model.MBDIndex = int.Parse(Request.Form["ddlMBDIndex"]);
                model.MBD = Request.Form["txtMBD"];
                model.MSH = Request.Form["txtMSH"];
                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.Salt = new Random().Next(10000, 99999).ToString();
                model.NumID = Request.Form["txtNumID"];
                //model.Address = "";// Request.Form["hduploadPic1"];

                //string imgsUrl = Request.Form["uploadPic"];
                //if (!string.IsNullOrEmpty(imgsUrl))
                //{
                //    string[] array = imgsUrl.Split(',');
                //    foreach (string arr in array)
                //    {
                //        model.Address += "≌" + arr;
                //    }
                //}

                //model.Country = Request.Form["txtCountry"];
                model.Province = Request.Form["ddlProvince"];
                model.City = Request.Form["ddlCity"];
                model.Zone = Request.Form["ddlZone"];

                model.FHState = false;
                return model;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString()))
            {
                Response.Write("非法关键字符");
                return;
            }
            Model.Member mtjmodel = BLL.Member.ManageMember.GetModel(MemberMode.MTJ);
            string error = "";
            if (mtjmodel == null || !mtjmodel.MState)
            {
                Response.Write("<script>alert('请检查您的地址，未检测出您的推荐人信息！');</script>");
            }
            else
            {

                string tel = Request.Form["txtTel"];
                string txtcode = Request.Form["txtTelCode"];
                string code = BLL.SMS.GetSKeyBuyTel(tel, Model.SMSType.ZCYZ);
                if ((string.IsNullOrEmpty(code) || code != txtcode))
                {
                    Response.Write("<script>alert('手机验证码错误');</script>");
                    return;
                }
                //判断验证码是否过期；
                DateTime DateTimer = Convert.ToDateTime(BLL.SMS.CodeTimer(code));
                if (DateTime.Now > DateTimer.AddSeconds(120))
                {
                    Response.Write("<script>alert('验证码过期，请重新申请！');</script>");
                    return;
                }
                Model.Member membermode = MemberMode;

                Model.Member model = BLL.Member.InsertAndReturnEntity(membermode, 0, true, ref error);

                if (model != null)
                {
                    Model.Sys_SQ_Answer objAnswer = new Model.Sys_SQ_Answer();
                    objAnswer.MID = model.ID;
                    objAnswer.QId = long.Parse(Request.Form["ddlQuestion"]);
                    objAnswer.Answer = Request.Form["txtAnswer"];
                    objAnswer.CreatedBy = model.MID;
                    if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                    {
                        //if (model.Role.CanLogin)
                        //{
                        //    FormsAuthentication.SetAuthCookie(model.MID, true);
                        //    BLL.Member bllmodel = new BLL.Member { TModel = model };
                        //    Session["Member"] = bllmodel;
                        //    BLL.Member.AddOnLine(model.MID);
                        //}
                        //Response.Redirect("redirect.htm", false);
                        Response.Write("<script>alert('注册成功');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('" + error + "');</script>");
                }
            }

        }
    }
}
