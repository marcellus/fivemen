using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ±í¸ñÍ·
    /// </summary>
    public class ColumnHeaderDraw:TextDraw
    {
        public ColumnHeaderDraw(string text)
            : base(text)
        {
            this.Font = PrintCommonSetting.Default_Column_Header_Font;
        }
    }
}
