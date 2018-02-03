using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
	/// <summary>
	/// 操作记录
	/// </summary>
	[Table("Member_OperationRecord")]
	public class OperationRecord : SQLEntity
	{
		[IdentityKey]
		public int ID { get; set; }

		/// <summary>
		/// 操作者
		/// </summary>
		public string MID { get; set; }

		/// <summary>
		/// 级别
		/// </summary>
		public string LevelCode { get; set; }

		/// <summary>
		/// 角色
		/// </summary>
		public string RoleCode { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>
		[ColumnConfig(UsePropertyForInsert = false,InsertSQL ="GETDATE()")]
		public DateTime Time { get; set; }

		/// <summary>
		/// 操作类型
		/// </summary>
		[Column("TypeCode")]
		[ColumnConfig(DBType = DBType.String)]
		public ChangeType Type { get; set; }

		/// <summary>
		/// 具体的操作
		/// </summary>
		public string Operation { get; set; }
	}
}
