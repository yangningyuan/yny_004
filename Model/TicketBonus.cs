using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class TicketBonus
    {
        public int Percents { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BonusPlan { get; set; }
        public List<BonusGift> GiftList { get; set; }
        public bool TicketState { get; set; }
        public decimal Money { get; set; }
        public int PlayBonus { get; set; }
        public string AboutBonus { get; set; }
    }
}
