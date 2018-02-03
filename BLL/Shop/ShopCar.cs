using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    //ShopCar
    public class ShopCar
    {
        public static Model.ShopCar GetModel(object obj)
        {
            return yny_004.DAL.ShopCar.GetModel(obj);
        }

        public static Hashtable Insert(Model.ShopCar model, Hashtable MyHs)
        {
            return yny_004.DAL.ShopCar.Insert(model, MyHs);
        }

        public static bool Insert(Model.ShopCar model)
        {
            return yny_004.DAL.ShopCar.Insert(model);
        }

        public static Hashtable Update(Model.ShopCar model, Hashtable MyHs)
        {
            return yny_004.DAL.ShopCar.Update(model, MyHs);
        }

        public static bool Update(Model.ShopCar model)
        {
            return yny_004.DAL.ShopCar.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.ShopCar.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.ShopCar.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.ShopCar.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.ShopCar.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.ShopCar> GetList(string strWhere)
        {
            return yny_004.DAL.ShopCar.GetList(strWhere);
        }

        public static List<Model.ShopCar> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.ShopCar.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
