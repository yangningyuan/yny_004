using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace yny_004.Web.Member
{
    public partial class Add : BasePage
    {
        protected override void SetPowerZone()
        {
            txtMTJ.Value = TModel.MID;
            if (!TModel.Role.IsAdmin)
            {
                txtMTJ.Attributes.Add("readonly", "readonly");
            }
            //if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            //{
            //    if (string.IsNullOrEmpty(txtMBD.Value))
            //        txtMBD.Value = Request.QueryString["mid"].Trim();
            //}
            //else
            //{
            //    txtMBD.Value = txtMTJ.Value;
            //}


            //Random r = new Random();
            //var rid = r.Next(1, 999).ToString();

            //txtMID.Value = "huiyuan" + rid;

            //if (!string.IsNullOrEmpty(Request.QueryString["bdindex"]))
            //{
            //    int bdindex = int.Parse(Request.QueryString["bdindex"]);
            //    if (bdindex == 1)
            //    {
            //        ddlMBDIndex.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        ddlMBDIndex.SelectedIndex = 1;
            //    }
            //}


            BindDdlPwdQuestion();

            Sys_BankInfoBLL sbiBLL = new Sys_BankInfoBLL();
            txtBank.DataSource = sbiBLL.GetList(" 1 = 1 and IsDeleted = 0 order by Code");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Name";
            txtBank.DataBind();
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
                model.MID = Request.Form["txtTel"].Trim();
                model.MName = Request.Form["txtMName"].Trim();
                model.Password = Request.Form["txtPassword"].Trim();
                model.SecPsd = Request.Form["txtSecPsd"].Trim();
                model.Tel = Request.Form["txtTel"].Trim();
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
                //model.MBDIndex = int.Parse(Request.Form["ddlMBDIndex"]);
                model.MBD = model.MTJ;
                //model.MBD = Request.Form["txtMBD"];
                //model.MSH = Request.Form["txtMSH"];
                model.MSH = "";
                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.Salt = new Random().Next(10000, 99999).ToString();
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
                //model.NumID = Request.Form["txtNumID"];
                //model.Country = Request.Form["txtCountry"];
                model.Province = Request.Form["ddlProvince"].Trim();
                model.City = Request.Form["ddlCity"].Trim();
                //model.Zone = Request.Form["ddlZone"].Trim();

                model.FHState = false;
                return model;
            }
        }

        private Model.BankModel BankInfo
        {
            get
            {
                Model.BankModel model = new Model.BankModel();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankCreateDate = DateTime.Now;
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                model.MID = Request.Form["txtMID"];
                model.IsPrimary = true;
                return model;
            }
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            if (!BLL.CommonBase.TestSql(Request.QueryString.ToString() + Request.Form.ToString()))
            {
                return "非法关键字符";
            }
            string error = "";

            //List<Model.Member> list = BllModel.GetMemberEntityList("Tel='" + Request.Form["txtTel"].Trim() + "'");
            //if (list.Count >= BLL.Configuration.Model.E_BbinMaxCount)
            //{
            //    error += "该手机号码已被绑定";
            //}
            //else
            //{
            //    //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
            //    //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
            //    //{
            //    //    error += "手机验证码错误！";
            //    //}
            //}

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }
            Model.Member membermode = MemberMode;

            //Model.Member mbd = BllModel.GetModel(membermode.MTJ);
            //if (mbd == null || !mbd.MState)
            //{
            //    return "推荐人不存在或未激活";
            //}
            //else
            //{
            //    int mbdcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from Member where MBD='" + mbd.MID + "' and MID <> '" + mbd.MID + "' "));
            //    if (mbdcount >= 3)
            //    {
            //        return "此接点人伞下名额已满，请重新填写接点人";
            //    }
            //}

            Model.Member model = BLL.Member.InsertAndReturnEntity(membermode, 0, true, ref error);
            if (model != null)
            {
                //Model.Sys_SQ_Answer objAnswer = new Model.Sys_SQ_Answer();
                //objAnswer.MID = model.ID;
                //objAnswer.QId = long.Parse(Request.Form["ddlQuestion"]);
                //objAnswer.Answer = Request.Form["txtAnswer"];
                //objAnswer.CreatedBy = model.MID;
                //if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                //{
                    return "注册成功";
                //}
            }
            else
            {
                return error;
            }
            return error;
        }
    }
}