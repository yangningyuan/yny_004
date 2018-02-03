using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDAL;
using System.Data;
using System.Collections;
using CommonModel;

namespace CommonBLL
{
    public class Sys_BankInfoBLL
    {
        public Sys_BankInfo GetModel(object obj)
        {
            return Sys_BankInfoDAL.GetModel(obj);
        }

        public Hashtable Insert(Sys_BankInfo model, Hashtable MyHs)
        {
            return Sys_BankInfoDAL.Insert(model, MyHs);
        }

        public bool Insert(Sys_BankInfo model)
        {
            return Sys_BankInfoDAL.Insert(model);
        }

        public Hashtable Update(Sys_BankInfo model, Hashtable MyHs)
        {
            return Sys_BankInfoDAL.Update(model, MyHs);
        }

        public bool Update(Sys_BankInfo model)
        {
            return Sys_BankInfoDAL.Update(model);
        }

        public Hashtable Delete(object obj, Hashtable MyHs)
        {
            return Sys_BankInfoDAL.Delete(obj, MyHs);
        }

        public bool Delete(object obj)
        {
            return Sys_BankInfoDAL.Delete(obj);
        }

        public DataTable GetTable(string strWhere)
        {
            return Sys_BankInfoDAL.GetTable(strWhere);
        }

        public DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return Sys_BankInfoDAL.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public List<Sys_BankInfo> GetList(string strWhere)
        {
            return Sys_BankInfoDAL.GetList(strWhere);
        }

        public List<Sys_BankInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return Sys_BankInfoDAL.GetList(strWhere, pageIndex, pageSize, out count);
        }
        public bool SaveOrUpdate(IList<Sys_BankInfo> list)
        {
            Hashtable MyHs = new Hashtable();//以事务方式
            foreach (Sys_BankInfo obj in list)
            {
                if (obj.Id == 0) //需要插入的
                {
                    Sys_BankInfoDAL.Insert(obj,MyHs);
                }
                else
                {
                    //需要更新的
                    Sys_BankInfo objUpdate = obj;
                    Sys_BankInfoDAL.Update(obj,MyHs);
                }
            }
            return CommonBase.RunHashtable(MyHs);
        }
    }
}
