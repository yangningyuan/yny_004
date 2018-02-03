using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class HKChangeWY : BasePage
    {
        protected string adminBank = "";
        protected string adminBranch = "";
        protected string adminBankNumber = "";
        protected string adminBankCardName = "";
        protected string alipay = "";
        protected string weixin = "";
        protected string alipayname = "";


        protected string mantissa = "";
        protected string code = "";

        protected Dictionary<string, Model.Reward> ListReward = BLL.Reward.List;

        private string GetMantissa()
        {
            string ss = "";
            Random r = new Random();
            int count = r.Next(0, 100);
            if (count < 10)
            {
                ss = "0" + count;
            }
            else
            {
                ss = "" + count;
            }
            return ss;
        }
        /// <summary>
        /// 随机立减1-3
        /// </summary>
        /// <returns></returns>
        public string GetRanLJ()
        {
            string ss = "";
            Random r = new Random();
            int count = r.Next(1, 4);
            //if (count < 10)
            //{
            //    ss = "0" + count;
            //}
            //else
            //{
            //    ss = "" + count;
            //}
            return count.ToString();
        }

        private string GetHKCode()
        {
            string ss = "";
            Random r = new Random();
            do
            {
                int count = r.Next(0, 1000000);
                ss = "" + count;
                ss = ss.PadLeft(6, '0');
            } while (BLL.HKModel.Exist(ss));
            return ss;
        }

        protected override void SetPowerZone()
        {
            bankauto.Value = string.IsNullOrEmpty(TModel.BankNumber) ? "0" : "1";
            getsuiji.Value = GetRanLJ();
            mantissa = GetMantissa();
            Session["mantissa"] = mantissa;
            //code = GetHKCode();
            //Session["code"] = code;

            //txtTel.Value = TModel.Tel;
            //RioMJB.Checked = true;
            //foreach (Model.BankModel item in BLL.Member.ManageMember.GetMyBankInfo())
            //{
            //    ddlToBank.Items.Add(item.Bank);
            //}
            //Model.Member model = TModel;
            //txtBankName.Value = model.BankCardName;
            //txtFromBank.Value = model.Bank;
            //txtHKDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            Model.Member manage = BllModel.GetModel(BLL.Member.ManageMember.TModel.MID);
            try
            {
                adminBank = manage.Bank;
                adminBranch = manage.Branch;
                adminBankNumber = manage.BankNumber;
                adminBankCardName = manage.BankCardName;
                alipayname = manage.QRCode;
                alipay = manage.Alipay;
                weixin = manage.WeChat;
            }
            catch
            {
            }
        }

        private Model.HKModel HKModel
        {
            get
            {
                Model.HKModel model = new Model.HKModel();
                model.HKCreateDate = DateTime.Now;
                model.BankName = Request.Form["txtBankName"];
                model.FromBank = Request.Form["txtFromBank"];
                model.HKDate = DateTime.Now;// DateTime.Parse(Request.Form["txtHKDate"]);
                model.HKState = false;
                //model.HKType = int.Parse(Request.Form["RioHK"]);
                model.HKType = 1;
                model.MID = TModel.MID;
                model.RealMoney = decimal.Parse(Request.Form["txtRealMoney"]) - Convert.ToDecimal(Request.Form["getsuiji"]) + Convert.ToDecimal(Session["mantissa"]) / 100;
                //model.ToBank = Request.Form["ddlToBank"];
                model.ValidMoney = decimal.Parse(Request.Form["txtRealMoney"]) / BLL.Configuration.Model.B_InFloat;
                model.IsAuto = false;
                model.MajorKey = Request.Form["txtTel"];
                return model;
            }
        }

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            string error = GetBank(TModel);
            if (!string.IsNullOrEmpty(error))
            {
                return "请先完善资料";
            }

            if (Session["mantissa"] == null)
            {
                return "页面过期,请刷新页面";
            }

            Model.HKModel model = HKModel;

            if (model.ValidMoney < 100)
            {
                return "最少充值100";
            }

            if (BLL.HKModel.Insert(model))
            {
                Session["code"] = null;
                Session["mantissa"] = null;
                BLL.Task.SendManage(TModel, "001", "会员账号：" + TModel.MID + "于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "确认汇款信息，请注意查收，并及时审核！");
                return "操作成功，请等待财务审核";
            }
            return "操作失败";
        }
    }
}