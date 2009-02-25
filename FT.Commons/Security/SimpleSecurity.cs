/********************************************************************************
* File:SimpleSecurity.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace FT.Commons.Security
{
    /// <summary>
    /// 使用字符偏移一定数字进行加解密，最简单的加解密
    /// </summary>
    public class SimpleSecurity:ISecurity
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
            log.Debug("before encrypt the string is:"+encode);
            string htext = "";
            for (int i = 0; i < encode.Length; i++)
            {
                htext = htext + (char)(encode[i] + 10 - 1 * 2);
            }
            log.Debug("after encrypt the string is:" + htext);
            return htext;

        }

        /// <summary>
        /// 解密需要解密的字符串，并返回解密后的字符串
        /// </summary>
        /// <param name="decode">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string decode)
        {
            log.Debug("before decrypt the string is:" + decode);
            string dtext = "";
            for (int i = 0; i < decode.Length; i++)
            {
                dtext = dtext + (char)(decode[i] - 10 + 1 * 2);
            }
            log.Debug("after decrypt the string is:" + dtext);
            return dtext;
        }

        #endregion
    }
}
