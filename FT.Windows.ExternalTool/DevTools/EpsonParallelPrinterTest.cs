using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Threading;
using FT.Commons.Print;
using FT.Commons.Win32;

namespace FT.Windows.ExternalTool.DevTools
{
    public partial class EpsonParallelPrinterTest : Form
    {
        public EpsonParallelPrinterTest()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private ParallelPrinterConfig config;

        private LPTHelper helper;

        private void EpsonParallelPrinterTest_Load(object sender, EventArgs e)
        {
            config = FT.Commons.Cache.StaticCacheManager.GetConfig<ParallelPrinterConfig>();
            this.txtPrintThreadSeconds.Text = config.Seconds.ToString();
            this.txtPrintTotalNum.Text = config.Pages.ToString();
            this.txtHotPort.Text = config.LPT;
            this.lvCommandLists.Items.Clear();
            for (int i = 0; i < config.Commands.Count; i++)
            {
                this.lvCommandLists.Items.Add(config.Commands[i]);
            }
            helper = new LPTHelper();
        }

        public void Print()
        {
            
            string tmp = string.Empty;
            string[] tmpArray;
            string port = this.txtHotPort.Text.Trim();
            
            for (int i = 0; i < config.Commands.Count; i++)
            {
                WindowFormDelegate.SetMainThreadHint(this.lbPrintHint, string.Format("正执行第{0}条命令",i));
                //Thread.Sleep(500);
                tmp = config.Commands[i];
                if (tmp.IndexOf("|") != -1)
                {
                    tmpArray = tmp.Trim().Split('|');
                    if (tmpArray.Length > 0)
                    {
                        tmp = string.Empty;
                        for (int j = 0; j < tmpArray.Length; j++)
                        {
                            tmp += (char)Convert.ToInt32(tmpArray[j]);
                        }
                    }
                }
                if (port.StartsWith("lpt"))
                {
                    helper.Write(tmp);
                }
                else
                {
                    helper2.Write(tmp);
                }
            }
            
        }

        private void EpsonParallelPrinterTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                config.Pages = Convert.ToInt32(this.txtPrintTotalNum.Text.Trim());
                config.Seconds = Convert.ToInt32(this.txtPrintThreadSeconds.Text.Trim());
                config.LPT = this.txtHotPort.Text.Trim();
            }
            catch
            {
            }
            RefreshCommand();
            FT.Commons.Cache.StaticCacheManager.SaveConfig<ParallelPrinterConfig>(config);
            helper.Close();
        }

        private void RefreshCommand()
        {
            config.Commands.Clear();
            for (int i = 0; i < this.lvCommandLists.Items.Count; i++)
            {
                config.Commands.Add(this.lvCommandLists.Items[i].Text);
            }
        }
        private void SetReadHint(string msg)
        {
            WindowFormDelegate.SetMainThreadHint(this.lbPrintHint, this.lbPrintHint.Text+=msg);
        }

        private SerialPortHelper helper2 = new SerialPortHelper();

        private void btnHotOpenDevice_Click(object sender, EventArgs e)
        {
            string port = this.txtHotPort.Text.Trim();
            if (port.StartsWith("lpt"))
            {
                if (helper.Open(this.txtHotPort.Text.Trim()))
                {
                    this.btnHotOpenDevice.Enabled = false;
                    this.btnHotCloseDevice.Enabled = true;
                    this.btnHotGetState.Enabled = true;
                    this.btnBeginPrint.Enabled = true;
                    this.btnEndPrint.Enabled = false;
                    this.btnPrintCommandOnce.Enabled = true;
                    this.lbOperationHint.Text = "打开并口成功！";
                    helper.Read(new HandleReturnStringDelegate(SetReadHint));
                }
                else
                {
                    this.lbOperationHint.Text = "打开并口失败！";
                }
            }
            else
            {
                try
                {
                    if (helper2.Open(port, Convert.ToInt32(this.txtBaudRate.Text.Trim()),
                        (System.IO.Ports.Parity)Convert.ToInt32(this.txtParity.Text.Trim())
                        , Convert.ToInt32(this.txtDataBits.Text.Trim()),
                        (System.IO.Ports.StopBits)Convert.ToInt32(this.txtStopBit.Text.Trim())
                        ))
                    {
                        this.btnHotOpenDevice.Enabled = false;
                        this.btnHotCloseDevice.Enabled = true;
                        this.btnHotGetState.Enabled = true;
                        this.btnBeginPrint.Enabled = true;
                        this.btnEndPrint.Enabled = false;
                        this.btnPrintCommandOnce.Enabled = true;
                        this.lbOperationHint.Text = "打开串口成功！";
                        helper2.Read(new HandleReturnStringDelegate(SetReadHint));
                    }
                    else
                    {
                        this.lbOperationHint.Text = "打开串口失败！";
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show(ex.ToString());
                }
            }

        }

        private void btnHotCloseDevice_Click(object sender, EventArgs e)
        {
               string port = this.txtHotPort.Text.Trim();
               if (port.StartsWith("lpt"))
               {
                   if (helper.Close())
                   {
                       this.btnHotOpenDevice.Enabled = true;
                       this.btnHotCloseDevice.Enabled = false;
                       this.btnHotGetState.Enabled = false;
                       this.btnBeginPrint.Enabled = false;
                       this.btnEndPrint.Enabled = false;
                       this.btnPrintCommandOnce.Enabled = false;
                       this.lbOperationHint.Text = "关闭并口成功！";
                   }
                   else
                   {
                       this.lbOperationHint.Text = "关闭并口失败！";
                   }
               }
               else
               {
                   if (helper2.Close())
                   {
                       this.btnHotOpenDevice.Enabled = true;
                       this.btnHotCloseDevice.Enabled = false;
                       this.btnHotGetState.Enabled = false;
                       this.btnBeginPrint.Enabled = false;
                       this.btnEndPrint.Enabled = false;
                       this.btnPrintCommandOnce.Enabled = false;
                       this.lbOperationHint.Text = "关闭串口成功！";
                   }
                   else
                   {
                       this.lbOperationHint.Text = "关闭串口失败！";
                   }
               }
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
            RefreshCommand();
            printThread = new Thread(new ThreadStart(PrintTask));
            printThread.IsBackground = true;
            printThread.Start();

            this.btnEndPrint.Enabled = true;
            this.btnBeginPrint.Enabled = false;
        }

        private Thread printThread = null;

        private int counter = 0;
        private int stopCounter = 0;

        private int threadSleepTime = 20;

        private void btnEndPrint_Click(object sender, EventArgs e)
        {
            if (printThread != null)
            {
                printThread.Abort();
                this.lbPrintHint.Text += ",用户停止打印！";
            }

            this.btnEndPrint.Enabled = false;
            this.btnBeginPrint.Enabled = true;
        }

        private void PrintTask()
        {
            while (this.counter < this.stopCounter)
            {
                // StringBuilder msg = new StringBuilder();
                //int i = HotPrinterImporter.PrintLine(this.txtPrintContent.Text.Trim(), msg);
                //if (i == 0)
                //{
                this.Print();
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
            WindowFormDelegate.SetMainThreadHint(this.lbPrintHint, msg);
        }

        private void btnPrintCommandOnce_Click(object sender, EventArgs e)
        {
            this.RefreshCommand();
            this.Print();
        }

        private void btnRemoveFromQuence_Click(object sender, EventArgs e)
        {
            for (int i = this.lvCommandLists.Items.Count - 1; i >= 0; i--)
            {
                if (this.lvCommandLists.Items[i].Selected)
                {
                    this.lvCommandLists.Items.RemoveAt(i);
                }
            }
        }

        private void btnAddToPrintQuence_Click(object sender, EventArgs e)
        {
            if (this.lvCommandLists.SelectedIndices.Count > 0)
            {
                int i = this.lvCommandLists.SelectedIndices[0];
                if (i >=0)
                {
                    i++;
                }
                this.lvCommandLists.Items.Insert(i, new ListViewItem(this.txtPrintCommand.Text));
                this.lvCommandLists.Items[i].Selected = true;
                
            }
            else
            {
                this.lvCommandLists.Items.Add(new ListViewItem(this.txtPrintCommand.Text));
            }
            
        }

        private void lvCommonPrintCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lvCommonPrintCommand.SelectedItems.Count>0)
                this.txtPrintCommand.Text = this.lvCommonPrintCommand.SelectedItems[0].Text;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.lvCommandLists.Items.Clear();
        }
    }
}
