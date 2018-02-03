using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace yny_004.Web.Shop
{
    public partial class CategoryEdit : BasePage
    {
        protected override void SetPowerZone()
        {

        }
        protected override void SetValue(string id)
        {
            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            CategoryModel = BLL.GoodCategory.GetModel(mid);

        }

        public Model.GoodCategory CategoryModel
        {
            get
            {
                Model.GoodCategory model = null;
                string sid = Request.Form["hidId"];
                if (string.IsNullOrEmpty(sid) || sid == "0")
                {
                    model = new Model.GoodCategory();
                    model.IsDeleted = false;
                    model.Status = 1;
                }
                else
                {
                    model = BLL.GoodCategory.GetModel(sid);
                }
                model.Code = Request.Form["txtCode"].Trim();
                model.Name = Request.Form["txtName"].Trim();
                return model;
            }
            set
            {
                if (value != null)
                {
                    txtCode.Value = value.Code;
                    txtName.Value = value.Name;
                    hidId.Value = value.Id.ToString();
                }
            }
        }

        //添加收货人，并保证只有一个默认收货人
        protected override string btnAdd_Click()
        {
            string sid = Request.Form["hidId"];
            Hashtable myHs = new Hashtable();
            Model.GoodCategory obj = null;
            if (string.IsNullOrEmpty(sid) || sid == "0")
            {
                //添加
                obj = CategoryModel;
                //校验编号是否已存在
                if (BLL.GoodCategory.GetList("IsDeleted=0 and Code='" + obj.Code + "'").FirstOrDefault() != null)
                {
                    return "2";
                }

                BLL.GoodCategory.Insert(obj, myHs);
            }
            else
            {
                obj = CategoryModel;
                BLL.GoodCategory.Update(obj, myHs);
            }
            if (BLL.CommonBase.RunHashtable(myHs))
            {
                return "1";
            }
            return "0";
        }
    }
}