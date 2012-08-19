using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Text;
using System.Collections;
using System.Drawing;

namespace FT.Commons.Tools
{
    public class FontHelper:BaseHelper
    {
        private FontHelper()
        {
        }

        public static ArrayList GetInstallFont()
        {
            InstalledFontCollection MyFont = new InstalledFontCollection();
            FontFamily[] MyFontFamilies = MyFont.Families;
            ArrayList list = new ArrayList();
            int Count = MyFontFamilies.Length;
            for (int i = 0; i < Count; i++)
            {
                string FontName = MyFontFamilies[i].Name;
                list.Add(FontName);
            }
            return list;
        }
    }
}
