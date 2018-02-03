using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    public class BMember
    {
        private static object obj = new Random().Next(1, 100);
        public static yny_004.Model.BMember GetModel(string obj)
        {
            return yny_004.DAL.BMember.GetModel(obj);
        }

        public static Hashtable Insert(Model.Member member, Hashtable MyHs)
        {
            Model.BMember model = new Model.BMember();
            model.AMID = member.MID;
            model.AMember = member;
            model.BMCreateDate = DateTime.Now;
            model.BMDate = DateTime.Now;
            model.BMState = true;
            model.YJCount = 0;
            model.YJMoney = 0;
            model.BIsClock = false;
            model.BCount = 0;
            model.sort = GetMaxCount() + 1;//获取编号
            model.BMBD = GetBMBDTemp(model.sort);//获取接点人
            model.BMID = GetBMIDTemp(member);//获取B网编号
            Insert(model, MyHs);
            //BLL.ChangeMoney.R_BJD(model, member, 1, MyHs);
            return MyHs;
        }

        public static int GetMaxCount()
        {
            if (DAL.BMember.tempBMemberList.Any())
            {
                return DAL.BMember.tempBMemberList.Max(m => m.sort);
            }
            else
            {
                return DAL.BMember.GetMaxSort();
            }
        }

        public static string GetBMIDTemp(Model.Member model)
        {
            var bmodel = DAL.BMember.tempBMemberList.Where(m => m.AMID == model.MID).OrderByDescending(m => m.sort).FirstOrDefault();
            if (bmodel != null)
            {
                var ke = bmodel.BMID.Split('_');
                int index = Convert.ToInt32(ke[ke.Length - 1]);
                return model.MID + "_" + (index + 1);
            }
            return GetBMID(model);
        }

        public static string GetBMBDTemp(int sort)
        {
            int psort = (sort - 1) / 3;
            var model = DAL.BMember.tempBMemberList.Where(m => m.sort == psort).FirstOrDefault();
            if (model != null)
            {
                return model.BMID;
            }
            else
            {
                return DAL.BMember.GetModelBySort(psort);
            }
        }

        public static System.Collections.Hashtable Insert(yny_004.Model.BMember model, System.Collections.Hashtable MyHs)
        {
            DAL.BMember.tempBMemberList.Add(model);
            return yny_004.DAL.BMember.Insert(model, MyHs);
        }

        public static bool Insert(yny_004.Model.BMember model)
        {
            lock (obj)
            {
                obj = new Random().Next(1, 100);
                Hashtable MyHs = new Hashtable();
                Insert(model, MyHs);
                BLL.ChangeMoney.HBChangeTran(model.BCount, model.AMember.MID, BLL.Member.ManageMember.TModel.MID, "GW", model.AMember, "MJB", "", MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                    return true;
                return false;
            }
        }

        private static string GetBMBD(string mid, int count)
        {
            return DAL.BMember.GetBMBD(mid, count);
        }

        public static System.Collections.Hashtable Update(yny_004.Model.BMember model, System.Collections.Hashtable MyHs)
        {
            return yny_004.DAL.BMember.Update(model, MyHs);
        }

        public static bool Update(yny_004.Model.BMember model)
        {
            return yny_004.DAL.BMember.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return yny_004.DAL.BMember.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return yny_004.DAL.BMember.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return yny_004.DAL.BMember.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.BMember.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<yny_004.Model.BMember> GetList(string strWhere)
        {
            return yny_004.DAL.BMember.GetList(strWhere);
        }
        public static List<yny_004.Model.BMember> GetList(int top, string strWhere)
        {
            return yny_004.DAL.BMember.GetList(top, strWhere);
        }

        public static List<yny_004.Model.BMember> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.BMember.GetList(strWhere, pageIndex, pageSize, out count, "BMID DESC");
        }

        public static string GetBMID(Model.Member model)
        {
            return yny_004.DAL.BMember.GetBMID(model);
        }
    }
}
