using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// �ı���ӡ����
    /// </summary>
    public class TextDraw:BaseDraw
    {
        private StringFormat formater;

        /// <summary>
        /// �ַ����ھ����е�λ��
        /// </summary>
        public StringFormat Formater
        {
            get { return formater; }
            set { formater = value; }
        }
        private string text;

        /// <summary>
        /// ��Ҫ��ӡ���ı�
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private Font font=PrintCommonSetting.Default_Text_Font;

        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private Brush brush=PrintCommonSetting.Default_Text_Brush;

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

        public TextDraw(string text)
        {
            this.text = text;
        }

        protected override void DrawContent(Graphics graphics)
        {
            if (this.Formater == null)
            {
                formater = new StringFormat();
                //formater.Alignment = StringAlignment.Center;
                formater.LineAlignment = StringAlignment.Center;
            }
            graphics.DrawString(text, font, brush, this.Rectangle, this.Formater);
        }

        public override bool IsFinish()
        {
            return true;
        }
    }
}
