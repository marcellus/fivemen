using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// �����ĵײ���������ֶ���Ĭ�������ִ�С
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
