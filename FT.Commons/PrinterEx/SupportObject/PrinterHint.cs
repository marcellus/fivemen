using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ��ӡ��ʾ���󣬱��繫˾���ƣ�ҳ�룬�Լ�һЩ������Ҫÿҳ��ӡ�Ķ���
    /// </summary>
    public class PrinterHint : PrinterRow
    {
        private bool printInEveryPage;

        /// <summary>
        /// �Ƿ���ÿҳ��ӡ��Ĭ��Ϊfalse��
        /// </summary>
        public bool PrintInEveryPage
        {
            get { return printInEveryPage; }
            set { printInEveryPage = value; }
        }


    }
}
