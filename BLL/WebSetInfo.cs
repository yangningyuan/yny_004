using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class WebSetInfo
    {
        public static Model.WebSetInfo Model
        {
            get
            {
                return DAL.WebSetInfo.Model;
            }
            set
            {
                DAL.WebSetInfo.Model = null;
            }
        }

        public static bool Update(Model.WebSetInfo model)
        {
            return DAL.WebSetInfo.Update(model);
        }
    }
}
