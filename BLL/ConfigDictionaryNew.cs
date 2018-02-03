using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.BLL
{
    public class ConfigDictionaryNew
    {
        /// <summary>
        /// 得到见点奖
        /// </summary>
        /// <param name="mid">推荐会员账号</param>
        /// <returns></returns>
        public static Model.ConfigDictionary GetConfigDictionary(int Level, string DType, string DKey)
        {
            return DAL.ConfigDictionary.GetConfigDictionary(Level, DType, DKey);
        }
    }
}
