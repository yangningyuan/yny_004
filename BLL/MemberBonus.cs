using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class MemberBonus
    {
        public static Model.MemberBonus GetModel(string obj)
        {
            return DAL.MemberBonus.GetModel(obj);
        }

        public static System.Collections.Hashtable Insert(Model.MemberBonus model, System.Collections.Hashtable MyHs)
        {
            return DAL.MemberBonus.Insert(model, MyHs);
        }

        public static bool Insert(Model.MemberBonus model)
        {
            return DAL.MemberBonus.Insert(model);
        }

        public static System.Collections.Hashtable Update(string mid, string fieldName, int fieldValue, System.Collections.Hashtable MyHs)
        {
            return DAL.MemberBonus.Update(mid, fieldName, fieldValue, MyHs);
        }

        public static bool Update(Model.MemberBonus model)
        {
            return DAL.MemberBonus.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return DAL.MemberBonus.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return DAL.MemberBonus.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return DAL.MemberBonus.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.MemberBonus.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MemberBonus> GetList(string strWhere)
        {
            return DAL.MemberBonus.GetList(strWhere);
        }

        public static List<Model.MemberBonus> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.MemberBonus.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}