using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using System.Drawing;

namespace FT.Commons.Print
{
    public class TemplatePrintObject : ObjectPrinter
    {
        private TemplateTextConfig config;
        public TemplatePrintObject(TemplateTextConfig config)
        {
            this.config = config;
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
                TemplateTextObject text;
                Font font;
                for (int i = 0; i < config.Lists.Count;i++ )
                {
                    text=config.Lists[i];
                    font = new Font(text.FontName, text.FontSize);
                    this.DrawStringHor(text.Content, font, new Point(text.Left, text.Top));
                }
            }
        }

    }
}
