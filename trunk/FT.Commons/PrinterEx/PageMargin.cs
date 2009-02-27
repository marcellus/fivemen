using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// 基本的页面配置
    /// </summary>
    public class PageMargin
    {
        private int top=10;

        /// <summary>
        /// 上边距
        /// </summary>
        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        private int bottom=10;

        /// <summary>
        /// 下边距
        /// </summary>
        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        private int left=10;

        /// <summary>
        /// 左边距
        /// </summary>
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private int right=10;

        /// <summary>
        /// 右边距
        /// </summary>
        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        private int pindingWidth;

        /// <summary>
        /// 装订线宽度，如果等于0就不打印装订线
        /// </summary>
        public int PindingWidth
        {
            get { return pindingWidth; }
            set { pindingWidth = value; }
        }
        
        private int pindingLine;

        /// <summary>
        /// 装订线位置距离大小
        /// </summary>
        public int PindingLine
        {
            get { return pindingLine; }
            set { pindingLine = value; }
        }

        private Direction pindDirection=Direction.Left;

        /// <summary>
        /// 装订线方向,默认左边
        /// </summary>
        public Direction PindDirection
        {
            get { return pindDirection; }
            set { pindDirection = value; }
        }

        private int height;

        /// <summary>
        /// 页面的高度
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

       
        private int width;

        /// <summary>
        /// 页面的宽度
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public PageMargin()
        {
        }


        /// <summary>
        /// 通过PrintDocument获取一个PrinterMargins对象
        /// </summary>
        /// <param name="printDocument"></param>
        /// <returns></returns>
        public PageMargin(PrintDocument printDocument)
        {

            left = printDocument.DefaultPageSettings.Margins.Left;
            right = printDocument.DefaultPageSettings.Margins.Right;

            top = printDocument.DefaultPageSettings.Margins.Top;
            bottom = printDocument.DefaultPageSettings.Margins.Bottom;

            width = printDocument.DefaultPageSettings.PaperSize.Width;
            height = printDocument.DefaultPageSettings.PaperSize.Height;


            //宽与高为打印区的宽，所以是页面宽与高减去相应的边距
            width = width - left - right;
            height = height - top - bottom;
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("有效的绘图范围的长度或者宽度不得小于0！");
            }
        }
    }

    /// <summary>
    /// 方向的位置
    /// </summary>
    public enum Direction
    {
        Left,Right,Top,Bottom
    }
}
