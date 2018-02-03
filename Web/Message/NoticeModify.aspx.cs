using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Message
{
    public partial class NoticeModify : BasePage
    {
        protected string txtNContent = "";
        protected override void SetValue(string id)
        {
            NoticeModel = BLL.Notice.Select(int.Parse(id), false);
        }

        private Model.Notice NoticeModel
        {
            get
            {
                Model.Notice model = new Model.Notice();
                model.NTitle = Request.Form["txtNTitle"];
                model.NContent = HttpUtility.UrlDecode(Request.Form["hdContent"]);
                model.ID = int.Parse(Request.Form["lbID"]);
                model.NState = true;
                if (!string.IsNullOrEmpty(Request.Form["hdchkFixed"]))
                    model.IsFixed = bool.Parse(Request.Form["hdchkFixed"]);
                else
                    model.IsFixed = false;
                return model;
            }
            set
            {
                lbID.Value = value.ID.ToString();
                txtNTitle.Value = value.NTitle;
                txtNContent = value.NContent;
                chkFixed.Checked = value.IsFixed;
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.Notice.Update(NoticeModel))
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}