using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Bar;
using FT.Device.IDCard;

namespace InputDevMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MonitorConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<MonitorConfig>();
            if (config.IsStartIdCardReader)
            {
                idcardReader.StartWatching();
                this.btnStartIdCardReader.Text = "停止";
                this.ShowIdCardReaderState();
            }
            if (config.IsStartBarReader)
            {
                barReader.StartWatching();
                this.btnStartBarReader.Text = "停止";
                this.ShowBarReaderState();
            }
        }

        private void btnIdCardReader_Click(object sender, EventArgs e)
        {
            Form form = new FT.Device.IDCard.IDCardConfigForm();
            form.ShowDialog();
        }

        private void btnBarReader_Click(object sender, EventArgs e)
        {
            Form form = new FT.Commons.Bar.BarReaderConfigForm();
            form.ShowDialog();
        }

        private SimpleBarReader barReader = new SimpleBarReader();
        private void btnCodeBarReader_Click(object sender, EventArgs e)
        {
            if (this.btnStartBarReader.Text == "启动")
            {
                barReader.StartWatching();
                this.btnStartBarReader.Text = "停止";

            }
            else
            {
                barReader.StopWatching();
                this.btnBarReader.Text = "启动";
            }
            this.ShowBarReaderState();

           
        }

        private void ShowBarReaderState()
        {
            if (barReader.IsOpen)
            {
                this.lbBarReaderHint.Text = "状态：已启动";
            }
            else
            {
                this.lbBarReaderHint.Text = "状态：未启动";
            }
        }

        private IDCardReaderHelper idcardReader = new IDCardReaderHelper();

        private void btnStartIdCardReader_Click(object sender, EventArgs e)
        {
            if (this.btnStartIdCardReader.Text == "启动")
            {
                idcardReader.StartWatching();
                this.btnStartIdCardReader.Text = "停止";

            }
            else
            {
                idcardReader.StopWatching();
                this.btnStartIdCardReader.Text = "启动";
            }

            this.ShowIdCardReaderState();
        }

        private void ShowIdCardReaderState()
        {
            if (idcardReader.IsOpen)
            {
                this.lbIdCardReaderHint.Text = "状态：已启动";
            }
            else
            {
                this.lbIdCardReaderHint.Text = "状态：未启动";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new SystemConfig();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
           
        }
    }
}
