using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace yny_004.BLL
{
    public class Order
    {
        public static Model.Order GetModel(object obj)
        {
            return yny_004.DAL.Order.GetModel(obj);
        }

        public static Hashtable Insert(Model.Order model, Hashtable MyHs)
        {
            return yny_004.DAL.Order.Insert(model, MyHs);
        }

        public static bool Insert(Model.Order model)
        {
            return yny_004.DAL.Order.Insert(model);
        }

        public static Hashtable Update(Model.Order model, Hashtable MyHs)
        {
            return yny_004.DAL.Order.Update(model, MyHs);
        }

        public static bool Update(Model.Order model)
        {
            return yny_004.DAL.Order.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.Order.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.Order.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.Order.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.Order.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.Order> GetList(string strWhere)
        {
            return yny_004.DAL.Order.GetList(strWhere);
        }

        public static List<Model.Order> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.Order.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static int GetOrderCount(Model.Member model, bool isDone)
        {
            string equ = "<>";
            if (isDone)
            {
                equ = "=";
            }
            string strSql = " select count(*) from [Order] where Status " + equ + " 4 and MID = '" + model.MID + "' ";
            if (model.Role.Super)
            {
                strSql = " select count(*) from [Order] where Status " + equ + " 4 ";
            }
            object obj = BLL.CommonBase.GetSingle(strSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
