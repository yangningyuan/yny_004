using System;
using System.Collections.Generic;
using System.Web;

namespace yny_004.Web.AjaxM
{
    /// <summary>
    /// Regedit 的摘要说明
    /// </summary>
    public class Regedit : IHttpHandler
    {

        public Model.Member MemberMode
        {
            get
            {
                Model.Member model = new Model.Member();
                model.MID = _context.Request.Form["txtTel"].Trim();
                model.MName = _context.Request.Form["txtMName"].Trim();
                model.Password = _context.Request.Form["txtPassword"].Trim();
                model.SecPsd = _context.Request.Form["txtSecPsd"].Trim();
                model.Tel = _context.Request.Form["txtTel"].Trim();
                model.RoleCode = "Notactive";
                model.AgencyCode = "001";
                model.MAgencyType = BLL.Configuration.Model.SHMoneyList[model.AgencyCode];
                model.IsClock = false;
                model.IsClose = false;
                model.MState = false;
                model.MTJ = _context.Request.Form["txtMTJ"];
                //if (model.MTJ == "0")
                //{
                //    model.MTJ = BLL.Member.ManageMember.TModel.MID;
                //}
                //model.MBDIndex = int.Parse(Request.Form["ddlMBDIndex"]);
                model.MBD = model.MTJ;
                //model.MBD = Request.Form["txtMBD"];
                //model.MSH = Request.Form["txtMSH"];
                model.MSH = "";
                model.Bank = _context.Request.Form["txtBank"];
                model.Branch = _context.Request.Form["txtBranch"];
                model.BankCardName = _context.Request.Form["txtBankCardName"];
                model.BankNumber = _context.Request.Form["txtBankNumber"];
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
                //model.Country = _context.Request.Form["txtCountry"];
                model.Province = _context.Request.Form["ddlProvince"].Trim();
                model.City = _context.Request.Form["ddlCity"].Trim();
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
                model.Bank = _context.Request.Form["txtBank"];
                model.BankCardName = _context.Request.Form["txtBankCardName"];
                model.BankCreateDate = DateTime.Now;
                model.BankNumber = _context.Request.Form["txtBankNumber"];
                model.Branch = _context.Request.Form["txtBranch"];
                model.MID = _context.Request.Form["txtMID"];
                model.IsPrimary = true;
                return model;
            }
        }

        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string error = "";
            _context = context;

            if (!BLL.CommonBase.TestSql(_context.Request.QueryString.ToString() + _context.Request.Form.ToString()))
            {
                context.Response.Write("非法关键字符");
                return;
            }

            List<Model.Member> list = BLL.Member.ManageMember.GetMemberEntityList("Tel='" + _context.Request.Form["txtTel"].Trim() + "'");
            if (list.Count >= BLL.Configuration.Model.E_BbinMaxCount)
            {
                error += "该手机号码已被绑定";
            }
            else
            {
                string code = BLL.SMS.GetSKeyBuyTel(_context.Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
                if ((string.IsNullOrEmpty(code) || code != _context.Request.Form["txtTelCode"].Trim()))
                {
                    error += "手机验证码错误！";
                }
            }
            if (!string.IsNullOrEmpty(error))
            {
                context.Response.Write(error);
                return;
            }

            Model.Member membermode = MemberMode;

            //if (membermode.MName != membermode.BankCardName)
            //{
            //    context.Response.Write("开户姓名必须与会员姓名一直");
            //    return;
            //}
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
                //objAnswer.QId = long.Parse(_context.Request.Form["ddlQuestion"]);
                //objAnswer.Answer = _context.Request.Form["txtAnswer"];
                //objAnswer.CreatedBy = model.MID;
                //if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                //{
                    context.Response.Write("注册成功");
                    return;
                //}
            }
            context.Response.Write(error);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}