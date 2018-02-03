/**  版本信息模板在安装目录下，可自行修改。
* BaseParameter.cs
*
* 功 能： N/A
* 类 名： BaseParameter
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/5 11:14:03   N/A    初版
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
    /// BaseParameter:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BaseParameter
    {
        public BaseParameter()
        { }
        #region Model
        private string _ownclass;
        private string _identifyname;
        private string _pvalue;
        private string _ptype;
        /// <summary>
        /// 类名
        /// </summary>
        public string OwnClass
        {
            set { _ownclass = value; }
            get { return _ownclass; }
        }
        /// <summary>
        /// 字段名
        /// </summary>
        public string IdentifyName
        {
            set { _identifyname = value; }
            get { return _identifyname; }
        }
        /// <summary>
        /// 属性值
        /// </summary>
        public string PValue
        {
            set { _pvalue = value; }
            get { return _pvalue; }
        }
        /// <summary>
        /// 属性类型
        /// </summary>
        public string PType
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        #endregion Model

    }
}

