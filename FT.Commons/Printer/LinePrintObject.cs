using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Print
{
    public class LinePrintObject : ObjectPrinter
    {
        private string lineContent;
        public LinePrintObject(string lineContent)
        {
            this.lineContent = lineContent;
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
                this.Draw10String(this.lineContent, new System.Drawing.Point(40, 10));
            }
        }
    }
}
