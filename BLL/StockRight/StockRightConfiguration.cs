using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class StockRightConfiguration
    {
        public static Model.StockRightConfiguration Model
        {
            get
            {
                return DAL.StockRightConfiguration.StockRightCf;
            }
            set
            {
                DAL.StockRightConfiguration.StockRightCf = value;
            }
        }

        public static bool Update(Model.StockRightConfiguration model)
        {
            return DAL.StockRightConfiguration._Update(model);
        }

        public static bool ReSetSys()
        {
            return DAL.StockRightConfiguration.ReSetSys();
        }
    }
}
