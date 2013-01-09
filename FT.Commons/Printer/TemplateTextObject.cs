using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Print
{
    [Serializable]
    public class TemplateTextObject
    {
        private string imgPath=string.Empty;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath
        {
            get { return imgPath; }
            set { imgPath = value; }
        }

        private string fontName;

        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }
        private int fontSize;

        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        private int left;

        public int Left
        {
            get { return left; }
            set { left = value; }
        }
        private int top;

        public int Top
        {
            get { return top; }
            set { top = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
