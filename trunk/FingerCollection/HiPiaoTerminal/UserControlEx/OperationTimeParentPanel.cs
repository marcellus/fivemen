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
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            }
            catch (Exception ex)
            {

                Console.WriteLine("执行倒计时界面出现异常："+ex);
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

        public void StopOpertionTime()
        {
            this.timer1.Stop();
        }
        public void BeginOperationSeconds()
        {
            timer1.Stop();
            timer1.Start();
        }

        private bool CounterTime = false;


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.FindForm() == null||this.Parent==null)
            {
#if DEBUG
                Console.WriteLine(this.Name+"控件不属于窗体，停止计时器");
#endif
                this.timer1.Stop();
                this.timer1.Enabled = false;
            }
            else if (!CounterTime)
            {
                CounterTime = true;
                this.timer1.Stop();
                this.timer1.Enabled = false;
                int count = Convert.ToInt32(this.lbTimeSecond.Text);
#if DEBUG
                Console.WriteLine(System.DateTime.Now.Second.ToString() + "操作界面倒计时时间：" + this.lbTimeSecond.Text);
#endif
                
                if (count > 1)
                {
                    this.lbTimeSecond.Text = (count - 1).ToString();
                    this.timer1.Enabled = true;
                    this.timer1.Start();
                }
                else
                {
                    //GlobalTools.StopUnOperationCounter();
                    timer1.Stop();
                    timer1.Enabled = false;
#if DEBUG           
                    Console.WriteLine("操作界面本身的操作时间已经到了！");
#endif
                    GlobalTools.ReturnMain();
                }
                CounterTime = false;
            }
        }
    }
}
