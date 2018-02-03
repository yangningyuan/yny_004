using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class StockRightConfiguration
    {
        /// <summary>
        /// 开放时间
        /// </summary>
        public string OpenTime { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        public bool OpenSwitch { get; set; }
        /// <summary>
        /// 日限额
        /// </summary>
        public int TotalCount { get; set; }

        [IgnoreThis]
        public List<Model.StockRightConfig> stockRightConfigList { get; set; }
        [IgnoreThis]
        public Dictionary<string, Model.StockRightConfig> stockRightConfigDic { get; set; }
    }
}
