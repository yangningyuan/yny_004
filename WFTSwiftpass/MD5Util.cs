﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WFTSwiftpass
{
    /*=================================================================
    * Author: yqd
    * CreatedTime: 2017/12/4 16:27:07
    * Description: <MD5Util 的摘要说明。> 
    *
    * Modified By : <更新人>
    * ModifiedTime: 2017/12/4 16:27:07
    * ModifiedNote:
    ===================================================================*/
    public class MD5Util
    {
        public MD5Util()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr">需要签名的串</param>
        /// <param name="charset">编码</param>
        /// <returns>返回大写的MD5签名结果</returns>
        public static string GetMD5(string encypStr, string charset)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
                Console.WriteLine(ex);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
    }
}
