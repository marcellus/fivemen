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
    /// 负责页面的打印
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
        /// 清理需要打印的对象
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        private PageMargin margin;

        /// <summary>
        /// 默认的页面设置
        /// </summary>
        public PageMargin Margin
        {
            get { return margin; }
            set { margin = value; }
        }

    }
}
