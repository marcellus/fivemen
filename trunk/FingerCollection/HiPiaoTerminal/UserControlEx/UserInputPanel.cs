using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace HiPiaoTerminal.UserControlEx
{

    public partial class UserInputPanel : UserControl
    {
        public UserInputPanel()
        {
            InitializeComponent();
            this.txtMain.TextChanged += new EventHandler(txtMain_TextChanged);
            this.txtMain.MouseDown += new MouseEventHandler(txtMain_MouseDown);
            CheckForIllegalCrossThreadCalls = false;
            this.txtMain.TextChanged+=new EventHandler(txtMain_TextChanged);

           // this.txtMain.Enabled = false;
           // this.txtMain.KeyDown += new KeyEventHandler(txtMain_KeyDown);
           
           
        }

        public override bool Focused
        {
            get
            {
                return this.txtMain.Focused;
            }
        }

        public delegate void OnSubTextChanged();//定义委托
        public event OnSubTextChanged onSubTextChanged;//定义事件

        void txtMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((57 >= e.KeyValue && e.KeyValue >= 48) || (90 >= e.KeyValue && e.KeyValue >= 65) || (122 >= e.KeyValue & e.KeyValue >= 97))
            {
                if (this.txtMain.Text != this.txtMain.Hint)
                {
                    this.txtMain.Text += e.KeyCode.ToString();
                }
                else
                {
                    this.txtMain.Text = e.KeyCode.ToString();
                    //this.txtMain.HideHint();
                }
            }
        }

        void txtMain_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(this.txtMain.Handle);
        }
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);



        void txtMain_TextChanged(object sender, EventArgs e)
        {
           // this.OnKeyUp(null);
            if (this.onSubTextChanged != null)
            {
                onSubTextChanged();
                
            }
        }

        public char PasswordChar
        {
            get
            {
                return this.txtMain.TempPasswordChar;
            }
            set{
                this.txtMain.TempPasswordChar= value;
            }
        }

        public  string Hint
        {
            get
            {
                return this.txtMain.Hint;
            }
            set
            {
                this.txtMain.Hint = value;
            }
        }

        public void Focus()
        {
           
           
           // this.txtMain.Focus();
            this.panel1.BackgroundImage = HiPiaoTerminal.Properties.Resources.Green_Left;
            this.panel2.BackgroundImage = HiPiaoTerminal.Properties.Resources.Green_Right;
            this.panelCenter.BackgroundImage = HiPiaoTerminal.Properties.Resources.Green_Center;
            txtMain_Click(null,null);
            txtMain_Enter(null, null);
            this.txtMain.Focus();
            
        }

        public void UnFocus()
        {
            this.panel1.BackgroundImage = HiPiaoTerminal.Properties.Resources.Gray_Left;
            this.panel2.BackgroundImage = HiPiaoTerminal.Properties.Resources.Gray_Right;
            this.panelCenter.BackgroundImage = HiPiaoTerminal.Properties.Resources.Gray_Center;
            this.txtMain_Leave(null, null);
        }

        public override string Text
        {
            get
            {
                return this.txtMain.GetRealText() ;
            }
            set
            {
                this.txtMain.Text = value;
                if (this.txtMain.Hint != value)
                {
                    this.txtMain.ForeColor = Color.Black;
                }
            }
        }

        private void UserInputPanel_Enter(object sender, EventArgs e)
        {
           
            this.Focus();
            
        }

        private void UserInputPanel_Leave(object sender, EventArgs e)
        {
            this.UnFocus();
        }

        private void UserInputPanel_Resize(object sender, EventArgs e)
        {
            this.panel1.Width = this.panel2.Width = 14;
            this.panelCenter.Location = new Point(14, 0);
            this.panelCenter.Width = this.Size.Width - 2 * this.panel1.Width ;
            this.txtMain.Location = new Point(9, 16);
            this.txtMain.Width = this.Size.Width - 2 * this.panel1.Width - 5;
            

        }

        private void FlashUnderLine()
        {
            //Console.WriteLine("开始执行线程");
            while (true)
            {
                try
                {
                    Graphics gc = this.txtMain.CreateGraphics();
                    int wd = (int)gc.MeasureString("x", txtMain.Font).Width;
                    int ht = (int)gc.MeasureString("x", txtMain.Font).Height;
                    int begin = 0;
                    Point p2=this.txtMain.Location;
                    if (this.txtMain.HasValue)
                    {
                        begin = txtMain.Text.Length-1;
                        if (begin == 0)
                        {
                            begin = 1;
                        }
                        p2 = txtMain.GetPositionFromCharIndex(begin);
                    }
                    else
                    {
                        begin = 0;
                        p2 = new Point(this.txtMain.Location.X, this.txtMain.Location.Y);
                    }
                     
                    //Point p = txtMain.Location;
                    // p.X += p.X +wd;
                    // p.Y += p.Y;
                    //Console.WriteLine("转化前下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString());
                    if (begin != 0)
                    {
                        this.picUnderLine.Location = new Point(p2.X + wd, this.picUnderLine.Location.Y);
                    }
                    else
                    {
                        this.picUnderLine.Location = new Point(p2.X+5, this.picUnderLine.Location.Y);
                    }
                    //this.picUnderLine.Width = wd;
                    //Console.WriteLine("转化后下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString());
                    this.picUnderLine.Visible = !this.picUnderLine.Visible;
                    System.Threading.Thread.Sleep(500);
                }
                catch
                {
                    return;
                }
            }
           // return p;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.txtMain.OnTextChangedEx(e);
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                if(value!=Color.Transparent)
                    this.txtMain.BackColor = value;
            }
        }

        private Thread flashThread;

        private void txtMain_Enter(object sender, EventArgs e)
        {
            if (relativeLabel != null)
            {
                relativeLabel.ForeColor = Color.FromArgb(48, 48, 48);
            }

            this.picUnderLine.Visible = true;
            Console.WriteLine(this.Name + "-txtMain获取到焦点");
            if (flashThread != null)
            {
                try
                {
                    flashThread.Abort();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(this.Name + "-txtMain停止线程异常"+ex);
                }

            }
           
            flashThread = new Thread(new ThreadStart(FlashUnderLine));
            flashThread.IsBackground = true;
            flashThread.Start();
            Console.WriteLine(this.Name + "-txtMain开启线程闪烁");
           
            /*
            Console.WriteLine("txtMain获取焦点开始"+flashThread.ThreadState.ToString());
            if (flashThread.ThreadState == ThreadState.Unstarted)
            {
                Console.WriteLine("txtMain启动闪烁线程");
                flashThread.Start();
            }
            else if (flashThread.ThreadState == ThreadState.WaitSleepJoin )
            {
                flashThread.Interrupt();
                flashThread.Start();
            }
            else if (flashThread.ThreadState == ThreadState.Stopped)
            {
                flashThread.Abort();
                flashThread.Start();
            }
            Console.WriteLine("txtMain获取焦点完毕");
             * */
        }

        private void txtMain_Leave(object sender, EventArgs e)
        {
            if (relativeLabel != null)
            {
                relativeLabel.ForeColor = Color.FromArgb(121, 121, 121);
            }
            Console.WriteLine(this.Name+"-txtMain失去焦点开始" + flashThread.ThreadState.ToString());
            if (flashThread.ThreadState != ThreadState.StopRequested||flashThread.ThreadState!=ThreadState.Stopped)
            {
                flashThread.Abort();
                this.picUnderLine.Visible = false;
                Console.WriteLine("停止线程闪烁");
            }
            //Console.WriteLine("txtMain失去焦点完毕");
        }

        private void txtMain_TextChanged_1(object sender, EventArgs e)
        {

        }

        private Label relativeLabel;

        public Label RelativeLabel
        {
            get { return relativeLabel; }
            set {
                
                relativeLabel = value;
                if (relativeLabel != null)
                {
                    relativeLabel.ForeColor = Color.FromArgb(121, 121, 121);
                }

            
            }
        }

        private void txtMain_Click(object sender, EventArgs e)
        {

            if (this.txtMain.HasValue)
            {

                this.txtMain.SelectAll();
                this.txtMain.Select(this.txtMain.Text.Length, 0);
                this.txtMain.SelectionStart = this.txtMain.Text.Length;
               
                //this.txtMain.SelectionStart = this.txtMain.Text.Length;
                //this.txtMain.ScrollToCaret();
            }
            else
            {
                this.txtMain.SelectionStart = 0;
            }
        }

        
    }
}
