using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class TJList : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = " 1=1 and MTJ='"+TModel.MID+"' ";
           
            string mkey = "";
            mkey = TModel.MID;
           
            List<Model.Member> listchange = null;

            listchange=BllModel.GetMemberEntityList(where, CurrentPage, ItemsPerPage, out totalCount);

            var list = listchange.Select(item => new
            {

                MID = item.MID,
                MHB = item.MConfig.MHB,
                MJB= item.MConfig.MJB,
                Date = item.MState?item.MDate.ToString("yyyy-MM-dd"):item.MCreateDate.ToString("yyyy-MM-dd"),

            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }
    }
}