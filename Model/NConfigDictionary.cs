/**  版本信息模板在安装目录下，可自行修改。
* NConfigDictionary.cs
*
* 功 能： N/A
* 类 名： NConfigDictionary
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/26 16:03:47   N/A    初版
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
    /// NConfigDictionary:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NConfigDictionary
    {
        public NConfigDictionary()
        { }
        #region Model
        private string _ndtpye;
        private string _dkey;
        private int _startlevel;
        private int _endlevel;
        private int _startrec;
        private int _endrec;
        private string _dvalue;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string NDTpye
        {
            set { _ndtpye = value; }
            get { return _ndtpye; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DKey
        {
            set { _dkey = value; }
            get { return _dkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StartLevel
        {
            set { _startlevel = value; }
            get { return _startlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int EndLevel
        {
            set { _endlevel = value; }
            get { return _endlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StartRec
        {
            set { _startrec = value; }
            get { return _startrec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int EndRec
        {
            set { _endrec = value; }
            get { return _endrec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DValue
        {
            set { _dvalue = value; }
            get { return _dvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

