using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using FT.Commons.Tools;
using HiPiaoTerminal.CommonForm;
using FT.Windows.Controls.PanelEx;
using HiPiaoInterface;
using HiPiaoTerminal.Maintain;
//using HiPiaoTerminalWpf;
using HiPiaoTerminal.Account;
using HiPiaoTerminal.BuyTicket;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal
{
    /// <summary>
    /// 全局工具，界面跳转
    /// </summary>
    public class GlobalTools
    {
        private GlobalTools()
        {
        }

        private static VitualKeyBoardPanel allKeyBoard=new VitualKeyBoardPanel();

        public static void HideAllKeyBoard()
        {
            allKeyBoard.Visible = false;
        }

        public static void SetAllKeyBoard(TextBox txt)
        {
           
            allKeyBoard.InputTextBox = txt;
           
            Point point = txt.FindForm().PointToScreen(txt.Location);
            Console.WriteLine("转化屏幕的坐标是：X=" + point.X.ToString() + "=Y=" + point.Y.ToString());
            Form frm = allKeyBoard.FindForm();

            if (frm == null)
            {
               
                txt.FindForm().Controls.Add(allKeyBoard);
            }
            else
            {
                frm.Controls.Remove(allKeyBoard);
                txt.FindForm().Controls.Add(allKeyBoard);
            }

            Console.WriteLine("txt下划线的坐标是：X=" + txt.Location.X.ToString() + "=Y=" + txt.Location.Y.ToString()+"txt高度:"+txt.Height.ToString()+"键盘高度："+allKeyBoard.Height.ToString());
            Console.WriteLine("转化前键盘的坐标是：X=" + allKeyBoard.Location.X.ToString() + "=Y=" + allKeyBoard.Location.Y.ToString());
            if (point.Y > allKeyBoard.Height + txt.Height)
            {
                allKeyBoard.Location = new Point(point.X, point.Y - allKeyBoard.Height - txt.Height + 20);
            }
            else
            {
                allKeyBoard.Location = new Point(point.X, point.Y + txt.Height + 1);
            }
            allKeyBoard.BringToFront();
            Console.WriteLine("转化后键盘的坐标是：X=" + allKeyBoard.Location.X.ToString() + "=Y=" + allKeyBoard.Location.Y.ToString());
            allKeyBoard.Visible = true;
        }


        public static void SetAllKeyBoard2(TextBox txt)
        {

            allKeyBoard.InputTextBox = txt;
            Point point = txt.FindForm().PointToScreen(txt.Location);
            Form frm = allKeyBoard.FindForm();

            if (frm == null)
            {
                Console.WriteLine("");
                txt.FindForm().Controls.Add(allKeyBoard);
            }
            else
            {
                frm.Controls.Remove(allKeyBoard);
                txt.FindForm().Controls.Add(allKeyBoard);
            }

            if (point.Y > allKeyBoard.Height + txt.Height)
            {
                allKeyBoard.Location = new Point(point.X, point.Y - allKeyBoard.Height - txt.Height + 20);
            }
            else
            {
                allKeyBoard.Location = new Point(point.X, point.Y + txt.Height + 1);
            }
            allKeyBoard.Visible = true;
        }
        /*
        public static void PopFirstWpf(System.Windows.Controls.UserControl panel)
        {
            NotifyUserForm form = new NotifyUserForm(panel);
            
            form.ColorType = 2;
            form.ShowDialog();
            
        }
         * */

        public static void PopNetError()
        {
            GlobalTools.Pop("网络故障，请向影院工作人员垂询！", "或拨打400-601-556");
        }

        public static void Pop(string hint1)
        {
            MessageForm form = new MessageForm(hint1);
            form.ShowDialog();
        }

        public static void Pop(string hint1, string hint2)
        {
            MessageForm form = new MessageForm(hint1, hint2);
            form.ShowDialog();
        }

        public static void ChangePanel(Form frm,Control panel)
        {
            if (frm != null && panel != null)
            {
                frm.Controls.Clear();
                frm.Width = panel.Width;
                frm.Height = panel.Height;
                panel.Dock = DockStyle.Fill;
                frm.Controls.Add(panel);
            }
        }

        public static DialogResult Pop(Control panel)
        {
            ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<ConfigModel.SystemConfig>();
            if (config.UseMaskPanel)
            {
                return PopMask(panel);
            }
            else
            {
                return PopUnMask(panel);
            }
        }


        public static DialogResult PopMask(Control panel)
        {
            Form form = new NotifyUserForm(panel);


            return form.ShowDialog();
        }

        public static DialogResult PopUnMask(Control panel)
        {
           // /*
             
           Form form = new Form();
                
                form.FormBorderStyle = FormBorderStyle.None;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Width = panel.Width;
                form.Height = panel.Height;
                panel.Dock = DockStyle.Fill;
                //form.BackColor = Color.Red;
                //form.BackColor = Color.FromArgb(117, 117, 117);
                //form.Opacity = 0.6d;
                //form.TransparencyKey = Color.FromArgb(117, 117, 117);
                //form.BackgroundImage = TestResource.TestRegister;
                form.Controls.Add(panel);
               // form.FormClosing += new FormClosingEventHandler(form_FormClosing);
              return  form.ShowDialog();
            // */
           // Form form = new NotifyUserForm(panel);
            
            
           // return form.ShowDialog();

        }

        public static UserObject loginUser;

        public static void GoLoginPanel()
        {
            GlobalTools.GoPanel(new UserLoginPanel(0));
        }

        public static UserObject GetLoginUser()
        {
            if (loginUser == null)
            {
                GoLoginPanel();
                return null;
            }
            return loginUser;
        }
        /// <summary>
        /// 登陆账户
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        public static bool LoginAccount(string uid, string pwd)
        {
            UserObject obj=HiPiaoInterface.HiPiaoOperatorFactory.GetHiPiaoOperator().Login(uid, pwd);
            if (obj != null)
            {
                loginUser = obj;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 退出账户
        /// </summary>
        public static bool QuitAccount()
        {
            loginUser = null;
            GlobalTools.ReturnMain();
            return true;
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        public static bool QueryAccount()
        {

            GlobalTools.ReturnUserAccout();
            return true;
        }

        private static Timer UpdateTimer;

        private static Timer UnOperationTimer;

        private static Timer AutoCloseComputerTimer;

        public static void InitAll(Form form)
        {
            RefreshMovieShowList();
            UpdateTimer = new Timer();
            UpdateTimer.Interval = 60000*5;
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Start();
            UnOperationTimer = new Timer();
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            UnOperationTimer.Interval = config.UnOperationTime*1000;
            UnOperationTimer.Tick += new EventHandler(UnOperationTimer_Tick);
            UnOperationTimer.Start();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            MainForm = form;
        }

        static void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Stop();
            }
            if (UnOperationTimer != null)
            {
                UnOperationTimer.Stop();
            }
        }

        public static int UnOperationLeaveSecond = 30;
        private static int UnOperationMaxSecond = 30;

        public static void ResetUnOperationTime()
        {
            UnOperationLeaveSecond = UnOperationMaxSecond;
        }

        //主操作窗体，所有控件创建和销毁都在被窗体内
        private static Form MainForm;

        private static UpdateUnOperationTimeDelegate UpdateUnOperationTime;

        public static void RegistUpdateUnOperationTime(UpdateUnOperationTimeDelegate updateDelegate)
        {
            UpdateUnOperationTime = updateDelegate;
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]

        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);



        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);



        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]

        private static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);

        const int GWL_EXSTYLE = -20;

        const int WS_EX_TRANSPARENT = 0x20;

        const int WS_EX_LAYERED = 0x80000;

        const int LWA_ALPHA = 2;

        //弹出提示窗体时候的遮罩
        public static void Mask(Form form)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.Yellow;
            panel.TabIndex = 2999;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Transparent;
            
           // panel.BackColor = Color.FromArgb(65, 204, 212, 230);
            panel.BackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255); 
            
            form.Controls.Add(panel);
            panel.BringToFront();
            //SetWindowLong(form.Handle, GWL_EXSTYLE, GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

           // SetLayeredWindowAttributes(form.Handle, 0, 128, LWA_ALPHA);
        }

        //关闭提示窗体时候的遮罩
        public static void UnMask(Form form)
        {
            form.Controls.RemoveAt(0);
            //SetWindowLong(form.Handle, GWL_EXSTYLE, GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

           // SetLayeredWindowAttributes(form.Handle, 0, 128, LWA_ALPHA);
        }

        
        //未操作时候返回主界面
        static void UnOperationTimer_Tick(object sender, EventArgs e)
        {
            if (MainForm.Controls.Count > 0)
            {
                MainPanel panel = MainForm.Controls[0] as MainPanel;
                if (panel != null)
                {
                    UnOperationLeaveSecond = UnOperationMaxSecond;
                    UpdateUnOperationTime = null;
                    UnOperationTimer.Stop();
                }
                else
                {
                    UnOperationLeaveSecond--;
                    if (UpdateUnOperationTime != null)
                    {
                        UpdateUnOperationTime();
                    }
                    if (UnOperationLeaveSecond == 0)
                    {
                        ReturnMain();

                    }
                }
            }
            
        }
        /// <summary>
        /// 停止未操作计数
        /// </summary>
        public static void StopUnOperationCounter()
        {

            UnOperationTimer.Stop();
            UnOperationLeaveSecond = UnOperationMaxSecond;
        }
        /// <summary>
        /// 开始未操作计数
        /// </summary>
        public static void StartUnOperationCounter()
        {
            
            UnOperationLeaveSecond = UnOperationMaxSecond;
            UnOperationTimer.Start();
        }

        static void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTimer.Stop();
            //DoSomeThing
            UpdateMovieShows();

            UpdateTimer.Start();
        }
        public static List<MovieObject> MovieShowList = new List<MovieObject>();

        private static readonly object synObj = new object();

        /// <summary>
        /// 定时更新影片显示内容。内容见于下载到MovieShows目录下
        /// </summary>
        public static void UpdateMovieShows()
        {
            //download new adshows
            RefreshMovieShowList();
        }

        /// <summary>
        /// 定时刷新影片显示内容
        /// </summary>
        public static void RefreshMovieShowList()
        {
            lock (synObj)
            {
                MovieShowList.Clear();
                DirectoryInfo dir = new DirectoryInfo("MovieShows");
                if (dir != null)
                {
                    FileInfo[] files = dir.GetFiles();
                    MovieObject movie = null;
                    Image img=null;
                    for (int i = 0; i < files.Length; i++)
                    {
                        img = Image.FromFile(files[i].FullName);
                        movie = new MovieObject();
                        movie.AdImage = (Image)img.Clone();
                        movie.Name = files[i].Name;
                        MovieShowList.Add(movie);
                    }
                }
            }
            //FileInfo

        }

        /// <summary>
        /// 初始化所有的控件操作，只要有操作就认为重算未操作时间
        /// </summary>
        /// <param name="ctr"></param>
        public static void InitUnOperationControl(Control ctr)
        {
            if (ctr.Controls.Count == 0)
            {
                if (ctr is Button || ctr is PictureBox)
                {
                    ctr.Click += new EventHandler(ctr_Click);
                    ctr.Enter += new EventHandler(ctr_Click);
                    ctr.Leave += new EventHandler(ctr_Click);
                }
                
            }
            foreach (Control tmp in ctr.Controls)
            {
                InitUnOperationControl(tmp);
            }
        }

        

        //private static

        public static void ShowInput(TextBox txt)
        {
            //.ShowToTextBox(txt);
             VitualKeyBoardPanel panel=new VitualKeyBoardPanel();
             panel.InputTextBox = txt;
            Form form = new Form();
           // Form formBorder = new Form();
           // formBorder.Paint += new PaintEventHandler(formBorder_Paint);
            //form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.FormBorderStyle = FormBorderStyle.None;
            panel.Paint += new PaintEventHandler(formBorder_Paint);
            form.Width = panel.Width;
            form.Height = panel.Height;
            panel.Dock = DockStyle.Fill;
            form.Controls.Add(panel);
            Point point=txt.FindForm().PointToScreen(txt.Location);
            form.StartPosition = FormStartPosition.Manual;
            if (point.Y > panel.Height+txt.Height)
            {
                form.Location = new Point(point.X, point.Y -panel.Height- txt.Height+20);
            }
            else
            {
                form.Location = new Point(point.X, point.Y + txt.Height+1);
            }
            
            //txt.Text = point.X.ToString() + "-" + point.Y.ToString()+"-"+txt.Height;
            //form.StartPosition = FormStartPosition.CenterParent;
            // form.Paint += new PaintEventHandler(form_Paint);
            // MainForm.BackColor = Color.Blue;
            form.ShowDialog();
        }

        static void formBorder_Paint(object sender, PaintEventArgs e)
        {
            Control frm = sender as Control;
            Color color = Color.OrangeRed;// Color.LightSeaGreen
            int width=1;
            ControlPaint.DrawBorder(e.Graphics,
                                frm.ClientRectangle,
                                color,//7f9db9
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid,
                                color,
                                width,
                                ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// 仅仅显示提示信息，并点击确定的时候可设置是否返回操作首页
        /// </summary>
        /// <param name="text"></param>
        /// <param name="returnHome"></param>
        public static void ShowMessage(string text, bool returnHome)
        {
            /*
            NotifyUserInfoPanel ctr = new NotifyUserInfoPanel(text);
            ctr.ReturnHome = returnHome;
            ShowMessage(ctr);
             */
            MessageForm form = new MessageForm(text);
            form.ReturnHome = returnHome;
            form.ShowDialog();
        }
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="panel"></param>
        public static void ShowMessage(Control panel)
        {
            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.Width = panel.Width;
            form.Height = panel.Height;
            panel.Dock = DockStyle.Fill;
            form.Controls.Add(panel);
            form.StartPosition = FormStartPosition.CenterParent;
           // form.Paint += new PaintEventHandler(form_Paint);
           // MainForm.BackColor = Color.Blue;
            form.Load += new EventHandler(form_Load);
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
            form.ShowDialog();
        }

        static void form_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PaintRound(sender);
        }

        static void form_Load(object sender, EventArgs e)
        {
           // Mask(MainForm);
            StopUnOperationCounter();
            
        }

        static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
           // MainForm.BackColor = SystemColors.Control;
           // UnMask(MainForm);
            StartUnOperationCounter();
        }

        static void ctr_Click(object sender, EventArgs e)
        {
            ResetUnOperationTime();
        }

        /// <summary>
        /// 返回主界面
        /// </summary>
        public static void GoPanel(Control panel)
        {
            if (MainForm != null)
            {
                Control parent = MainForm;
                parent.Controls.Clear();
                parent.Controls.Add(panel);
                if (panel is MainPanel)
                {
                    StopUnOperationCounter();
                }
                else
                {
                    ResetUnOperationTime();
                    StopUnOperationCounter();
                    StartUnOperationCounter();
                    InitUnOperationControl(parent.Controls[0]);
                }
            }

        }

       
        /// <summary>
        /// 返回主界面
        /// </summary>
        public static void ReturnMain()
        {
            GoPanel(new MainPanel());  
        }
        /// <summary>
        /// 快速购票
        /// </summary>

        public static void QuickBuyTicket()
        {
            GoPanel(new MovieSelectorPanel());       
            //InitUnOperationControl(parent.Controls[0]);   
        }

        public static bool Confirm(string str)
        {
            ConfirmForm form = new ConfirmForm(str);
            return form.ShowDialog()==DialogResult.OK;
        }

        public static void ReturnMaintainWithPwd()
        {
            /*
            if (DialogResult.OK == Pop(new UnLockPanel()))
            {
                ReturnMaintain();
            }
             * */
            GoPanel(new ManagerLoginWithPwdPanel());
        }

        /// <summary>
        /// 用户跳转到维护界面
        /// </summary>
        public static void ReturnMaintain()
        {
            GoPanel(new ManagerFunctionsPanel());
        }

        /// <summary>
        /// 用户快速注册
        /// </summary>
        public static void QuickRegister()
        {
            GoPanel(new QuickRegisterPanel());
        }

        /// <summary>
        /// 影票打印
        /// </summary>
        public static void ReturnTicketPrint()
        {
            GoPanel(new TicketPrintPanel());
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public static void UserLogin()
        {
            GoPanel(new UserLoginPanel(0));   
        }

       
        /// <summary>
        /// 哈票网体验
        /// </summary>
        public static void UserTaste()
        {
            GoPanel(new UserTastePanel());
        }



        /// <summary>
        /// 用户账户
        /// </summary>
        public static void ReturnUserAccout()
        {
            GlobalTools.LoginAccount("", "");
            GlobalTools.GetLoginUser();
            GoPanel(new MyAccountPanel());
        }


        




        public static void ToManagePanel()
        {

        }
    }

    /// <summary>
    /// 未操作时候的委托
    /// </summary>
    public delegate void UpdateUnOperationTimeDelegate();
}
