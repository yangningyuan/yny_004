/**  版本信息模板在安装目录下，可自行修改。
* StockRight.cs
*
* 功 能： N/A
* 类 名： StockRight
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:09   N/A    初版
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
    /// StockRight:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockRight
    {
        public StockRight()
        { }
        #region Model
        private int _id;
        private string _mid;
        private DateTime _buydate;
        private decimal _buymoney;
        private int _buycount;
        private string _stocktype;
        private int _fhcount;
        private decimal _fhmoney;
        private bool _isvalid;
        private DateTime? _outdate;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员帐号
        /// </summary>
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 购买总价
        /// </summary>
        public decimal BuyMoney
        {
            set { _buymoney = value; }
            get { return _buymoney; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount
        {
            set { _buycount = value; }
            get { return _buycount; }
        }
        /// <summary>
        /// 股权类型
        /// </summary>
        public string StockType
        {
            set { _stocktype = value; }
            get { return _stocktype; }
        }
        /// <summary>
        /// 已分红次数
        /// </summary>
        public int FHCount
        {
            set { _fhcount = value; }
            get { return _fhcount; }
        }
        /// <summary>
        /// 剩余分红钱数
        /// </summary>
        public int RemainFHCount { get; set; }
        /// <summary>
        /// 已分红钱数
        /// </summary>
        public decimal FHMoney
        {
            set { _fhmoney = value; }
            get { return _fhmoney; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        /// <summary>
        /// 出局时间
        /// </summary>
        public DateTime? OutDate
        {
            set { _outdate = value; }
            get { return _outdate; }
        }
        #endregion Model

    }
}

