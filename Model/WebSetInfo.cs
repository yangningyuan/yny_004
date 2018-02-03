using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class WebSetInfo
    {
        /// <summary>
        /// 网站状态
        /// </summary>
        public bool WebState { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        public string WebTitle { get; set; }
        /// <summary>
        /// 网站关键字
        /// </summary>
        public string WKeyword { get; set; }
        /// <summary>
        /// 网站描述
        /// </summary>
        public string WDescription { get; set; }
        /// <summary>
        /// 版权
        /// </summary>
        public string WCopyright { get; set; }
        /// <summary>
        /// 网站开放时间
        /// </summary>
        public string OpenTimeStr { get; set; }
        /// <summary>
        /// 关闭提示
        /// </summary>
        public string CloseInfo { get; set; }
        public List<string> OpenTimeList
        {
            get
            {
                if (!string.IsNullOrEmpty(OpenTimeStr))
                    return OpenTimeStr.Split(';').Where(emp => !string.IsNullOrEmpty(emp)).ToList();
                return new List<string>();
            }
        }
        /// <summary>
        /// 提现提示
        /// </summary>
        public string TXInfo { get; set; }
        /// <summary>
        /// 汇款提示
        /// </summary>
        public string HKInfo { get; set; }
        public int PageSize { get; set; }//每页行数
    }
}
