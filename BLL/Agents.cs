/**  版本信息模板在安装目录下，可自行修改。
* Agents.cs
*
* 功 能： N/A
* 类 名： Agents
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/10 12:00:24   N/A    初版
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
using System.Linq;
using System.Collections;

namespace yny_004.BLL
{
    /// <summary>
    /// Agents
    /// </summary>
    public partial class Agents
    {
        private readonly yny_004.DAL.Agents dal = new yny_004.DAL.Agents();
        public Agents()
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
        public static bool Add(yny_004.Model.Agents model)
        {
            return DAL.Agents.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.Agents model)
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
        public static yny_004.Model.Agents GetModel(int ID)
        {
            return DAL.Agents.GetModel(ID);
        }

        public static DataSet GetList(string strWhere)
        {
            return DAL.Agents.GetList(strWhere);
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
        public static List<yny_004.Model.Agents> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Agents.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static yny_004.Model.Agents GetModel(string strWhere)
        {
            Model.Agents model = GetModelList(strWhere).FirstOrDefault();
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<yny_004.Model.Agents> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.Agents> modelList = new List<yny_004.Model.Agents>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.Agents model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DAL.Agents.DataRowToModel(dt.Rows[n]);
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
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.Agents> GetBCenterEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Agents.GetBCenterEntityList(strWhere, pageIndex, pageSize, out count);
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
        /// 是否可以成为代理
        /// </summary>
        public static string CanBeAgent(Model.Agents agents)
        {
            string result = "";
            //是否有过这个代理
            if (agents.Type != "VIP")
            {//升级为代理
                //省市县是否已经有代理
                Model.Agents agent = GetModel(string.Format(" Province = '{0}' and City = '{1}' and Zone = '{2}' and Type = '{3}' and IsValid = {4} ", agents.Province, agents.City, agents.Zone, agents.Type, (int)AgentValidEnum.Success));
                if (agent != null)
                {
                    result = "该区域已经存在代理";
                }
            }
            return result;
        }

        /// <summary>
        /// 区域检测
        /// </summary>
        public static string ZoneValid(Model.Agents model)
        {
            if (model.Type == "VIP3")
            {
                if (string.IsNullOrEmpty(model.Province))
                {
                    return "必须选择省";
                }
                model.City = "";
                model.Zone = "";
            }
            if (model.Type == "VIP2")
            {
                if (string.IsNullOrEmpty(model.City))
                {
                    return "必须选择市";
                }
                model.Zone = "";
            }
            if (model.Type == "VIP1")
            {
                if (string.IsNullOrEmpty(model.Zone))
                {
                    return "必须选择县";
                }
            }
            return "";
        }

        /// <summary>
        /// 添加申请
        /// </summary>
        public static string AddApply(Model.Agents model)
        {
            string result = ZoneValid(model);
            if (string.IsNullOrEmpty(result))
            {
                result = CanBeAgent(model);
                if (string.IsNullOrEmpty(result))
                {
                    //添加
                    if (Add(model))
                    {
                        return "";
                    }
                    else
                    {
                        return "申请失败";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 审核代理
        /// </summary>
        public static string SHAgent(Model.Agents model)
        {
            string result = CanBeAgent(model);
            if (string.IsNullOrEmpty(result))
            {
                Hashtable MyHs = new Hashtable();
                MyHs.Add(" update Agents set IsValid = 1 where ID = " + model.ID + " ", null);
                Model.Member member = BLL.Member.GetModelByMID(model.MID);
                member.RoleCode = model.Type;
                BLL.Member.UpdateRole(member, MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    result = "";
                }
                else
                {
                    result = "审核失败";
                }
            }
            return result;
        }


        public static string GetStrWhere(Model.Member member, string type)
        {
            string strWhere = " Type = '" + type + "' ";
            if (type == "VIP1")
            {
                strWhere += string.Format(" and Province = '{0}' and City = '{1}' and Zone = '{2}' and IsValid = 1 ", member.Province, member.City, member.Zone);
            }
            if (type == "VIP2")
            {
                strWhere += string.Format(" and Province = '{0}' and City = '{1}' and Zone = '{2}' and IsValid = 1 ", member.Province, member.City, "");
            }
            if (type == "VIP3")
            {
                strWhere += string.Format(" and Province = '{0}' and City = '{1}' and Zone = '{2}' and IsValid = 1 ", member.Province, "", "");
            }
            return strWhere;
        }

        /// <summary>
        /// 获取领导人
        /// </summary>
        public static string GetLeader(Model.Member member)
        {
            //县级代理
            Model.Agents agent = GetModel(GetStrWhere(member, "VIP1"));
            if (agent != null)
            {
                return agent.MID;
            }
            //市级代理
            agent = GetModel(GetStrWhere(member, "VIP2"));
            if (agent != null)
            {
                return agent.MID;
            }
            //省级代理
            agent = GetModel(GetStrWhere(member, "VIP3"));
            if (agent != null)
            {
                return agent.MID;
            }
            return BLL.Member.ManageMember.TModel.MID;
        }

        #endregion  ExtensionMethod
    }
}

