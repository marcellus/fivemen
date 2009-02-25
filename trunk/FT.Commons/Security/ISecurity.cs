/********************************************************************************
* File:ISecurity.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Security
{
    /// <summary>
    /// 加密解密接口
    /// </summary>
    public interface ISecurity
    {
        /// <summary>
        /// 加密参数encode的字符串，并返回加密后的字符串
        /// </summary>
        /// <param name="encode">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
         string Encrypt(string encode);
         /// <summary>
         /// 解密需要解密的字符串，并返回解密后的字符串
         /// </summary>
         /// <param name="decode">需要解密的字符串</param>
         /// <returns>解密后的字符串</returns>
         string Decrypt(string decode);
    }
}
