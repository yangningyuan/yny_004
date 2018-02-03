/**  版本信息模板在安装目录下，可自行修改。
* QuitRecord.cs
*
* 功 能： N/A
* 类 名： QuitRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/9 11:38:00   N/A    初版
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
    /// QuitRecord
    /// </summary>
    public partial class QuitRecord
    {
        private readonly yny_004.DAL.QuitRecord dal = new yny_004.DAL.QuitRecord();
        public QuitRecord()
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
        public int Add(yny_004.Model.QuitRecord model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.QuitRecord model)
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
        public yny_004.Model.QuitRecord GetModel(string ID)
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
        public List<yny_004.Model.QuitRecord> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yny_004.Model.QuitRecord> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.QuitRecord> modelList = new List<yny_004.Model.QuitRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.QuitRecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.QuitRecord.DataRowToModel(dt.Rows[n]);
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        public static bool CreateQuit(Model.Member member)
        {
            Model.QuitRecord quit = new Model.QuitRecord();
            quit.CreateTime = DateTime.Now;
            quit.EnterTime = member.MDate;
            quit.MID = member.MID;
            quit.State = 0;
            quit.TXMoney = BLL.ChangeMoney.GetTXMoney(" FromMID = '" + member.MID + "' and ChangeType = 'TX' ");
            quit.InvestMoney = member.MConfig.SHMoney;

            return new yny_004.DAL.QuitRecord().Add(quit) > 0;
        }

        public static List<yny_004.Model.QuitRecord> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return yny_004.DAL.QuitRecord.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static string QuitSH(string par, Model.Member member)
        {
            if (member.Role.IsAdmin)
            {
                var list = par.Split('@');
                Model.QuitRecord model = new BLL.QuitRecord().GetModel(list[0]);
                if (model != null)
                {
                    if (list[1] == "1")
                    {
                        model.State = 1;
                    }
                    else
                    {
                        model.State = 2;
                    }
                    model.CompleteTime = DateTime.Now;
                    model.Remark = list[2];
                    Hashtable MyHs = new Hashtable();
                    if (model.State == 1)
                    {
                        //封号
                        MyHs.Add(" update member set IsClock = 1 ,IsClose = 1 where MID = '" + model.MID + "' ", null);
                    }
                    DAL.QuitRecord.Update(model, MyHs);
                    if (CommonBase.RunHashtable(MyHs))
                    {
                        return "审核成功";
                    }
                    else
                    {
                        return "审核失败";
                    }
                }
                return "参数错误";
            }
            else
            {
                return "您没有权限";
            }
        }

        #endregion  ExtensionMethod
    }
}

