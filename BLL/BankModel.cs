using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    /// <summary>
    /// 龙子基类操作
    /// </summary>
    public class BankModel
    {
        public static Hashtable Insert(Model.BankModel model, Hashtable MyHs)
        {
            DAL.BankModel.Insert(model, MyHs);
            return MyHs;
        }
        public static bool Insert(Model.BankModel model)
        {
            Hashtable MyHs = new Hashtable();
            DAL.BankModel.Insert(model, MyHs);
            List<Model.BankModel> list = BLL.BankModel.GetList(" MID='" + model.MID + "' order by IsPrimary desc,BankCreateDate asc ");
            if (model.IsPrimary)
            {
                Model.Member member = DAL.Member.GetModel(model.MID);
                member.Bank = model.Bank;
                member.Branch = model.Branch;
                member.BankNumber = model.BankNumber;
                member.BankCardName = model.BankCardName;
                DAL.Member.UpdateBankInfo(member, MyHs);
                foreach (Model.BankModel item in list)
                {
                    item.IsPrimary = false;
                    Update(item, MyHs);
                }
            }
            else
            {
                if (list.Where(emp => emp.IsPrimary).Count() <= 0)
                {
                    list[0].IsPrimary = true;
                    Update(list[0], MyHs);
                    Model.Member member = DAL.Member.GetModel(list[0].MID);
                    member.Bank = list[0].Bank;
                    member.Branch = list[0].Branch;
                    member.BankNumber = list[0].BankNumber;
                    member.BankCardName = list[0].BankCardName;
                    DAL.Member.UpdateBankInfo(member, MyHs);
                }
            }
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static Hashtable Update(Model.BankModel model, Hashtable MyHs)
        {
            DAL.BankModel.Update(model, MyHs);
            return MyHs;
        }
        public static bool Update(Model.BankModel model)
        {
            Hashtable MyHs = new Hashtable();
            DAL.BankModel.Update(model, MyHs);
            List<Model.BankModel> list = BLL.BankModel.GetList(" MID='" + model.MID + "' order by IsPrimary desc,BankCreateDate asc ");
            list = list.Where(emp => emp.BankCode != model.BankCode).ToList();
            if (model.IsPrimary)
            {
                Model.Member member = DAL.Member.GetModel(model.MID);
                member.Bank = model.Bank;
                member.Branch = model.Branch;
                member.BankNumber = model.BankNumber;
                member.BankCardName = model.BankCardName;
                DAL.Member.UpdateBankInfo(member, MyHs);
                foreach (Model.BankModel item in list)
                {
                    item.IsPrimary = false;
                    Update(item, MyHs);
                }
            }
            else
            {
                if (list.Where(emp => emp.IsPrimary).Count() <= 0)
                {
                    list[0].IsPrimary = true;
                    Update(list[0], MyHs);

                    Model.Member member = DAL.Member.GetModel(list[0].MID);
                    member.Bank = list[0].Bank;
                    member.Branch = list[0].Branch;
                    member.BankNumber = list[0].BankNumber;
                    member.BankCardName = list[0].BankCardName;
                    DAL.Member.UpdateBankInfo(member, MyHs);
                }
            }
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static Hashtable Delete(string lzCodeList, Hashtable MyHs)
        {
            DAL.BankModel.Delete(lzCodeList, MyHs);
            return MyHs;
        }
        public static List<Model.BankModel> GetList(string strWhere)
        {
            return DAL.BankModel.GetList(strWhere);
        }
        public static Model.BankModel GetModel(string lzCode)
        {
            return DAL.BankModel.GetModel(lzCode);
        }
        public static List<Model.BankModel> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BankModel.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
