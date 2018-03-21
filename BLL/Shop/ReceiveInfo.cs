using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.BLL
{
    //ReceiveInfo
    public class ReceiveInfo
    {
        public static Model.ReceiveInfo GetModel(object obj)
        {
            return yny_004.DAL.ReceiveInfo.GetModel(obj);
        }

        public static Hashtable Insert(Model.ReceiveInfo model, Hashtable MyHs)
        {
            return yny_004.DAL.ReceiveInfo.Insert(model, MyHs);
        }

        public static bool Insert(Model.ReceiveInfo model)
        {
            return yny_004.DAL.ReceiveInfo.Insert(model);
        }
        public static int InsertByID(Model.ReceiveInfo model)
        {
            return yny_004.DAL.ReceiveInfo.InsertByID(model);
        }

        public static Hashtable Update(Model.ReceiveInfo model, Hashtable MyHs)
        {
            return yny_004.DAL.ReceiveInfo.Update(model, MyHs);
        }

        public static bool Update(Model.ReceiveInfo model)
        {
            return yny_004.DAL.ReceiveInfo.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return yny_004.DAL.ReceiveInfo.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.ReceiveInfo.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.ReceiveInfo.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.ReceiveInfo.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.ReceiveInfo> GetList(string strWhere)
        {
            return yny_004.DAL.ReceiveInfo.GetList(strWhere);
        }

        public static List<Model.ReceiveInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.ReceiveInfo.GetList(strWhere, pageIndex, pageSize, out count);
        }
        public static void UpdateToNoMian(string mid,string id)
        {
            string sql= "update ReceiveInfo set IsMain=0 where MID='"+mid+"' and Id<>"+id;
             DAL.CommonBase.RunSql(sql);
        }
    }
}
