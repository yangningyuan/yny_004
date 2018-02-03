using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    /// <summary>
    /// 龙子基类操作
    /// </summary>
    public class HKModel
    {
        public static List<string> tempList = new List<string>();
        public static Hashtable Insert(Model.HKModel model, Hashtable MyHs)
        {
            DAL.HKModel.Insert(model, MyHs);
            return MyHs;
        }
        public static bool Exist(string code)
        {
            return DAL.HKModel.Exist(code);
        }
        public static bool Insert(Model.HKModel model)
        {
            Hashtable MyHs = new Hashtable();

            //if (BLL.HKModel.Exist(model.MajorKey))
            //{
            //    throw new Exception("请勿重复提交");
            //}
            DAL.HKModel.Insert(model, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static Hashtable Update(Model.HKModel model, Hashtable MyHs)
        {
            DAL.HKModel.Update(model, MyHs);
            return MyHs;
        }
        public static bool Update(Model.HKModel model)
        {
            Hashtable MyHs = new Hashtable();
            DAL.HKModel.Update(model, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static Hashtable Delete(string lzCodeList, Hashtable MyHs)
        {
            DAL.HKModel.Delete(lzCodeList, MyHs);
            return MyHs;
        }
        public static List<Model.HKModel> GetList(string strWhere)
        {
            return DAL.HKModel.GetList(strWhere);
        }
        public static Model.HKModel GetModel(string lzCode)
        {
            return DAL.HKModel.GetModel(lzCode);
        }
        public static List<Model.HKModel> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.HKModel.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
