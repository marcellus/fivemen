using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 打印和绘图对象的接口
    /// </summary>
    public interface IDraw
    {

        /// <summary>
        /// 获取或设置绘制区域
        /// </summary>
        System.Drawing.Rectangle Rectangle
        {
            get;
            set;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        void Draw(Graphics graphics);

        /// <summary>
        /// 是否绘制完毕,供组合对象使用
        /// </summary>
        /// <returns>如果没有绘制完毕，分页绘制</returns>
        bool IsFinish();
    }
}
