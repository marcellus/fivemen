using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using FT.Commons.PrinterEx.SupportObject;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// ����ҳ��Ĵ�ӡ
    /// </summary>
    public class PagePrinter
    {
        private int pageHeight;

        public int PageHeight
        {
            get { return pageHeight; }
            set { pageHeight = value; }
        }

        private ArrayList list = new ArrayList();

        public void Add(IDraw draw)
        {
            if (draw != null)
            {
                list.Add(draw);
            }
        }

        /// <summary>
        /// ������Ҫ��ӡ�Ķ���
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        private PageMargin margin;

        /// <summary>
        /// Ĭ�ϵ�ҳ������
        /// </summary>
        public PageMargin Margin
        {
            get { return margin; }
            set { margin = value; }
        }

    }
}
