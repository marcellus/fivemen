using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using log4net;
using FT.Commons.Bar;

namespace FT.Commons.Bar
{
    public partial class CodeReader : Form
    {
        protected ILog log = log4net.LogManager.GetLogger("FT.Windows.ExternalTool.CodeReader");
        
        private void AppendText(string text)
        {
            /*
            if (this.txtDetail.InvokeRequired)
            {
                
                ProcessBarData d = new ProcessBarData(AppendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtDetail.AppendText(text+"\r\n");
            }*/
            SendKeys.SendWait(text);
            SendKeys.SendWait("{ENTER}");
            //for (int i = 0; i < text.Length; i++)
            //{
               
            //}
        }

        private SimpleBarReader reader = new SimpleBarReader();

        public CodeReader()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void CodeReader_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!reader.StartWatching())
                {
                    MessageBoxHelper.Show("Æô¶¯ÌõÂë¼àÌýÊ§°Ü£¡");
                }
                else
                {
                    //reader.RegisterProcesser(AppendText);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txtDetail.Text = "";
        }

        private void CodeReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader.IsOpen)
            {
                reader.StopWatching();
            }
        }
    }
}