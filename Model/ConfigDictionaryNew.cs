/**  版本信息模板在安装目录下，可自行修改。
* ConfigDictionaryNew.cs
*
* 功 能： N/A
* 类 名： ConfigDictionaryNew
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/9 17:37:20   N/A    初版
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
    /// ConfigDictionaryNew:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ConfigDictionaryNew
    {
        public ConfigDictionaryNew()
        { }
        #region Model
        private string _code;
        private string _dkey;
        private int _tjcount;
        private int _subtjcount;
        private int _gjcount;
        private int _cjcount;
        private decimal _fhmoney;
        private decimal _outfloat;
        private decimal _hbfhfloat;
        private int _fhdays;

        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Dkey
        {
            set { _dkey = value; }
            get { return _dkey; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TJCount
        {
            set { _tjcount = value; }
            get { return _tjcount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SubTJCount
        {
            set { _subtjcount = value; }
            get { return _subtjcount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int GJCount
        {
            set { _gjcount = value; }
            get { return _gjcount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CJCount
        {
            set { _cjcount = value; }
            get { return _cjcount; }
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
        public decimal OutFloat
        {
            set { _outfloat = value; }
            get { return _outfloat; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal HBFHFloat
        {
            set { _hbfhfloat = value; }
            get { return _hbfhfloat; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int FHDays
        {
            set { _fhdays = value; }
            get { return _fhdays; }
        }

        #endregion Model

    }
}

