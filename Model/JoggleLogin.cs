/**  版本信息模板在安装目录下，可自行修改。
* JoggleLogin.cs
*
* 功 能： N/A
* 类 名： JoggleLogin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/1 10:40:15   N/A    初版
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
    /// JoggleLogin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JoggleLogin
    {
        public JoggleLogin()
        { }
        #region Model
        private int _id;
        private string _mid;
        private string _code;
        private DateTime _createtime;
        private bool _isvalid;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 校验码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime Createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        #endregion Model
    }
}

