using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
	public class QueryOperationRecord
	{
		/// <summary>
		/// 查询操作者
		/// </summary>
		public string MID { get; set; }

		/// <summary>
		/// 查询角色
		/// </summary>
		public string RoleCode { get; set; }

		/// <summary>
		/// 查询级别
		/// </summary>
		public string LevelCode { get; set; }

		/// <summary>
		/// 操作类型
		/// </summary>
		public string TypeCode { get; set; }

		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? EndTime { get; set; }
	}
}
