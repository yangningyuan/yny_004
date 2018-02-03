using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    //GoodCategory
    public class GoodCategory
    {
        public static Model.GoodCategory GetModel(object obj)
        {
            return yny_004.DAL.GoodCategory.GetModel(obj);
        }
        public static Model.GoodCategory GetModelByCode(object obj)
        {
            return yny_004.DAL.GoodCategory.GetModelByCode(obj);
        }

        public static Hashtable Insert(Model.GoodCategory model, Hashtable MyHs)
        {
            return yny_004.DAL.GoodCategory.Insert(model, MyHs);
        }

        public static bool Insert(Model.GoodCategory model)
        {
            return yny_004.DAL.GoodCategory.Insert(model);
        }

        public static Hashtable Update(Model.GoodCategory model, Hashtable MyHs)
        {
            return yny_004.DAL.GoodCategory.Update(model, MyHs);
        }

        public static bool Update(Model.GoodCategory model)
        {
            return yny_004.DAL.GoodCategory.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.GoodCategory.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.GoodCategory.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.GoodCategory.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.GoodCategory.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.GoodCategory> GetList(string strWhere)
        {
            return yny_004.DAL.GoodCategory.GetList(strWhere);
        }

        public static List<Model.GoodCategory> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.GoodCategory.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
