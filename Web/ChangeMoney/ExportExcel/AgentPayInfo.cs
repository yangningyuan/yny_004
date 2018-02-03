using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yny_004.Web.ExportExcel
{
	/// <summary>
	/// 代付信息
	/// </summary>
	public class AgentPayInfo
	{
		/// <summary>
		/// 版本号
		/// </summary>
		public string Version { get; set; }

		/// <summary>
		/// 打印日期
		/// </summary>
		public string PrintDate { get; set; }

		/// <summary>
		/// 商户名称
		/// </summary>
		public string MerchantName { get; set; }

		/// <summary>
		/// 商户号
		/// </summary>
		public string MerchantID { get; set; }

		/// <summary>
		/// 联系人
		/// </summary>
		public string Contact { get; set; }

		/// <summary>
		/// 联系人电话
		/// </summary>
		public string ContactNumber { get; set; }

		/// <summary>
		/// 商户批次号
		/// </summary>
		public string MerchantBatchNumber { get; set; }
	}
}