using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web
{
    public partial class Error : BasePage
    {
        protected new void Page_Load(object send, EventArgs e)
        {
            if (!WebModel.WebState || !TestCloseTime())
            {
            }
            else
            {
                Response.Write("<script>window.top.location.href='/Default.aspx'</script>");
            }

        }

        private bool TestCloseTime()
        {
            string nowDate = DateTime.Now.ToString("yyyy-MM-dd ");
            foreach (string time in WebModel.OpenTimeList)
            {
                string[] times = time.Split('-');
                if (DateTime.Parse(nowDate + times[0]) < DateTime.Now && DateTime.Parse(nowDate + times[1]) > DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}