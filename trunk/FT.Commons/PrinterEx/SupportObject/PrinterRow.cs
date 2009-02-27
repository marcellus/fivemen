using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 待打印的行
    /// </summary>
    public class PrinterRow:PrinterComposite
    {
        
    
        /// <summary>
        /// 根据子对象进行绘画
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
                //复位表格的相对位置，以便在所有页面都要绘画对象不会变化
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
                throw new ArgumentException("对不起，添加的draw超出本行的高度！");
            }
            if (draw.Rectangle.X+draw.Rectangle.Width > this.Rectangle.Width)
            {
                throw new ArgumentException("对不起，添加的draw宽度超出本行的宽度！");
            }

            /**
        * 所有子对象的高度叠加起来是否超出父对象的高度，超出说明无法正常打印int allheight = 0;
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
