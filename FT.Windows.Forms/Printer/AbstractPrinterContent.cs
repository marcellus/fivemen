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
        /// �Ƿ��ӡ�� ͷ
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
        /// ����ȫ����������ӡ
        /// </summary>
        public void Print()
        {
            PrinterContent content = this.BuildPrinter();
            if (printSetting.PrintModel == "ֱ�Ӵ�")
            {
                content.Print();
            }
            else if (printSetting.PrintModel == "ѡ���ӡ��")
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
        /// �ڶ�����
        /// </summary>
        public string HeaderTitle
        {
            get { return headerTitle; }
            set { headerTitle = value; }
        }

      

        /// <summary>
        /// �������ʵ�ֵĴ�ӡ���ݵ�ʵ�ʶ���
        /// </summary>
        /// <returns></returns>
        protected abstract PrinterTable BuildContent();

        /// <summary>
        /// dt���б����widths�����ж�һ�У����һ���ɴ�ӡ�Լ�����ʣ�೤��
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
            //string[] columnHeader ={ "���", "����", "����", "�Ա�", "���֤������", "׼��֤����", "�ɼ�", "��ע" };
            int len = columnWidth.Length;
            PrinterTable table = new PrinterTable();
            
            PrinterRow row = new PrinterRow();
            int tmp = 0;
            TextDraw text = null;
            int rowHeight = 20;
            if (this.isPrintColName)
            {
                row.Rectangle = new System.Drawing.Rectangle(0, 0, customMargin.Width, 43);
                
                
                Font coltitle = new Font("����", 12, FontStyle.Bold);
                
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
            Font col = new Font("����", 10);
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
        /// ����Ĺ��÷���
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
            Font font = new Font("����", 20);
            Font cap = new Font("����", 14);
            int height = 25;
            PrinterHint header = new PrinterHint();
            header.Rectangle = new Rectangle(0, 0, pagewidth, height + captionHeight + 12);
            header.PrintInEveryPage = false;
            header.Border = BordersEdgeStyle.None;
            //��ӡ��λ����
            TitleDraw title = new TitleDraw(comp.NickName+" "+System.DateTime.Now.ToShortDateString());
            title.Font = cap;
            title.Rectangle = new Rectangle(0, 0, pagewidth, height);
            title.Border = BordersEdgeStyle.None;
            title.Formater = sf;
            //��ӡ������
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
