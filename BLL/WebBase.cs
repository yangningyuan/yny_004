using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public static class WebBase
    {
        public static Model.WebBase Model
        {
            get
            {
                return DAL.WebBase.Model;
            }
        }

        public static bool Update(Model.WebBase model)
        {
            return DAL.WebBase.Update(model);
        }
    }
}
