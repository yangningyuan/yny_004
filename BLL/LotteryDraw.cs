/**  版本信息模板在安装目录下，可自行修改。
* LotteryDraw.cs
*
* 功 能： N/A
* 类 名： LotteryDraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/8 18:39:53   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using yny_004.Model;
using System.Collections;
namespace yny_004.BLL
{
    /// <summary>
    /// LotteryDraw
    /// </summary>
    public partial class LotteryDraw
    {
        private readonly yny_004.DAL.LotteryDraw dal = new yny_004.DAL.LotteryDraw();
        public LotteryDraw()
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
        public static bool Add(yny_004.Model.LotteryDraw model)
        {
            return DAL.LotteryDraw.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Add(yny_004.Model.LotteryDraw model, Hashtable MyHs)
        {
            return DAL.LotteryDraw.Add(model, MyHs);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.LotteryDraw model)
        {
            return DAL.LotteryDraw.Update(model);
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
        public static bool DeleteList(string IDlist)
        {
            return DAL.LotteryDraw.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public yny_004.Model.LotteryDraw GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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
        public List<yny_004.Model.LotteryDraw> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yny_004.Model.LotteryDraw> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.LotteryDraw> modelList = new List<yny_004.Model.LotteryDraw>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.LotteryDraw model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.LotteryDraw.DataRowToModel(dt.Rows[n]);
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

        public static List<yny_004.Model.LotteryDraw> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.LotteryDraw.GetList(strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 创建红包
        /// </summary>
        public static string CreateDraw(int count, decimal money, string mid)
        {
            if (count <= 0)
            {
                return "红包数量必须大于0";
            }
            if (money < 0)
            {
                return "红包金额不能小于0";
            }
            if (!string.IsNullOrWhiteSpace(mid) && BLL.Member.GetModelByMID(mid) == null)
            {
                return "指定会员不存在";
            }
            Hashtable MyHs = new Hashtable();
            for (int i = 0; i < count; i++)
            {
                Model.LotteryDraw model = new Model.LotteryDraw();
                model.CreateTime = DateTime.Now;
                model.LMoney = money;
                model.PointMID = mid;
                model.State = false;
                Add(model, MyHs);
            }
            if (CommonBase.RunHashtable(MyHs))
            {
                return "1";
            }
            else
            {
                return "生成失败";
            }
        }

        private static object lockobj = new object();

        public static string RobDraw(Model.Member member)
        {
            //// 
            //if (BLL.ChangeMoney.EnoughChange(member.MID, BLL.Configuration.Model.DrawMoney, "MGP"))
            //{
            //    //红包数量是否足够
            //    Model.LotteryDraw model = DAL.LotteryDraw.RobDraw(member.MID);
            //    if (model != null)
            //    {
            //        Hashtable MyHs = new Hashtable();
            //        //扣钱
            //        BLL.ChangeMoney.HBChangeTran(BLL.Configuration.Model.DrawMoney, member.MID, BLL.Member.ManageMember.TModel.MID, "CHB", null, "MGP", "拆红包", MyHs);
            //        //更新
            //        model.CostMoney = BLL.Configuration.Model.DrawMoney;
            //        model.GetTime = DateTime.Now;
            //        model.GetMID = member.MID;
            //        model.State = true;
            //        DAL.LotteryDraw.Update(model, MyHs);
            //        //扣钱
            //        if (model.LMoney > 0)
            //        {
            //            BLL.ChangeMoney.HBChangeTran(model.LMoney, BLL.Member.ManageMember.TModel.MID, member.MID, "R_HBJL", null, "MCW", "红包奖励", MyHs);
            //        }
            //        if (CommonBase.RunHashtable(MyHs))
            //        {
            //            if (model.LMoney > 0)
            //            {
            //                return "1恭喜您,获得" + model.LMoney + "奖励";
            //            }
            //            else
            //            {
            //                return "1很遗憾，您未中奖";
            //            }
            //        }
            //        else
            //        {
            //            return "0拆红包失败";
            //        }
            //    }
            //    return "0红包已领完";
            //}
            //else
            {
                return "0您" + BLL.Reward.List["MGP"].RewardName + "不足,无法继续拆红包";
            }
        }

        public static int GetReaminCount(string mid)
        {
            yny_004.DAL.LotteryDraw dall = new yny_004.DAL.LotteryDraw();
            return dall.GetRecordCount(" State = 0 and (PointMID = '' or PointMID = '" + mid + "') ");
        }

        #endregion  ExtensionMethod
    }
}

