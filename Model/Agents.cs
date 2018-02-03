/**  版本信息模板在安装目录下，可自行修改。
* Agents.cs
*
* 功 能： N/A
* 类 名： Agents
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/10 13:46:16   N/A    初版
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
    /// Agents:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Agents
    {
        public Agents()
        { }
        #region Model
        private int _id;
        private string _mid;
        private string _province;
        private string _city;
        private string _zone;
        private string _type;
        private decimal _fhfloat;
        private DateTime _createtime;
        private int _isvalid;
        private string _remarks;
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
        public string MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Zone
        {
            set { _zone = value; }
            get { return _zone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FHFloat
        {
            set { _fhfloat = value; }
            get { return _fhfloat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public AgentValidEnum IsValid
        {
            set { _isvalid = (int)value; }
            get { return (AgentValidEnum)_isvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsValidStr
        {
            get
            {
                switch (IsValid)
                {
                    case AgentValidEnum.Pending:
                        return "待审核";
                    case AgentValidEnum.Success:
                        return "审核成功";
                    case AgentValidEnum.Fail:
                        return "已拒绝";
                    default:
                        return "未知";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model
    }

    public enum AgentValidEnum
    {
        /// <summary>
        /// 待审核
        /// </summary>
        Pending = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 失败
        /// </summary>
        Fail = 2
    }
}

