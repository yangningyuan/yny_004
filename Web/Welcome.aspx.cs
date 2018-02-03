using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web
{
    public partial class Welcome : BasePage
    {
        public Model.Monitor model = new Model.Monitor();
        protected override void SetPowerZone()
        {
            model = BLL.Monitor.GetMonitor();
        }
    }
}