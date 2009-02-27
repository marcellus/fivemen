using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ����ӡ�ı����,���趨���ӡ��Χ
    /// </summary>
    public class PrinterTable:BaseDraw
    {

        private PrinterRow columnHeader;

        /// <summary>
        /// ��ͷ����
        /// </summary>
        public PrinterRow ColumnHeader
        {
            get { return columnHeader; }
            set { columnHeader = value; }
        }

        /// <summary>
        /// ������϶����ҳ��
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
                //�и�+�м��
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
        /// PrinterRow�Ŀɻ��Ƶľ��ζ���x��y��
        /// </summary>
        protected List<PrinterRow> list = new List<PrinterRow>();
       
        private int currentRowIndex = 0;

        /// <summary>
        /// �������ӡ���ĵ�ǰ��
        /// </summary>
        public int CurrentRowIndex
        {
            get { return currentRowIndex; }
            set { currentRowIndex = value; }
        }

        private PrinterRow header=null;

        /// <summary>
        /// ������ͷ
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
        /// ��ӡ����ͷ
        /// </summary>
        private void PrintHeader(Graphics graphics)
        {
            if (header != null)
            {
                header.Draw(graphics);
            }
        }



        #region BaseDraw ��Ա

        private int currentY;

        /// <summary>
        /// ��϶���Ĵ�ӡ��һ���ֺ��yλ��
        /// </summary>
        public int CurrentY
        {
            get { return currentY; }
            set { currentY = value; }
        }

        private bool everyPageHeader = true;

        /// <summary>
        /// �Ƿ�ÿҳ����ӡ��ͷ
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
                    //ֻ��һ�λ���ÿ�ζ�Ҫ��
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
                //����е�y����
                y = y + tmpy;
               
                //�ж��ٻ�һ���Ƿ񳬳�ҳ�Ŀɻ���λ�õĸ߶�
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
