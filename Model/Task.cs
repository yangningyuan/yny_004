using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    /// <summary>
    /// 对话
    /// </summary>
    public class Task
    {
        public int ID { get; set; }
        public string TFromMID { get; set; }
        public string TFromMName { get; set; }
        public string TToMID { get; set; }
        public string TToMName { get; set; }
        public DateTime TDateTime { get; set; }
        public string TContent { get; set; }
        public string TDataStr { get; set; }
        public bool TState { get; set; }
        public string TType { get; set; }
        public string TTypeStr
        {
            get
            {
                switch (TType)
                {
                    case "001":
                        return "我的消息";
                    case "002":
                        return "付款问题";
                    case "003":
                        return "账户问题";
                    case "004":
                        return "建议问题";
                    case "005":
                        return "技术问题";
                    case "006":
                        return "提现问题";
                    case "008":
                        return "交易投诉";
                    default:
                        return "其他问题";
                }
            }
        }
    }

    public enum TaksType { CW, KF, GL }
}
