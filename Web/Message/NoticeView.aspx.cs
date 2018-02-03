using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Message
{
    public partial class NoticeView : BasePage
    {
        public Model.Notice model;
        protected override void SetValue(string id)
        {
            model = BLL.Notice.Select(int.Parse(id), true);
        }
    }
}