using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace yny_004.BLL
{
    public class BCenter
    {
        public static bool Insert(Model.BCenter model)
        {

            Hashtable MyHs = new Hashtable();
            MyHs = DAL.BCenter.Insert(model, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);

        }

        public static List<Model.BCenter> GetList(string strWhere)
        {
            return DAL.BCenter.GetList(strWhere);
        }
        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.BCenter> GetBCenterEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.BCenter.GetBCenterEntityList(strWhere, pageIndex, pageSize, out count);
        }

        public static bool SHBCenter(string mid)
        {
            return DAL.BCenter.SHBCenter(mid);
        }

        public static string DeleteBCenter(string midlist)
        {
            return DAL.BCenter.DeleteBCenter(midlist);
        }

        public static Model.BCenter GetModel(string mid)
        {
            return DAL.BCenter.GetModel(mid);
        }
    }
}
