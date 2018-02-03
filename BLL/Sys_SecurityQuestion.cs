using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    public class Sys_SecurityQuestion
    {
        public Model.Sys_SecurityQuestion GetModel(object obj)
        {
            return DAL.Sys_SecurityQuestion.GetModel(obj);
        }

        public Hashtable Insert(Model.Sys_SecurityQuestion model, Hashtable MyHs)
        {
            return DAL.Sys_SecurityQuestion.Insert(model, MyHs);
        }

        public bool Insert(Model.Sys_SecurityQuestion model)
        {
            return DAL.Sys_SecurityQuestion.Insert(model);
        }

        public Hashtable Update(Model.Sys_SecurityQuestion model, Hashtable MyHs)
        {
            return DAL.Sys_SecurityQuestion.Update(model, MyHs);
        }

        public bool Update(Model.Sys_SecurityQuestion model)
        {
            return DAL.Sys_SecurityQuestion.Update(model);
        }

        public Hashtable Delete(object obj, Hashtable MyHs)
        {
            return DAL.Sys_SecurityQuestion.Delete(obj, MyHs);
        }

        public bool Delete(object obj)
        {
            return DAL.Sys_SecurityQuestion.Delete(obj);
        }

        public DataTable GetTable(string strWhere)
        {
            return DAL.Sys_SecurityQuestion.GetTable(strWhere);
        }

        public DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Sys_SecurityQuestion.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public List<Model.Sys_SecurityQuestion> GetList(string strWhere)
        {
            return DAL.Sys_SecurityQuestion.GetList(strWhere);
        }

        public List<Model.Sys_SecurityQuestion> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Sys_SecurityQuestion.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public  bool SaveOrUpdate(IList<Model.Sys_SecurityQuestion> list)
        {
            Hashtable MyHs = new Hashtable();//以事务方式
            foreach (Model.Sys_SecurityQuestion obj in list)
            {
                if (obj.ID == 0) //需要插入的
                {
                    DAL.Sys_SecurityQuestion.Insert(obj);
                }
                else
                {
                    //需要更新的
                    Model.Sys_SecurityQuestion objUpdate = obj;
                    DAL.Sys_SecurityQuestion.Update(obj);
                }
            }
            return CommonBase.RunHashtable(MyHs);
        }
    }
}
