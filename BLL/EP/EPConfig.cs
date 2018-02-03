using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data;

namespace yny_004.BLL
{
    //EPConfig
    public class EPConfig
    {
        public static Model.EPConfig EPConfigModel
        {
            get
            {
                return DAL.EPConfig.EPConfigModel;
            }
            set
            {
                DAL.EPConfig.EPConfigModel = value;
            }
        }
        public static yny_004.Model.EPConfig GetModel()
        {
            return yny_004.DAL.EPConfig.GetModel();
        }

        public static bool Update(yny_004.Model.EPConfig model)
        {
            return yny_004.DAL.EPConfig.Update(model);
        }

        public static bool ResetEP()
        {
            return yny_004.DAL.EPConfig.ResetEP();
        }
    }
}
