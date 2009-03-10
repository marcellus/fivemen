using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 需要打印的内容
    /// </summary>
    public class PrinterContent
    {

       

        private static PrintDocument document; 

        private bool isPrinterPages=true;

        /// <summary>
        /// 打印页码的高度
        /// </summary>
        public const int Printer_Pages_Height = 18;

        /// <summary>
        /// 默认打印页码
        /// </summary>
        public bool IsPrinterPages
        {
            get { return isPrinterPages; }
            set { isPrinterPages = value; }
        }

        private string pagesFormatter = "第{0}页";

        /// <summary>
        /// 格式化页码的字符串
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
            //在第一页计算总页数
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

                    //打印或预览完毕后重置，以免在预览窗口中打印时打不出网格体Body
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
        /// 设置自定义的页面边距
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
        /// 待打印的实质内容，可以是一个Row，也可以是一个Table
        /// </summary>
        public PrinterTable Body
        {
            get { return body; }
            set { body = value; }
        }

       
        private PrinterHint header;

        /// <summary>
        /// 打印的头部,是一个行组合对象,需要对可用打印区域进行定位
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
        /// 打印的底部，是一个行组合对象,需要对可用打印区域进行定位
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
                //声明返回值的PrinterSettings
                PrinterSettings ps = new PrinterSettings();
                
                //可以选定页
                pDlg.AllowSomePages = true;

                //指定打印文档
                pDlg.Document = document;

                //显示对话框
                DialogResult result = pDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //保存打印设置
                    ps = pDlg.PrinterSettings;
                    
                    ppDlg.Text = "打印预览";
                    ppDlg.WindowState = FormWindowState.Maximized;
                    ppDlg.PrintPreviewControl.Zoom = 1;
                    //指定打印文档
                    ppDlg.Document = document;
                    ppDlg.ShowDialog();
                }

            }
            catch (System.Drawing.Printing.InvalidPrinterException e)
            {
                MessageBox.Show("请先在控制面板添加打印机!", "未找到打印机");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印错误");
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
               
                ppDlg.Text = "打印预览";
                ppDlg.WindowState = FormWindowState.Maximized;
                ppDlg.PrintPreviewControl.Zoom = 1;
                //指定打印文档
                ppDlg.Document = document;

                //显示对话框
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
                MessageBox.Show("请先在控制面板添加打印机!", "未找到打印机");
                //ShowInvalidPrinterException(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印错误");
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
                MessageBox.Show("请先在控制面板添加打印机!", "未找到打印机");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印错误");
            }
           
           
        }

        public bool HaveMorePages()
        {
            return !body.IsFinish();
        }
        /// <summary>
        /// 当前页索引
        /// </summary>
        private int currentPageIndex = 1;

        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }

        /// <summary>
        /// 打印header和footer
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
