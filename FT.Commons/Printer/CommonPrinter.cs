using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Drawing.Printing;

namespace FT.Commons.Print
{
    /// <summary>
    /// 打印入口类，所有的打印从此入口
    /// </summary>
    public class CommonPrinter
    {
        private  System.Drawing.Printing.PrintDocument printDocument1;
        private  System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private  System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private  System.Windows.Forms.PrintDialog printDialog1;
        private  IPrinter printer;

        /// <summary>
        /// 判断是否该实例能否被打印
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance can printer; otherwise, <c>false</c>.
        /// </returns>
        public bool CanPrinter()
        {
            return printer != null;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonPrinter"/> class.
        /// </summary>
        /// <param name="print">The print.</param>
        public CommonPrinter(IPrinter print)
        {
            this.printer = print;
            this.InitPrint();
            this.printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 100);
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }

        public void Print()
        {
            this.printDocument1.Print();
        }

        /// <summary>
        /// Inits the print.
        /// </summary>
        private void  InitPrint()
        {
            printDocument1 = new System.Drawing.Printing.PrintDocument();

            

            printDialog1 = new System.Windows.Forms.PrintDialog();

            // 
            // printDialog1
            // 
            printDialog1.Document = printDocument1;
            printDialog1.UseEXDialog = true;


            printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
          //  printPreviewDialog1.KeyDown += new KeyEventHandler(printPreviewDialog1_KeyDown);
           // printPreviewDialog1.ActiveControl = printPreviewDialog1.Controls[1];
            
             // 
             // printPreviewDialog1
             // 
            printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;


            pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
             // 
             // pageSetupDialog1
             // 
             pageSetupDialog1.Document =printDocument1;

        }

        void printPreviewDialog1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBoxHelper.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Enter)
            {
                
                printDocument1.Print();
                //printPreviewDialog1.PreviewKeyDown();
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Shows the printer setting.
        /// </summary>
        /// <returns></returns>
        private DialogResult ShowPrinterSetting()
        {
            return printDialog1.ShowDialog();
        }

        /// <summary>
        /// Shows the page setting.
        /// </summary>
        public void ShowPageSetting()
        {
            pageSetupDialog1.ShowDialog();
           
        }

        public void SetPaperSize(int width, int height)
        {

           // this.printDocument1.DefaultPageSettings.PaperSize.Kind = PaperKind.Custom;
            this.printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom paper", width, height);
            //this.printDocument1.DefaultPageSettings.PaperSize.Height = height;
        }

        public void SetPageSize(int left, int top, int right, int bottom)
        {
            this.printDocument1.DefaultPageSettings.Margins.Left = left;
            this.printDocument1.DefaultPageSettings.Margins.Top = top;
            this.printDocument1.DefaultPageSettings.Margins.Right = right;
            this.printDocument1.DefaultPageSettings.Margins.Bottom = bottom;
           // this.printDocument1.DefaultPageSettings.Margins
        }

        public void Preview()
        {
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            this.printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// Shows the preview printer.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowPreviewPrinter()
        {
            if (this.ShowPrinterSetting() == DialogResult.OK)
            {
                try
                {
                    printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                    this.printPreviewDialog1.WindowState = FormWindowState.Maximized;
                   // printPreviewDialog1.Controls[1].Controls[0].Controls[0].Focus();
                   // MessageBoxHelper.Show(printPreviewDialog1.Controls[1].Controls[0].Controls[0].ToString());
                   // this.ShowControl(printPreviewDialog1);
                    DialogResult result= printPreviewDialog1.ShowDialog();
                   // printPreviewDialog1.Focus();
                   // SendKeys.Send("{Tab}");
                  //  SendKeys.Send("{Tab}");
                    //printPreviewDialog1.Load += new EventHandler(printPreviewDialog1_Load);
                  
                    
                   // MessageBoxHelper.Show(printPreviewDialog1.Controls.Count.ToString());//2
                    //MessageBoxHelper.Show(printPreviewDialog1.Controls[0].Controls.Count.ToString());//1
                   // MessageBoxHelper.Show(printPreviewDialog1.Controls[1].Controls.Count.ToString());//0
                    return result;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return DialogResult.No;
                }
            }
            return DialogResult.Cancel;
        }

        private void ShowControl(Control ctr)
        {
           // Control btn = ctr.Controls[1].Controls[0];
           // MessageBoxHelper.Show(btn.ToString() + "->" + btn.Text);
            foreach (Control tmp in ctr.Controls)
            {
                MessageBoxHelper.Show(tmp.ToString()+"->"+tmp.Text);
                ShowControl(tmp);
            }
        }

       

        /// <summary>
        /// Handles the PrintPage event of the printDocument1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        private  void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.White);
            this.printer.Paint(e.Graphics);
           // e.Graphics.DrawImage(this.printer.Paint(), e.MarginBounds.Left, e.MarginBounds.Top);
            if (this.printer.HasMorePage())
            {
                this.printer.Next();
                //this.image = this.printer.Paint();
               // this.PaintImage();
                e.HasMorePages = true;

            }
            else
            {
                e.HasMorePages = false;
            }

        }

    }
}
