using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Notice
    {
        public int ID { get; set; }
        public string NTitle { get; set; }
        public string NContent { get; set; }
        public int NClicks { get; set; }
        public bool NState { get; set; }
        public DateTime NCreateTime { get; set; }
        public bool IsFixed { get; set; }
    }
}
