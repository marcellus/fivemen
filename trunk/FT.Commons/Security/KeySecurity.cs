/********************************************************************************
* File:KeySecurity.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using log4net;

namespace FT.Commons.Security
{
    /// <summary>
    /// 使用关键字进行加密解密
    /// </summary>
    public class KeySecurity:ISecurity
    {
        private ILog log = log4net.LogManager.GetLogger("FT.Commons.Security");
        /// <summary>
        /// 默认关键字
        /// </summary>
        const string KEY_64 = "FTSECURI";//注意了，是8个字符，64位

        /// <summary>
        /// 默认关键字
        /// </summary>
        const string IV_64 = "FTSECURI";

        private string key = KEY_64;

        public KeySecurity()
        {


        }

        public KeySecurity(string key)
        {

            this.key = key;
        }

        #region ISecurity 成员

        /// <summary>
        /// 加密参数encode的字符串，并返回加密后的字符串
        /// </summary>
        /// <param name="encode">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public string Encrypt(string encode)
        {
            log.Debug("before encrypt the string is:"+encode);
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(encode);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            string result=Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            log.Debug("after encrypt the string is:"+result);
            return result;
        }

        /// <summary>
        /// 解密需要解密的字符串，并返回解密后的字符串
        /// </summary>
        /// <param name="decode">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string decode)
        {
           log.Debug("before decrypt the string is:" + decode);
           byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
           byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(key);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(decode);
            }
            catch(Exception ex)
            {
               log.Debug(ex.ToString());
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            string result=sr.ReadToEnd();
           log.Debug("after decrypt the string is:" + result);
            return result;
 
        }

        #endregion
    }
}
