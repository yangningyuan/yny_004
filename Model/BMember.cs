using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class BMember
    {
        public int ID { get; set; }
        public string AMID { get; set; }
        public string BMID { get; set; }
        public string BMBD { get; set; }
        public DateTime BMCreateDate { get; set; }
        public DateTime BMDate { get; set; }
        public bool BMState { get; set; }
        public bool BIsClock { get; set; }
        public decimal YJCount { get; set; }
        public decimal YJMoney { get; set; }
        public decimal BCount { get; set; }
        public Member AMember { get; set; }
        public int sort { get; set; }
    }
}
