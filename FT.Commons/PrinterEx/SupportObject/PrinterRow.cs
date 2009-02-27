using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ����ӡ����
    /// </summary>
    public class PrinterRow:PrinterComposite
    {
        
    
        /// <summary>
        /// �����Ӷ�����л滭
        /// </summary>
        protected override void DrawContent(Graphics graphics)
        {
            IDraw draw = null;
            int x = this.Rectangle.X;
            int y=this.Rectangle.Y;
            int tmpx = 0;
            int tmpy = 0;
            for (int i = 0; i < this.list.Count; i++)
            {
                draw = this.list[i];
                //��λ�������λ�ã��Ա�������ҳ�涼Ҫ�滭���󲻻�仯
                tmpx = draw.Rectangle.X;
                tmpy = draw.Rectangle.Y;
                draw.Rectangle = new System.Drawing.Rectangle(x+tmpx, y+tmpy, draw.Rectangle.Width, draw.Rectangle.Height);
                draw.Draw(graphics);
                draw.Rectangle = new Rectangle(tmpx,tmpy,draw.Rectangle.Width,draw.Rectangle.Height);
                //x = x + draw.Rectangle.Width;
                
            }
        }

        public override bool IsFinish()
        {
            return true;
        }



        protected override void CheckAdd(IDraw draw)
        {
            if (draw.Rectangle.Y + draw.Rectangle.Height > this.Rectangle.Height)
            {
                throw new ArgumentException("�Բ�����ӵ�draw�������еĸ߶ȣ�");
            }
            if (draw.Rectangle.X+draw.Rectangle.Width > this.Rectangle.Width)
            {
                throw new ArgumentException("�Բ�����ӵ�draw��ȳ������еĿ�ȣ�");
            }

            /**
        * �����Ӷ���ĸ߶ȵ��������Ƿ񳬳�������ĸ߶ȣ�����˵���޷�������ӡint allheight = 0;
           foreach (IDraw tmp in list)
           {
               allheight += tmp.Rectangle.Height;
           }
           if (allheight > this.Rectangle.Height)
           {
               return false;
           }
           return true;*/
        }
    }
}
