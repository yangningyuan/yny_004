using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Xml;
using System.Net;
using System.IO;

namespace yny_004.Web.Payment.KaiLT
{
    public partial class OrderReturn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //接收数据
                string serverUrl = Request.Form["serverUrl"];


                string merchantId = Request.Form["merchantId"];
                string version = Request.Form["version"];
                string language = Request.Form["language"];
                string signType = Request.Form["signType"];
                string payType = Request.Form["payType"];
                string issuerId = Request.Form["issuerId"];
                string mchtOrderId = Request.Form["mchtOrderId"];
                string orderNo = Request.Form["orderNo"];
                string orderDatetime = Request.Form["orderDatetime"];
                string orderAmount = Request.Form["orderAmount"];
                string payDatetime = Request.Form["payDatetime"];
                string payResult = Request.Form["payResult"];
                string signMsg = Request.Form["signMsg"];


                StringBuilder bufSignSrc = new StringBuilder();

                appendSignPara(bufSignSrc, "merchantId", merchantId);
                appendSignPara(bufSignSrc, "version", version);
                appendSignPara(bufSignSrc, "language", language);
                appendSignPara(bufSignSrc, "signType", signType);
                appendSignPara(bufSignSrc, "payType", payType);
                appendSignPara(bufSignSrc, "issuerId", issuerId);
                appendSignPara(bufSignSrc, "mchtOrderId", mchtOrderId);
                appendSignPara(bufSignSrc, "orderNo", orderNo);
                appendSignPara(bufSignSrc, "orderDatetime", orderDatetime);
                appendSignPara(bufSignSrc, "orderAmount", orderAmount);
                appendSignPara(bufSignSrc, "payDatetime", payDatetime);
                appendSignPara(bufSignSrc, "payResult", payResult);
                //appendSignPara(bufSignSrc, "signMsg", signMsg);
                appendLastSignPara(bufSignSrc, "key", "yny123456");

                //appendLastSignPara(bufSignSrc, "key", key);

                string srcMsg = bufSignSrc.ToString();
                string strsignMsg = FormsAuthentication.HashPasswordForStoringInConfigFile(srcMsg, "MD5");

                //签名原文
                //string content = billno + amount + mydate + succ + ipsbillno + currency_type;
                //签名是否正确
                Boolean verify = false;

                //验证方式：12-md5
                if (payResult == "1")
                {
                    ////Md5摘要（商户证书在商户后台可下载）
                    //string merchant_key = "MK3LaSgnNnb2qfZ6sDfP5wOZ3f6VsXm068Ieo3LNUps3qRfdMS2AMGLzW3rUwkUPaBVHwVrOSsUqeuJCa2j04BDQNsiLlQ1Ku23FWxGRBDI4L4vBKFUTb4vyXeUdM5Dc";
                    //string signature1 = FormsAuthentication.HashPasswordForStoringInConfigFile(content + merchant_key, "MD5").ToLower();
                    if (strsignMsg == signMsg)
                    {
                        verify = true;
                    }
                }

                //判断签名验证是否通过
                if (verify == true)
                {
                    //判断交易是否成功

                    if (!yny_004.BLL.HKModel.tempList.Contains(orderNo))
                    {
                        yny_004.BLL.HKModel.tempList.Add(orderNo);
                        try
                        {
                            //if (yny_004.BLL.Member.ManageMember.SHPayHB(orderNo))
                            //{
                                Response.Write("交易成功！");
                                Response.End();
                            //}
                            //else
                            //{
                            //    Response.Write("交易失败！");
                            //    Response.End();
                            //}
                        }
                        finally
                        {
                            if (yny_004.BLL.HKModel.tempList.Contains(orderNo))
                                yny_004.BLL.HKModel.tempList.Remove(orderNo);
                        }
                    }
                    Response.Write("交易成功！");
                    Response.End();

                }
                else
                {
                    Response.Write("签名不正确！");
                }
            }
            catch (Exception ex)
            {
                yny_004.BLL.Task.SendManage(yny_004.BLL.Member.ManageMember.TModel, "", ex.Source);
            }

        }
        //---------------------------------------以下代码请勿更动------------------------------------------------------------
        private bool verify(String srcMsg, String signMsg, String certPath, Boolean isAbsolatePath)
        {
            //base64解码签名串
            Byte[] signMsgBytes = decode(signMsg);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //读取x509证书
            X509Certificate2 x509 = new X509Certificate2();
            if (isAbsolatePath)
            {
                //设置证书的绝对路径
                //x509.Import(@"c:\Projects\MyWebSite\cert\TLCert.cer");
                x509.Import(certPath);
            }
            else
            {
                //或者设置证书的相对路径
                //x509.Import(HttpContext.Current.Server.MapPath("../cert/TLCert.cer"));
                x509.Import(HttpContext.Current.Server.MapPath(certPath));
            }

            //x509.PublicKey.Key.ToXmlString();
            //灌注到rsa
            rsa.FromXmlString(x509.PublicKey.Key.ToXmlString(false));
            bool verifyResult = rsa.VerifyData(System.Text.Encoding.UTF8.GetBytes(srcMsg), "SHA1", signMsgBytes);

            return verifyResult;
        }
        private bool isEmpty(String src)
        {
            if (null == src || "".Equals(src) || "-1".Equals(src))
            {
                return true;
            }
            return false;
        }

        private void appendSignPara(System.Text.StringBuilder buf, String key, String value)
        {
            if (!isEmpty(value))
            {
                buf.Append(key).Append('=').Append(value).Append('&');
            }
        }

        private void appendLastSignPara(System.Text.StringBuilder buf, String key,
                String value)
        {
            if (!isEmpty(value))
            {
                buf.Append(key).Append('=').Append(value);
            }
        }

        //body是要传递的参数,格式"roleId=1&uid=2"
        //post的cotentType填写:
        //"application/x-www-form-urlencoded"
        //soap填写:"text/xml; charset=utf-8"
        public static string PostHttp(string url, string body)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            string contentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 20000;

            byte[] btBodys = Encoding.UTF8.GetBytes(body);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }
        //---------------------------------------BASE64------------------------------------------------------------

        /// <summary> Traverse the String until hitting the next Base64 character.
        /// Assumes that there is still another valid Base64 character
        /// left in the String.
        /// </summary>
        private char NextUsefulChar
        {
            get
            {
                char result = '_'; // Start with a non-Base64 character
                while (!isUsefulChar(result))
                {
                    result = mString[mIndex++];
                }

                return result;
            }

        }
        /// <summary> Byte value that maps to 'a' in Base64 encoding
        /// </summary>
        private const int LOWER_CASE_A_VALUE = 26;

        /// <summary> Byte value that maps to '0' in Base64 encoding
        /// </summary>
        private const int ZERO_VALUE = 52;

        /// <summary> Byte value that maps to '+' in Base64 encoding
        /// </summary>
        private const int PLUS_VALUE = 62;

        /// <summary> Byte value that maps to '/' in Base64 encoding
        /// </summary>
        private const int SLASH_VALUE = 63;

        /// <summary> Bit mask for one character worth of bits in Base64 encoding.
        /// Equivalent to binary value 111111b.
        /// </summary>
        private const int SIX_BIT_MASK = 63;

        /// <summary> Bit mask for one byte worth of bits in Base64 encoding.
        /// Equivalent to binary value 11111111b.
        /// </summary>
        private const int EIGHT_BIT_MASK = 0xFF;

        /// <summary> The input String to be decoded
        /// </summary>
        private System.String mString;

        /// <summary> Current position in the String(to be decoded)
        /// </summary>
        private int mIndex = 0;

        /// <summary> Encode an array of bytes using Base64
        /// </summary>
        /// <param name="data[]">The bytes to be encoded
        /// </param>
        /// <returns> A valid Base64 representation of the input
        /// 
        /// </returns>
        public System.String encode(byte[] data)
        {
            // Base64 encoding yields a String that is 33% longer than the byte array
            int charCount = ((data.Length * 4) / 3) + 4;

            // New lines will also be needed for every 76 charactesr, so allocate a
            // StringBuffer that is long enough to hold the full result without
            // having to expand later
            System.Text.StringBuilder result = new System.Text.StringBuilder((charCount * 77) / 76);

            int byteArrayLength = data.Length;
            int byteArrayIndex = 0;
            int byteTriplet = 0;
            while (byteArrayIndex < byteArrayLength - 2)
            {
                // Build the 24 bit byte triplet from the input data
                byteTriplet = convertUnsignedByteToInt(data[byteArrayIndex++]);
                // Each input byte contributes 8 bits to the triplet
                byteTriplet <<= 8;
                byteTriplet |= convertUnsignedByteToInt(data[byteArrayIndex++]);
                byteTriplet <<= 8;
                byteTriplet |= convertUnsignedByteToInt(data[byteArrayIndex++]);

                // Look at the lowest order six bits and remember them
                byte b4 = (byte)(SIX_BIT_MASK & byteTriplet);
                // Move the byte triplet to get the next 6 bit value
                byteTriplet >>= 6;
                byte b3 = (byte)(SIX_BIT_MASK & byteTriplet);
                byteTriplet >>= 6;
                byte b2 = (byte)(SIX_BIT_MASK & byteTriplet);
                byteTriplet >>= 6;
                byte b1 = (byte)(SIX_BIT_MASK & byteTriplet);

                // Add the Base64 encoded character to the result String
                result.Append(mapByteToChar(b1));
                result.Append(mapByteToChar(b2));
                result.Append(mapByteToChar(b3));
                result.Append(mapByteToChar(b4));

                // There are 57 bytes for every 76 characters, so wrap the line when needed
                //if ( byteArrayIndex % 57 == 0 ) {
                //    result.append( "\n" );
                //}
            }

            // Check if we have one byte left over
            if (byteArrayIndex == byteArrayLength - 1)
            {
                // Convert our one byte to an int
                byteTriplet = convertUnsignedByteToInt(data[byteArrayIndex++]);
                // Right pad the second 6 bit value with zeros
                byteTriplet <<= 4;

                byte b2 = (byte)(SIX_BIT_MASK & byteTriplet);
                byteTriplet >>= 6;
                byte b1 = (byte)(SIX_BIT_MASK & byteTriplet);

                result.Append(mapByteToChar(b1));
                result.Append(mapByteToChar(b2));

                // Add "==" to the output to make it a multiple of 4 Base64 characters
                result.Append("==");
            }

            // Check if we have two byte left over
            if (byteArrayIndex == byteArrayLength - 2)
            {
                // Convert our two bytes to an int
                byteTriplet = convertUnsignedByteToInt(data[byteArrayIndex++]);
                byteTriplet <<= 8;
                byteTriplet |= convertUnsignedByteToInt(data[byteArrayIndex++]);
                // Right pad the third 6 bit value with zeros
                byteTriplet <<= 2;

                byte b3 = (byte)(SIX_BIT_MASK & byteTriplet);
                byteTriplet >>= 6;
                byte b2 = (byte)(SIX_BIT_MASK & byteTriplet);
                byteTriplet >>= 6;
                byte b1 = (byte)(SIX_BIT_MASK & byteTriplet);

                result.Append(mapByteToChar(b1));
                result.Append(mapByteToChar(b2));
                result.Append(mapByteToChar(b3));

                // Add "==" to the output to make it a multiple of 4 Base64 characters
                result.Append("=");
            }

            return result.ToString();
        }


        /// <summary> Decode an input String using Base64
        /// </summary>
        /// <param name="data">The String to be decoded
        /// </param>
        /// <returns> The appropriate byte array
        /// 
        /// </returns>
        public byte[] decode(System.String data)
        {
            mString = data;
            mIndex = 0;

            /// <summary> Total number of Base64 characters in the input
            /// </summary>
            int mUsefulLength = 0;
            int length = mString.Length;
            for (int i = 0; i < length; i++)
            {
                if (isUsefulChar(mString[i]))
                {
                    mUsefulLength++;
                }
            }

            //mString = data;


            // A Base64 byte array is 75% the size of its String representation
            int byteArrayLength = mUsefulLength * 3 / 4;

            byte[] result = new byte[byteArrayLength];

            int byteTriplet = 0;
            int byteIndex = 0;

            // Continue until we have less than 4 full characters left to
            // decode in the input.
            while (byteIndex + 2 < byteArrayLength)
            {

                // Package a set of four characters into a byte triplet
                // Each character contributes 6 bits of useful information
                byteTriplet = mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);

                // Grab a normal byte (eight bits) out of the byte triplet
                // and put it in the byte array
                result[byteIndex + 2] = (byte)(byteTriplet & EIGHT_BIT_MASK);
                byteTriplet >>= 8;
                result[byteIndex + 1] = (byte)(byteTriplet & EIGHT_BIT_MASK);
                byteTriplet >>= 8;
                result[byteIndex] = (byte)(byteTriplet & EIGHT_BIT_MASK);
                byteIndex += 3;
            }

            // Check if we have one byte left to decode
            if (byteIndex == byteArrayLength - 1)
            {
                // Take out the last two characters from the String
                byteTriplet = mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);

                // Remove the padded zeros
                byteTriplet >>= 4;
                result[byteIndex] = (byte)(byteTriplet & EIGHT_BIT_MASK);
            }

            // Check if we have two bytes left to decode
            if (byteIndex == byteArrayLength - 2)
            {
                // Take out the last three characters from the String
                byteTriplet = mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);
                byteTriplet <<= 6;
                byteTriplet |= mapCharToInt(NextUsefulChar);

                // Remove the padded zeros
                byteTriplet >>= 2;
                result[byteIndex + 1] = (byte)(byteTriplet & EIGHT_BIT_MASK);
                byteTriplet >>= 8;
                result[byteIndex] = (byte)(byteTriplet & EIGHT_BIT_MASK);
            }

            return result;
        }

        /// <summary> Convert a Base64 character to its 6 bit value as defined by the mapping.
        /// </summary>
        /// <param name="c">Base64 character to decode
        /// </param>
        /// <returns> int representation of 6 bit value
        /// 
        /// </returns>
        private int mapCharToInt(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A';
            }

            if (c >= 'a' && c <= 'z')
            {
                return (c - 'a') + LOWER_CASE_A_VALUE;
            }

            if (c >= '0' && c <= '9')
            {
                return (c - '0') + ZERO_VALUE;
            }

            if (c == '+')
            {
                return PLUS_VALUE;
            }

            if (c == '/')
            {
                return SLASH_VALUE;
            }

            throw new System.ArgumentException(c + " is not a valid Base64 character.");
        }


        /// <summary> Convert a byte between 0 and 63 to its Base64 character equivalent
        /// </summary>
        /// <param name="b">Byte value to be converted
        /// </param>
        /// <returns> Base64 char value
        /// 
        /// </returns>
        private char mapByteToChar(byte b)
        {
            if (b < LOWER_CASE_A_VALUE)
            {
                return (char)('A' + b);
            }

            if (b < ZERO_VALUE)
            {
                return (char)('a' + (b - LOWER_CASE_A_VALUE));
            }

            if (b < PLUS_VALUE)
            {
                return (char)('0' + (b - ZERO_VALUE));
            }

            if (b == PLUS_VALUE)
            {
                return '+';
            }

            if (b == SLASH_VALUE)
            {
                return '/';
            }

            throw new System.ArgumentException("Byte " + b + " is not a valid Base64 value");
        }

        /// <param name="c">Character to be examined
        /// </param>
        /// <returns> Whether or not the character is a Base64 character
        /// 
        /// </returns>
        private bool isUsefulChar(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || (c == '+') || (c == '/');
        }


        /// <summary> Convert a byte to an integer.  Needed because in Java bytes
        /// are signed, and for Base64 purposes they are not.  If not done
        /// this way, when converted to an int, 0xFF will become -127
        /// </summary>
        /// <param name="b">Byte value to be converted
        /// </param>
        /// <returns> Value as an integer, as if byte was unsigned
        /// 
        /// </returns>
        private int convertUnsignedByteToInt(byte b)
        {
            if (b >= 0)
            {
                return (int)b;
            }

            return 256 + b;
        }
    }
}