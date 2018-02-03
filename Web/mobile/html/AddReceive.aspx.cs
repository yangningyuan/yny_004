using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class AddReceive : BasePage
    {
        protected override void SetPowerZone()
        {

        }
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            ReceiveInfoModel = BLL.ReceiveInfo.GetModel(mid);

        }

        public Model.ReceiveInfo ReceiveInfoModel
        {
            get
            {
                Model.ReceiveInfo model = null;
                string sid = Request.Form["hidId"];
                if (string.IsNullOrEmpty(sid) || sid == "0")
                {
                    model = new Model.ReceiveInfo();
                    model.IsDeleted = false;
                    model.Status = 1;
                }
                else
                {
                    model = BLL.ReceiveInfo.GetModel(sid);
                }
                model.Address = Request.Form["txtAddress"].Trim();
                model.Receiver = Request.Form["txtReceive"].Trim();
                model.City = Request.Form["ddlCity"].Trim();
                model.Zone = Request.Form["ddlZone"].Trim();
                model.Province = Request.Form["ddlProvince"].Trim();
                model.ZipCode = Request.Form["txtZipCode"];
                model.Phone = Request.Form["txtPhone"];
                model.Tel = Request.Form["txtTel"];
                model.IsMain = Request.Form["chkIsMain"] == "1";
                return model;
            }
            set
            {
                if (value != null)
                {
                    txtAddress.Value = value.Address;
                    ddlProvince.Items.Add(value.Province);
                    ddlCity.Items.Add(value.City);
                    ddlZone.Items.Add(value.Zone);
                    txtReceive.Value = value.Receiver;
                    txtZipCode.Value = value.ZipCode;
                    txtTel.Value = value.Tel;
                    txtPhone.Value = value.Phone;
                    chkIsMain.Checked = value.IsMain;
                    hidId.Value = value.Id.ToString();
                }
            }
        }
    }
}