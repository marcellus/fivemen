using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 组合打印对象,行对象判断是否可打印是由宽度判断，table之类的由高度判断
    /// 组合内对象的坐标是相对坐标
    /// </summary>
    public abstract class PrinterComposite : BaseDraw
    {

       




        /// <summary>
        /// 是否可加入一个Idraw对象
        /// </summary>
        /// <param name="draw">需要添加到组合对象中的对象</param>
        /// <returns>是否可添加,如果不可添加抛出异常</returns>
        protected abstract void CheckAdd(IDraw draw);

        protected List<IDraw> list = new List<IDraw>();

        public void Add(IDraw draw)
        {
            if (draw.Rectangle.Height > this.Rectangle.Height)
            {
                throw new ArgumentException("可打印的子对象高度超出父对象的高度！");
            }
            if (draw.Rectangle.Width > this.Rectangle.Width)
            {
                throw new ArgumentException("可打印的子对象宽度超出父对象的宽度！");
            }
            CheckAdd(draw);
                
            list.Add(draw);
          
        }






        protected override void DrawContent(Graphics graphics)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool IsFinish()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
