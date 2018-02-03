/**  版本信息模板在安装目录下，可自行修改。
* BCenter.cs
*
* 功 能： N/A
* 类 名： BCenter
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/2 11:00:34   N/A    初版
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
    /// BCenter:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BCenter
    {
        public BCenter()
        { }

        #region Model

        private string _mid;
        private string _mname;
        private string _type;
        private DateTime _adddate;
        private bool _status;
        private DateTime? _validtime;
        private string _img;
        /// <summary>
        /// 会员帐号
        /// </summary>
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MName
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ValidTime
        {
            set { _validtime = value; }
            get { return _validtime; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string Img
        {
            set { _img = value; }
            get { return _img; }
        }

        #endregion Model
    }
}

