using System.Collections;
using System.Collections.Generic;
/**  版本信息模板在安装目录下，可自行修改。
* LuckyMoney.cs
*
* 功 能： N/A
* 类 名： LuckyMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/12 10:09:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System.Data;
using System;
namespace yny_004.BLL
{
    /// <summary>
    /// LuckyMoney
    /// </summary>
    public partial class LuckyMoney
    {
        private readonly yny_004.DAL.LuckyMoney dal = new yny_004.DAL.LuckyMoney();
        public LuckyMoney()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(string mid, decimal money, Hashtable MyHs)
        {
            Model.LuckyMoney model = new Model.LuckyMoney();
            //创建时间(第一次分红时间)
            model.CreateTime = DateTime.Now;
            //是否有效
            model.isValid = 0;
            //会员MID
            model.MID = mid;
            //分红次数
            model.FHTimes = 0;
            model.FHMoney = 0;
            model.TotalMoney = money;

            return DAL.LuckyMoney.Add(model, MyHs);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(yny_004.Model.LuckyMoney model)
        {
            return DAL.LuckyMoney.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_004.Model.LuckyMoney model, Hashtable MyHs)
        {
            return DAL.LuckyMoney.Add(model, MyHs);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.LuckyMoney model)
        {
            return DAL.LuckyMoney.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(yny_004.Model.LuckyMoney model, Hashtable MyHs)
        {
            return DAL.LuckyMoney.Update(model, MyHs);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.LuckyMoney GetModel(int ID)
        {
            return DAL.LuckyMoney.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.LuckyMoney GetModel(string strWhere)
        {
            return DAL.LuckyMoney.GetModel(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return DAL.LuckyMoney.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_004.Model.LuckyMoney> GetModelList(string strWhere)
        {
            DataSet ds = DAL.LuckyMoney.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_004.Model.LuckyMoney> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.LuckyMoney> modelList = new List<yny_004.Model.LuckyMoney>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.LuckyMoney model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.LuckyMoney.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        #region  ExtensionMethod

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.LuckyMoney> GetLuckyMoneyEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.LuckyMoney> LuckyMoneyList = new List<Model.LuckyMoney>();

            DataTable table = DAL.LuckyMoney.GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                LuckyMoneyList.Add(DAL.LuckyMoney.DataRowToModel(table.Rows[i]));
            }

            return LuckyMoneyList;
        }

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.LuckyMoney> GetLuckyMoneyEntityListQ(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.LuckyMoney> LuckyMoneyList = new List<Model.LuckyMoney>();

            DataTable table = DAL.LuckyMoney.GetTableQ(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                LuckyMoneyList.Add(DAL.LuckyMoney.DataRowToModel(table.Rows[i]));
            }

            return LuckyMoneyList;
        }

        /// <summary>
        /// 我的分红包数量
        /// </summary>
        public static int MyFHB(string mid, bool? isOut = null)
        {
            string strWhere = string.Format(@" MID = '{0}' ", mid);
            if (isOut != null)
            {
                if (isOut.Value)
                {
                    strWhere += " and isValid = 0 ";
                }
                else
                {
                    strWhere += " and isValid = 1 ";
                }
            }

            var list = GetModelList(strWhere);
            return list.Count;
        }

        private static object lock_apply = new object();
        private static List<string> appliList = new List<string>();

        public static string InvestApply(string mid, decimal applyMoney, int type = 0)
        {
            Model.LuckyMoney lucky = new Model.LuckyMoney();
            lucky.ApplyMoney = applyMoney;
            lucky.CreateTime = DateTime.Now;
            lucky.TotalMoney = 0;
            lucky.TakeOffmoney = 0;
            lucky.MID = mid;
            lucky.isValid = 0;
            lucky.FHTimes = 0;
            lucky.EditTime = DateTime.Now;
            lucky.Type = type;
            lock (lock_apply)
            {

                //今日投资额
                decimal appLyMoney = BLL.LuckyMoney.GetTotalMoney("ApplyMoney", " isValid <> 2 and DATEDIFF(DD,CreateTime,GETDATE()) = 0 ");
                decimal tLyMoney = BLL.LuckyMoney.GetTotalMoney("ApplyMoney", " isValid = 2 and DATEDIFF(DD,EditTime,GETDATE()) = 0 ");
                if (appLyMoney - tLyMoney + applyMoney > BLL.Configuration.Model.E_MaxTouZi)
                {
                    return "今日已达最大投资额度";
                }

                try
                {
                    Model.Member member = DAL.Member.GetModel(mid);
                    if (member == null)
                    {
                        throw new Exception("会员不存在");
                    }
                    if (member.IsClock)
                    {
                        throw new Exception("账户冻结,无法申请");
                    }
                    if (appliList.Contains(mid))
                        return "请不要重复提交！";
                    else
                        appliList.Add(mid);

                    if (type == 1 || BLL.ChangeMoney.EnoughChange(mid, applyMoney, "MJB"))
                    {
                        Hashtable MyHs = new Hashtable();
                        Add(lucky, MyHs);
                        if (type == 0)
                        {
                            BLL.ChangeMoney.HBChangeTran(applyMoney, mid, BLL.Member.ManageMember.TModel.MID, "appplyIn", null, "MJB", "", MyHs);
                            BLL.ChangeMoney.R_TJ(applyMoney, member,member,1, MyHs);
                            BLL.ChangeMoney.YJCountTran(applyMoney, member, member, MyHs);
                        }
                        if (BLL.CommonBase.RunHashtable(MyHs))
                        {
                            //Hashtable hs = new Hashtable();
                            //BLL.ChangeMoney.YJSJCountTran(member, member, hs);
                            //BLL.CommonBase.RunHashtable(hs);
                            if (type == 0)
                            {
                                if (!member.MState)
                                {
                                    BLL.Member.ManageMember.UpMAgencyType(DAL.Configuration.TModel.SHMoneyList["002"], member.MID, "MJB", member, 0);
                                }
                            }
                            if (appliList.Contains(mid))
                                appliList.Remove(mid);
                            return "申请成功";
                        }
                        else
                        {
                            if (appliList.Contains(mid))
                                appliList.Remove(mid);
                            return "申请失败";
                        }
                    }
                    else
                    {
                        if (appliList.Contains(mid))
                            appliList.Remove(mid);
                        return "您的" + BLL.Reward.List["MJB"].RewardName + "不足!";
                    }
                }
                catch (Exception e)
                {
                    if (appliList.Contains(mid))
                        appliList.Remove(mid);
                    return e.Message;
                }
            }
        }


        public static decimal GetTotalMoney(string mid)
        {
            return DAL.LuckyMoney.GetTotalMoney(mid);
        }

        public static decimal GetTotalMoney(string fileName, string strWhere)
        {
            return DAL.LuckyMoney.GetTotalMoney(fileName, strWhere);
        }

        public static int GetCount(string fileName, string strWhere)
        {
            return DAL.LuckyMoney.GetCount(fileName, strWhere);
        }

        #endregion  ExtensionMethod
    }
}

