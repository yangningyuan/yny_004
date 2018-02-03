/**  版本信息模板在安装目录下，可自行修改。
* ZFHTable.cs
*
* 功 能： N/A
* 类 名： ZFHTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/1/23 15:29:02   N/A    初版
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
    /// ZFHTable:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ZFHTable
    {
        public ZFHTable()
        { }
        #region Model
        private string _allrewardstr;
        private decimal _e_jqfhfloat;
        private DateTime _begintime;
        private decimal _fhmoney;
        private int _fhstate;
        /// <summary>
        /// 
        /// </summary>
        public string AllRewardStr
        {
            set { _allrewardstr = value; }
            get { return _allrewardstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal E_JQFHFloat
        {
            set { _e_jqfhfloat = value; }
            get { return _e_jqfhfloat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime beginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FHMoney
        {
            set { _fhmoney = value; }
            get { return _fhmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FHState
        {
            set { _fhstate = value; }
            get { return _fhstate; }
        }
        #endregion Model
    }
}

