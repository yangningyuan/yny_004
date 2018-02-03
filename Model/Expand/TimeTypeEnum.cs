using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public enum TimeTypeEnum : int
    {
        /// <summary>
        /// 分钟
        /// </summary>
        Minute = 1,

        /// <summary>
        /// 小时
        /// </summary>
        Hour = 2,

        /// <summary>
        /// 天
        /// </summary>
        Day = 3,

        /// <summary>
        /// 周
        /// </summary>
        Week = 4,

        /// <summary>
        /// 月
        /// </summary>
        Month = 5,

        /// <summary>
        /// 季度
        /// </summary>
        Quarter = 6,
    }
}
