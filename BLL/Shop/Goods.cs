using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    //Goods
    public class Goods
    {
        public static Model.Goods GetModel(object obj)
        {
            return yny_004.DAL.Goods.GetModel(obj);
        }

        public static Hashtable Insert(Model.Goods model, Hashtable MyHs)
        {
            return yny_004.DAL.Goods.Insert(model, MyHs);
        }

        public static bool Insert(Model.Goods model)
        {
            return yny_004.DAL.Goods.Insert(model);
        }

        public static Hashtable Update(Model.Goods model, Hashtable MyHs)
        {
            return yny_004.DAL.Goods.Update(model, MyHs);
        }

        public static bool Update(Model.Goods model)
        {
            return yny_004.DAL.Goods.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.Goods.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.Goods.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.Goods.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.Goods.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.Goods> GetList(string strWhere)
        {
            return yny_004.DAL.Goods.GetList(strWhere);
        }

        public static List<Model.Goods> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.Goods.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
