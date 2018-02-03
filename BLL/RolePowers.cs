using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    public class RolePowers
    {
        public static Model.RolePowers GetModel(string obj)
        {
            return DAL.RolePowers.GetModel(obj);
        }

        public static bool Insert(Model.RolePowers model)
        {
            return DAL.RolePowers.Insert(model);
        }

        public static bool Update(Model.RolePowers model)
        {
            return DAL.RolePowers.Update(model);
        }



        public static bool Delete(string idList)
        {
            return DAL.RolePowers.Delete(idList);
        }

        public static bool BatchInsert(List<Model.RolePowers> list)
        {
            foreach (Model.RolePowers obj in list)
            {
                Insert(obj);
            }
            DAL.Roles.RolsList = null;
            return true;
        }

        public static bool BatchUpdate(List<Model.RolePowers> list, string cid)
        {
            //先删除
            DAL.RolePowers.DeleteByCID(cid);
            foreach (Model.RolePowers obj in list)
            {
                Insert(obj);
            }
            DAL.Roles.RolsList = null;
            return true;
        }

        public static List<Model.RolePowers> GetList(string strWhere)
        {
            return DAL.RolePowers.GetList(strWhere);
        }


    }
}
