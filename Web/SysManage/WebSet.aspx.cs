using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.SysManage
{
    public partial class WebSet : BasePage
    {
        protected Model.WebSetInfo SetInfo
        {
            get
            {
                Model.WebSetInfo model = BLL.WebSetInfo.Model;
                model.CloseInfo = Request.Form["txtCloseInfo"];
                model.HKInfo = Request.Form["txtHKInfo"];
                model.OpenTimeStr = Request.Form["txtOpenTimeStr"];
                model.TXInfo = Request.Form["txtTXInfo"];
                model.WCopyright = Request.Form["txtWCopyright"];
                model.WDescription = Request.Form["txtWDescription"];
                model.WebState = bool.Parse(Request.Form["rdoState"]);
                model.WebTitle = Request.Form["txtWebTitle"];
                model.WKeyword = Request.Form["txtWKeyword"];
                model.PageSize = int.Parse(Request.Form["txtPageSize"]);
                return model;
            }
            set
            {
                txtCloseInfo.Value = value.CloseInfo;
                txtHKInfo.Value = value.HKInfo;
                txtOpenTimeStr.Value = value.OpenTimeStr;
                txtTXInfo.Value = value.TXInfo;
                txtWCopyright.Value = value.WCopyright;
                txtWDescription.Value = value.WDescription;
                txtWebTitle.Value = value.WebTitle;
                txtWKeyword.Value = value.WKeyword;
                rdoOpen.Checked = value.WebState;
                rdoClose.Checked = !value.WebState;
                txtPageSize.Value = value.PageSize.ToString();
            }
        }
        protected override void SetValue()
        {
            SetInfo = BLL.WebSetInfo.Model;
        }
        protected override string btnModify_Click()
        {
            if (BLL.WebSetInfo.Update(SetInfo))
                return "操作成功";
            return "操作失败";
        }
    }
}