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
