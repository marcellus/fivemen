using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.PrinterEx;
using FT.Commons.PrinterEx.SupportObject;
using FT.Windows.Forms;
using FT.Commons.Cache;
using System.Drawing;
using FT.Windows.Forms.Domain;
using System.Data;

namespace FT.Windows.Forms
{
    public abstract class AbstractPrinterContent
    {
        static AbstractPrinterContent()
        {
            
        }

        private bool isPrintColName = true;
        /// <summary>
        /// 是否打印列 头
        /// </summary>
        public bool IsPrintColName
        {
            get { return isPrintColName; }
            set { isPrintColName = value; }
        }

        private GlobalPrintSetting printSetting;

        private PageMargin GetPageMargin()
        {
            printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            PageMargin customMarign = new PageMargin();
            customMarign.Left = Convert.ToInt32(printSetting.Left);
            customMarign.Right = Convert.ToInt32(printSetting.Right);
            customMarign.Top = Convert.ToInt32(printSetting.Top);
            customMarign.Bottom = Convert.ToInt32(printSetting.Bottom);
            return customMarign;
        }

        /// <summary>
        /// 根据全局配置来打印
        /// </summary>
        public void Print()
        {
            PrinterContent content = this.BuildPrinter();
            if (printSetting.PrintModel == "直接打")
            {
                content.Print();
            }
            else if (printSetting.PrintModel == "选择打印机")
            {
                content.PrinterSetting();
            }
            else
            {
                content.Preview();
            }
        }

        protected PageMargin customMargin;

        private string headerTitle = string.Empty;

        /// <summary>
        /// 第二标题
        /// </summary>
        public string HeaderTitle
        {
            get { return headerTitle; }
            set { headerTitle = value; }
        }

      

        /// <summary>
        /// 子类必须实现的打印内容的实质东西
        /// </summary>
        /// <returns></returns>
        protected abstract PrinterTable BuildContent();

        /// <summary>
        /// dt的列必须比widths数组列多一列，最后一列由打印自己计算剩余长度
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="widths"></param>
        /// <returns></returns>
        protected PrinterTable BuildContent(DataTable dt, int[] widths)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int all = 0;
            int[] columnWidth=new int[widths.Length+1];
            for (int i = 0; i < widths.Length; i++)
            {
                columnWidth[i]=widths[i];
                all+=widths[i];
            }
            columnWidth[widths.Length] = customMargin.Width - all;
            //string[] columnHeader ={ "序号", "车号", "姓名", "性别", "身份证明号码", "准考证明号", "成绩", "备注" };
            int len = columnWidth.Length;
            PrinterTable table = new PrinterTable();
            
            PrinterRow row = new PrinterRow();
            int tmp = 0;
            TextDraw text = null;
            int rowHeight = 20;
            if (this.isPrintColName)
            {
                row.Rectangle = new System.Drawing.Rectangle(0, 0, customMargin.Width, 43);
                
                
                Font coltitle = new Font("宋体", 12, FontStyle.Bold);
                
                for (int i = 0; i < len; i++)
                {
                    text = new TextDraw(dt.Columns[i].ColumnName);
                    text.Formater = sf;
                    text.Font = coltitle;
                    text.Border = BordersEdgeStyle.All;
                    text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[i], 43);
                    tmp += columnWidth[i];
                    row.Add(text);
                }
                table.Header = row;
            }
            //table.Add(row);
            row = null;
            Font col = new Font("宋体", 10);
            DataRow dr = null;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dr = dt.Rows[j];
                tmp = 0;
                row = new PrinterRow();
                row.Rectangle = new System.Drawing.Rectangle(0, 0, customMargin.Width, rowHeight);
                for (int i = 0; i < len; i++)
                {
                    text = new TextDraw(Convert.IsDBNull(dr[i]) ? string.Empty : dr[i].ToString());
                    text.Border = BordersEdgeStyle.All;
                    text.Font = col;
                    text.Formater = sf;
                    text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[i], rowHeight);
                    tmp += columnWidth[i];
                    row.Add(text);
                }
                table.Add(row);
            }
            table.Border = BordersEdgeStyle.None;
            return table;
        }

        /// <summary>
        /// 对外的公用方法
        /// </summary>
        /// <returns></returns>
        public virtual PrinterContent BuildPrinter()
        {
            this.customMargin=this.GetPageMargin();
            PrinterContent content = new PrinterContent();

            content.CustomPageMargin = customMargin;
            content.Header = this.BuildHeader();
            content.IsPrinterPages = true;
            content.Footer = this.BuildFooter();
            content.Body = this.BuildContent();
            return content;
        }

        protected virtual PrinterHint BuildHeader()
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;

            StringFormat sf2 = new StringFormat();
            sf2.LineAlignment = StringAlignment.Center;
            sf2.Alignment = StringAlignment.Center;

            CompanyInfo comp = StaticCacheManager.GetConfig<CompanyInfo>();


            int pagewidth = customMargin.Width;
            int captionHeight = 45;
            Font font = new Font("宋体", 20);
            Font cap = new Font("宋体", 14);
            int height = 25;
            PrinterHint header = new PrinterHint();
            header.Rectangle = new Rectangle(0, 0, pagewidth, height + captionHeight + 12);
            header.PrintInEveryPage = false;
            header.Border = BordersEdgeStyle.None;
            //打印单位名称
            TitleDraw title = new TitleDraw(comp.NickName+" "+System.DateTime.Now.ToShortDateString());
            title.Font = cap;
            title.Rectangle = new Rectangle(0, 0, pagewidth, height);
            title.Border = BordersEdgeStyle.None;
            title.Formater = sf;
            //打印主标题
            TitleDraw titleMain = new TitleDraw(this.headerTitle);
            titleMain.Font = font;
            titleMain.Rectangle = new Rectangle(0, height, pagewidth, captionHeight);
            titleMain.Border = BordersEdgeStyle.None;
            titleMain.Formater = sf2;
            header.Add(title);
            header.Add(titleMain);
            return header;
        }

        protected virtual PrinterHint BuildFooter()
        {
            return null;
        }
    }
}
