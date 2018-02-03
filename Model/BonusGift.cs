using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class BonusGift
    {
        public int GiftNum { get; set; }
        public string GiftName { get; set; }
        public int Probaly { get; set; }//抽中概率
        public string GiftType { get; set; }//奖励类型,MHB,MJB,
        public int GiftCount { get; set; }
        public string GiftCode { get; set; }
        public string BonusPlan { get; set; }
        public string GiftRemark { get; set; }
        public bool IsAuto { get; set; }//即时生效
        public int Points { get; set; }//赠送积分
    }
}
