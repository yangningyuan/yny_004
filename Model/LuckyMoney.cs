/**  版本信息模板在安装目录下，可自行修改。
* LuckyMoney.cs
*
* 功 能： N/A
* 类 名： LuckyMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/12 10:09:36   N/A    初版
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
    /// LuckyMoney:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LuckyMoney
    {
        public LuckyMoney()
        { }
        #region Model
        private int _id;
        private string _mid;
        private DateTime _createtime;
        private int _fhtimes;
        private decimal _fhmoney;
        private int _isvalid;
        private decimal _totalmoney;
        private DateTime _edittime;

        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户MID
        /// </summary>
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
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
        /// 分红次数
        /// </summary>
        public int FHTimes
        {
            set { _fhtimes = value; }
            get { return _fhtimes; }
        }

        /// <summary>
        /// 分红钱数
        /// </summary>
        public decimal FHMoney
        {
            set { _fhmoney = value; }
            get { return _fhmoney; }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public int isValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }

        /// <summary>
        /// 总价值
        /// </summary>
        public decimal TotalMoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }

        /// <summary>
        /// 总价值
        /// </summary>
        public DateTime EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }

        public decimal ApplyMoney { get; set; }


        public decimal TakeOffmoney { get; set; }


        public int Type { get; set; }

        #endregion Model
    }
}

