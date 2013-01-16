using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using FT.Commons.Win32;
using HiPiaoTerminal.ConfigModel;
using FT.Commons.Tools;

namespace HiPiaoTerminal.UserControlEx
{

    public partial class UserInputPanel : UserControl
    {
        public UserInputPanel()
        {
            InitializeComponent();
            //this.txtMain.Enabled = false;
            this.txtMain.TextChanged += new EventHandler(txtMain_TextChanged);
            this.txtMain.MouseDown += new MouseEventHandler(txtMain_MouseDown);
            this.txtMain.GotFocus += new EventHandler(txtMain_GotFocus);
            this.Click += new EventHandler(UserInputPanel_Click);
            this.txtMain.Click += new EventHandler(UserInputPanel_Click);
            CheckForIllegalCrossThreadCalls = false;
           // this.txtMain.TextChanged+=new EventHandler(txtMain_TextChanged);

           // this.txtMain.Enabled = false;
           // this.txtMain.KeyDown += new KeyEventHandler(txtMain_KeyDown);
            this.txtMain.KeyPress += new KeyPressEventHandler(txtMain_KeyPress);
           // this.txtMain.TabStop = false;
          //  HideCaret(this.txtMain.Handle);
           
           
        }

        void txtMain_GotFocus(object sender, EventArgs e)
        {
#if DEBUG 
            Console.WriteLine("TxtMain获取到焦点,隐藏插入标记");
#endif
            HideCaret(this.txtMain.Handle);

        }

      

        void UserInputPanel_Click(object sender, EventArgs e)
        {
           // this.txtMain.Focus();
           // HideCaret(this.txtMain.Handle);
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.AllowNumberKeyboard&&this.keyboardType!=7)
            {
                this.keyboardType = 1;
            }

            if (config.UseVirtualKeyboard)
            {
#if DEBUG
                Console.WriteLine("用户单击了按钮" + this.Name);
#endif
                GlobalTools.HideAllKeyBoard();
              
                if (this.keyboardType == 1)
                {

                    GlobalTools.SetAllKeyBoardWithForm(this.txtMain, keyboardType);
                }
                else if (this.keyboardType == 2)
                {
                    GlobalTools.SetAllKeyBoardWithForm(this.txtMain, keyboardType);
                }
            }
             
        }

        public override bool Focused
        {
            get
            {
                return this.txtMain.Focused;
            }
        }

        private AllowInputEnum allowInputType=AllowInputEnum.AllowAll;

        public AllowInputEnum AllowInputType
        {
            get { return allowInputType; }
            set { allowInputType = value; }
        }

        public delegate void OnSubTextChanged();//定义委托
        public event OnSubTextChanged onSubTextChanged;//定义事件

        void txtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
#if DEBUG
            Console.WriteLine("用户输入的keychar为"+e.KeyChar);
            string tttt = e.KeyChar.ToString();
#endif
            //
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
           if (e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 13 || e.KeyChar == 32)
            {
                e.Handled = true;
            }
         
            else if (this.allowInputType == AllowInputEnum.LargeLetter)
            {
               
                    if ((90 >= e.KeyChar && e.KeyChar >= 65))
                    {

                    }
                    else
                    {
                        e.Handled = true;
                    }
            }
            else if (this.allowInputType == AllowInputEnum.LargeLetterAndNumber)
            {
                if ((57 >= e.KeyChar && e.KeyChar >= 48) || (90 >= e.KeyChar && e.KeyChar >= 65))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (this.allowInputType == AllowInputEnum.Number)
            {
                if ((57 >= e.KeyChar && e.KeyChar >= 48))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (this.allowInputType == AllowInputEnum.SmallLetter)
            {
                if ((122 >= e.KeyChar & e.KeyChar >= 97))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (this.allowInputType == AllowInputEnum.SmallLetterAndNumber)
            {
                if ((57 >= e.KeyChar && e.KeyChar >= 48) || (122 >= e.KeyChar & e.KeyChar >= 97))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
            }
        }

        void txtMain_KeyDown(object sender, KeyEventArgs e)
        {
           
           
            /*
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
             */
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
            if (this.IsDeleted && this.txtMain.HasValue)
            {
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
            }
            if (this.txtMain.HasValue&&this.onSubTextChanged != null)
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

        public int MaxInputLength
        {
            get
            {
                return this.txtMain.MaxLength; ;
            }
            set
            {
                this.txtMain.MaxLength = value;
            }
        }

        private bool isActive = false;

        private Image SetBackImage(Image image)
        {
            if (this.BackColor != SystemColors.Window)
            {
                return ImageHelper.SetImageColorAll(image, Color.White, this.BackColor, 0);
            }
            else
            {
                return image;
            }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value;
            if (!value)
            {
                
                this.panelLeftTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Top_NotActive);
                this.panelLeftCenterBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Center_NotActive);
                this.panelLeftBottonBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Bottom_NotActive);

                this.panelMainTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_MainTop_NotActive);
                this.panelMainBottomBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_MainBottom_NotActive);

                this.panelRightTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Top_NotActive);
                this.panelRightBottonBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Bottom_NotActive);
                this.panelRightCenterBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Center_NotActive);
                if (this.txtMain.Text.Length > 0)
                {
                    this.btnDelete.Visible = false;
                }
            }
            else
            {
                this.panelLeftTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Top_Active);
                this.panelLeftCenterBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Center_Active);
                this.panelLeftBottonBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Left_Bottom_Active);

                this.panelMainTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_MainTop_Active);
                this.panelMainBottomBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_MainBottom_Active);

                this.panelRightTopBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Top_Active);
                this.panelRightBottonBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Bottom_Active);
                this.panelRightCenterBorder.BackgroundImage = this.SetBackImage(Properties.Resources.UserInput_Right_Center_Active);
                if (this.txtMain.Text.Length > 0)
                {
                    this.btnDelete.Visible = true;
                }
            }
            
            
            }
        }

        

        public new void Focus()
        {

           // HideCaret(this.txtMain.Handle);
           // this.txtMain.Focus();
           // this.IsActive = true;
           // txtMain_Click(null,null);
           // txtMain_Enter(null, null);
            this.txtMain.Focus();
          //  HideCaret(this.txtMain.Handle);
            
            
        }

        private int keyboardType = 1;

        /// <summary>
        /// 键盘的类型，1为窗体全键盘，2为窗体数字键盘，3为控件全键盘，4为控件数字键盘
        /// </summary>
        public int KeyboardType
        {
            get { return keyboardType; }
            set { keyboardType = value; }
        }


        public void UnFocus()
        {
            //this.IsActive = false;
            this.User_Leave(null, null);
          //  HideCaret(this.txtMain.Handle);
            
            //this.txtMain.FindForm().Focus();
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
                
                if (value == string.Empty)
                {
                    if (!this.txtMain.Focused)
                    {
                        this.txtMain.UnFocus();
                    }
                }
                else if (this.txtMain.Hint != value)
                {
                    this.txtMain.ForeColor = Color.Black;
                }
            }
            
        }

        private void UserInputPanel_Enter(object sender, EventArgs e)
        {
          //  HideCaret(this.txtMain.Handle);
#if DEBUG
            Console.WriteLine("userinputpanel获取焦点"+this.Name);
#endif
            if (this.Parent != null)
            {
#if DEBUG
                Console.WriteLine(this.Name+"的parent为"+this.Parent.Name+"findform="+this.FindForm());
#endif
            }
            if (this.FindForm() != null&&this.Parent!=null)
            {
#if DEBUG
                Console.WriteLine("输入框属于窗体");
#endif
                this.Focus();
            }
            else
            {
#if DEBUG
                Console.WriteLine("输入框不属于窗体了");
#endif
            }
            
            
        }

        private void UserInputPanel_Leave(object sender, EventArgs e)
        {
            if (this.FindForm() != null)
            {
#if DEBUG
                Console.WriteLine("userinputpanel失去焦点" + this.Name);
#endif
                this.UnFocus();
            }
            else
            {
#if DEBUG
                Console.WriteLine("输入框不属于窗体了");
#endif
            }
        }

        private void UserInputPanel_Resize(object sender, EventArgs e)
        {

            this.ResizeCompute();

        }
        /*
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Cursor.Current = Cursors.Default;
                // Cursor.Show();
                SendKeys.Send("{TAB}");
                //this.Close();
                //return false;
            }
            return false;
        }
*/

        private bool isDeleted = false;

        /// <summary>
        /// 是否允许内部删除按钮
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        private void ResizeCompute()
        {

            int borderLen = 14;
            int centerHeight=this.Height-2*borderLen;
            int centerWidth=this.Width-2*borderLen;
            this.panelRightTopBorder.Size = this.panelRightBottonBorder.Size = this.panelLeftTopBorder.Size
                = this.panelLeftBottonBorder.Size = new Size(borderLen, borderLen);
            this.panelLeftTopBorder.Location = new Point(0, 0);
            this.panelLeftCenterBorder.Location = new Point(0, borderLen);
            this.panelLeftCenterBorder.Size=new Size(borderLen,centerHeight);
            this.panelLeftBottonBorder.Location = new Point(0,centerHeight + borderLen);

            this.panelMainTopBorder.Location = new Point(borderLen, 0);
            this.panelMainTopBorder.Size = new Size(centerWidth, borderLen);
            this.panelCenter.Location = new Point(borderLen, borderLen);
            this.panelCenter.Size = new Size(centerWidth, centerHeight);
            this.panelMainBottomBorder.Location = new Point(borderLen, centerHeight + borderLen);
            this.panelMainBottomBorder.Size = new Size(centerWidth, borderLen);

            this.panelRightTopBorder.Location = new Point(centerWidth + borderLen, 0);
            this.panelRightCenterBorder.Location = new Point(centerWidth + borderLen, borderLen);
            this.panelRightCenterBorder.Size = new Size(borderLen, centerHeight);
            this.panelRightBottonBorder.Location = new Point(centerWidth+borderLen, centerHeight + borderLen);

            this.txtMain.Location = new Point(0, 0);
            this.txtMain.Height = centerHeight;
            FT.Commons.Tools.WinFormHelper.CenterVer(this.txtMain);

            
            this.picUnderLine.Location = new Point(0, this.panelCenter.Height-3);
           // this.txtMain.Width = this.Size.Width - 2 * this.panelLeftTopBorder.Width - 5;
          //  this.picUnderLine.Location = new Point(0, this.txtMain.Height + 2+this.txtMain.Location.Y);
            if (this.IsDeleted)
            {
                if (this.Height < 100)
                {
                    this.btnDelete.Size = new Size(49, 45);
                }
                else
                {
                    this.btnDelete.Size = new Size(98, 90);
                }
                this.btnDelete.Location = new Point(this.Width - borderLen - this.btnDelete.Width, 2);
                this.btnDelete.BringToFront();
                FT.Commons.Tools.WinFormHelper.CenterVer(this.btnDelete);
                this.txtMain.Width = centerWidth-this.btnDelete.Width;
            }
            else
            {
                this.btnDelete.Visible = false;
                this.txtMain.Width = centerWidth;
            }
            
        }

        private void FlashUnderLine()
        {
            //Console.WriteLine("开始执行线程");
            while (true)
            {
#if DEBUG
                //Console.WriteLine("隐藏光标显示");
#endif
              //  this.txtMain.TabStop = false;
               // HideCaret(this.txtMain.Handle);
               // HideCaret(this.txtMain.Handle);
               // HideCaret(this.txtMain.Handle);
               // HideCaret(this.txtMain.Handle);
                
                try
                {
                    //Graphics gc = this.txtMain.CreateGraphics();
                    if (this.FindForm()==null||this.Parent == null||this.Visible==false)
                    {
                        break;
                    }
                    Graphics gc = this.CreateGraphics();
                    int x = 0;

                    string txt=this.txtMain.GetRealText();
#if DEBUG
                    Form obj = this.FindForm();
                    string name111 = obj.Name;
                    Control ctr = this.Parent;
                    bool ttt=this.Visible;
                    Console.WriteLine("转化前下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString()+"文字内容为："+txt);
#endif
                    if (this.PasswordChar == '*')
                    {
                        if(txt.Length>0)
                        {

                            int wd = (int)gc.MeasureString(new string('*',txt.Length), txtMain.Font).Width;
                            x += wd-10;
                        }
                        
                    }
                    else if (this.txtMain.GetRealText().Length > 0)
                    {
                        
                        x += (int)gc.MeasureString(this.txtMain.GetRealText(), txtMain.Font).Width-10;
                    }
                    else
                    {

                    }
                    this.picUnderLine.Location = new Point(x, this.picUnderLine.Location.Y);
#if DEBUG

                   // Console.WriteLine("FlashUnderLine中隐藏插入标记" + "文字内容为：" + txt);
#endif
                  //  HideCaret(this.txtMain.Handle);

//                    if (maskLabel == null)
//                    {
//                        maskLabel = new Label();
//                        maskLabel.AutoSize = false;
//                        maskLabel.Text = " ";
//                        maskLabel.Height = this.txtMain.Height - 2;
//                        maskLabel.Width = 3;
//                        maskLabel.BackColor = Color.Red;
//                        FT.Commons.Win32.WindowFormDelegate.AddControlTo(this.panelCenter, maskLabel);
//                        //this.panelCenter.Controls.Add(maskLabel);
                        
//                    }
//                    else
//                    {
//                        maskLabel.BringToFront();
//                        //Point pMouse=Control.MousePosition;
//                       // int from = 0;
//                       // if (this.txtMain.Text.Length > 0)
//                       // {
//                            //from = this.txtMain.Text.Length ;
//                       // }
//                        Point pMouse = txtMain.GetPositionFromCharIndex(this.txtMain.GetRealText().Length-1); 
//                        Point pClient=this.txtMain.PointToClient(pMouse);
//                        int maskX = (int)gc.MeasureString(this.txtMain.GetRealText(), txtMain.Font).Width;
//#if DEBUG
//                        Console.WriteLine("maskX坐标为:" + maskX);
//                        Console.WriteLine("光标屏幕坐标为:" + pMouse.X + "  Y=" + pMouse.Y);
//                        Console.WriteLine("转换光标坐标为:" + pClient.X + "  Y=" + pClient.Y);
//#endif
//                        //maskLabel.lo
//                        maskLabel.Location = new Point(maskX-10, this.picUnderLine.Location.Y - this.maskLabel.Height - 8);
//                    }




                    /*
#if DEBUG
                    if (this.picUnderLine.Parent != null)
                    {
                        Console.WriteLine("下划线的容器长宽为：长=" + this.panelCenter.Width.ToString() + "=高=" + this.panelCenter.Height.ToString());
                        Console.WriteLine("输入框长宽为：长=" + this.txtMain.Width.ToString() + "=高=" + this.txtMain.Height.ToString());
                    }
                    Console.WriteLine("转化后下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString());
#endif
                     */
                    this.picUnderLine.Visible = !this.picUnderLine.Visible;
                    gc.Dispose();
                    System.Threading.Thread.Sleep(500);
                   
                }
      /*          
                try
                {
                    Graphics gc = this.txtMain.CreateGraphics();
                    
                    int wd = (int)gc.MeasureString("x", txtMain.Font).Width;
                    if (this.PasswordChar == '*')
                    {
                        wd = (int)gc.MeasureString("*", txtMain.Font).Width;
                    }

                    int ht = (int)gc.MeasureString("x", txtMain.Font).Height;
#if DEBUG
                    Console.WriteLine("获取的字体的宽度为：" + wd + "高度为" + ht);
#endif
                    int begin = 0;
                    Point p2=this.txtMain.Location;
                   // bool result = (bool)WindowFormDelegate.GetControlProperty(this.txtMain, "HasValue");
                    if (this.txtMain.GetRealText().Length>0)
                    {
                        begin = txtMain.Text.Length-1;
                        if (begin == 0)
                        {
                            begin = 1;
                        }
                        p2 = txtMain.GetPositionFromCharIndex(begin);
#if DEBUG
                        Console.WriteLine("有字符长度存在P2为：X=" + p2.X.ToString() + "=Y=" + p2.Y.ToString());
#endif
                    }
                    else
                    {
#if DEBUG
                        Console.WriteLine("由于没有字符长度存在P2为：X=" + p2.X.ToString() + "=Y=" + p2.Y.ToString());
#endif
                        begin = 0;
                        p2 = new Point(this.txtMain.Location.X, this.txtMain.Location.Y);
                    }
                     
                    //Point p = txtMain.Location;
                    // p.X += p.X +wd;
                    // p.Y += p.Y;
#if DEBUG
                    Console.WriteLine("转化前下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString());
#endif
                    if (begin != 0)
                    {
                        this.picUnderLine.Location = new Point(p2.X + wd, this.picUnderLine.Location.Y);
                    }
                    else
                    {
                        this.picUnderLine.Location = new Point(5, this.picUnderLine.Location.Y);
                    }

                    
                    //this.picUnderLine.Width = wd;
#if DEBUG
                    if (this.picUnderLine.Parent != null)
                    {
                        Console.WriteLine("下划线的容器长宽为：长=" + this.panelCenter.Width.ToString() + "=高=" + this.panelCenter.Height.ToString());
                        Console.WriteLine("输入框长宽为：长=" + this.txtMain.Width.ToString() + "=高=" + this.txtMain.Height.ToString());
                    }
                    Console.WriteLine("转化后下划线的坐标是：X=" + this.picUnderLine.Location.X.ToString() + "=Y=" + this.picUnderLine.Location.Y.ToString());
#endif
                    this.picUnderLine.Visible = !this.picUnderLine.Visible;
                    System.Threading.Thread.Sleep(500);
                }
       * */
                catch(Exception ex)
                {
#if DEBUG
                    Console.WriteLine("thread-exception===>"+ex.ToString());
#endif
                    return;
                }
            }
           // return p;
        }

        private Label maskLabel;

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
            if (this.FindForm() != null)
            {
                
                this.IsActive = true;
                txtMain_Click(null, null);
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                if (config.UseVirtualKeyboard)
                {
#if DEBUG
                    Console.WriteLine("用户定焦了输入框" + this.Name);
#endif
                    GlobalTools.HideAllKeyBoard();
                    if (this.keyboardType == 1)
                    {
                        GlobalTools.SetAllKeyBoardWithForm(this.txtMain, keyboardType);
                    }
                    else if (this.keyboardType == 2)
                    {
                        GlobalTools.SetAllKeyBoardWithForm(this.txtMain, keyboardType);
                    }
                }
                else
                {

                }

                if (relativeLabel != null)
                {
                    relativeLabel.ForeColor = Color.FromArgb(48, 48, 48);
                }

                this.picUnderLine.Visible = true;
#if DEBUG
                Console.WriteLine(this.Name + "-txtMain获取到焦点");
#endif
                if (flashThread != null)
                {
                    try
                    {
                        flashThread.Abort();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(this.Name + "-txtMain停止线程异常" + ex);
                    }

                }

                flashThread = new Thread(new ThreadStart(FlashUnderLine));
                flashThread.IsBackground = true;
                flashThread.Start();
#if DEBUG
                Console.WriteLine(this.Name + "-txtMain开启线程闪烁");
#endif
            }
            else
            {
#if DEBUG
                Console.WriteLine("TxtMain-Enter:控件不属于窗体了");
#endif
            }
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

        private void User_Leave(object sender, EventArgs e)
        {
            this.IsActive = false;
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseVirtualKeyboard)
            {
#if DEBUG
                Console.WriteLine("TxtMain-Leave开始隐藏小键盘");
#endif
                GlobalTools.HideAllKeyBoard();
            }
            else
            {

            }
            if (relativeLabel != null)
            {
                relativeLabel.ForeColor = Color.FromArgb(121, 121, 121);
            }
            if (flashThread != null)
            {
#if DEBUG
                Console.WriteLine(this.Name + "-txtMain失去焦点开始" + flashThread.ThreadState.ToString());
#endif
                if (flashThread.ThreadState != ThreadState.StopRequested || flashThread.ThreadState != ThreadState.Stopped)
                {
                    flashThread.Abort();
                    this.picUnderLine.Visible = false;
#if DEBUG
                    Console.WriteLine("停止线程闪烁");
#endif
                }
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
          //  HideCaret(this.txtMain.Handle);
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

        private void UserInputPanel_Load(object sender, EventArgs e)
        {
            this.ResizeCompute();
            
        }

        private void panelCenter_Resize(object sender, EventArgs e)
        {

        }

        private void panelMainTopBorder_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panelMainBottomBorder_Enter(object sender, EventArgs e)
        {
            //this.Focus();
        }

        private void panelMainBottomBorder_Leave(object sender, EventArgs e)
        {
            //this.UnFocus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.txtMain.Text = string.Empty;
            if (this.onSubTextChanged != null)
            {
                this.onSubTextChanged();
            }
        }

        private void txtMain_MouseDown_1(object sender, MouseEventArgs e)
        {
            //HideCaret(this.txtMain.Handle);
        }

        
    }
}
