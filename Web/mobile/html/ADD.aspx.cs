using CommonBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class ADD : BasePage
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
                //model.Bank = Request.Form["txtBank"];
                //model.Branch = Request.Form["txtBranch"];
                //model.BankCardName = Request.Form["txtBankCardName"];
                //model.BankNumber = Request.Form["txtBankNumber"];
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
                //model.Province = Request.Form["ddlProvince"].Trim();
                //model.City = Request.Form["ddlCity"].Trim();
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
    }
}