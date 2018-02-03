using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Contents
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string CID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string CTitle { get; set; }
        /// <summary>
        /// 目录级别
        /// </summary>
        public int CLevel { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string CAddress { get; set; }
        /// <summary>
        /// 父节点序号
        /// </summary>
        public string CFID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool CState { get; set; }
        /// <summary>
        /// 是否在列表中显示
        /// </summary>
        public bool VState { get; set; }
        /// <summary>
        /// 是否在列表中显示
        /// </summary>
        public int CIndex { get; set; }
        /// <summary>
        /// 是否在列表中显示
        /// </summary>
        public string CImage { get; set; }

        /// <summary>
        /// 是否是快捷菜单
        /// </summary>
        public bool IsQuickMenu { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否外部链接
        /// </summary>
        public bool IsOuterLink { get; set; }

        /// <summary>
        /// 外部链接地址
        /// </summary>
        public string OuterAddress { get; set; }
    }
}
