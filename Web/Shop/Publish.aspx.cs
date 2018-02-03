using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.Shop
{
    public partial class Publish : BasePage
    {
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            GoodsModel = BLL.Goods.GetModel(mid);
        }

        protected override void SetPowerZone()
        {
            ddlCategory.DataSource = BLL.GoodCategory.GetList("IsDeleted=0");
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Code";
            ddlCategory.DataBind();
        }

        public Model.Goods GoodsModel
        {
            get
            {
                Model.Goods model = null;
                string sid = Request.Form["hidId"];
                if (string.IsNullOrEmpty(sid) || sid == "0")
                {
                    model = new Model.Goods();
                    model.IsDeleted = false;
                    model.SelledCount = 0;
                    model.Status = 1;
                    model.GoodsCode = GetGuid();
                }
                else
                {
                    model = BLL.Goods.GetModel(sid);
                }
                model.CostPrice = decimal.Parse(Request.Form["txtPrice"].Trim() != "" ? Request.Form["txtPrice"].Trim() : "0");
                model.GName = Request.Form["txtName"].Trim();
                model.GParentCode = Request.Form["ddlCategory"].Trim();
                model.MemberPrice = model.CostPrice;
                model.SellingCount = int.Parse(Request.Form["txtStock"].Trim() != "" ? Request.Form["txtStock"].Trim() : "0");
                model.Unit = Request.Form["txtUnit"];
                model.Remark = Request.Form["txtRemark"];
                return model;
            }
            set
            {
                if (value != null)
                {
                    ddlCategory.Value = value.GParentCode;
                    txtName.Value = value.GName;
                    txtPrice.Value = value.CostPrice.ToString();
                    txtStock.Value = value.SellingCount.ToString();
                    txtRemark.Value = value.Remark;
                    txtUnit.Value = value.Unit;
                    hidId.Value = value.GID.ToString();
                    var list = BLL.GoodsPic.GetList("IsDeleted=0 and GId='" + value.GoodsCode + "'");
                    if (list != null && list.Count > 0)
                    {
                        try
                        {
                            hidMainPic.Value = list.Where(c => c.IsMain == true).FirstOrDefault().PicURL;
                        }
                        catch
                        {
                            hidMainPic.Value = list[0].PicURL;
                        }
                        rep_PicList.DataSource = list;
                        rep_PicList.DataBind();
                    }
                }
            }
        }

        protected override string btnModify_Click()
        {
            string sid = Request.Form["hidId"];
            Hashtable myHs = new Hashtable();
            if (string.IsNullOrEmpty(sid) || sid == "0")
            {
                //添加
                Model.Goods obj = GoodsModel;
                BLL.Goods.Insert(obj, myHs);
                SaveImgs(obj.GoodsCode, myHs);
            }
            else
            {
                Model.Goods obj = GoodsModel;
                BLL.Goods.Update(obj, myHs);
                DeleteImgs(myHs);
                SaveImgs(obj.GoodsCode, myHs);
            }
            if (BLL.CommonBase.RunHashtable(myHs))
                return "操作成功";
            return "操作失败";
        }

        protected void DeleteImgs(Hashtable hs)
        {
            string deleId = Request.Form["hidDelIds"];
            if (!string.IsNullOrEmpty(deleId))
            {
                string[] array = deleId.Split(',');
                BLL.GoodsPic.Delete(deleId.Substring(0,deleId.Length-1), hs);
            }
        }


        protected void SaveImgs(string saleId, Hashtable hs)
        {
            string imgsUrl = Request.Form["uploadPic"];
            if (!string.IsNullOrEmpty(imgsUrl))
            {
                string[] array = imgsUrl.Split(',');
                List<Model.GoodsPic> listInsert = new List<Model.GoodsPic>();
                List<Model.GoodsPic> listUpdate = new List<Model.GoodsPic>();
                //int mainCount = 0;
                foreach (string arr in array)
                {
                    Model.GoodsPic obj = new Model.GoodsPic();
                    obj.IsMain = false;
                    obj.PicURL = arr;
                    obj.GId = saleId;
                    obj.Code = Guid.NewGuid().ToString();
                    obj.IsDeleted = false;
                    obj.Status = 1;
                    if (obj.PicURL == Request.Form["hidMainPic"])
                    {
                        obj.IsMain = true;
                    }
                    //查看这个图片是否在数据库中存在，存在就不添加
                    var listHas = BLL.GoodsPic.GetList("PicURL='" + obj.PicURL + "'");
                    if (listHas != null && listHas.Count > 0)
                    { //存在，就修改，主要是修改IsMain
                        Model.GoodsPic objU = listHas[0];
                        if (objU.IsMain != obj.IsMain)
                        {
                            objU.IsMain = obj.IsMain;
                            listUpdate.Add(objU);
                        }
                    }
                    else
                    {//不存在，就添加
                        listInsert.Add(obj);
                    }
                }
                foreach (Model.GoodsPic obj in listInsert)
                {
                    BLL.GoodsPic.Insert(obj, hs);
                }
                foreach (Model.GoodsPic obj in listUpdate)
                {
                    BLL.GoodsPic.Update(obj, hs);
                }
            }
        }
    }
}
