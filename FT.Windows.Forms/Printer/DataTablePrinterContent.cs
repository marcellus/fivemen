using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FT.Windows.Forms
{
    public class DataTablePrinterContent : AbstractPrinterContent
    {
        protected DataTable dt;

        protected int[] widths;

        public DataTablePrinterContent(DataTable dt, int[] widths)
        {
            if (dt == null)
            {
                throw new ArgumentException("Ҫ��ӡ�ı����ΪNull��");
            }
            if (widths == null)
            {
                throw new ArgumentException("�������ô�ӡ���п�");
            }
            this.dt = dt;
            this.widths = widths;
        }

        /// <summary>
        /// widths�����dt������һ�У����һ���Զ������
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static void Print(DataTable dt, int[] widths, string title)
        {
            Print(dt, widths, title, true);
        }

        /// <summary>
        /// widths�����dt������һ�У����һ���Զ������
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static void Print(DataTable dt, int[] widths, string title,bool isPrintColName)
        {
            BuildAbstractPrinterContent(dt,widths,title,isPrintColName).Print();
        }

        /// <summary>
        /// widths�����dt������һ�У����һ���Զ������
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static AbstractPrinterContent BuildAbstractPrinterContent(DataTable dt, int[] widths, string title, bool isPrintColName)
        {
            DataTablePrinterContent content = new DataTablePrinterContent(dt, widths);
            content.IsPrintColName = isPrintColName;
            content.HeaderTitle = title;
            return content;
        }

        /// <summary>
        /// widths�����dt������һ�У����һ���Զ������
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static AbstractPrinterContent BuildAbstractPrinterContent(DataTable dt, int[] widths, string title)
        {
            return BuildAbstractPrinterContent(dt, widths, title, false);
        }

        protected override FT.Commons.PrinterEx.SupportObject.PrinterTable BuildContent()
        {
            return this.BuildContent(dt, widths);
        }
    }
}
