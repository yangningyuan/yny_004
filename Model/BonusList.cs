using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class BonusList
    {
        private string _BonusCode;
        public string BonusCode
        {
            get
            {
                if (string.IsNullOrEmpty(_BonusCode))
                    _BonusCode = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100000, 999999);
                return _BonusCode;
            }
            set
            {
                _BonusCode = value;
            }
        }
        public string MID { get; set; }
        public DateTime BonusDate { get; set; }
        public bool IsValid { get; set; }
        public string GiftCode { get; set; }
        public DateTime ValidDate { get; set; }
        public string BonusRemark { get; set; }
        public int Points { get; set; }
    }
}
