using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using CommonBLL;

namespace yny_004.Web.Member
{
    public partial class ModifyMember : BasePage
    {
        protected Model.Member model;
        protected override void SetValue(string id)
        {
            Sys_BankInfoBLL sbiBLL = new Sys_BankInfoBLL();
            txtBank.DataSource = sbiBLL.GetList(" 1 = 1 and IsDeleted = 0 order by Code");
            txtBank.DataTextField = "Name";
            txtBank.DataValueField = "Name";
            txtBank.DataBind();

            BindDdlPwdQuestion(ddlQuestion);
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                ddlMemberType.Items.Add(new ListItem(item.RName, item.RType));//角色

            //会员级别
            ddlSHMoney.DataSource = BLL.Configuration.Model.SHMoneyTable;
            ddlSHMoney.DataTextField = "MAgencyName";
            ddlSHMoney.DataValueField = "MAgencyType";
            ddlSHMoney.DataBind();

            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            model = BllModel.GetModel(mid);
            MemberModel = model;
        }

        public Model.Member MemberModel
        {
            get
            {
                Model.Member model = BllModel.GetModel(Request.Form["txtMID"].Trim());
                model.MName = Request.Form["txtMName"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtPassword"].Trim()))
                {
                    model.Password = Request.Form["txtPassword"].Trim();
                }
                if (!string.IsNullOrEmpty(Request.Form["txtSecPsd"].Trim()))
                {
                    model.SecPsd = Request.Form["txtSecPsd"].Trim();
                }
                //model.Country = Request.Form["ddlRegion"];
                model.Province = Request.Form["ddlProvince"];
                model.City = Request.Form["ddlCity"];
                //model.Zone = Request.Form["ddlZone"];
                //model.Tel = Request.Form["txtTel"].Trim();
                //model.Email = Request.Form["txtEmail"].Trim();
                model.MTJ = Request.Form["txtMTJ"].Trim();
                model.MBD = model.MTJ;
                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                //model.MBD = Request.Form["txtMBD"].Trim();
                //model.WeChat = Request.Form["txtWeChat"];
                //model.Alipay = Request.Form["txtAlipay"];
                //model.MSH = Request.Form["txtMSH"].Trim();
                //model.MBDIndex = int.Parse(Request.Form["txtMBDIndex"].Trim() != "" ? Request.Form["txtMBDIndex"].Trim() : "0");
                model.RoleCode = Request.Form["ddlMemberType"];
                model.IsClose = Request.Form["chkIsClose"] == "on";
                model.IsClock = Request.Form["chkIsClock"] == "on";
                model.AgencyCode = Request.Form["ddlSHMoney"];
                //model.Address = Request.Form["txtAddress"];
                //model.NumID = Request.Form["txtNumID"];
                //model.Country = Request.Form["txtCountry"];
                //model.QQ = Request.Form["txtQQ"];
                if (!string.IsNullOrEmpty(Request.Form["txtPassword"].Trim()))
                {
                    model.Password = Request.Form["txtPassword"].Trim();
                    model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                }
                if (!string.IsNullOrEmpty(Request.Form["txtSecPsd"].Trim()))
                {
                    model.SecPsd = Request.Form["txtSecPsd"].Trim();
                    model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
                }
                if (model.MConfig != null)
                {
                    //model.MConfig.MJB = decimal.Parse(Request.Form["txtMJB"].Trim() != "" ? Request.Form["txtMJB"].Trim() : "0");
                    //model.MConfig.MHB = decimal.Parse(Request.Form["txtMHB"].Trim() != "" ? Request.Form["txtMHB"].Trim() : "0");
                    //model.MConfig.MCW = decimal.Parse(Request.Form["txtMCW"].Trim() != "" ? Request.Form["txtMCW"].Trim() : "0");
                    //model.MConfig.MGP = decimal.Parse(Request.Form["txtMGP"].Trim() != "" ? Request.Form["txtMGP"].Trim() : "0");
                    model.MConfig.JJTypeList = Request.Form["txtJJTypeList"].Trim();
                    model.MConfig.JTFHState = bool.Parse(Request.Form["ddlJTFHState"]);
                    model.MConfig.DTFHState = bool.Parse(Request.Form["ddlDTFHState"]);
                    model.MConfig.TXStatus = Request.Form["cbkIsTX"] == "1";
                    model.MConfig.ZZStatus = Request.Form["chkIsZZ"] == "1";

                    //model.MConfig.GQCount = int.Parse(Request.Form["txtGQCount"]);
                    //model.MConfig.HLGQCount = int.Parse(Request.Form["txtHLGQCount"]);
                }
                return model;
            }
            set
            {
                if (value != null)
                {
                    //ddlRegion.Value = value.Country;
                    ddlProvince.Items.Add(value.Province);
                    ddlCity.Items.Add(value.City);
                    //ddlZone.Items.Add(value.Zone);
                    //txtEmail.Value = value.Email;
                    txtMID.Value = value.MID;
                    txtMName.Value = value.MName;
                    //txtTel.Value = value.Tel;
                    txtMTJ.Value = value.MTJ;
                    txtBank.Value = value.Bank;
                    txtBranch.Value = value.Branch;
                    txtBankCardName.Value = value.BankCardName;
                    txtBankNumber.Value = value.BankNumber;

                    //txtMBD.Value = value.MBD;
                    //txtWeChat.Value = value.WeChat;
                    //txtAlipay.Value = value.Alipay;
                    //txtMSH.Value = value.MSH;
                    //txtNumID.Value = value.NumID;
                    //txtQQ.Value = value.QQ;
                    //txtAddress.Value = value.Address;
                    ddlMemberType.Value = value.RoleCode.ToString();
                    chkIsClock.Checked = value.IsClock;
                    chkIsClose.Checked = value.IsClose;
                    //txtMBDIndex.Value = value.MBDIndex.ToString();
                    ddlSHMoney.Value = value.AgencyCode.ToString();
                    if (value.MConfig != null)
                    {
                        //txtMHB.Value = value.MConfig.MHB.ToString();
                        //txtMJB.Value = value.MConfig.MJB.ToString();
                        //txtMCW.Value = value.MConfig.MCW.ToString();
                        //txtMGP.Value = value.MConfig.MGP.ToString();
                        txtJJTypeList.Value = value.MConfig.JJTypeList;
                        ddlDTFHState.Value = value.MConfig.DTFHState.ToString();
                        ddlJTFHState.Value = value.MConfig.JTFHState.ToString();
                        chkIsZZ.Checked = value.MConfig.ZZStatus;
                        cbkIsTX.Checked = value.MConfig.TXStatus;

                        //txtHLGQCount.Value = value.MConfig.HLGQCount.ToString();
                        //txtGQCount.Value = value.MConfig.GQCount.ToString();
                    }

                    ////绑定会员的密保问题
                    //Model.Sys_SQ_Answer objAns = new BLL.Sys_SQ_Answer().GetList("MID=" + value.ID + " and IsDeleted=0").FirstOrDefault();
                    //if (objAns != null)
                    //{
                    //    ddl_PwdQuestion.Value = objAns.QId.ToString();
                    //    pwdAnswer.Value = objAns.Answer;
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
            Hashtable MyHs = new Hashtable();
            if (Request.Form["chkCloseAll"] == "on" || Request.Form["chkClockAll"] == "on")
            {
                string where = "";
                if (Request.Form["chkCloseAll"] == "on")
                    where += string.Format(" IsClose = {0} ", (MemberModel.IsClose ? 1 : 0));
                if (Request.Form["chkClockAll"] == "on")
                    where += string.Format(" IsClock = {0} ", (MemberModel.IsClock ? 1 : 0));
                if (!string.IsNullOrEmpty(where))
                {
                    MyHs.Add(string.Format("update Member set {0} where MID in (select mid from [dbo].[getSubBDMember]('{1}'))", where, MemberModel.MID), null);
                }
                //List<Model.Member> list = BllModel.GetMemberEntityList("MID in (select mid from getTreeBuyMID('" + MemberModel.MID + "'))");
                //foreach (Model.Member item in list)
                //{
                //    if (Request.Form["chkCloseAll"] == "on")
                //        item.IsClose = MemberModel.IsClose;
                //    if (Request.Form["chkClockAll"] == "on")
                //        item.IsClock = MemberModel.IsClock;
                //    BllModel.Update(item, MyHs);
                //}
            }

            BllModel.Update(MemberModel, MyHs);
            //string error = BLL.Member.CanSetAgency(MemberModel);
            //if (!string.IsNullOrEmpty(error))
            //{
            //    return error;
            //}
            //MyHs.Add(" update member set MSH = '" + MemberModel.MID + "' where  " + BLL.Member.GetLeaderCondition(MemberModel) + " and MID <> '" + MemberModel.MID + "'", null);
            if (MemberModel.Role.IsAdmin)
            {
                UpdateQuestion(MemberModel.ID, MyHs);
            }
            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_XGHYZL, string.Format("修改{0}的资料", MemberModel.MID));

                return "操作成功";
            }
            return "操作失败";
        }
    }
}