using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    /// <summary>
    /// 福利奖
    /// </summary>
    public class SHMoney
    {
        #region 基本属性
        /// <summary>
        /// 会员级别
        /// </summary>
        public string MAgencyType { get; set; }

        /// <summary>
        /// 级别名称
        /// </summary>
        public string _MAgencyName;
        public string MAgencyName
        {
            get
            {
                return "<b style='color:" + this.MColor + ";font-weight: bold;white-space: nowrap;'>" + this._MAgencyName + "</b>";
            }
            set
            {
                _MAgencyName = value;
            }
        }

        /// <summary>
        /// 审核费用
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 对碰比例
        /// </summary>
        public decimal BTFloat { get; set; }

        /// <summary>
        /// 推荐奖/直推奖
        /// </summary>
        public decimal TJFloat { get; set; }

        /// <summary>
        /// 提现比例
        /// </summary>
        public decimal TXFloat { get; set; }

        /// <summary>
        /// 税扣
        /// </summary>
        public decimal TakeOffFloat { get; set; }

        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal ReBuyFloat { get; set; }

        /// <summary>
        /// 重复消费
        /// </summary>
        public decimal MCWFloat { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string MColor { get; set; }

        /// <summary>
        /// 图谱层数
        /// </summary>
        public int ViewLevel { get; set; }

        /// <summary>
        /// 推荐人数
        /// </summary>
        public int TJCount { set; get; }

        /// <summary>
        /// 市场总业绩
        /// </summary>
        public decimal YJMoney { set; get; }

        /// <summary>
        /// 考核市场数量
        /// </summary>
        public int TeamCount { set; get; }

        /// <summary>
        /// 其它市场比例
        /// </summary>
        public decimal teamPer { set; get; }

        /// <summary>
        /// 最小市场业绩
        /// </summary>
        public decimal MinTeamMoney { set; get; }

        /// <summary>
        /// 可开市场数量
        /// </summary>
        public int SubCount { set; get; }

        /// <summary>
        /// 对碰比例
        /// </summary>
        public decimal DPFloat { get; set; }

        /// <summary>
        /// 对碰封顶
        /// </summary>
        public decimal DPTopMoney { get; set; }

        #endregion
    }
}
