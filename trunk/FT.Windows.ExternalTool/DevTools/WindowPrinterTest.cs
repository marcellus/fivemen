using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FT.Commons.Tools;
using FT.Commons.Win32;
using FT.Commons.Print;

namespace FT.Windows.ExternalTool.DevTools
{
    public partial class WindowPrinterTest : Form
    {
        public WindowPrinterTest()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Thread printThread = null;

        private int counter = 0;
        private int stopCounter = 0;

        private int threadSleepTime = 20;

        private void PrintTask()
        {
            while (this.counter < this.stopCounter)
            {
               // StringBuilder msg = new StringBuilder();
                //int i = HotPrinterImporter.PrintLine(this.txtPrintContent.Text.Trim(), msg);
                //if (i == 0)
                //{
                LinePrintObject printer = new LinePrintObject(this.txtPrintContent.Text.Trim());
                CommonPrinter commonPrinter = new CommonPrinter(printer);
                commonPrinter.Print();
                counter++;
                //}
                this.setHint("正在打印：" + counter.ToString() + "页！");
                System.Threading.Thread.Sleep(this.threadSleepTime * 1000);
                if (this.counter == this.stopCounter)
                {

                    this.setHint("打印完成：" + counter.ToString() + "页！");
                    this.btnBeginPrint.Enabled = true;
                    this.btnEndPrint.Enabled = false;
                    break;
                }
                
            }
        }

        private void setHint(string msg)
        {
            WindowFormDelegate.SetMainThreadHint(this.lbHint, msg);
            /*
            if (lbHint.InvokeRequired)
            {
                SetMainThreadHintDelegate msgCallback = new SetMainThreadHintDelegate(setHint);
                lbHint.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                lbHint.Text = msg;
            }
             */
        }


        private void btnBeginPrint_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                stopCounter = Convert.ToInt32(this.txtPrintTotalNum.Text.Trim());
                if (stopCounter == 0)
                {
                    MessageBoxHelper.Show("打印页数必须超过0！");
                    this.txtPrintTotalNum.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("打印页数不是数字格式！");
                this.txtPrintTotalNum.Focus();
                return;
            }

            try
            {
                this.threadSleepTime = Convert.ToInt32(this.txtPrintThreadSeconds.Text.Trim());
                if (threadSleepTime == 0)
                {
                    MessageBoxHelper.Show("打印间隔必须超过0！");
                    this.txtPrintThreadSeconds.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("打印间隔不是数字格式！");
                this.txtPrintThreadSeconds.Focus();
                return;
            }



            counter = 0;
            printThread = new Thread(new ThreadStart(PrintTask));
            printThread.IsBackground = true;
            printThread.Start();

            this.btnEndPrint.Enabled = true;
            this.btnBeginPrint.Enabled = false;
        }

        private void btnEndPrint_Click(object sender, EventArgs e)
        {
            if (printThread != null)
            {
                printThread.Abort();
                this.lbHint.Text += ",用户停止打印！";
            }

            this.btnEndPrint.Enabled = false;
            this.btnBeginPrint.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                stopCounter = Convert.ToInt32(this.txtPrintTotalNum.Text.Trim());
                if (stopCounter == 0)
                {
                    MessageBoxHelper.Show("打印页数必须超过0！");
                    this.txtPrintTotalNum.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("打印页数不是数字格式！");
                this.txtPrintTotalNum.Focus();
                return;
            }

            try
            {
                this.threadSleepTime = Convert.ToInt32(this.txtPrintThreadSeconds.Text.Trim());
                if (threadSleepTime == 0)
                {
                    MessageBoxHelper.Show("打印间隔必须超过0！");
                    this.txtPrintThreadSeconds.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("打印间隔不是数字格式！");
                this.txtPrintThreadSeconds.Focus();
                return;
            }



            counter = 0;
            printThread = new Thread(new ThreadStart(PrintTask));
            printThread.IsBackground = true;
            printThread.Start();

            this.btnEndPrint.Enabled = true;
            this.btnBeginPrint.Enabled = false;
        }
    }
}
