using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class OperationTimeParentPanel : UserControl
    {
        public OperationTimeParentPanel()
        {
            InitializeComponent();
            try
            {
                GlobalTools.StopUnOperationCounter();
            }
            catch (Exception ex)
            {
            }
        }

        public void SetSepartor(bool result)
        {
            this.panel1.Visible = result;
        }

        public void SetOperationTime(int seconds)
        {
            this.lbTimeSecond.Text = seconds.ToString();
            BeginOperationSeconds();
        }

        public void BeginOperationSeconds()
        {

            timer1.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(this.lbTimeSecond.Text);
            if (count > 1)
                this.lbTimeSecond.Text = (count - 1).ToString();
            else
            {
                //GlobalTools.StopUnOperationCounter();
                timer1.Stop();
                GlobalTools.ReturnMain();
            }
        }
    }
}
