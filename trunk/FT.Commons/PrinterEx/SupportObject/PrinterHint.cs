using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 打印提示对象，比如公司名称，页码，以及一些其他需要每页打印的对象
    /// </summary>
    public class PrinterHint : PrinterRow
    {
        private bool printInEveryPage;

        /// <summary>
        /// 是否在每页打印，默认为false；
        /// </summary>
        public bool PrintInEveryPage
        {
            get { return printInEveryPage; }
            set { printInEveryPage = value; }
        }


    }
}
