using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class UpMAgencyType : BasePage
    {
        protected string MyMAgencyTypeRdo;
        protected string MAgencyTypeColor;
        protected decimal maxUpMAgency;
        protected Model.Member sjmodel;
        protected override void SetValue(string id)
        {
            sjmodel = BllModel.GetModel(id);
            hdmid.Value = sjmodel.MID;
        }
        protected override void SetValue()
        {
            sjmodel = TModel;
            hdmid.Value = sjmodel.MID;
        }
        protected override void SetPowerZone()
        {
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.Where(emp => emp.MAgencyType != "001"))
            {
                MAgencyTypeColor += "<td style='width:60px;color:#00CCFF;'>" + item.MAgencyName + "<br />[" + item.Money + "]</td>";
                if (item.Money < sjmodel.MAgencyType.Money || !BLL.ChangeMoney.EnoughChange(TModel.MID, item.Money - sjmodel.MAgencyType.Money, "MHB"))
                    continue;
                else
                    MyMAgencyTypeRdo += "<input name='AgencyTypeList' id='" + item.MAgencyType + "' value='" + item.MAgencyType + "' type='radio' checked=\"checked\" />" + item.MAgencyName + "[" + (item.Money - sjmodel.MAgencyType.Money) + "]&nbsp;";
            }
            if (string.IsNullOrEmpty(MyMAgencyTypeRdo))
            {
                MyMAgencyTypeRdo += "暂不可升级";
                //btn.Visible = false;
            }
                
        }
    }
}