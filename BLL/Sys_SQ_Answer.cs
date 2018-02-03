using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    public class Sys_SQ_Answer
    {
        public Model.Sys_SQ_Answer GetModel(object obj)
        {
            return DAL.Sys_SQ_Answer.GetModel(obj);
        }

        public Hashtable Insert(Model.Sys_SQ_Answer model, Hashtable MyHs)
        {
            return DAL.Sys_SQ_Answer.Insert(model, MyHs);
        }

        public bool Insert(Model.Sys_SQ_Answer model)
        {
            return DAL.Sys_SQ_Answer.Insert(model);
        }

        public Hashtable Update(Model.Sys_SQ_Answer model, Hashtable MyHs)
        {
            return DAL.Sys_SQ_Answer.Update(model, MyHs);
        }

        public bool Update(Model.Sys_SQ_Answer model)
        {
            return DAL.Sys_SQ_Answer.Update(model);
        }

        public Hashtable Delete(object obj, Hashtable MyHs)
        {
            return DAL.Sys_SQ_Answer.Delete(obj, MyHs);
        }

        public bool Delete(object obj)
        {
            return DAL.Sys_SQ_Answer.Delete(obj);
        }

        public DataTable GetTable(string strWhere)
        {
            return DAL.Sys_SQ_Answer.GetTable(strWhere);
        }

        public DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Sys_SQ_Answer.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public List<Model.Sys_SQ_Answer> GetList(string strWhere)
        {
            return DAL.Sys_SQ_Answer.GetList(strWhere);
        }

        public List<Model.Sys_SQ_Answer> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Sys_SQ_Answer.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
