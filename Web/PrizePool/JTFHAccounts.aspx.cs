using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.PrizePool
{
    public partial class JTFHAccounts : BasePage
    {
        protected string fhzz = "";
        protected override void SetValue()
        {
            var model = new BLL.ZFHTable().GetModel();
            if (model.FHState == 0)
            {
                fhzz = "等待提交任务";
            }
            else if (model.FHState == 1)
            {
                fhzz = "等待执行";
            }
            else
            {
                fhzz = "正在执行";
            }
            //txtTotalYj.Value = BLL.ChangeMoney.GetDayFHMoney("", "'SH'", null, DateTime.Now.GetWeekFirstDayMon()).ToFixedString();
            //txtTotalMember.Value = Convert.ToInt32(BLL.CommonBase.GetSingle(string.Format("select count(MID) from member left join ( select ToMID,sum(money) totalMoney from changemoney where 1 = 1 and changetype in ({0}) group by ToMID ) a on member.mid = a.tomid where MState = 1 and AgencyCode <> '001' and RoleCode in ('Nomal','VIP') and totalmoney is null or totalmoney < shmoney * {1}", BLL.Reward.AllRewardStr, BLL.Configuration.Model.E_JQFHFloat))).ToString();
        }

        private Model.Accounts FHTModel
        {
            get
            {
                Model.Accounts model = new Model.Accounts();
                model.CreateDate = DateTime.Now;
                model.IsAuto = false;
                model.PCode = "003";

                return model;
            }
        }

        protected override string btnAdd_Click()
        {
            return "操作失败";
        }

        protected override string btnModify_Click()
        {
            if (BLL.ChangeMoney.R_DFH())
            {
                BLL.OperationRecordBLL.Add(TModel.MID, ChangeType.O_JTFH, "静态分红");
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }

        protected override string btnOther_Click()
        {
            if (BLL.ChangeMoney.TX())
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}