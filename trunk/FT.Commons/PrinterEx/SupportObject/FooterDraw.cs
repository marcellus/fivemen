using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 基本的底部输出的文字对象，默认了文字大小
    /// </summary>
    public class FooterDraw:TextDraw
    {
        public FooterDraw(string text):base(text)
        {
            this.Font = PrintCommonSetting.Default_Footer_Font;
            StringFormat format = new System.Drawing.StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            this.Formater = format;
        }
    }
}
