using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class ReceiveInfo : BasePage
    {
        protected override string btnOther_Click()
        {
            string where = string.Format(" IsDeleted=0 and MID = '{0}'   ", TModel.MID);
            var list = BLL.ReceiveInfo.GetList(where, CurrentPage, ItemsPerPage, out totalCount).Select(item => new
            {
                ID = item.Id,
                Name = item.Receiver,
                Tel = item.Tel,
                Address = item.Province + item.City + item.Zone + "<br/>" + item.Address,
                State = item.IsMain ? "是" : "否",
                op = getStringCZ(item)
            });
            return jss.Serialize(new { Items = list, TotalCount = totalCount });
        }

        private string getStringCZ(Model.ReceiveInfo offer)
        {
            string op = "";
            op += "<input type='button' value='修改' class='btn btn-success btn-sm' onclick=\"pcallhtml('/mobile/html/AddReceive.aspx?id=" + offer.Id + "', '新增收货人');\" /><br/>";
            op += "<input type='button' value='删除' class='btn btn-success btn-sm' onclick='delreceive(" + offer.Id + ")' /><br/>";
            return op;
        }

        protected override string btnModify_Click()
        {
            string id = Request.QueryString["id"];
            if (BLL.ReceiveInfo.Delete(id))
            {
                return "删除成功";
            }
            else {
                return "删除失败，数据错误";
            }

        }
    }
}