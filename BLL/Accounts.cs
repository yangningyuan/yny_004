using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    public class Accounts
    {
        public static Model.Accounts tempAccount { get; set; }
        public static Hashtable BDInsert(Model.Accounts model, Hashtable MyHs, bool isRecord = true)
        {
            if (isRecord)
            {
                BLL.ChangeMoney.FHChangeTran(model, MyHs);
            }
            model.IfAccount = true;
            model.AccountsDate = DateTime.Now;
            DAL.Accounts.Insert(model, MyHs);
            return MyHs;
        }
        public static bool Insert(Model.Accounts model)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                Hashtable MyHs = new Hashtable();
                BLL.ChangeMoney.FHChangeTran(model, MyHs);
                if (model.TotalFHMoney > 0)
                {
                    model.IfAccount = true;
                    model.AccountsDate = DateTime.Now;
                    DAL.Accounts.Insert(model, MyHs);
                }

                return DAL.CommonBase.RunHashtable(MyHs);
            }
        }

        public static Hashtable Update(Model.Accounts model, Hashtable MyHs)
        {
            if (!model.IfAccount)
            {
                lock (DAL.Member.tempMemberList)
                {
                    DAL.Member.tempMemberList.Clear();
                    BLL.ChangeMoney.FHChangeTran(model, MyHs);
                    model.IfAccount = true;
                    model.AccountsDate = DateTime.Now;
                }
            }
            DAL.Accounts.Update(model, MyHs);
            return MyHs;
        }
        public static bool Update(Model.Accounts model)
        {
            Hashtable MyHs = new Hashtable();
            DAL.Accounts.Update(model, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static bool Delete(string CodeList)
        {
            return DAL.Accounts.Delete("'" + CodeList + "'");
        }
        public static Hashtable Delete(string lzTypeCodeList, Hashtable MyHs)
        {
            DAL.Accounts.Delete(lzTypeCodeList, MyHs);
            return MyHs;
        }
        public static List<Model.Accounts> GetList(string strWhere)
        {
            return DAL.Accounts.GetList(strWhere);
        }
        public static List<Model.Accounts> GetList(int top, string strWhere)
        {
            return DAL.Accounts.GetList(top, strWhere);
        }

        public static List<Model.Accounts> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Accounts.GetList(strWhere, pageIndex, pageSize, out count);
        }
        public static Model.Accounts GetModel(string typeCode)
        {
            return DAL.Accounts.GetModel(typeCode);
        }

        public static Model.Accounts GetTopModel(string pCode, string remark)
        {
            return DAL.Accounts.GetTopModel(pCode, remark);
        }

        public static string GetFHInfo(string pCode, string remark)
        {
            return DAL.Accounts.GetFHInfo(pCode, remark);
        }
    }
}
