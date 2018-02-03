using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    /// <summary>
    /// 配置字典
    /// </summary>
    public class ConfigDictionary
    {

        /// <summary>
        /// 类型
        /// </summary>
        public string DType { get; set; }
        /// <summary>
        /// 开始数
        /// </summary>
        public int StartLevel { get; set; }

        /// <summary>
        /// 结束数
        /// </summary>
        public int EndLevel { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string DValue { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string DKey { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
    }
}
