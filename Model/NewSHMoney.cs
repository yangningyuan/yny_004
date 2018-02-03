/**  版本信息模板在安装目录下，可自行修改。
* NewSHMoney.cs
*
* 功 能： N/A
* 类 名： NewSHMoney
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/1 17:49:03   N/A    初版
*
* Copyright (c) 2012 yny_004 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace yny_004.Model
{
    /// <summary>
    /// NewSHMoney:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewSHMoney
    {
        public NewSHMoney()
        { }
        #region Model
        private string _ntype;
        private string _nname;
        private decimal _njcfloat;
        private decimal _ntotalyj;
        private decimal _nsmallsumyj;
        private int _ndcount;
        private decimal _nminyj;
        /// <summary>
        /// 等级代码
        /// </summary>
        public string NType
        {
            set { _ntype = value; }
            get { return _ntype; }
        }
        /// <summary>
        /// 等级名称
        /// </summary>
        public string NName
        {
            set { _nname = value; }
            get { return _nname; }
        }
        /// <summary>
        /// 极差奖比例
        /// </summary>
        public decimal NJCFloat
        {
            set { _njcfloat = value; }
            get { return _njcfloat; }
        }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal NTotalYJ
        {
            set { _ntotalyj = value; }
            get { return _ntotalyj; }
        }
        /// <summary>
        /// 小业绩之和
        /// </summary>
        public decimal NSmallSumYJ
        {
            set { _nsmallsumyj = value; }
            get { return _nsmallsumyj; }
        }
        /// <summary>
        /// 部门数
        /// </summary>
        public int NDCount
        {
            set { _ndcount = value; }
            get { return _ndcount; }
        }
        /// <summary>
        /// 最低业绩
        /// </summary>
        public decimal NMinYJ
        {
            set { _nminyj = value; }
            get { return _nminyj; }
        }
        #endregion Model

    }
}

