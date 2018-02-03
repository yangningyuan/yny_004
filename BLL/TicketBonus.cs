using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class TicketBonus
    {
        public static Model.TicketBonus Model
        {
            get
            {
                return DAL.TicketBonus.Model;
            }
            set
            {
                DAL.TicketBonus.Model = value;
            }
        }

        public static Model.TicketBonus GetModel()
        {
            return DAL.TicketBonus.GetModel();
        }

        public static System.Collections.Hashtable Update(Model.TicketBonus model, System.Collections.Hashtable MyHs)
        {
            foreach (yny_004.Model.BonusGift item in model.GiftList)
            {
                DAL.BonusGift.Update(item, MyHs);
            }
            Model = null;
            return DAL.TicketBonus.Update(model, MyHs);
        }

        public static bool Update(Model.TicketBonus model)
        {
            return DAL.TicketBonus.Update(model);
        }
    }
}
