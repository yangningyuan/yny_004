/**  版本信息模板在安装目录下，可自行修改。
* StockRight.cs
*
* 功 能： N/A
* 类 名： StockRight
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:09   N/A    初版
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
    /// StockRight
    /// </summary>
    public partial class StockRight
    {
        private readonly yny_004.DAL.StockRight dal = new yny_004.DAL.StockRight();
        public StockRight()
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
        public bool Add(yny_004.Model.StockRight model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.StockRight model)
        {
            return dal.Update(model);
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
        public yny_004.Model.StockRight GetModel(int ID)
        {
            return DAL.StockRight.GetModel(ID);
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
            return DAL.StockRight.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_004.Model.StockRight> GetModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = DAL.StockRight.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yny_004.Model.StockRight> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_004.Model.StockRight> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.StockRight> modelList = new List<yny_004.Model.StockRight>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.StockRight model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.StockRight.DataRowToModel(dt.Rows[n]);
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

        public static List<Model.StockRight> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.StockRight.GetList(strWhere, pageIndex, pageSize, out count);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        public static string BuyStockRight(string mid, int count, Model.StockRightConfig src)
        {
            if (!BLL.ChangeMoney.EnoughChange(mid, count * src.BuyMoney, "MCW"))
            {
                return "您的" + BLL.Reward.List["MCW"].RewardName + "不足";
            }
            Model.StockRight sr = new Model.StockRight();
            sr.BuyCount = count;
            sr.BuyDate = DateTime.Now;
            sr.BuyMoney = count * src.BuyMoney;
            sr.FHCount = 0;
            sr.FHMoney = 0;
            sr.IsValid = true;
            sr.MID = mid;
            sr.StockType = src.Code;

            Hashtable MyHs = new Hashtable();
            DAL.StockRight.Add(sr, MyHs);
            BLL.ChangeMoney.HBChangeTran(sr.BuyMoney, sr.MID, BLL.Member.ManageMember.TModel.MID, "R_BuySR", null, "MCW", "购买股权", MyHs);
            if (CommonBase.RunHashtable(MyHs))
            {
                return "购买成功";
            }
            return "购买失败";
        }

        public static Hashtable PutGQFH(int ID, Hashtable MyHs)
        {
            Model.StockRight sr = DAL.StockRight.GetModel(ID);
            var src = DAL.StockRightConfig.GetStockRightConfigDic()[sr.StockType];
            //分红钱数
            decimal money = (sr.FHMoney + sr.BuyMoney) * src.FHFloat;
            //分红次数
            sr.FHCount++;
            //分红钱数
            sr.FHMoney += money;
            if (sr.FHCount >= src.FHCount)
            {
                sr.IsValid = false;
                sr.OutDate = DateTime.Now;
                //返还本金
                BLL.ChangeMoney.HBChangeTran(sr.BuyMoney, BLL.Member.ManageMember.TModel.MID, sr.MID, "R_FHBJ", null, "MHB", "", MyHs, sr.ID + "", sr.StockType);
            }
            DAL.StockRight.Update(sr, MyHs);
            BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, sr.MID, "R_GQFH", null, "MHB", sr.ID + "", MyHs);

            return MyHs;
        }

        /// <summary>
        /// 发放股权
        /// </summary>
        public static bool PutGQFH(int ID)
        {
            return CommonBase.RunHashtable(PutGQFH(ID, new Hashtable()));
        }

        /// <summary>
        /// 获取购买金额
        /// </summary>
        public static decimal GetBuyMoney(Model.Member member, string type)
        {
            string strWhere = " and IsValid = 1 ";
            if (!member.Role.IsAdmin)
            {
                strWhere += " and MID = '" + member.MID + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere += " and StockType = '" + type + "' ";
            }
            return DAL.StockRight.GetBuyMoney(strWhere).ToFixedDecimal();
        }

        /// <summary>
        /// 获取购买金额
        /// </summary>
        public static decimal GetTotalPutMoney(Model.Member member, string type, int? day = null)
        {
            string strWhere = "  ";
            if (!member.Role.IsAdmin)
            {
                strWhere += " and MID = '" + member.MID + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere += " and StockType = '" + type + "' ";
            }
            if (day != null)
            {
                strWhere += " and DATEDIFF(DAY,BuyDate,GETDATE()) = " + day.Value + " ";
            }
            return DAL.StockRight.GetTotalPutMoney(strWhere).ToFixedDecimal();
        }

        /// <summary>
        /// 获取收益
        /// </summary>
        public static decimal GetPutMoney(Model.Member member, string type, int? day = null)
        {
            string strWhere = " and IsValid = 1 ";
            if (!member.Role.IsAdmin)
            {
                strWhere += " and MID = '" + member.MID + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere += " and StockType = '" + type + "' ";
            }
            //if (day != null)
            //{
            //    strWhere += " and DATEDIFF(DAY,BuyDate,GETDATE()) = " + day.Value + " ";
            //}
            return DAL.StockRight.GetPutMoney(strWhere).ToFixedDecimal();
        }

        /// <summary>
        /// 卖出数量
        /// </summary>
        public static int GetSellCount(Model.Member member, string type, int? day = null)
        {
            string strWhere = "  ";
            if (!member.Role.IsAdmin)
            {
                strWhere += " and MID = '" + member.MID + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere += " and StockType in (" + type + ") ";
            }
            if (day != null)
            {
                strWhere += " and DATEDIFF(DAY,BuyDate,GETDATE()) = " + day.Value + " ";
            }
            return DAL.StockRight.GetSellCount(strWhere);
        }

        /// <summary>
        /// 卖出数量
        /// </summary>
        public static int GetRemainderCount(Model.Member member, string type, int? day = null)
        {
            string strWhere = "  ";
            //if (!member.Role.IsAdmin)
            //{
            //    strWhere += " and MID = '" + member.MID + "' ";
            //}
            if (!string.IsNullOrEmpty(type))
            {
                strWhere += " and StockType in (" + type + ") ";
            }
            if (day != null)
            {
                strWhere += " and DATEDIFF(DAY,BuyDate,GETDATE()) = " + day.Value + " ";
            }
            return BLL.StockRightConfiguration.Model.TotalCount - DAL.StockRight.GetSellCount(strWhere);
        }

        #endregion  ExtensionMethod
    }
}

