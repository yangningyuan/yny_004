using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class BonusList
    {
        public static Model.BonusList GetModel(string obj)
        {
            return DAL.BonusList.GetModel(obj);
        }

        public static System.Collections.Hashtable Insert(Model.BonusList model, System.Collections.Hashtable MyHs)
        {
            if (model.IsValid)
            {
                BLL.ChangeMoney.GetGiftMoneyChangeTran(model, MyHs);
            }
            BLL.MemberBonus.Update(model.MID, "Points", model.Points, MyHs);
            return DAL.BonusList.Insert(model, MyHs);
        }

        public static bool Insert(Model.BonusList model)
        {
            return DAL.BonusList.Insert(model);
        }

        public static System.Collections.Hashtable Update(Model.BonusList model, System.Collections.Hashtable MyHs)
        {
            return DAL.BonusList.Update(model, MyHs);
        }

        public static bool Update(Model.BonusList model)
        {
            return DAL.BonusList.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return DAL.BonusList.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return DAL.BonusList.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return DAL.BonusList.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BonusList.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.BonusList> GetList(string strWhere)
        {
            return DAL.BonusList.GetList(strWhere);
        }

        public static List<Model.BonusList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BonusList.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
