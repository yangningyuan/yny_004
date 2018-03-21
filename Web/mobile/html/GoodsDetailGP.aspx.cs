using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class GoodsDetailGP : BasePage
    {
        protected Model.Goods model;
        protected List<Model.GoodsPic> listpic = null;
        protected string mtype = "";
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            hidId.Value = mid;
            remid.Value = TModel.MID;
            model = BLL.Goods.GetModel(mid);
            var list = BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + model.GoodsCode + "'");
            listpic = list;
            rep_PicList.DataSource = list;
            rep_PicList.DataBind();

        }

        protected override void SetPowerZone()
        {
            int recount= Convert.ToInt32( BLL.CommonBase.GetSingle(" select COUNT(*) from ReceiveInfo where MID='"+TModel.MID+"' and IsDeleted=0 and Status=1 and IsMain=1; "));
            isautoreceive.Value = recount > 0 ? "1" : "0";
            mtype = "<input id=\"rdoXFB\" value=\"MGP\" type=\"radio\" name=\"rdo\" checked=\"checked\" style=\"width: 5%;\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MGP"].RewardName+"<span style='color:red;'>["+TModel.MConfig.MGP+ "]</span>" + "</label><input id=\"rdoXFB\" value=\"MJB\" type=\"radio\" name=\"rdo\"  style=\"width: 5%;\"/><label for=\"wx\">" + yny_004.BLL.Reward.List["MJB"].RewardName + "&nbsp;<span style='color:red;'>[" + TModel.MConfig.MJB+"]</span>" + "</label>";
            //mtype = "<option selected=\"selected\" value=\"MGP\">" + yny_004.BLL.Reward.List["MGP"].RewardName + "</option><option value=\"MJB\">" + yny_004.BLL.Reward.List["MJB"].RewardName + "</option>";
        }

        protected string GetCategory(string code)
        {
            Model.GoodCategory goodC = BLL.GoodCategory.GetModelByCode(code);
            if (goodC != null)
            {
                return goodC.Name;
            }
            return "分类不存在";
        }
    }
}