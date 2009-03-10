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
                throw new ArgumentException("要打印的表格不能为Null！");
            }
            if (widths == null)
            {
                throw new ArgumentException("必须设置打印的列宽！");
            }
            this.dt = dt;
            this.widths = widths;
        }

        /// <summary>
        /// widths必须比dt的列少一列，最后一列自动计算的
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static void Print(DataTable dt, int[] widths, string title)
        {
            Print(dt, widths, title, true);
        }

        /// <summary>
        /// widths必须比dt的列少一列，最后一列自动计算的
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <param name="title"></param>
        public static void Print(DataTable dt, int[] widths, string title,bool isPrintColName)
        {
            BuildAbstractPrinterContent(dt,widths,title,isPrintColName).Print();
        }

        /// <summary>
        /// widths必须比dt的列少一列，最后一列自动计算的
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
        /// widths必须比dt的列少一列，最后一列自动计算的
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
