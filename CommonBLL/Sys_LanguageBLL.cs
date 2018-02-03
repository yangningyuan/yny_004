using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDAL;
using System.Data;
using System.Collections;
using CommonModel;

namespace CommonBLL
{
    public class Sys_LanguageBLL
    {
        public static Sys_Language GetModel(object obj)
        {
            return Sys_LanguageDAL.GetModel(obj);
        }
        public static string Delete(string cidlist)
        {
            if (Sys_LanguageDAL.Delete(cidlist))
                return "删除成功";
            return "删除失败";
        }
        public static Hashtable Insert(Sys_Language model, Hashtable MyHs)
        {
            return Sys_LanguageDAL.Insert(model, MyHs);
        }

        public static bool Insert(Sys_Language model)
        {
            return Sys_LanguageDAL.Insert(model);
        }

        public static Hashtable Update(Sys_Language model, Hashtable MyHs)
        {
            return Sys_LanguageDAL.Update(model, MyHs);
        }

        public static bool Update(Sys_Language model)
        {
            return Sys_LanguageDAL.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return Sys_LanguageDAL.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return Sys_LanguageDAL.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return Sys_LanguageDAL.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return Sys_LanguageDAL.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Sys_Language> GetList(string strWhere)
        {
            return Sys_LanguageDAL.GetList(strWhere);
        }

        public static List<Sys_Language> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return Sys_LanguageDAL.GetList(strWhere, pageIndex, pageSize, out count);
        }
        public static int SaveOrUpdate(IList<Sys_Language> list)
        {
            int result = 0;
            foreach (Sys_Language obj in list)
            {
                if (obj.Id == 0) //需要插入的
                {
                    Sys_LanguageDAL.Insert(obj);
                }
                else
                {
                    //需要更新的
                    Sys_Language objUpdate = obj;
                    Sys_LanguageDAL.Update(obj);
                }
                result++;
            }
            return result;
        }
        public static bool SaveOrUpdate(Sys_Language obj)
        {
            bool result = false;
            if (obj.Id == 0) //需要插入的
            {
                result = Sys_LanguageDAL.Insert(obj);
            }
            else
            {
                //需要更新的
                result = Sys_LanguageDAL.Update(obj);
            }
            return result;
        }

        public static bool SaveOrUpdate(List<Sys_Language> list)
        {
            bool result = false;
            Hashtable MyHs = new Hashtable();
            foreach (Sys_Language obj in list)
            {
                if (obj.Id == 0) //需要插入的
                {

                    Sys_LanguageDAL.Insert(obj, MyHs);
                }
                else
                {
                    //需要更新的
                    Sys_LanguageDAL.Update(obj, MyHs);
                }
            }
            result = CommonBase.RunHashtable(MyHs);
            return result;
        }
    }
}
