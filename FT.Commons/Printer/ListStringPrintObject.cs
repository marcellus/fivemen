using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using System.Drawing;

namespace FT.Commons.Printer
{
    public class ListStringPrintObject : ObjectPrinter
    {

        private List<string> lists;
        private int leftDistance;
        private int fontHeightDistance;
        private Font printerFont;

        public ListStringPrintObject(List<string> list,Font font,int fontHeight)
        {
            this.lists = list;
            this.printerFont = font;
            this.leftDistance = 0;
            this.fontHeightDistance = fontHeight;
        }


        public override int GetTotalPage()
        {
            return 1;
        }

        public override System.Drawing.Image Paint()
        {
            throw new NotImplementedException();
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() == 1)
            {
               
                for (int i = 0; i < lists.Count;i++ )
                {
                    this.DrawStringHor(lists[i], printerFont, new Point(leftDistance, fontHeightDistance*i));
                }
            }
        }
    }
}
