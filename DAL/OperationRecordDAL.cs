using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace yny_004.DAL
{
	public class OperationRecordDAL
	{
		public static void Add(Model.OperationRecord entity)
		{
			EntityHelper.Insert(entity);
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="query"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalCount"></param>
		/// <returns></returns>
		public static IEnumerable<Model.OperationRecord> QueryByPage(Model.QueryOperationRecord query, int pageIndex, int pageSize, out int totalCount)
		{
			string where = GetWhere(query);
			return CommonBase.GetTable("Member_OperationRecord", "ID", "ID DESC", where, pageIndex, pageSize, out totalCount).AsEnumerable().Select(row=>row.ToEntity<Model.OperationRecord>());
		}


		private static string GetWhere(Model.QueryOperationRecord query)
		{
			StringBuilder sql = new StringBuilder();
			var flag = false;

			if (!string.IsNullOrEmpty(query.MID))
			{
				sql.AppendFormat("MID = '{0}'", query.MID);
				flag = true;
			}

			if (!string.IsNullOrEmpty(query.RoleCode))
			{
				if (flag) sql.AppendFormat(" AND ");
				sql.AppendFormat("RoleCode = '{0}'", query.RoleCode);
				flag = true;
			}

			if (!string.IsNullOrEmpty(query.LevelCode))
			{
				if (flag) sql.AppendFormat(" AND ");
				sql.AppendFormat("LevelCode = '{0}'", query.LevelCode);
				flag = true;
			}

			if (!string.IsNullOrEmpty(query.TypeCode))
			{
				if (flag) sql.AppendFormat(" AND ");
				sql.AppendFormat("TypeCode = '{0}'", query.TypeCode);
				flag = true;
			}

			if (query.StartTime != null)
			{
				if (flag) sql.AppendFormat(" AND ");
				sql.AppendFormat("Time > '{0}'", query.StartTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
				flag = true;
			}
			if (query.EndTime != null)
			{
				if (flag) sql.AppendFormat(" AND ");
				sql.AppendFormat("Time <= '{0}'", query.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
				flag = true;
			}

			return sql.ToString();
		}
	}
}
