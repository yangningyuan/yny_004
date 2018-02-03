using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Message
{
    public partial class NoticeAdd : BasePage
    {
        private Model.Notice NoticeModel
        {
            get
            {
                Model.Notice model = new Model.Notice();
                model.NTitle = Request.Form["txtNTitle"];
                model.NContent = HttpUtility.UrlDecode(Request.Form["hdContent"]);
                if (!string.IsNullOrEmpty(Request.Form["hdchkFixed"]))
                    model.IsFixed = bool.Parse(Request.Form["hdchkFixed"]);
                else
                    model.IsFixed = false;
                return model;
            }
        }

        protected override string btnAdd_Click()
        {
            if (BLL.Notice.Add(NoticeModel))
            {
                return "操作成功";
            }
            return "操作失败";
        }
    }
}