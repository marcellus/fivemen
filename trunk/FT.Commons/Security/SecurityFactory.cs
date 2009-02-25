/********************************************************************************
* File:SecurityFactory.cs
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
    /// 默认的加解密工厂
    /// </summary>
    public class SecurityFactory
    {
        private static ISecurity instance;
        /// <summary>
        /// 获取加密类实例，单例实现，非线程安全
        /// </summary>
        /// <returns>单例</returns>
        public  static ISecurity GetSecurity()
        {
            if(instance==null)
            {
               instance=new KeySecurity();
            }
            return instance; 
        }

    }
}
