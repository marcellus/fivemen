/********************************************************************************
* File:MD5Security.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using log4net;

namespace FT.Commons.Security
{
    /// <summary>
    /// 使用md5进行加密，不能进行解密
    /// </summary>
    public class MD5Security:ISecurity
    {
        private ILog log = log4net.LogManager.GetLogger("FT.Commons.Security");
        #region ISecurity 成员

        /// <summary>
        /// 加密参数encode的字符串，并返回加密后的字符串
        /// </summary>
        /// <param name="encode">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public string Encrypt(string encode)
        {
            log.Debug("before encrypt the string is:" + encode);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(encode)), 4, 8);
            result = result.Replace("-", "");
            log.Debug("after encrypt the string is:" + result);
            return result;

        }

        /// <summary>
        /// 不提供解密方法
        /// </summary>
        /// <param name="decode">需要解密的字符串</param>
        /// <returns>不实现该方法</returns>
        public string Decrypt(string decode)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
