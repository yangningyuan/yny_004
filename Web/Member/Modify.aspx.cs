﻿using System;
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

                    
                    model.QRCode = Request.Form["txtQRCode"];
                }
				model.Alipay = Request.Form["txtAlipay"];
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

                        
                        txtQRCode.Value = value.QRCode;
                    }
					txtAlipay.Value = value.Alipay;
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

        protected override string btnAdd_Click()
        {
			int qdcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select count(*) from changemoney where tomid='" + TModel.MID + "' and changetype='R_QD' "));

			if (qdcount <= 0)
            {
				if (qdcount >= BLL.Configuration.Model.E_BbinTimes)
				{
					return "已达到最大签到次数";
				}
				
                Hashtable MyHs = new Hashtable();
                BLL.ChangeMoney.HBChangeTran(BLL.Configuration.Model.E_DayFHFloat, BLL.Member.ManageMember.TModel.MID, TModel.MID, "R_QD", null, "MHB", "", MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                    return "签到成功"+ BLL.Configuration.Model.E_DayFHFloat+"元";
                else
                    return "签到失败";
            }
            else
            {
                return "您已签到";
            }
            
        }
        protected object qhbobj = new object();

        protected override string btnOther_Click()
        {
            lock (qhbobj)
            {
                if (BLL.ChangeMoney.EnoughChange(TModel.MID, BLL.Configuration.Model.E_TJFloat, "MHB"))
                {
					//if (TModel.MConfig.MCW <= 0)
					//	return "红包余额不足";
                    Hashtable MyHs = new Hashtable();
                    BLL.ChangeMoney.KFMoneyChange(TModel.MID,BLL.Member.ManageMember.TModel.MID,BLL.Configuration.Model.E_TJFloat,"MHB",MyHs);
                    Random r = new Random();
                    int i = r.Next(BLL.Configuration.Model.E_TZMin, BLL.Configuration.Model.E_TZMax);                    
                    decimal x = (decimal)i;

					if (x >= BLL.Configuration.Model.E_TZMin && x < BLL.Configuration.Model.B_TBTJDate)
					{
						i = r.Next(BLL.Configuration.Model.B_TBTJDate, BLL.Configuration.Model.E_TZMax);
						x = (decimal)i;
					}
					else {
						i = r.Next(BLL.Configuration.Model.E_TZMin, BLL.Configuration.Model.B_TBTJDate);
						x = (decimal)i;
					}

					int t = r.Next(0, 9);
					decimal xt = (decimal)t/10;

					decimal money = 0;
					if ((x + xt) > BLL.Configuration.Model.E_TZMax)
					{
						money = x;
					}
					else
					{
						money = x + xt;
					}
                    if (BLL.Configuration.Model.E_TZMax < money)
                    {
                        money = BLL.Configuration.Model.E_TZMax;
                    }
                    //TModel.MConfig.MCW -= money;
                    //BLL.Member.UpdateConfigTran(TModel.MID,"MCW","-"+money.ToString(),null,false,System.Data.SqlDbType.Decimal,MyHs);
                    if (money <= 0)
                        return "呵呵哒";
					decimal yue = money * BLL.Configuration.Model.E_BbinMoney;
					decimal gpft = money * BLL.Configuration.Model.E_BbinFHFloat;
					TModel.MConfig.MHB += yue;
					BLL.Member.UpdateConfigTran(TModel.MID, "MHB", "+" + yue.ToString(), null, false, System.Data.SqlDbType.Decimal, MyHs);
					TModel.MConfig.MJB += gpft;
					BLL.Member.UpdateConfigTran(TModel.MID, "MJB", "+" + gpft.ToString(), null, false, System.Data.SqlDbType.Decimal, MyHs);

					Model.LuckyMoney luck = new Model.LuckyMoney();
					luck.MID = TModel.MID;
					luck.isValid = 0;
					luck.ApplyMoney = money;
					luck.CreateTime = DateTime.Now;
					luck.EditTime = DateTime.Now;
					BLL.LuckyMoney.Add(luck, MyHs);
					if (BLL.CommonBase.RunHashtable(MyHs))
						return money.ToString();
					else
						return "未重载...";

				}
                else
                {
                    return "余额不足";
                }
            }
        }
    }
}