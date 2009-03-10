using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// ��Ҫ��ӡ������
    /// </summary>
    public class PrinterContent
    {

       

        private static PrintDocument document; 

        private bool isPrinterPages=true;

        /// <summary>
        /// ��ӡҳ��ĸ߶�
        /// </summary>
        public const int Printer_Pages_Height = 18;

        /// <summary>
        /// Ĭ�ϴ�ӡҳ��
        /// </summary>
        public bool IsPrinterPages
        {
            get { return isPrinterPages; }
            set { isPrinterPages = value; }
        }

        private string pagesFormatter = "��{0}ҳ";

        /// <summary>
        /// ��ʽ��ҳ����ַ���
        /// </summary>
        public string PagesFormatter
        {
            get { return pagesFormatter; }
            set { pagesFormatter = value; }
        }

        public PrinterContent()
        {
            if (document == null)
            {
                document = new PrintDocument();
                pageMargin = new PageMargin(document);

            }
            else
            {
                document.Dispose();
                document = new PrintDocument();
                
            }
            customPageMargin = pageMargin;
            
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            
            
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            this.PrintCommon(e.Graphics);
            //�ڵ�һҳ������ҳ��
            if (currentPageIndex == 1)
            {
                //this.pages = body.ComputePages(pageMargin.Height - (header != null ? header.Rectangle.Height : 0) - (footer != null ? footer.Rectangle.Height : 0) - (IsPrinterPages ? Printer_Pages_Height : 0));
            }
            try
            {
                body.Draw(e.Graphics);

                if (!body.IsFinish())
                {
                    e.HasMorePages = true;
                    CurrentPageIndex++;
                }
                else
                {
                    e.HasMorePages = false;

                    //��ӡ��Ԥ����Ϻ����ã�������Ԥ�������д�ӡʱ�򲻳�������Body
                    this.CurrentPageIndex = 1;
                    this.body.CurrentRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        private int pages = 1;

        private static PageMargin pageMargin;

        public static PageMargin PageMargin
        {
            get { return PrinterContent.pageMargin; }
            set { PrinterContent.pageMargin = value; }
        }

        private PageMargin customPageMargin;

        /// <summary>
        /// �����Զ����ҳ��߾�
        /// </summary>
        public PageMargin CustomPageMargin
        {
            get { return customPageMargin; }
            set { customPageMargin = value;

            if (document != null)
            {
                customPageMargin.Width = document.DefaultPageSettings.PaperSize.Width - customPageMargin.Left - customPageMargin.Right;
                customPageMargin.Height = document.DefaultPageSettings.PaperSize.Height - customPageMargin.Top - customPageMargin.Bottom;
            }
            }
        }

        private PrinterTable body;
        /// <summary>
        /// ����ӡ��ʵ�����ݣ�������һ��Row��Ҳ������һ��Table
        /// </summary>
        public PrinterTable Body
        {
            get { return body; }
            set { body = value; }
        }

       
        private PrinterHint header;

        /// <summary>
        /// ��ӡ��ͷ��,��һ������϶���,��Ҫ�Կ��ô�ӡ������ж�λ
        /// </summary>
        public PrinterHint Header
        {
            get { return header; }
            set { header = value;
            header.Rectangle = new Rectangle(customPageMargin.Left, customPageMargin.Top, header.Rectangle.Width, header.Rectangle.Height);
            
            }
        }

        
        private PrinterHint footer;

        /// <summary>
        /// ��ӡ�ĵײ�����һ������϶���,��Ҫ�Կ��ô�ӡ������ж�λ
        /// </summary>
        public PrinterHint Footer
        {
            get { return footer; }
            set { footer = value; }
        }

        public void PrinterSetting()
        {
            PrintDialog pDlg = new PrintDialog();
            PrintPreviewDialog ppDlg = new PrintPreviewDialog();
            try
            {
                //��������ֵ��PrinterSettings
                PrinterSettings ps = new PrinterSettings();
                
                //����ѡ��ҳ
                pDlg.AllowSomePages = true;

                //ָ����ӡ�ĵ�
                pDlg.Document = document;

                //��ʾ�Ի���
                DialogResult result = pDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //�����ӡ����
                    ps = pDlg.PrinterSettings;
                    
                    ppDlg.Text = "��ӡԤ��";
                    ppDlg.WindowState = FormWindowState.Maximized;
                    ppDlg.PrintPreviewControl.Zoom = 1;
                    //ָ����ӡ�ĵ�
                    ppDlg.Document = document;
                    ppDlg.ShowDialog();
                }

            }
            catch (System.Drawing.Printing.InvalidPrinterException e)
            {
                MessageBox.Show("�����ڿ��������Ӵ�ӡ��!", "δ�ҵ���ӡ��");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ӡ����");
            }
            finally
            {
                pDlg.Dispose();
                pDlg = null;
                ppDlg.Dispose();
                ppDlg = null;
            }
        }

        public void Preview()
        {
            PrintPreviewDialog ppDlg = new PrintPreviewDialog();
            try
            {
               
                ppDlg.Text = "��ӡԤ��";
                ppDlg.WindowState = FormWindowState.Maximized;
                ppDlg.PrintPreviewControl.Zoom = 1;
                //ָ����ӡ�ĵ�
                ppDlg.Document = document;

                //��ʾ�Ի���
                //				ppDlg.FindForm().Visible = false;


                DialogResult result = ppDlg.ShowDialog();

                //				ppDlg.FindForm().Visible = true;
                if (result == DialogResult.OK)
                {
                    //...
                }

            }
            catch (System.Drawing.Printing.InvalidPrinterException e)
            {
                MessageBox.Show("�����ڿ��������Ӵ�ӡ��!", "δ�ҵ���ӡ��");
                //ShowInvalidPrinterException(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ӡ����");
            }
            finally
            {
                ppDlg.Dispose();
                ppDlg = null;
            }
        }

        public void Print()
        {
            try
            {
                document.Print();
            }
            catch (System.Drawing.Printing.InvalidPrinterException e)
            {
                MessageBox.Show("�����ڿ��������Ӵ�ӡ��!", "δ�ҵ���ӡ��");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ӡ����");
            }
           
           
        }

        public bool HaveMorePages()
        {
            return !body.IsFinish();
        }
        /// <summary>
        /// ��ǰҳ����
        /// </summary>
        private int currentPageIndex = 1;

        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }

        /// <summary>
        /// ��ӡheader��footer
        /// </summary>
        private void PrintCommon(Graphics graphics)
        {
            body.Rectangle = new Rectangle(customPageMargin.Left, customPageMargin.Top, customPageMargin.Width, customPageMargin.Height);
            if (header != null)
            {
                if (this.CurrentPageIndex == 1 || header.PrintInEveryPage)
                {
                    header.Rectangle = new Rectangle(customPageMargin.Left, customPageMargin.Top, header.Rectangle.Width, header.Rectangle.Height);
                    header.Draw(graphics);
                    // body.Rectangle.Height=customPageMargin.Height-header.Rectangle.Height;
                    body.Rectangle = new Rectangle(body.Rectangle.X, body.Rectangle.Y+header.Rectangle.Height, body.Rectangle.Width, body.Rectangle.Height - header.Rectangle.Height);

                }

            }

            if (footer != null)
            {
                if (this.CurrentPageIndex == 1 || footer.PrintInEveryPage)
                {
                    body.Rectangle = new Rectangle(body.Rectangle.X, body.Rectangle.Y, body.Rectangle.Width, body.Rectangle.Height - footer.Rectangle.Height);
                    footer.Rectangle = new Rectangle(customPageMargin.Left, body.Rectangle.Y + body.Rectangle.Height, body.Rectangle.Width, footer.Rectangle.Height);
                    footer.Draw(graphics);
                    
                }
            }

            if (this.IsPrinterPages)
            {
                FooterDraw draw=new FooterDraw(string.Format(this.PagesFormatter,new object[]{this.currentPageIndex,this.pages}));
                draw.Border = BordersEdgeStyle.None;
                draw.Rectangle = new Rectangle(customPageMargin.Left, customPageMargin.Height + customPageMargin.Top - Printer_Pages_Height, customPageMargin.Width, Printer_Pages_Height);
                draw.Draw(graphics);
                body.Rectangle = new Rectangle(body.Rectangle.X, body.Rectangle.Y, body.Rectangle.Width, body.Rectangle.Height - Printer_Pages_Height);
               // draw.Rectangle=new Rectangle(this.customPageMargin.Top,
               // draw.Draw(graphics);
            }
        }
        
    }
}
