/**  版本信息模板在安装目录下，可自行修改。
* LotteryDraw.cs
*
* 功 能： N/A
* 类 名： LotteryDraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/8 18:39:53   N/A    初版
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
    /// LotteryDraw:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LotteryDraw
    {
        public LotteryDraw()
        { }
        #region Model
        private int _id;
        private string _code;
        private DateTime _createtime;
        private decimal _lmoney;
        private bool _state;
        private string _getmid;
        private string _pointmid;
        private decimal? _costmoney;
        private DateTime? _gettime;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 红包编号
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 红包钱数
        /// </summary>
        public decimal LMoney
        {
            set { _lmoney = value; }
            get { return _lmoney; }
        }
        /// <summary>
        /// 红包状态(0:未领取;1:已领取)
        /// </summary>
        public bool State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 领取人
        /// </summary>
        public string GetMID
        {
            set { _getmid = value; }
            get { return _getmid; }
        }
        /// <summary>
        /// 指定领取人
        /// </summary>
        public string PointMID
        {
            set { _pointmid = value; }
            get { return _pointmid; }
        }
        /// <summary>
        /// 花费钱数
        /// </summary>
        public decimal? CostMoney
        {
            set { _costmoney = value; }
            get { return _costmoney; }
        }
        /// <summary>
        /// 领取时间
        /// </summary>
        public DateTime? GetTime
        {
            set { _gettime = value; }
            get { return _gettime; }
        }
        #endregion Model

    }
}

