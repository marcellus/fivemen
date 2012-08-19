using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FT.Windows.Controls.PanelEx
{
    public partial class ProcessPanel : UserControl
    {
        public ProcessPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Color color1 = Color.FromArgb(180, 217, 1);

        private Color color2 = SystemColors.MenuHighlight;

        private int currentIndex = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  timer1.Stop();
        }

        private void Flash()
        {
            while (true)
            {
                try
                {
                    if (currentIndex == 6)
                    {
                        currentIndex = 0;
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        this.Controls["lb" + i.ToString()].BackColor = color1;
                    }
                    this.Controls["lb" + currentIndex.ToString()].BackColor = color2;
                    currentIndex++;
                    System.Threading.Thread.Sleep(300);
                }
                catch
                {
                    return;
                }
            }
           
        }

        public void StopProcess()
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }

        private Thread thread;

        public void StartProcess()
        {
            thread = new Thread(new ThreadStart(Flash));
            thread.IsBackground = true;
            thread.Start();
            //Flash();
        }

        private void ProcessPanel_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            
        }
    }
}
