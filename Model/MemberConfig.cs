using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class MemberConfig
    {
        /// <summary>
        /// 会员账号
        /// </summary>
        public string MID { get; set; }
        /// <summary>
        /// 市场业绩数量
        /// </summary>
        public int YJCount { get; set; }
        /// <summary>
        /// 市场业绩
        /// </summary>
        public int YJMoney { get; set; }
        /// <summary>
        /// 推荐业绩数量总
        /// </summary>
        public int TJCount { get; set; }
        /// <summary>
        /// 推荐业绩
        /// </summary>
        public int TJMoney { get; set; }
        /// <summary>
        /// 有效投资额
        /// </summary>
        public int SHMoney { get; set; }
        /// <summary>
        /// 双轨对碰
        /// </summary>
        public int UpSumMoney { get; set; }
        /// <summary>
        /// 毛收益
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 实际收益
        /// </summary>
        public decimal RealMoney { get; set; }
        /// <summary>
        /// 奖金
        /// </summary>
        public string JJTypeList { get; set; }
        /// <summary>
        /// 扣税
        /// </summary>
        public decimal TakeOffMoney { get; set; }
        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal ReBuyMoney { get; set; }
        /// <summary>
        /// 累计提现
        /// </summary>
        public decimal TotalTXMoney { get; set; }
        /// <summary>
        /// 股权
        /// </summary>
        public decimal MHB { get; set; }
        /// <summary>
        /// 股权
        /// </summary>
        public decimal MJJ { get; set; }
        /// <summary>
        /// 资金池
        /// </summary>
        public decimal MJB { get; set; }
        private decimal _mgp;
        /// <summary>
        /// 分红
        /// </summary>
        public decimal MGP
        {
            get
            {
                return _mgp;
            }
            set
            {
                _mgp = value.ToFixedDecimal(0);
            }
        }
        /// <summary>
        /// 红包区
        /// </summary>
        public decimal MCW { get; set; }
        /// <summary>
        /// 冻结费用
        /// </summary>
        public decimal MHBFreeze { get; set; }
        /// <summary>
        /// 动态分红开关
        /// </summary>
        public bool DTFHState { get; set; }
        /// <summary>
        /// 静态总开关
        /// </summary>
        public bool JTFHState { get; set; }
        /// <summary>
        /// 一条线分红
        /// </summary>
        public decimal TotalDFHMoney { get; set; }
        /// <summary>
        /// 代数奖
        /// </summary>
        public decimal TotalZFHMoney { get; set; }
        /// <summary>
        /// 消费积分
        /// </summary>
        public decimal TotalYFHMoney { get; set; }

        public Model.Member Member { get; set; }
        /// <summary>
        /// 已有股权数量
        /// </summary>
        public int GQCount { get; set; }
        /// <summary>
        /// 推荐股权数量
        /// </summary>
        public int HLGQCount { get; set; }

        /// <summary>
        /// 增加字段是否可提现
        /// </summary>
        public bool TXStatus { get; set; }
        /// <summary>
        /// 增加字段是否可转账
        /// </summary>
        public bool ZZStatus { get; set; }

        public int EPTimeOutCount { get; set; }

        public int EPXingCount { get; set; }

        public string EPXingJiStr
        {
            get
            {
                string str = "<span style='color:red;'>";
                for (int i = 0; i < this.EPXingCount; i++)
                {
                    str += "★";
                }
                return str + "</span>";
            }
        }

        /// <summary>
        /// 推荐奖比例
        /// </summary>
        public decimal TJFloat { get; set; }
    }
}
