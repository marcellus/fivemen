using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 待打印的表格类,无需定义打印范围
    /// </summary>
    public class PrinterTable:BaseDraw
    {

        private PrinterRow columnHeader;

        /// <summary>
        /// 列头定义
        /// </summary>
        public PrinterRow ColumnHeader
        {
            get { return columnHeader; }
            set { columnHeader = value; }
        }

        /// <summary>
        /// 计算组合对象的页数
        /// </summary>
        /// <returns></returns>
        public int ComputePages(int pageHeight)
        {
            int all = 0;
            if (this.header != null)
            {
                all = header.Rectangle.Height;
            }
            int pages = 1;
            int tmp = 0;
            foreach (PrinterRow row in list)
            {
                //行高+行间距
                tmp=all+ row.Rectangle.Height+row.Rectangle.Y;
                if (tmp > pageHeight)
                {
                    if (this.everyPageHeader&&this.header!=null)
                    {
                        all = this.header.Rectangle.Height;
                    }
                    else
                    {
                        all = 0;
                    }
                    all += row.Rectangle.Height + row.Rectangle.Y;
                    pages += 1;
                }
                else
                {
                    all = tmp;
                }
            }
            return pages;
            
            
            
        }


        /// <summary>
        /// PrinterRow的可绘制的矩形都是x和y的
        /// </summary>
        protected List<PrinterRow> list = new List<PrinterRow>();
       
        private int currentRowIndex = 0;

        /// <summary>
        /// 表格对象打印到的当前行
        /// </summary>
        public int CurrentRowIndex
        {
            get { return currentRowIndex; }
            set { currentRowIndex = value; }
        }

        private PrinterRow header=null;

        /// <summary>
        /// 表格的列头
        /// </summary>
        public PrinterRow Header
        {
            get { return header; }
            set { header = value; }
        }

        public void Add(PrinterRow draw)
        {
            list.Add(draw);
        }
        /// <summary>
        /// 打印出列头
        /// </summary>
        private void PrintHeader(Graphics graphics)
        {
            if (header != null)
            {
                header.Draw(graphics);
            }
        }



        #region BaseDraw 成员

        private int currentY;

        /// <summary>
        /// 组合对象的打印完一部分后的y位置
        /// </summary>
        public int CurrentY
        {
            get { return currentY; }
            set { currentY = value; }
        }

        private bool everyPageHeader = true;

        /// <summary>
        /// 是否每页都打印列头
        /// </summary>
        public bool EveryPageHeader
        {
            get { return everyPageHeader; }
            set { everyPageHeader = value; }
        }
      



        protected override void DrawContent(Graphics graphics)
        {
            IDraw draw = null;
            int x = this.Rectangle.X;
            int y = this.Rectangle.Y;
            bool newPage = true;
            int tmpx = 0,tmpy=0;
            while(this.CurrentRowIndex< this.list.Count)
            {
                if (this.header != null && newPage)
                {
                    //只画一次或者每次都要画
                    if (this.CurrentRowIndex == 0 || this.everyPageHeader)
                    {
                        newPage = false;
                        tmpx = header.Rectangle.X;
                        tmpy = header.Rectangle.Y;
                        header.Rectangle = new System.Drawing.Rectangle(x + header.Rectangle.X, y + header.Rectangle.Y, header.Rectangle.Width, header.Rectangle.Height);
                        header.Draw(graphics);
                        header.Rectangle = new Rectangle(tmpx, tmpy, header.Rectangle.Width, header.Rectangle.Height);
                        y += header.Rectangle.Y + header.Rectangle.Height;
                        continue;
                    }
                }
                
                draw = this.list[CurrentRowIndex];
                tmpx = draw.Rectangle.X;
                tmpy = draw.Rectangle.Y;
                //算出行的y距离
                y = y + tmpy;
               
                //判断再画一行是否超出页的可绘制位置的高度
                if (draw.Rectangle.Height + y > this.Rectangle.Height+this.Rectangle.Y)
                {
                    if (this.everyPageHeader)
                    {
                        newPage = true;
                    }
                    break;
                }
                draw.Rectangle = new System.Drawing.Rectangle(x+tmpx,y, draw.Rectangle.Width, draw.Rectangle.Height);
                draw.Draw(graphics);
                draw.Rectangle = new System.Drawing.Rectangle(tmpx, tmpy, draw.Rectangle.Width, draw.Rectangle.Height);
                y += draw.Rectangle.Height;
                CurrentRowIndex++;

            }
        }

        public override bool IsFinish()
        {
            return this.CurrentRowIndex >= this.list.Count;
        }

        #endregion
    }
}
