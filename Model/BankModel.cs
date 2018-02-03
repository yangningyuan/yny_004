using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonModel;

namespace yny_004.Model
{
    public class BankModel
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        /// 
        private string _bankCode;
        public string BankCode
        {
            get
            {
                if (string.IsNullOrEmpty(_bankCode))
                    _bankCode = BankCreateDate.ToString("yyyyMMddHHmmss");
                return _bankCode;
            }
            set
            {
                _bankCode = value;
            }
        }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }
   
        /// <summary>
        /// 开户支行
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber { get; set; }
        /// <summary>
        /// 银行卡户主
        /// </summary>
        public string BankCardName { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 是否主要提现银行
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime BankCreateDate { get; set; }
        public Sys_BankInfo BankInfo { get; set; }
    }
}
