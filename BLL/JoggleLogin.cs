/**  版本信息模板在安装目录下，可自行修改。
* JoggleLogin.cs
*
* 功 能： N/A
* 类 名： JoggleLogin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/1 10:40:15   N/A    初版
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
using System.Configuration;
namespace yny_004.BLL
{
    /// <summary>
    /// JoggleLogin
    /// </summary>
    public partial class JoggleLogin
    {
        private readonly yny_004.DAL.JoggleLogin dal = new yny_004.DAL.JoggleLogin();
        public JoggleLogin()
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
        public int Add(yny_004.Model.JoggleLogin model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(yny_004.Model.JoggleLogin model)
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
        public yny_004.Model.JoggleLogin GetModel(int ID)
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
        public List<yny_004.Model.JoggleLogin> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<yny_004.Model.JoggleLogin> DataTableToList(DataTable dt)
        {
            List<yny_004.Model.JoggleLogin> modelList = new List<yny_004.Model.JoggleLogin>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                yny_004.Model.JoggleLogin model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
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
        /// 验证
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="code"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string GetCheckCodeValid(string mid, string code, string domain)
        {
            string time = ConfigurationManager.AppSettings["validityTime"].ToString();
            //验证密码
            Model.JoggleLogin model = dal.GetModelByMID(mid, time);
            if (model == null)
            {
                return "0登录过期";
            }
            else
            {
                DateTime now = DateTime.Now;
                //校验当前时间
                string validCode = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mid + model.Code + now.ToString("yyyyMMddHHmm") + domain, "MD5");
                //校验前一分钟
                string validCode1 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mid + model.Code + now.AddMinutes(-1).ToString("yyyyMMddHHmm") + domain, "MD5");
                if (code == validCode || code == validCode1)
                {
                    string oldCode = model.Code;
                    //生成随机验证码
                    model.Code = GetRandomCode();
                    if (dal.Update(model))
                    {
                        return "1" + model.Code;
                    }
                    else
                    {
                        return "1" + oldCode;
                    }
                }
                else
                {
                    return "0验证失败";
                }
            }
        }
        /// <summary>
        /// 创建
        /// </summary>
        public string CreateJoggle(string mid)
        {
            string time = ConfigurationManager.AppSettings["validityTime"].ToString();
            Model.JoggleLogin model = dal.GetModelByMID(mid, time);
            if (model != null)
            {
                model.Code = GetRandomCode();
                model.Createtime = DateTime.Now;
                if (!dal.Update(model))
                {
                    return "0";
                }
            }
            else
            {
                model = new Model.JoggleLogin();
                model.MID = mid;
                model.Code = GetRandomCode();
                model.Createtime = DateTime.Now;
                if (!(dal.Add(model) > 0))
                {
                    return "0";
                }
            }
            return "1" + model.Code;
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandomCode()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        #endregion  ExtensionMethod
    }
}

