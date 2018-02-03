using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonModel;
using CommonBLL;

namespace yny_004.Web.SysManage
{
    public partial class BankInfo : BasePage
    {
        protected override void SetPowerZone()
        {
            BindRep();
        }
        protected void BindRep()
        {

            Sys_BankInfoBLL BLL = new Sys_BankInfoBLL();
            rep_List.DataSource = BLL.GetList(" 1=1 and  IsDeleted=0 order by ID desc");
            rep_List.DataBind();
        }

        protected override string btnAdd_Click()
        {
            Sys_BankInfo obj = null;
            IList<Sys_BankInfo> list = GetDetailModelList();
            IList<Sys_BankInfo> listNew = new List<Sys_BankInfo>();
            foreach (Sys_BankInfo objNew in list)
            {
                Sys_BankInfo sq = objNew;
                if (objNew.Id == 0)
                {
                    sq.CreatedBy = TModel.MID;
                    sq.CreatedTime = DateTime.Now;
                    sq.IsDeleted = false;
                    sq.Status = true;
                }
                else
                {
                    sq = new Sys_BankInfoBLL().GetModel(objNew.Id);
                    sq.Code = objNew.Code;
                    sq.LinkUrl = objNew.LinkUrl;
                    sq.Name = objNew.Name;
                    sq.PicUrl = objNew.PicUrl;
                    sq.Remark = objNew.Remark;
                    sq.UpdatedBy = TModel.MID;
                    sq.UpdatedTime = DateTime.Now;
                }
                listNew.Add(sq);
            }
            //删除需要删除的
            string deleteId = Request.Form["hidDelIds"];
            if (!string.IsNullOrEmpty(deleteId))
            {
                string[] arr = deleteId.Split(',');
                foreach (string str in arr)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        Sys_BankInfo sq = new Sys_BankInfoBLL().GetModel(str);
                        sq.IsDeleted = true;
                        sq.UpdatedBy = TModel.MID;
                        sq.UpdatedTime = DateTime.Now;
                        // new BLL.Sys_SecurityQuestion().Delete(str);
                        listNew.Add(sq);
                        //new Sys_BankInfoBLL().Delete(str);
                    }
                }
            }
            //更新或新增
            if(new Sys_BankInfoBLL().SaveOrUpdate(listNew))
            {
                return "操作成功";
            }
            else
                return "操作失败";

        }



        public string[] EditTableKeysForTrain { get { return new string[] { "Code", "Name", "Pic", "hidId","link","remark" }; } }

        protected IList<Sys_BankInfo> GetDetailModelList()
        {
            string[] arrRequest = Request.Form.AllKeys;
            IList<string> newDetailListTrain = new List<string>();
            IList<Sys_BankInfo> listSafe = new List<Sys_BankInfo>();
            foreach (string str in arrRequest)
            {
                var key = str.Split('_')[0];
                if (EditTableNeedSaveKeys(key, EditTableKeysForTrain))
                {
                    newDetailListTrain.Add(str);
                }

            }
            IList<string> strFlagsTrain = GetSetedGuid(newDetailListTrain);

            listSafe = AddToTotalModel(listSafe, AddListModel(strFlagsTrain, EditTableKeysForTrain));

            return listSafe;
        }
        protected IList<Sys_BankInfo> AddToTotalModel(IList<Sys_BankInfo> toAdd, IList<Sys_BankInfo> origin)
        {
            foreach (Sys_BankInfo obj in origin)
            {
                Sys_BankInfo newObj = obj;
                toAdd.Add(newObj);
            }
            return toAdd;
        }


        protected IList<Sys_BankInfo> AddListModel(IList<string> strFlags, string[] EditTableKeys)
        {
            IList<Sys_BankInfo> list = new List<Sys_BankInfo>();
            object id = null; string code = "", name = "", picUrl = "",link="",remark="";
            foreach (string str in strFlags)
            {
                foreach (string sin in EditTableKeys)
                {
                    switch (sin)
                    {
                        case "hidId": id = Request.Form[sin + "_" + str]; break;
                        case "Code":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                code = Request.Form[sin + "_" + str];
                            break;
                        case "Name":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                name = Request.Form[sin + "_" + str];
                            break;
                        case "Pic":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                picUrl = Request.Form[sin + "_" + str];
                            break;
                        case "link":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                link = Request.Form[sin + "_" + str];
                            break;
                        case "remark":
                            if (Request.Form[sin + "_" + str] != null && !string.IsNullOrEmpty(Request.Form[sin + "_" + str]))
                                remark = Request.Form[sin + "_" + str];
                            break;
                    }
                }
                list.Add(NewEntity(id, code, name, picUrl, link,remark));
            }
            return list;
        }
        private Sys_BankInfo NewEntity(object id, string code, string name, string picUrl, string link, string remark)
        {
            Sys_BankInfo obj = null;
            if (!string.IsNullOrEmpty(name))
            {
                obj = new Sys_BankInfo {  Id= ToNullLong(id), Name=name,  Code=code, PicUrl=picUrl , LinkUrl=link,Remark=remark};
            }
            return obj;
        }
    }
}