using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// 打印的接口对象，多个对象也一样,composite模式
    /// </summary>
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
        /// 判断是否有更多的页
        /// </summary>
        /// <returns>
        /// 	<c>true</c> 如果有更多的页; 否则, <c>false</c>.
        /// </returns>
        bool HasMorePage();


        /// <summary>
        /// 直接执行打印
        /// </summary>
        void Print();

        
        /// <summary>
        /// 打印预览
        /// </summary>
        void Preview();

        /// <summary>
        /// 打印出实例当前页的图片
        /// </summary>
        /// <returns>当前页生成的图片</returns>
        Image Paint();
    }

    /// <summary>
    /// 打印使用墨水的类别，也就是套打和全打
    /// </summary>
    public enum PrintInkStype
    {
        /// <summary>
        /// 省墨，也就是套打
        /// </summary>
        SaveInk,
        /// <summary>
        /// 全打印，有底板的，底板来源可以是图片，Excel，或者word等文档
        /// </summary>
        Whole
    }
}
