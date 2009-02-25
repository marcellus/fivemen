/********************************************************************************
* File:IPrinter.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.ComponentModel;


namespace FT.Commons.Print
{
    ///<summary>
    ///Class <c>IPrinter</c>
    ///Description:能使用通用打印页的对象接口
    ///</summary>
    public interface IPrinter
    {
        /// <summary>
        /// 获取打印的当前页，一个对象也许可以分多页打印
        /// </summary>
        /// <returns>当前页数</returns>
         int GetCurrentPage();
        /// <summary>
        /// 获取一个打印对象能打印多少页，计算出来的
        /// </summary>
        /// <returns></returns>
         int GetTotalPage();
        /// <summary>
        /// 如果有多页，next则对当前对象页数进行加一
        /// </summary>
        /// <returns></returns>
         void Next();
        /// <summary>
        /// 判断是否有更多的页
        /// </summary>
        /// <returns>
        /// 	<c>true</c> 如果有更多的页; 否则, <c>false</c>.
        /// </returns>
        bool HasMorePage();

         /// <summary>
         /// 最后一页
         /// </summary>
        void ToLastPage();

        /// <summary>
        /// 第一页
        /// </summary>
        void ToFirstPage();
        /// <summary>
        /// 上一页
        /// </summary>
        void Preview();
        /// <summary>
        /// 打印出实例当前页的图片
        /// </summary>
        /// <returns>当前页生成的图片</returns>
         Image Paint();

         /// <summary>
         /// 输出当前实力到graphics上，供打印机调用
         /// </summary>
         /// <returns>打印使用</returns>
         void Paint(System.Drawing.Graphics graphics);
    }
}