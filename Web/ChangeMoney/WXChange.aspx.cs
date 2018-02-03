using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.ChangeMoney
{
    public partial class WXChange : BasePage
    {
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
                model.RealMoney = decimal.Parse(Request.Form["txtRealMoney"]);
                //model.ToBank = Request.Form["ddlToBank"];
                model.ValidMoney = decimal.Parse(Request.Form["txtRealMoney"]) / BLL.Configuration.Model.B_InFloat;
                model.IsAuto = false;
                model.Remark = Request.Form["uploadurl"] ;
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

            //if (Session["mantissa"] == null)
            //{
            //    return "页面过期,请刷新页面";
            //}

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