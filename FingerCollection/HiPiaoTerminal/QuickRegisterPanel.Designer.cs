namespace HiPiaoTerminal
{
    partial class QuickRegisterPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgreeAndRegister = new System.Windows.Forms.PictureBox();
            this.picMobileHint = new System.Windows.Forms.PictureBox();
            this.picRepeatPwdHint = new System.Windows.Forms.PictureBox();
            this.picPasswordHint = new System.Windows.Forms.PictureBox();
            this.picUserNameHint = new System.Windows.Forms.PictureBox();
            this.btnViewProtocol = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReturnButton = new System.Windows.Forms.PictureBox();
            this.btnReturnHome = new System.Windows.Forms.PictureBox();
            this.lbPasswordHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMobileHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRepeatPwdHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbUserNameHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtMobile = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtRepeatPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtPassword = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtUserName = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel4 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgreeAndRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMobileHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepeatPwdHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserNameHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewProtocol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgreeAndRegister
            // 
            this.btnAgreeAndRegister.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_Agree_NotOk;
            this.btnAgreeAndRegister.Location = new System.Drawing.Point(484, 686);
            this.btnAgreeAndRegister.Name = "btnAgreeAndRegister";
            this.btnAgreeAndRegister.Size = new System.Drawing.Size(422, 65);
            this.btnAgreeAndRegister.TabIndex = 1;
            this.btnAgreeAndRegister.TabStop = false;
            this.btnAgreeAndRegister.Click += new System.EventHandler(this.btnAgreeAndRegister_Click);
            // 
            // picMobileHint
            // 
            this.picMobileHint.Location = new System.Drawing.Point(1039, 563);
            this.picMobileHint.Name = "picMobileHint";
            this.picMobileHint.Size = new System.Drawing.Size(28, 31);
            this.picMobileHint.TabIndex = 1;
            this.picMobileHint.TabStop = false;
            this.picMobileHint.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // picRepeatPwdHint
            // 
            this.picRepeatPwdHint.Location = new System.Drawing.Point(1039, 446);
            this.picRepeatPwdHint.Name = "picRepeatPwdHint";
            this.picRepeatPwdHint.Size = new System.Drawing.Size(28, 31);
            this.picRepeatPwdHint.TabIndex = 1;
            this.picRepeatPwdHint.TabStop = false;
            this.picRepeatPwdHint.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // picPasswordHint
            // 
            this.picPasswordHint.Location = new System.Drawing.Point(1039, 332);
            this.picPasswordHint.Name = "picPasswordHint";
            this.picPasswordHint.Size = new System.Drawing.Size(28, 31);
            this.picPasswordHint.TabIndex = 1;
            this.picPasswordHint.TabStop = false;
            this.picPasswordHint.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // picUserNameHint
            // 
            this.picUserNameHint.Location = new System.Drawing.Point(1039, 219);
            this.picUserNameHint.Name = "picUserNameHint";
            this.picUserNameHint.Size = new System.Drawing.Size(28, 31);
            this.picUserNameHint.TabIndex = 1;
            this.picUserNameHint.TabStop = false;
            this.picUserNameHint.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // btnViewProtocol
            // 
            this.btnViewProtocol.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_Protocol_Hint;
            this.btnViewProtocol.Location = new System.Drawing.Point(602, 647);
            this.btnViewProtocol.Name = "btnViewProtocol";
            this.btnViewProtocol.Size = new System.Drawing.Size(166, 34);
            this.btnViewProtocol.TabIndex = 1;
            this.btnViewProtocol.TabStop = false;
            this.btnViewProtocol.Click += new System.EventHandler(this.btnViewProtocol_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_QuickRegister_Hint;
            this.pictureBox1.Location = new System.Drawing.Point(444, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(641, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnReturnButton
            // 
            this.btnReturnButton.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturnButton.Location = new System.Drawing.Point(1097, 40);
            this.btnReturnButton.Name = "btnReturnButton";
            this.btnReturnButton.Size = new System.Drawing.Size(160, 83);
            this.btnReturnButton.TabIndex = 0;
            this.btnReturnButton.TabStop = false;
            this.btnReturnButton.Click += new System.EventHandler(this.btnReturnButton_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnHome1;
            this.btnReturnHome.Location = new System.Drawing.Point(92, 40);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(352, 83);
            this.btnReturnHome.TabIndex = 0;
            this.btnReturnHome.TabStop = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // lbPasswordHint
            // 
            this.lbPasswordHint.AutoSize = true;
            this.lbPasswordHint.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPasswordHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbPasswordHint.Location = new System.Drawing.Point(374, 386);
            this.lbPasswordHint.Name = "lbPasswordHint";
            this.lbPasswordHint.Size = new System.Drawing.Size(0, 32);
            this.lbPasswordHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPasswordHint.TabIndex = 3;
            // 
            // lbMobileHint
            // 
            this.lbMobileHint.AutoSize = true;
            this.lbMobileHint.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMobileHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbMobileHint.Location = new System.Drawing.Point(374, 617);
            this.lbMobileHint.Name = "lbMobileHint";
            this.lbMobileHint.Size = new System.Drawing.Size(0, 32);
            this.lbMobileHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMobileHint.TabIndex = 3;
            // 
            // lbRepeatPwdHint
            // 
            this.lbRepeatPwdHint.AutoSize = true;
            this.lbRepeatPwdHint.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRepeatPwdHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbRepeatPwdHint.Location = new System.Drawing.Point(374, 502);
            this.lbRepeatPwdHint.Name = "lbRepeatPwdHint";
            this.lbRepeatPwdHint.Size = new System.Drawing.Size(0, 32);
            this.lbRepeatPwdHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRepeatPwdHint.TabIndex = 3;
            // 
            // lbUserNameHint
            // 
            this.lbUserNameHint.AutoSize = true;
            this.lbUserNameHint.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserNameHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(109)))), ((int)(((byte)(31)))));
            this.lbUserNameHint.Location = new System.Drawing.Point(374, 275);
            this.lbUserNameHint.Name = "lbUserNameHint";
            this.lbUserNameHint.Size = new System.Drawing.Size(0, 32);
            this.lbUserNameHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserNameHint.TabIndex = 3;
            // 
            // txtMobile
            // 
            this.txtMobile.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtMobile.BackColor = System.Drawing.SystemColors.Window;
            this.txtMobile.Font = new System.Drawing.Font("宋体", 21F);
            this.txtMobile.Hint = "请输入手机号";
            this.txtMobile.IsActive = false;
            this.txtMobile.IsDeleted = false;
            this.txtMobile.KeyboardType = 5;
            this.txtMobile.Location = new System.Drawing.Point(373, 540);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(0);
            this.txtMobile.MaxInputLength = 11;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PasswordChar = '\0';
            this.txtMobile.RelativeLabel = null;
            this.txtMobile.Size = new System.Drawing.Size(645, 74);
            this.txtMobile.TabIndex = 4;
            this.txtMobile.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtRepeatPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtRepeatPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtRepeatPwd.Hint = "请再次输入6位数字密码";
            this.txtRepeatPwd.IsActive = false;
            this.txtRepeatPwd.IsDeleted = false;
            this.txtRepeatPwd.KeyboardType = 5;
            this.txtRepeatPwd.Location = new System.Drawing.Point(373, 425);
            this.txtRepeatPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtRepeatPwd.MaxInputLength = 6;
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.PasswordChar = '*';
            this.txtRepeatPwd.RelativeLabel = null;
            this.txtRepeatPwd.Size = new System.Drawing.Size(645, 74);
            this.txtRepeatPwd.TabIndex = 3;
            this.txtRepeatPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 21F);
            this.txtPassword.Hint = "仅限6位数字密码";
            this.txtPassword.IsActive = false;
            this.txtPassword.IsDeleted = false;
            this.txtPassword.KeyboardType = 5;
            this.txtPassword.Location = new System.Drawing.Point(373, 310);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.MaxInputLength = 6;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RelativeLabel = null;
            this.txtPassword.Size = new System.Drawing.Size(645, 74);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.SmallLetterAndNumber;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 21F);
            this.txtUserName.Hint = "仅限小写字母/字母数字组合,20字符内";
            this.txtUserName.IsActive = false;
            this.txtUserName.IsDeleted = false;
            this.txtUserName.KeyboardType = 1;
            this.txtUserName.Location = new System.Drawing.Point(373, 197);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserName.MaxInputLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.RelativeLabel = null;
            this.txtUserName.Size = new System.Drawing.Size(645, 74);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 26F, System.Drawing.FontStyle.Bold);
            this.simpleLabel1.Location = new System.Drawing.Point(213, 214);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(125, 40);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 5;
            this.simpleLabel1.Text = "用户名";
            // 
            // simpleLabel2
            // 
            this.simpleLabel2.AutoSize = true;
            this.simpleLabel2.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 26F, System.Drawing.FontStyle.Bold);
            this.simpleLabel2.Location = new System.Drawing.Point(249, 327);
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Size = new System.Drawing.Size(89, 40);
            this.simpleLabel2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel2.TabIndex = 5;
            this.simpleLabel2.Text = "密码";
            // 
            // simpleLabel3
            // 
            this.simpleLabel3.AutoSize = true;
            this.simpleLabel3.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 26F, System.Drawing.FontStyle.Bold);
            this.simpleLabel3.Location = new System.Drawing.Point(177, 442);
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Size = new System.Drawing.Size(161, 40);
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel3.TabIndex = 5;
            this.simpleLabel3.Text = "确认密码";
            // 
            // simpleLabel4
            // 
            this.simpleLabel4.AutoSize = true;
            this.simpleLabel4.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 26F, System.Drawing.FontStyle.Bold);
            this.simpleLabel4.Location = new System.Drawing.Point(213, 557);
            this.simpleLabel4.Name = "simpleLabel4";
            this.simpleLabel4.Size = new System.Drawing.Size(125, 40);
            this.simpleLabel4.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel4.TabIndex = 5;
            this.simpleLabel4.Text = "手机号";
            // 
            // QuickRegisterPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.simpleLabel4);
            this.Controls.Add(this.simpleLabel3);
            this.Controls.Add(this.simpleLabel2);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.lbPasswordHint);
            this.Controls.Add(this.lbMobileHint);
            this.Controls.Add(this.lbRepeatPwdHint);
            this.Controls.Add(this.lbUserNameHint);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnAgreeAndRegister);
            this.Controls.Add(this.picMobileHint);
            this.Controls.Add(this.picRepeatPwdHint);
            this.Controls.Add(this.picPasswordHint);
            this.Controls.Add(this.picUserNameHint);
            this.Controls.Add(this.btnViewProtocol);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReturnButton);
            this.Controls.Add(this.btnReturnHome);
            this.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "QuickRegisterPanel";
            this.Size = new System.Drawing.Size(1280, 960);
            this.Load += new System.EventHandler(this.QuickRegisterPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAgreeAndRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMobileHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepeatPwdHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserNameHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewProtocol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnReturnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnReturnButton;
        private System.Windows.Forms.PictureBox btnViewProtocol;
        private System.Windows.Forms.PictureBox btnAgreeAndRegister;
        private System.Windows.Forms.PictureBox picUserNameHint;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtUserName;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtPassword;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtRepeatPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtMobile;
        private System.Windows.Forms.PictureBox picPasswordHint;
        private System.Windows.Forms.PictureBox picRepeatPwdHint;
        private System.Windows.Forms.PictureBox picMobileHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserNameHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPasswordHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRepeatPwdHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMobileHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel2;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel4;

    }
}
