using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;
using System.Collections;

namespace yny_004.Web.Member
{
    public partial class Modify : BasePage
    {
        protected string pic = "";
        protected string provice = "";
        protected string City = "";
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                txtMName.Attributes.Add("readonly", "readonly");

                if (!string.IsNullOrEmpty(TModel.BankCardName))
                {
                    txtBankCardName.Attributes.Add("readonly", "readonly");
                }
            }

            //if (TModel.Role.IsAdmin)
            {
                Sys_BankInfoBLL sbiBLL = new Sys_BankInfoBLL();
                txtBank.DataSource = sbiBLL.GetList(" 1 = 1 and IsDeleted = 0 order by Code");
                txtBank.DataTextField = "Name";
                txtBank.DataValueField = "Name";
                txtBank.DataBind();
            }

            MemberModel = TModel;
        }

        protected override void SetValue()
        {
        }

        public Model.Member MemberModel
        {
            get
            {
                Model.Member model = TModel;
                //model.Tel = Request.Form["txtTel"].Trim();
                if (TModel.Role.IsAdmin)
                {
                    model.MName = Request.Form["txtMName"].Trim();

                    model.Alipay = Request.Form["txtAlipay"];
                    model.QRCode = Request.Form["txtQRCode"];
                }
                if (string.IsNullOrEmpty(model.BankCardName))
                {
                    model.BankCardName = Request.Form["txtBankCardName"];
                }

                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["txtSePwd"] + model.Salt, "MD5").ToUpper();

                //model.Province = Request.Form["ddlProvince"];
                //model.City = Request.Form["ddlCity"];
                //model.Address = Request.Form["hduploadPic1"].Trim();
                //model.NumID = Request.Form["txtNumID"];
                //model.Address = "";
                //string imgsUrl = Request.Form["uploadPic"];
                //if (!string.IsNullOrEmpty(imgsUrl))
                //{
                //    string[] array = imgsUrl.Split(',');
                //    foreach (string arr in array)
                //    {
                //        model.Address += "≌" + arr;
                //    }
                //}

                return model;
            }
            set
            {
                if (value != null)
                {
                    txtMID.Value = value.MID;
                    txtMName.Value = value.MName;
                    //txtTel.Value = value.Tel;
                    if (TModel.Role.IsAdmin)
                    {

                        txtAlipay.Value = value.Alipay;
                        txtQRCode.Value = value.QRCode;
                    }
                    txtBankCardName.Value = value.BankCardName;
                    txtBank.Value = value.Bank;
                    txtBranch.Value = value.Branch;
                    txtBankNumber.Value = value.BankNumber;
                    
                    //ddlCity.Value = value.City;
                    //ddlProvince.Value = value.Province;
                    //provice = value.Province;
                    //City = value.City;
                    //txtNumID.Value = value.NumID;
                    //hduploadPic1.Value = value.Address;
                    //pic = "";
                    //if (!string.IsNullOrEmpty(value.Address))
                    //{
                    //    foreach (var pp in value.Address.Split('≌'))
                    //    {
                    //        if (!string.IsNullOrEmpty(pp))
                    //        {
                    //            pic += "<div class='appDiv'><img class='appImg' src='" + pp + "'/><img class='xClose' onclick='deletePic(this)'  title='删除' src='/Admin/pop/images/uploadify-cancel.png'/><input type='hidden' name='uploadPic' class='hidPicurl' value='" + pp + "'/></div>";
                    //        }
                    //    }
                    //}
                }
            }
        }
        protected void UpdateQuestion(int mid, Hashtable MyHs)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtAnswer"]))
            {
                Model.Sys_SQ_Answer objAns = new BLL.Sys_SQ_Answer().GetList("MID=" + mid + " and IsDeleted=0").FirstOrDefault();
                if (objAns != null)
                {
                    objAns.QId = long.Parse(Request.Form["ddlQuestion"]);
                    objAns.Answer = Request.Form["txtAnswer"];
                    new BLL.Sys_SQ_Answer().Update(objAns, MyHs);
                }
                else
                {
                    objAns = new Model.Sys_SQ_Answer();
                    objAns.QId = long.Parse(Request.Form["ddlQuestion"]);
                    objAns.Answer = Request.Form["txtAnswer"];
                    objAns.MID = mid;
                    objAns.IsDeleted = false;
                    objAns.CreatedBy = BLL.Member.ManageMember.TModel.MID;
                    objAns.CreatedTime = DateTime.Now;
                    objAns.Code = Guid.NewGuid().ToString();
                    objAns.Status = 1;
                    new BLL.Sys_SQ_Answer().Insert(objAns, MyHs);
                }
            }
        }
        /// <summary>
        /// 更新基本资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            string error = "";

            //if (string.IsNullOrWhiteSpace(MemberModel.Province))
            //{
            //    return "省不能为空";
            //}
            //if (string.IsNullOrWhiteSpace(MemberModel.City))
            //{
            //    return "市不能为空";
            //}

            if (BLL.WebBase.Model.TelVerify)
            {
                List<Model.Member> list = BllModel.GetMemberEntityList("Tel='" + Request.Form["txtTel"].Trim() + "' and MID<>'" + TModel.MID + "'");
                if (list.Count > 0)
                {
                    error += "该手机号码已被绑定";
                }
                else
                {
                    //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
                    ////if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()) && !TModel.Role.Super)
                    //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
                    //{
                    //    error += "手机验证码错误！";
                    //}
                }
            }
            if (string.IsNullOrEmpty(error))
            {
                
                Hashtable MyHs = new Hashtable();
                UpdateQuestion(MemberModel.ID,MyHs);
                BllModel.Update(MemberModel, MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_XGZL, "修改资料");
                    return "操作成功";
                }
                return "操作失败";
            }
            return error;
        }

    }
}