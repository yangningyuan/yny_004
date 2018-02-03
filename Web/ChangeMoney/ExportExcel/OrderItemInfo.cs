using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yny_004.Web.ExportExcel
{
	/// <summary>
	/// 订单项信息
	/// </summary>
	public class OrderItemInfo
	{
		/// <summary>
		/// 商户订单号
		/// </summary>
		public string OrderCode { get; set; }

		/// <summary>
		/// 收款人名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 收款人账号
		/// </summary>
		public string BankNumber { get; set; }

		/// <summary>
		/// 收款账户类型
		/// </summary>
		public string AccountType { get; set; }

		/// <summary>
		/// 交易金额，最多保留两位小数的正数
		/// </summary>
		public double Amount { get; set; }

		/// <summary>
		/// 开户行行号
		/// </summary>
		public string BankID { get; set; }

        /// <summary>
        /// 开户行名称（精确到支行）
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 开户省
        /// </summary>
        public string Provice { get; set; }
        /// <summary>
        /// 开户市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 开户行名称
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string Purpose { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks { get; set; }
	}
}