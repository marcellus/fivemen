using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using HiPiaoTerminal.Account;
using HiPiaoTerminal.UserRegister;
using HiPiaoTerminal.CommonForm;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.Maintain;
using HiPiaoTerminal.TestForm;
using HiPiaoTerminal.BuyTicket;
using HiPiaoInterface;
using HiPiaoTerminal.ConfigModel;
using System.IO.Ports;
using FT.Device.Rfid;

namespace HiPiaoTerminal
{
    public partial class MainPanel : SameBackgroudParentPanel
    {

        public MainPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);
            //timerShowMovie.Start();
            Console.WriteLine("MainPanel_Load开始隐藏小键盘");
            GlobalTools.HideAllKeyBoard();
            GlobalTools.RegistUpdateUnOperationTime(null);
            GlobalTools.StopUnOperationCounter();
            if (GlobalTools.loginUser == null)
            {
                this.lbWelcome1.Visible = false;
                this.lbWelcomeName.Visible = false;
                this.lbWelcome3.Visible = false;
                this.btnQuit.Visible = false;
                this.panelFlashCardHint.Visible = true;
                this.panelFlashCardHint.BringToFront();
                this.timerReadCard.Start();
                
            }
            else
            {
                this.panelFlashCardHint.Visible = false;
                this.timerReadCard.Stop();
               // this.panelFlashCardHint.BringToFront();
                this.lbWelcome1.Visible = true;
                this.lbWelcomeName.Visible = true;
                this.lbWelcomeName.Text = GlobalTools.loginUser.Name;
                this.lbWelcome3.Visible = true;
                this.btnQuit.Visible = true;
                this.lbWelcomeName.Location = new Point(this.lbWelcome3.Location.X - this.lbWelcomeName.Width, this.lbWelcome3.Location.Y);
                this.lbWelcome1.Location = new Point(this.lbWelcomeName.Location.X - this.lbWelcome1.Width,this.lbWelcome3.Location.Y);
                //FT.Commons.Tools.WinFormHelper.LocationAfter(this.lbWelcomeName, this.lbWelcome3);
            }
            GlobalTools.CloseAllPopForms();
	    try
            {
            	if (this.DesignMode)
            	{
                	Cursor = Cursors.Default;
            	}
            	else
                	GlobalTools.SetCursor();

	    }
	    catch(Exception ex)
	    {
	    }
                 
        }

        private void btnLoginPassport_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.ReturnUserAccout();
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            if (GlobalTools.loginUser == null)
            {
                GlobalTools.GoPanel(new UserLoginPanel(1));
            }
            else
            GlobalTools.QuickBuyTicket();
        }

        private void btnTicketPrint_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.ReturnTicketPrint();
        }

        private void btnQuickRegister_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.QuickRegister();
        }

        private void btnUserTaste_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.UserTaste();
        }

        private void timerShowMovie_Tick(object sender, EventArgs e)
        {
            /*
            //timerShowMovie.Stop();
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            List<AdvertisementObject> lists=HiPiaoCache.GetAdvertisement(config.Cinema);
            int len = lists.Count;
            if (len == 0)
            {
                
                return;
            }
            if (this.picShowMovies.Tag == null || this.picShowMovies.Tag.ToString() == (len - 1).ToString())
            {
                this.picShowMovies.Image = lists[0].AdvPic;
                this.picShowMovies.Tag = "0";
            }
            else
            {
                int currentIndex = Convert.ToInt32(this.picShowMovies.Tag.ToString());
                int nowIndex = currentIndex + 1;
                this.picShowMovies.Image = lists[nowIndex].AdvPic; 
                this.picShowMovies.Tag = nowIndex.ToString();
            }

            timerShowMovie.Start();
            */
        }

        

        private void MainPanel_Load(object sender, EventArgs e)
        {
           // ControlPaint.DrawButton(Graphics.FromHwnd(this.btnTicketPrint.Handle),
             //   new Rectangle(10, 10, btnTicketPrint.Width - 10, btnTicketPrint.Height - 10),
            //    ButtonState.Pushed);


          
            if(!adFullTimer.Enabled)
            {
                  SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                  if (config.AllowFullScreen&&config.FullScreenSecond > 0)
                  {
                      adFullTimer.Interval = config.FullScreenSecond * 1000;
                      adFullTimer.Stop();
                      adFullTimer.Start();
                  }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GlobalTools.Pop(new UserRegisterSuccessPanel());
            //0109990101  0100407983 0102500008
            //0102500005 cs0002
         /*   if (GlobalTools.LoginAccount("0102500005"))
            {
                string name = GlobalTools.GetLoginUser().Name;

                this.QuitReadCard();
                GlobalTools.ReturnUserAccout();
            }
          * */
           // GlobalTools.LoginAccount("0102500005");
          //  GlobalTools.Pop(new BindMobilePanel());

            //GlobalTools.ReturnMaintain();
            //GlobalTools.ShowMessage(new QuickPassportPanel());
           // GlobalTools.ShowMessage("网络故障，请向影院工作人员垂询！\r\n或拨打400-601-556！", true);
           // Account.ConfirmQuitAccountForm form = new HiPiaoTerminal.Account.ConfirmQuitAccountForm();
            //Form form =null;
           // form= new UIdOrPwdErrorForm();
            //form = new RegisterSuccessForm();
            //form = new NotifyUserForm();
            //form.Show();
            //GlobalTools.Pop(new UserRegisterSuccessPanel2());
            //GlobalTools.ReturnMaintainWithPwd();
            //GlobalTools.GoPanel(new ManagerModifyPwdPanel());
            //GlobalTools.Pop(new UserControl1());
           // Form frm = new RoundForm();
           // frm.ShowDialog();
            //GlobalTools.PopFirstWpf(new UserRegisterSuccessWpf());

           // GlobalTools.Pop(new UserNeedKnowInfoPanel());
           // GlobalTools.Pop(new UserNeedKnowInfoPanel());
           // GlobalTools.PopNetError();
          //  GlobalTools.Pop(new ConfirmPayPwdPanel());
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //GlobalTools.ShowInput(this.textBox1);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //GlobalTools.ShowInput(this.textBox2);
        }

        private void picToMaintain_Click(object sender, EventArgs e)
        {
            
        }

        private void picToMaintain2_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.QuitAccount();
        }

        private bool allowToMaintain = false;

        private void picToMaintain_DoubleClick(object sender, EventArgs e)
        {
            allowToMaintain = true;
        }

        private void picToMaintain2_DoubleClick(object sender, EventArgs e)
        {
            if (allowToMaintain)
            {
                this.QuitReadCard();
                GlobalTools.ReturnMaintainWithPwd();
            }
        }

        public void StopAdTimer()
        {
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "停止全屏广告计时!时间间隔为：" + adFullTimer.Interval);
#endif
            this.adFullTimer.Stop();
        }
        public void StartAdTimer()
        {
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "启动全屏广告计时!时间间隔为："+adFullTimer.Interval);
#endif
            this.adFullTimer.Start();
        }

        private void adFullTimer_Tick(object sender, EventArgs e)
        {
           
            if (this.Visible)
            {
                adFullTimer.Stop();
#if DEBUG
                Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "全屏广告展示时间到：");
#endif
                GlobalTools.ShowFullAdForm();
                adFullTimer.Start();
            }
        }
        private int icdev = -1;
        private bool hasRead = false;
        private ulong CardSerialNo = 0;
        private void timerReadCard_Tick(object sender, EventArgs e)
        {
            this.timerReadCard.Stop();
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString()+"首页开始监视刷卡！！！");
#endif
            int st = -1;
            short port = (short)Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RfidCard_Port"].ToString());
            if (icdev < 0)
            {
                if (port != 100)
                {
                    SerialPort serialPort = new SerialPort("com" + (port + 1).ToString(), 9600, System.IO.Ports.Parity.None, 8, StopBits.One);
                    serialPort.Close();
                }
                icdev = RfidImporter.dc_init(port, 115200);//第一个参数100为USB口，0为串口一，1为串口二等等。
                if (icdev <= 0)
                {
                    return;
                }
            }
            if (!hasRead)
            {
                //装载密码
                byte[] nkey = new byte[6] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
                byte[] nkey2 = new byte[6] { 0x68, 0x69, 0x70, 0x69, 0x61, 0x6f };
                int i;
                for (i = 0; i <= 15; i++)  //装载0-15扇区密码
                {
                    if (i == 3)
                    {
                        st = RfidImporter.dc_load_key(icdev, 0, i, nkey2);//第二个参数0代表使用密码A，第三个参数5代表扇区号
                    }
                    else
                        st = RfidImporter.dc_load_key(icdev, 0, i, nkey);//第二个参数0代表使用密码A，第三个参数5代表扇区号
                    if (st != 0)
                    {
                        //this.listBox1.Items.Add("扇区" + i + "装载密码 dc_load_key error!");
                        return;
                    }
                    // this.listBox1.Items.Add("扇区" + i + "装载密码 dc_load_key OK!");
                }
                hasRead = true;
            }


            st = RfidImporter.dc_card(icdev, '0', ref CardSerialNo);//第二个参数0指单卡操作，1指多卡操作。

            if (st != 0)
            {
                // this.listBox1.Items.Add("寻卡 失败!");
                this.timerReadCard.Start();
                return;
            }
            // this.listBox1.Items.Add("寻卡成功!");
            //this.listBox1.Items.Add("卡序列号：" + CardSerialNo);

            //string nkey = "FFFFFFFFFFFF";
            string nkeystr = "68697069616F";
            //校验密码   5扇区21块操作   
            //dc_authentication_passaddr_hex
            //dc_authentication_pass_hex
            // st = dc_authentication(icdev, 0, 3);
            //st=dc_authentication_passaddr_hex(icdev, 0, 3, nkey);

            st = RfidImporter.dc_authentication_pass_hex(icdev, 0, 3, nkeystr);
            if (st != 0)
            {
                //this.listBox1.Items.Add("扇区3校验密码失败!");
                this.timerReadCard.Start();
                GlobalTools.PopFlashCardError();
                return;
            }
            //this.listBox1.Items.Add("扇区3校验密码 OK!");


            StringBuilder sdata2 = new StringBuilder();
            int block = 12;
            //byte[] sdata1 = new byte[32];
            //
            //st = dc_read_hex(icdev, block, ref sdata1[0]);
            //dc_read
            st = RfidImporter.dc_read_hex(icdev, block, sdata2);
            //  st = dc_read(icdev, block, sdata2);
            if (st != 0)
            {
                //this.listBox1.Items.Add("块3的Hex方式读值 dc_read error!");
               
                this.timerReadCard.Start();
                GlobalTools.PopFlashCardError();
                return;
            }
            // this.listBox1.Items.Add(" 块3的值（Hex方式）为：" + sdata2);
            string card = string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                card += sdata2[i * 2 - 1].ToString();
            }
           // card = "0100407983";//cs0002
           // this.txtUserName.Text = card;// +"|" + CardSerialNo;
            ///TODO:是否自动登陆
            if (card.Length == 10)
            {

                if (GlobalTools.LoginAccount(card))
                {

                    this.QuitReadCard();
                    GlobalTools.ReturnUserAccout();
                }
            }
            else
            {
              

                #region 测试通过的代码
                /*
            if (icdev < 0)
            {
                icdev = dc_init(0, 115200);//第一个参数100为USB口，0为串口一，1为串口二等等。
                if (icdev <= 0)
                {
                    this.listBox1.Items.Add("初始化端口失败!");
                    return;
                }
                this.listBox1.Items.Add("初始化端口成功!");
            }
            //装载密码
            byte[] nkey = new byte[6] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            byte[] nkey2 = new byte[6] { 0x68, 0x69, 0x70, 0x69, 0x61, 0x6f };
            int i;
            for (i = 0; i <= 15; i++)  //装载0-15扇区密码
            {
                if (i == 3)
                {
                    st = dc_load_key(icdev, 0, i, nkey2);//第二个参数0代表使用密码A，第三个参数5代表扇区号
                }
                else
                    st = dc_load_key(icdev, 0, i, nkey);//第二个参数0代表使用密码A，第三个参数5代表扇区号
                if (st != 0)
                {
                    this.listBox1.Items.Add("扇区" + i + "装载密码 dc_load_key error!");
                    return;
                }
                this.listBox1.Items.Add("扇区" + i + "装载密码 dc_load_key OK!");
            }

            ulong CardSerialNo = 0;
            st = dc_card(icdev, '0', ref CardSerialNo);//第二个参数0指单卡操作，1指多卡操作。

            if (st != 0)
            {
                this.listBox1.Items.Add("寻卡 失败!");
                return;
            }
            this.listBox1.Items.Add("寻卡成功!");
            this.listBox1.Items.Add("卡序列号：" + CardSerialNo);

            //string nkey = "FFFFFFFFFFFF";
            string nkeystr = "68697069616F";
            //校验密码   5扇区21块操作   
            //dc_authentication_passaddr_hex
            //dc_authentication_pass_hex
            // st = dc_authentication(icdev, 0, 3);
            //st=dc_authentication_passaddr_hex(icdev, 0, 3, nkey);

            st = dc_authentication_pass_hex(icdev, 0, 3, nkeystr);
            if (st != 0)
            {
                this.listBox1.Items.Add("扇区3校验密码失败!");
                return;
            }
            this.listBox1.Items.Add("扇区3校验密码 OK!");


            StringBuilder sdata2 = new StringBuilder();
            int block = 12;
            //byte[] sdata1 = new byte[32];
            //
            //st = dc_read_hex(icdev, block, ref sdata1[0]);
            //dc_read
            st = dc_read_hex(icdev, block, sdata2);
            //  st = dc_read(icdev, block, sdata2);
            if (st != 0)
            {
                this.listBox1.Items.Add("块3的Hex方式读值 dc_read error!");
                return;
            }
            this.listBox1.Items.Add(" 块3的值（Hex方式）为：" + sdata2);
             * */
                #endregion
                this.timerReadCard.Start();
            }
        }

        /// <summary>
        /// 退出读卡操作
        /// </summary>
        public void QuitReadCard()
        {
            if (icdev > 0)
            {
                RfidImporter.dc_exit(icdev);//第一个参数100为USB口，0为串口一，1为串口二等等
                this.timerReadCard.Stop();
            }
        }
        
    }
}
