using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FT.Device.HotPrinter;
using FT.Commons.Win32;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool.DevTools
{
    public partial class Epson532SerialPrinterTest : Form
    {
        public Epson532SerialPrinterTest()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnHotOpenDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.OpenDevice(Convert.ToInt32(this.txtHotPort.Text.Trim()), msg);
            this.lbHotHint.Text = "打开设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {

                this.SetHotPrinter(true);
            }
        }

        
        private void SetHotPrinter(bool result)
        {
            this.btnHotChangeLine.Enabled = result;
            this.btnHotCloseDevice.Enabled = result;
            this.btnHotCutPaper.Enabled = result;
            this.btnHotGetState.Enabled = result;
            this.btnBeginPrint.Enabled = result;
            this.btnEndPrint.Enabled = result;

          
            this.btnHotOpenDevice.Enabled = !result;
           
            this.btnHotPrintLine.Enabled = result;
        }

        private void btnHotCloseDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.CloseDevice(msg);
            this.lbHotHint.Text = "关闭设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {

                this.SetHotPrinter(false);
            }
        }

        private void btnHotGetState_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.GetDeviceStatus(msg);
            this.lbHotHint.Text = "获取状态返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotPrintLine_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.PrintLine(this.txtHotPrintText.Text.Trim(), msg);
            this.lbHotHint.Text = "打印文字返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotChangeLine_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.PrintLine("", msg);
            this.lbHotHint.Text = "换行返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotCutPaper_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.CutPaper(msg);
            this.lbHotHint.Text = "切纸返回code:" + i + "返回msg:" + msg;
        }

        private Thread printThread =null;

        private int counter = 0;
        private int stopCounter = 0;

        private int threadSleepTime = 20;
        private void btnBeginPrint_Click(object sender, EventArgs e)
        {
            try
            {
                stopCounter=Convert.ToInt32(this.txtPrintTotalNum.Text.Trim());
                if (stopCounter == 0)
                {
                    MessageBoxHelper.Show("打印行数必须超过0！");
                    this.txtPrintTotalNum.Focus();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBoxHelper.Show("打印行数不是数字格式！");
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

        private void PrintTask()
        {
            while (this.counter < this.stopCounter)
            {
                StringBuilder msg = new StringBuilder();
                int i = HotPrinterImporter.PrintLine(this.txtPrintContent.Text.Trim(), msg);
                if (i == 0)
                {
                    counter++;
                }
                this.setHint("正在打印：" + counter.ToString() + "行！");
                System.Threading.Thread.Sleep(this.threadSleepTime * 1000);
                if (this.counter == this.stopCounter)
                {
                    
                    this.setHint("打印完成：" + counter.ToString() + "行！");
                    this.btnBeginPrint.Enabled = true;
                    this.btnEndPrint.Enabled = false;
                    break;
                }
                
            }
        }

        private void PrintTask2()
        {

            while (this.counter < this.stopCounter)
            {
                StringBuilder msg = new StringBuilder();
                int i = HotPrinterImporter.PrintLine(this.txtPrintContent.Text.Trim(), msg);
                if (i == 0)
                {
                    counter++;
                }
                WindowFormDelegate.SetMainThreadHint(this.lbHotHint, "正在打印：" + counter.ToString() + "行！");
                System.Threading.Thread.Sleep(this.threadSleepTime * 1000);
                if (this.counter == this.stopCounter)
                {
                    WindowFormDelegate.SetMainThreadHint(this.lbHotHint, "打印完成：" + counter.ToString() + "行！");
                    break;
                }
                
            }
            
            

        }

        private void setHint(string msg)
        {
            if (lbHotHint.InvokeRequired)
            {
                SetMainThreadHintDelegate msgCallback = new SetMainThreadHintDelegate(setHint);
                lbHotHint.Invoke(msgCallback, new object[] { msg });
            }
            else
            {
                lbHotHint.Text = msg;
            }
        }

        private void btnEndPrint_Click(object sender, EventArgs e)
        {
            if (printThread != null)
            {
                printThread.Abort();
                this.lbHotHint.Text += ",用户停止打印！";
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
                    MessageBoxHelper.Show("打印行数必须超过0！");
                    this.txtPrintTotalNum.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("打印行数不是数字格式！");
                this.txtPrintTotalNum.Focus();
                return;
            }
            counter = 0;
            printThread = new Thread(new ThreadStart(PrintTask2));
            printThread.IsBackground = true;
            printThread.Start();

            this.btnEndPrint.Enabled = true;
            this.btnBeginPrint.Enabled = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
