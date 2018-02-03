/**  版本信息模板在安装目录下，可自行修改。
* NewSHMoney.cs
*
* 功 能： N/A
* 类 名： NewSHMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/1 17:49:03   N/A    初版
*
* Copyright (c) 2012 yny_004 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using yny_004.Model;
using yny_004.DAL;
namespace yny_004.BLL
{
	/// <summary>
	/// NewSHMoney
	/// </summary>
	public partial class NewSHMoney
	{
        private readonly DAL.NewSHMoney dal = new DAL.NewSHMoney();
		public NewSHMoney()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string NType)
		{
			return dal.Exists(NType);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(yny_004.Model.NewSHMoney model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(yny_004.Model.NewSHMoney model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string NType)
		{
			
			return dal.Delete(NType);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NTypelist )
		{
			return dal.DeleteList(NTypelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static yny_004.Model.NewSHMoney GetModel(string NType)
		{
			return DAL.NewSHMoney.GetModel(NType);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_004.Model.NewSHMoney> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yny_004.Model.NewSHMoney> DataTableToList(DataTable dt)
		{
			List<yny_004.Model.NewSHMoney> modelList = new List<yny_004.Model.NewSHMoney>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yny_004.Model.NewSHMoney model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = DAL.NewSHMoney.DataRowToModel(dt.Rows[n]);
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

		#endregion  ExtensionMethod
	}
}

