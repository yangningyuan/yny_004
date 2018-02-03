/**  版本信息模板在安装目录下，可自行修改。
* StockRightConfig.cs
*
* 功 能： N/A
* 类 名： StockRightConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace yny_004.Model
{
    /// <summary>
    /// StockRightConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockRightConfig
    {
        public StockRightConfig()
        { }
        #region Model
        private string _code;
        private int _fhcount;
        private decimal _fhfloat;
        private decimal _buymoney;
        private int _limitcount;
        private int _sellcount;
        /// <summary>
        /// 股权编码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 分红天数(次数)
        /// </summary>
        public int FHCount
        {
            set { _fhcount = value; }
            get { return _fhcount; }
        }
        /// <summary>
        /// 分红比例
        /// </summary>
        public decimal FHFloat
        {
            set { _fhfloat = value; }
            get { return _fhfloat; }
        }
        /// <summary>
        /// 卖出单价
        /// </summary>
        public decimal BuyMoney
        {
            set { _buymoney = value; }
            get { return _buymoney; }
        }
        /// <summary>
        /// 今日限额
        /// </summary>
        public int LimitCount
        {
            set { _limitcount = value; }
            get { return _limitcount; }
        }
        /// <summary>
        /// 卖出数量
        /// </summary>
        public int SellCount
        {
            set { _sellcount = value; }
            get { return _sellcount; }
        }
        #endregion Model
    }
}

