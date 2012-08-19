using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FT.Commons.Tools;
using System.Threading;
using FT.Commons.Win32;
using FT.Commons.Print;

namespace FT.Windows.ExternalTool.DevTools
{
    public partial class TemplatePrinterTestForm : Form
    {
        
        public TemplatePrinterTestForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private TemplateTextConfig config;

        private void TemplatePrinterTestForm_Load(object sender, EventArgs e)
        {
            ArrayList lists = FontHelper.GetInstallFont();
            this.cbFonts.DataSource = lists;
            this.cbFonts.Text = "宋体";
            this.cbFonts.DropDownStyle = ComboBoxStyle.DropDownList;
            config = FT.Commons.Cache.StaticCacheManager.GetConfig<TemplateTextConfig>();
            this.dataGridView1.AutoGenerateColumns = false;
           // MessageBoxHelper.Show("模板条数："+config.Lists.Count.ToString());
            this.RefreshData();
            this.txtPageWidth.Text = config.PageWidth.ToString();
            this.txtPageHeight.Text = config.PageHeight.ToString();
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
                TemplatePrintObject printer = new TemplatePrintObject(config);
                CommonPrinter commonPrinter = new CommonPrinter(printer);
                commonPrinter.SetPaperSize(config.PageWidth, config.PageHeight);
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

        private void btnAddToPrintTemplate_Click(object sender, EventArgs e)
        {
            TemplateTextObject text = new TemplateTextObject();
            text.Content = this.txtContent.Text.TrimEnd();
            text.FontName = this.cbFonts.Text;
            text.FontSize = Convert.ToInt32(this.txtFontSize.Text);
            text.Left = Convert.ToInt32(this.txtLeft.Text);
            text.Top = Convert.ToInt32(this.txtTop.Text);
            config.Lists.Add(text);
            this.RefreshData();
        }

        private void RefreshData()
        {
            if (config.Lists.Count > 0)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = config.Lists;
            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
        }

        private void btnRemovePrintTemplate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows= this.dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                for (int j = rows.Count - 1; j >= 0; j--)
                {
                    this.config.Lists.RemoveAt(rows[j].Index);
                   // this.dataGridView1.Rows.RemoveAt(rows[j].Index);
                }
            }
            this.RefreshData();
            //this.dataGridView1.Rows[0].Selected = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            TemplatePrintObject printer = new TemplatePrintObject(config);
            CommonPrinter commonPrinter = new CommonPrinter(printer);
            commonPrinter.SetPaperSize(config.PageWidth, config.PageHeight);
            commonPrinter.Print();
        }

        private void TemplatePrinterTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.PageHeight = Convert.ToInt32(this.txtPageHeight.Text.Trim());
            config.PageWidth = Convert.ToInt32(this.txtPageWidth.Text.Trim());
            //MessageBoxHelper.Show("模板条数："+config.Lists.Count.ToString());
            FT.Commons.Cache.StaticCacheManager.SaveConfig<TemplateTextConfig>(config);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            TemplatePrintObject printer = new TemplatePrintObject(config);
            CommonPrinter commonPrinter = new CommonPrinter(printer);
            commonPrinter.SetPaperSize(config.PageWidth, config.PageHeight);
            commonPrinter.Preview();
        }
    }
}
