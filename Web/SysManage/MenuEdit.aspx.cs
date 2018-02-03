using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.SysManage
{
    public partial class MenuEdit : BasePage
    {
      
        protected override void SetPowerZone()
        {
          
            BindRoles();
            BindCFID();
            string id = Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(id))
            {
                menu = BLL.Contents.GetModel(id);
                txtCID.Attributes.Add("readonly", "readonly");
                ddlCFID.Items.FindByValue(hidCFID.Value).Selected = true;
            }
         
        }
     
        protected void BindRoles()
        {
            rep_Role.DataSource = BLL.Roles.GetList("");
            rep_Role.DataBind();
        }
        protected void BindCFID()
        {
            ddlCFID.DataSource = BLL.Contents.List.Where(c => c.CFID == "0");
            ddlCFID.DataTextField = "CTitle";
            ddlCFID.DataValueField = "CID";
            ddlCFID.DataBind();
            ddlCFID.Items.Insert(0,new ListItem("无","0"));
        }

        private Model.Contents menu
        {
            get
            {
                Model.Contents model = null;
                if (string.IsNullOrEmpty(Request.Form["hidId"]))
                {
                    model = new Model.Contents();
                    model.CState = true;
                    model.VState = true;
                    model.CID = Request.Form["txtCID"];
                }
                else
                {
                    model = BLL.Contents.GetModel(Request.Form["hidId"]);
                }
                model.CFID = Request.Form["ddlCFID"];
                model.Remark = Request.Form["hidPicUrl"];
                model.CTitle = Request.Form["txtName"];
                model.CImage = Request.Form["txtCImage"];
                model.CAddress = Request.Form["txtCAddress"];
                model.CIndex = string.IsNullOrEmpty(Request.Form["txtSort"]) ? 0 : int.Parse(Request.Form["txtSort"]);
                model.IsQuickMenu = !string.IsNullOrEmpty(Request.Form["chkStatus"]);
                model.IsOuterLink = !string.IsNullOrEmpty(Request.Form["chkIsOuterLink"]);
                if (model.IsOuterLink)
                {
                    model.OuterAddress = Request.Form["txtOuterAddress"];
                }

                return model;
            }
            set
            {
                txtName.Value = value.CTitle;
                txtCAddress.Value = value.CAddress;
                chkStatus.Checked = value.IsQuickMenu;
                hidId.Value = value.CID.ToString();
                txtSort.Value = value.CIndex.ToString();
                txtCID.Value = value.CID;
                iMenuIcon.Attributes.Add("class","fa "+value.CImage);
                txtCImage.Value = value.CImage;
                hidCFID.Value = value.CFID;
                hidPicUrl.Value = value.Remark;
                bigPngImg.Src = value.Remark;
                if (value.CLevel == 1)
                {
                    chkStatus.Attributes.Add("disabled", "disabled");
                }

                chkIsOuterLink.Checked = value.IsOuterLink;
                txtOuterAddress.Value = value.OuterAddress;
            }

        }

        protected override string btnAdd_Click()
        {
            bool isSave = false;
            if (string.IsNullOrEmpty(Request.Form["hidId"]))
            {
                isSave = true;
            }
            if (BLL.Contents.SaveOrUpdate(menu, isSave))
            {
                //设置权限
                if (isSave)
                    BLL.RolePowers.BatchInsert(rolePowersList());
                else
                    BLL.RolePowers.BatchUpdate(rolePowersList(), menu.CID);
                return "操作成功";
            }
            return "操作失败";
        }
        protected List<Model.RolePowers> rolePowersList()
        {
            List<Model.RolePowers> list = new List<Model.RolePowers>();
            string roleList = Request.Form["chkAuth"];
            if (!string.IsNullOrEmpty(roleList))
            {
                string[] array = roleList.Split(',');
                foreach (string str in array)
                {
                    Model.RolePowers obj = new Model.RolePowers();
                    obj.CID = menu.CID;
                    obj.IFVerify = true;
                    obj.RType = str;
                    list.Add(obj);
                }
            }
            return list;
        }

        protected string GetCheckedStatue(object rtype)
        {
            var list = BLL.RolePowers.GetList("RType='" + rtype + "' and RolePowers.CID='" + Request.QueryString["Id"] + "'");
            if (list != null && list.Count > 0)
            {
                return "checked='checked'";
            }
            else
                return "";
        }

    }
}