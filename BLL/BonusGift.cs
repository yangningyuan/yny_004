using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class BonusGift
    {
        public static Model.BonusGift GetModel(object obj)
        {
            return DAL.BonusGift.GetModel(obj);
        }
        public static Model.BonusGift GetModel(string obj, string plan)
        {
            return DAL.BonusGift.GetModel(obj, plan);
        }

        public static System.Collections.Hashtable Insert(Model.BonusGift model, System.Collections.Hashtable MyHs)
        {
            return DAL.BonusGift.Insert(model, MyHs);
        }

        public static bool Insert(Model.BonusGift model)
        {
            return DAL.BonusGift.Insert(model);
        }

        public static System.Collections.Hashtable Update(Model.BonusGift model, System.Collections.Hashtable MyHs)
        {
            return DAL.BonusGift.Update(model, MyHs);
        }

        public static bool Update(Model.BonusGift model)
        {
            return DAL.BonusGift.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return DAL.BonusGift.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return DAL.BonusGift.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return DAL.BonusGift.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BonusGift.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.BonusGift> GetList(string strWhere)
        {
            return DAL.BonusGift.GetList(strWhere);
        }

        public static List<Model.BonusGift> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BonusGift.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
