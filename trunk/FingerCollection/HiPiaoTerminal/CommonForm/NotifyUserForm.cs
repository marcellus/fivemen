using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;
//using HiPiaoTerminalWpf;
//using HiPiaoTerminal.Wpf;

namespace HiPiaoTerminal.CommonForm
{
    public partial class NotifyUserForm : Form
    {
        public NotifyUserForm()
        {
            InitializeComponent();
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White; 
        }
        private Control panel;
        //private System.Windows.Controls.UserControl panel2;
        private int colorType=1;

        public int ColorType
        {
            get { return colorType; }
            set { colorType = value; }
        }
        public NotifyUserForm(Control panel)
        {
            InitializeComponent();
            this.panel = panel;
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White; 
        }
/*
        public NotifyUserForm(System.Windows.Controls.UserControl panel)
        {
            InitializeComponent();
            this.panel2 = panel;
            IParentWpfWindows window=panel as IParentWpfWindows;
            if (window != null)
            {
                window.Register(this);
            }
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White; 
        }

        
        private Window window = null;
*/
        private Form form = null;
        private void NotifyUserForm_Load(object sender, EventArgs e)
        {
            if (this.panel != null)
            {
                if (colorType == 1)
                {
                    form = new FirstRoundNotifyForm();
                }
                else
                {
                    form = new SecondRoundNotifyForm();
                }
                
                form.FormBorderStyle = FormBorderStyle.None;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Width = panel.Width;
                form.Height = panel.Height;
                form.BackColor = Color.Red;
                panel.Dock = DockStyle.Fill;
                //form.BackColor = Color.Red;
                //form.BackColor = Color.FromArgb(117, 117, 117);
                //form.Opacity = 0.6d;
                //form.TransparencyKey = Color.FromArgb(117, 117, 117);
                //form.BackgroundImage = TestResource.TestRegister;
                form.Controls.Add(panel);
                form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                form.ShowDialog();
            }
            /*
            if (this.panel2 != null)
            {
                if (this.colorType == 1)
                {
                    FirstRoundWindow window = new FirstRoundWindow();
                    this.window = window;
                    window.AddPanel(panel2);
                    window.ShowDialog();
                    window.Closing += new CancelEventHandler(window_Closing);
                }
                else
                {
                   // window = new SecondRoundWindow();

                    SecondRoundWindow window = new SecondRoundWindow();
                    this.window = window;
                    window.AddPanel(panel2);
                    window.ShowDialog();
                    window.Closing += new CancelEventHandler(window_Closing);
                }
                
                
               

            }
             * */

        }

        void window_Closing(object sender, CancelEventArgs e)
        {
            //this.DialogResult = window.DialogResult as DialogResult;
            this.Close();
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = form.DialogResult;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.None;
            this.Close();
        }
    }
}
