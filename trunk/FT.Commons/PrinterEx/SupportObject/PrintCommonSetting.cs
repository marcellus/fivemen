using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 使用打印组件之间的一些默认设置
    /// </summary>
    public class PrintCommonSetting
    {
        /// <summary>
        /// 默认边框样式
        /// </summary>
        public static BordersEdgeStyle Default_Border_Style = BordersEdgeStyle.All;

        /// <summary>
        /// 默认打印的字体
        /// </summary>
        public static Pen Default_Font_Pen = new Pen(Color.Black);

        /// <summary>
        /// 默认边框颜色，红色方便调试
        /// </summary>
        public static Pen Default_Border_Pen = new Pen(Color.Black);

        /// <summary>
        /// 默认页面边距
        /// </summary>
        //public static PageMargin Default_Page_Margin = new PageMargin();

        /// <summary>
        /// 打印对象必须能根据纸张判断
        /// </summary>
        public static int Default_Page_Height = 3508;

        public static int Default_Page_Width = 2480;//默认为A4纸张

        /// <summary>
        /// 默认文字大小
        /// </summary>
        public static Font Default_Text_Font=new Font("宋体",12);

        /// <summary>
        /// 默认标题大小
        /// </summary>
        public static Font Default_Title_Font = new Font("黑体", 18);

        /// <summary>
        /// 默认表格列标题大小
        /// </summary>
        public static Font Default_Column_Header_Font = new Font("黑体", 14);

        /// <summary>
        /// 默认footer大小
        /// </summary>
        public static Font Default_Footer_Font = new Font("宋体", 9);

        /// <summary>
        /// 默认文字颜色笔刷
        /// </summary>
        public static Brush Default_Text_Brush = new SolidBrush(Color.Black);

        //public static Color
        //public static PageSettings Default_PageSettings = new PageSettings();
    }
}
