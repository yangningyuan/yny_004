using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Accounts
    {
        public int ID { get; set; }

        private string _acode;
        public string ACode
        {
            get
            {
                if (string.IsNullOrEmpty(_acode))
                    _acode = CreateDate.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
                return _acode;
            }
            set
            {
                _acode = value;
            }
        }
        /// <summary>
        /// 奖金类型001报单结算，002自动提现，003日分红，004周分红，005升级结算，006月结算
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// 奖金类型
        /// </summary>
        public string PCodeStr
        {
            get
            {
                if (PCode == "001")
                    return "报单拨出";
                else if (PCode == "002")
                    return "自动提现";
                else if (PCode == "003")
                    return "日红利";
                else if (PCode == "005")
                    return "升级拨出";
                else if (PCode == "007")
                    return "股权红利";
                return "未知";
            }
        }
        /// <summary>
        /// 分红日期
        /// </summary>
        public DateTime AccountsDate { get; set; }
        /// <summary>
        /// 总计分红
        /// </summary>
        public decimal TotalFHMoney { get; set; }
        /// <summary>
        /// 是否自动分红
        /// </summary>
        public bool IsAuto { get; set; }
        /// <summary>
        /// 结算人数
        /// </summary>
        public int FHCount { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否结算
        /// </summary>
        public bool IfAccount { get; set; }

        public string ARemark { get; set; }

        public Dictionary<string, decimal> AccountMember = new Dictionary<string, decimal>();
    }
}
