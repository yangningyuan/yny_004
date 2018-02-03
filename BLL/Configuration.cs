using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace yny_004.BLL
{
    public class Configuration
    {
        public static Model.Configuration Model
        {
            get
            {
                return DAL.Configuration.TModel;
            }
            set
            {
                DAL.Configuration.TModel = value;
            }
        }

        public static Dictionary<string, int> CodeTime
        {
            get
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                foreach (string str in ConfigurationManager.AppSettings["CodeTime"].Split(';'))
                {
                    if (!string.IsNullOrEmpty(str))
                        dic.Add(str.Split(':')[0], int.Parse(str.Split(':')[1]));
                }
                return dic;
            }
        }

        /// <summary>
        /// 设置【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        public static bool IsTranMoney(bool flag)
        {
            return DAL.Configuration.IsTranMoney(flag);
        }
    }
}
