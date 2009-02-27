using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 默认的标题对象,默认了字体大小
    /// </summary>
    public class TitleDraw:TextDraw
    {
        public TitleDraw(string text):base(text)
        {
            this.Font = PrintCommonSetting.Default_Title_Font;
            this.Formater = new StringFormat();
            Formater.Alignment = StringAlignment.Center;
            Formater.LineAlignment = StringAlignment.Center;
        }
    }
}
