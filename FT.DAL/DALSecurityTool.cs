/********************************************************************************
* File:DALSecurityTool.cs
* Author:chen
* Date:04/23/2008 09:52:18
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL
{

    /// <summary>
    /// Description:
    /// 数据库安全工具，insert 以及select等的校验以及入库前的处理
    /// </summary>
    public class DALSecurityTool
    {
        /// <summary>
        /// 转换插入的字段
        /// </summary>
        /// <param name="value">插入字段的值</param>
        /// <returns>转换后安全插入的字段</returns>
        public static string TransferInsertField(string value)
        {
            StringBuilder sb = new StringBuilder(value);
            sb.Replace("'","''");
            return sb.ToString();
        }
    }
}
