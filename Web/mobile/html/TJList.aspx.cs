using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class TJList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 and MTJ='"+TModel.MID+"' ";
           
            string mkey = "";
            mkey = TModel.MID;
           
            List<Model.Member> listchange = null;

            listchange=BllModel.GetMemberEntityList(where, CurrentPage, ItemsPerPage, out totalCount);

            var list = listchange.Select(item => new
            {

                MID = item.MID,
                MHB = item.MConfig.MHB,
                MJB= item.MConfig.MJB,
                Date = item.MState?item.MDate.ToString("yyyy-MM-dd"):item.MCreateDate.ToString("yyyy-MM-dd"),
                op = getStringCZ(item)
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

        private string getStringCZ(Model.Member member)
        {
            string op = "";
            if (member.MState)
            {
                op += "已激活";
            }
            else
            {
                op += "<a class='button-success' href='javascript:void(0)' value='激活'  onclick=\"upmember('" + member.MID + "')\">激活</a>";
            }
            return op;
        }

        protected override string btnAdd_Click()
        {
            Model.Member member = BLL.Member.GetModelByMID(Request.QueryString["mid"]);
            if (member != null && !member.MState && member.MTJ == TModel.MID)
            {
                Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList["002"];
                Hashtable MyHs = new Hashtable();
                return BllModel.UpMAgencyType(shmoney, member.MID,"MHB", TModel, shmoney.Money - member.MConfig.SHMoney);
            }
            else {
                return "没有此账号或此账号已激活";
            }
        }
    }
}