using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.PrinterTicket
{
    public partial class SuccessPrintPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public SuccessPrintPanel()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
#if DEBUG
            Console.WriteLine("执行定时器关闭窗体！");
#endif
            timer1.Enabled = false;
            this.FindForm().Close();
            GlobalTools.ReturnMain();
        }

        private void SuccessPrintPanel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
