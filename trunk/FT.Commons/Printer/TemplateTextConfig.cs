using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Print
{
    [Serializable]
    public class TemplateTextConfig
    {
        public int PageWidth  = 600;
        public int PageHeight = 400;
        public List<TemplateTextObject> Lists=new List<TemplateTextObject>();
    }
}
