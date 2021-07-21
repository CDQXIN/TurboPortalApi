using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TurboPortalApi.Common.SecurityHelper
{
    public static class SecurityMgr
    {
        //配置算法密钥
        private static byte[] _rgbKey = ASCIIEncoding.ASCII.GetBytes("TurboEn");
        //用于算法的初始化向量
        private static byte[] _rgbIV = ASCIIEncoding.ASCII.GetBytes("TurboDe");
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">加密内容</param>
        /// <returns></returns>
        public static string Encrypt(this string text)
        {
            //创建DES大管家
            DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
            //使用内存数据流
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //制定加密规则
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    dsp.CreateEncryptor(_rgbKey, _rgbIV),
                    CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                //正式加密
                streamWriter.Write(text);
                //清理缓冲区
                streamWriter.Flush();
                //用缓冲区的当前状态更新基础数据源或存储库，随后清除缓冲区。
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();
                //获取加密数据转为Base64格式的字符串
                string encryptText = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                return encryptText.Replace("+", "%2B").Replace("=", "%6B");

            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public static string Decrypt(this string encryptText)
        {
            try
            {
                encryptText = encryptText.Replace("%2B", "+").Replace("%6B", "=");
                //创建DES大管家
                DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
                //将Base64格式的字符串转成字节数组 
                byte[] buffer = Convert.FromBase64String(encryptText);
                //创建内存字节流
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //制定解密规则
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                         dsp.CreateDecryptor(_rgbKey, _rgbIV),
                         CryptoStreamMode.Write);
                    //解析当前加密字节流
                    cryptoStream.Write(buffer, 0, buffer.Length);
                    //用缓冲区的当前状态更新基础数据源或存储库，随后清除缓冲区。
                    cryptoStream.FlushFinalBlock();
                    //将内存字节流转成string类型
                    var res = ASCIIEncoding.UTF8.GetString(memoryStream.ToArray());
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string ToMd5(this string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(str + "Love@Turbo"));
            var md5Str = BitConverter.ToString(output).Replace("-", "");
            return md5Str;
        }
    }
}
