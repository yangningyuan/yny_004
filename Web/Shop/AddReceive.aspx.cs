using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.Shop
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

        //添加收货人，并保证只有一个默认收货人
        protected override string btnAdd_Click()
        {
            string sid = Request.Form["hidId"];
            Hashtable myHs = new Hashtable();
            Model.ReceiveInfo obj = null;
            if (string.IsNullOrEmpty(sid) || sid == "0")
            {
                //添加
                obj = ReceiveInfoModel;
                obj.MID = TModel.MID;
                BLL.ReceiveInfo.Insert(obj, myHs);
                if (obj.IsMain == true)
                {
                    BLL.ReceiveInfo.UpdateToNoMian(TModel.MID, "0");
                }

            }
            else
            {
                obj = ReceiveInfoModel;
                BLL.ReceiveInfo.Update(obj, myHs);
                if (obj.IsMain == true)
                {
                    BLL.ReceiveInfo.UpdateToNoMian(TModel.MID, obj.Id.ToString());
                }
            }
            if (BLL.CommonBase.RunHashtable(myHs))
            {
                var list = BLL.ReceiveInfo.GetList("IsDeleted=0 and MID='" + TModel.MID + "'");
                if (list.Where(c => c.IsMain == true).Count() <= 0)
                {
                    Model.ReceiveInfo info = list[0];
                    info.IsMain = true;
                    BLL.ReceiveInfo.Update(info);
                }
                return "操作成功";
            }
            return "操作失败";
        }
    }
}