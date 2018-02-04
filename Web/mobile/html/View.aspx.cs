using CommonBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class View : BasePage
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
                    btn.Visible = false;
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
            BindDdlPwdQuestion(ddlQuestion);
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

                if (string.IsNullOrEmpty(model.BankCardName))
                {
                    model.BankCardName = Request.Form["txtBankCardName"];
                }

                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankNumber = Request.Form["txtBankNumber"];
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

                    txtMName.Value = value.MName;
                    //txtTel.Value = value.Tel;

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
    }
}