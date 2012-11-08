using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.Account;
using HiPiaoTerminal.ConfigModel;
using FT.Device.Rfid;
using System.IO.Ports;

namespace HiPiaoTerminal
{
    public partial class UserLoginPanel : OperationTimeParentPanel
    {
        private int loginSuccessType = 0;
        public UserLoginPanel(int type)
        {
            InitializeComponent();
            this.SetSepartor(false);
            loginSuccessType=type;
            if (type == 0)
            {
                this.userLoginWithMoviePanel1.Visible = false;
                this.StopOpertionTime();
                this.SetOperationTime(100);
            }
            else
            {
                this.userLoginWithMoviePanel1.Visible = true;
                this.StopOpertionTime();
                this.SetOperationTime(100);
            }
           
            this.KeyDown += new KeyEventHandler(UserLoginPanel_KeyDown);
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseRfid)
            {
                this.panelUseRfid.Location = new Point(this.panelUseKey.Location.X, this.panelUseKey.Location.Y);
                this.panelUseRfid.Visible = true;
            }
            else
            {
                this.panelUseRfid.Visible = false;
            }
            this.panelUseKey.Visible = false;
        }

        private void UserLoginPanel_Load(object sender, EventArgs e)
        {
           // GlobalTools.RegistUpdateUnOperationTime(null);
            
            //this.FindForm().AcceptButton = this.btnLogin;
            this.txtUserName.Focus();
            ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<ConfigModel.SystemConfig>();
            if (config.UseRfid)
            {
                this.timerReadCard.Start();
            }
        }

        void UserLoginPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null, null);
            }
        }
       // override pro

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Cursor.Current = Cursors.Default;
               // Cursor.Show();
                this.btnLogin_Click(null, null);
                //this.Close();
                

            }
            return false;
            //return false;
        }


       

        private bool allowLogin=false;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (allowLogin)
            {
                try
                {

                    if (GlobalTools.LoginAccount(this.txtUserName.Text, this.txtPwd.Text))
                    {
                        if (loginSuccessType == 0)
                        {
                            this.QuitReadCard();
                            GlobalTools.ReturnUserAccout();
                        }
                        else if (loginSuccessType == 1)
                        {
                            this.QuitReadCard();
                            GlobalTools.QuickBuyTicket();
                        }
                    }
                    else
                    {
                        GlobalTools.Pop(new UIdOrPwdErrorPanel());

                    }
                }
                catch (Exception ex)
                {
                    GlobalTools.PopNetError();
                }
            }
        }

        private void txtUserName_onSubTextChanged()
        {
            string uid = this.txtUserName.Text;
            string pwd = this.txtPwd.Text;
            if (uid.Length > 0 && pwd.Length ==6)
            {
                allowLogin = true;
                this.btnLogin.IsActived = true;
            }
            else
            {
                allowLogin = false;
                this.btnLogin.IsActived = false;
            }
            if (this.txtPwd.Focused)
            {
                   // this.panelUseRfid.Visible = false;
                   


            }
            else if (this.txtUserName.Focused)
            {
              //  this.panelUseKey.Visible = false;
              

            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
          //  GlobalTools.QuitAccount();
            this.QuitReadCard();
            GlobalTools.ReturnMain();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.QuitReadCard();
            GlobalTools.ReturnMain();
        }

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                // Add the list of special keys that you want to handle 
                case Keys.Tab:
                    return true;
                case Keys.Enter:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void panelContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null,null);
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseRfid)
            {
                this.panelUseRfid.Visible = true;

            }
            else
            {
                this.panelUseRfid.Visible = false;
            }
            this.panelUseKey.Visible = false;
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseHardwareKeyboard)
            {
                this.panelUseKey.Visible = true;

            }
            else
            {
                this.panelUseKey.Visible = false;
            }
            this.panelUseRfid.Visible = false;
        }

        

        private int icdev = -1;
        private bool hasRead = false;
        private ulong CardSerialNo = 0;
        private void timerReadCard_Tick(object sender, EventArgs e)
        {
            this.timerReadCard.Stop();
            int st = -1;
            short port = (short)Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RfidCard_Port"].ToString());
            if (icdev < 0)
            {
                if (port != 100)
                {
                    SerialPort serialPort= new SerialPort("com"+(port+1).ToString(),9600,System.IO.Ports.Parity.None,8, StopBits.One);
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
                return;
            }
           // this.listBox1.Items.Add(" 块3的值（Hex方式）为：" + sdata2);
            string card=string.Empty;
            for (int i = 1; i <= 10; i++)
            {
                card += sdata2[i*2-1].ToString();
            }
            this.txtUserName.Text = card;// +"|" + CardSerialNo;
            this.txtPwd.Focus();

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

        /// <summary>
        /// 退出读卡操作
        /// </summary>
        public void QuitReadCard()
        {
            if (icdev>0)
            {
                RfidImporter.dc_exit(icdev);//第一个参数100为USB口，0为串口一，1为串口二等等
                this.timerReadCard.Stop();
            }
        }

        private void userLoginWithMoviePanel1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
