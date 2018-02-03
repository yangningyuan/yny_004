using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    public class GoodsPic
    {
        public static Model.GoodsPic GetModel(object obj)
        {
            return yny_004.DAL.GoodsPic.GetModel(obj);
        }

        public static Hashtable Insert(Model.GoodsPic model, Hashtable MyHs)
        {
            return yny_004.DAL.GoodsPic.Insert(model, MyHs);
        }

        public static bool Insert(Model.GoodsPic model)
        {
            return yny_004.DAL.GoodsPic.Insert(model);
        }

        public static Hashtable Update(Model.GoodsPic model, Hashtable MyHs)
        {
            return yny_004.DAL.GoodsPic.Update(model, MyHs);
        }

        public static bool Update(Model.GoodsPic model)
        {
            return yny_004.DAL.GoodsPic.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.GoodsPic.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.GoodsPic.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.GoodsPic.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.GoodsPic.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.GoodsPic> GetList(string strWhere)
        {
            return yny_004.DAL.GoodsPic.GetList(strWhere);
        }

        public static List<Model.GoodsPic> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.GoodsPic.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
