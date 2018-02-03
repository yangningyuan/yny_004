using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    /// <summary>
    /// 降星记录
    /// </summary>
    public class EPJX
    {
        /// <summary>
        /// 
        /// </summary>
        public int JXID { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime EPJXTime { get; set; }

        /// <summary>
        /// 类型内容
        /// </summary>
        public string EPJXRemark { get; set; }

        /// <summary>
        /// 会员账号
        /// </summary>
        public string EPJXMID { get; set; }

    }
}
