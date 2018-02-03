/**  版本信息模板在安装目录下，可自行修改。
* Sys_LanguageType.cs
*
* 功 能： N/A
* 类 名： Sys_LanguageType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/5/28 10:15:01   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace CommonModel
{
    /// <summary>
    /// Sys_LanguageType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_LanguageType
    {
        public Sys_LanguageType()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _name;
        private string _imgurl;
        private bool _status;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

