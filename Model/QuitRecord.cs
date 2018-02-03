/**  版本信息模板在安装目录下，可自行修改。
* QuitRecord.cs
*
* 功 能： N/A
* 类 名： QuitRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/9 11:38:00   N/A    初版
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
    /// QuitRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class QuitRecord
    {
        public QuitRecord()
        { }
        #region Model
        private int _id;
        private string _mid;
        private DateTime _createtime;
        private DateTime _entertime;
        private int _state;
        private decimal _txmoney;
        private decimal _investmoney;
        private DateTime? _completetime;
        private string _remark;
        /// <summary>
        /// 主键
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
        /// 申请时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 进入系统时间
        /// </summary>
        public DateTime EnterTime
        {
            set { _entertime = value; }
            get { return _entertime; }
        }
        /// <summary>
        /// 状态(0:未审核1:已审核2:已拒绝)
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 已提现金额
        /// </summary>
        public decimal TXMoney
        {
            set { _txmoney = value; }
            get { return _txmoney; }
        }
        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal InvestMoney
        {
            set { _investmoney = value; }
            get { return _investmoney; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CompleteTime
        {
            set { _completetime = value; }
            get { return _completetime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

