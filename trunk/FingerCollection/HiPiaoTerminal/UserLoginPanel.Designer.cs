namespace HiPiaoTerminal
{
    partial class UserLoginPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginPanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.lbUserName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.txtUserName = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.lbPwd = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnLogin = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive();
            this.btnCancel = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive();
            this.panelUseKey = new System.Windows.Forms.Panel();
            this.panelUseRfid = new System.Windows.Forms.Panel();
            this.userLoginWithMoviePanel1 = new HiPiaoTerminal.UserControlEx.UserLoginWithMoviePanel();
            this.panelContent.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.txtUserName);
            this.panelContent.Controls.Add(this.txtPwd);
            this.panelContent.Controls.Add(this.panelUseRfid);
            this.panelContent.Controls.Add(this.panelUseKey);
            this.panelContent.Controls.Add(this.btnCancel);
            this.panelContent.Controls.Add(this.btnLogin);
            this.panelContent.Controls.Add(this.lbPwd);
            this.panelContent.Controls.Add(this.lbUserName);
            this.panelContent.Location = new System.Drawing.Point(0, 210);
            this.panelContent.Size = new System.Drawing.Size(1280, 503);
            this.panelContent.TabIndex = 242;
            this.panelContent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panelContent_PreviewKeyDown);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.userLoginWithMoviePanel1);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Size = new System.Drawing.Size(1280, 185);
            this.panelHeader.TabIndex = 23131;
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 830;
            this.splitContainer1.TabIndex = 234;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Accout_UserLogin_Home;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_UserLogin_Hint;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(415, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(644, 83);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReturn.Location = new System.Drawing.Point(1063, 41);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(162, 83);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbUserName.Location = new System.Drawing.Point(150, 65);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(125, 40);
            this.lbUserName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserName.TabIndex = 114;
            this.lbUserName.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.SmallLetterAndNumber;
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F);
            this.txtUserName.Hint = "请输入用户名";
            this.txtUserName.IsActive = false;
            this.txtUserName.IsDeleted = false;
            this.txtUserName.KeyboardType = 1;
            this.txtUserName.Location = new System.Drawing.Point(276, 36);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserName.MaxInputLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.RelativeLabel = this.lbUserName;
            this.txtUserName.Size = new System.Drawing.Size(555, 110);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            // 
            // txtPwd
            // 
            this.txtPwd.AllowInputType = HiPiaoTerminal.UserControlEx.AllowInputEnum.Number;
            this.txtPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F);
            this.txtPwd.Hint = "账户密码";
            this.txtPwd.IsActive = false;
            this.txtPwd.IsDeleted = false;
            this.txtPwd.KeyboardType = 5;
            this.txtPwd.Location = new System.Drawing.Point(276, 168);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtPwd.MaxInputLength = 6;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.RelativeLabel = this.lbPwd;
            this.txtPwd.Size = new System.Drawing.Size(555, 110);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            this.txtPwd.Enter += new System.EventHandler(this.txtPwd_Enter);
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbPwd.Font = new System.Drawing.Font("方正兰亭纤黑简体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbPwd.Location = new System.Drawing.Point(150, 205);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(133, 40);
            this.lbPwd.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPwd.TabIndex = 114;
            this.lbPwd.Text = "密    码";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.IsActived = false;
            this.btnLogin.Location = new System.Drawing.Point(276, 318);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(268, 95);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登   录";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.IsActived = true;
            this.btnCancel.Location = new System.Drawing.Point(560, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(268, 95);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取    消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // panelUseKey
            // 
            this.panelUseKey.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_Please_Use_Keyboard;
            this.panelUseKey.Location = new System.Drawing.Point(863, 36);
            this.panelUseKey.Name = "panelUseKey";
            this.panelUseKey.Size = new System.Drawing.Size(349, 217);
            this.panelUseKey.TabIndex = 115;
            // 
            // panelUseRfid
            // 
            this.panelUseRfid.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_FlashMemeberCard;
            this.panelUseRfid.Location = new System.Drawing.Point(863, 294);
            this.panelUseRfid.Name = "panelUseRfid";
            this.panelUseRfid.Size = new System.Drawing.Size(341, 315);
            this.panelUseRfid.TabIndex = 116;
            // 
            // userLoginWithMoviePanel1
            // 
            this.userLoginWithMoviePanel1.BackColor = System.Drawing.SystemColors.Window;
            this.userLoginWithMoviePanel1.Location = new System.Drawing.Point(0, 40);
            this.userLoginWithMoviePanel1.Name = "userLoginWithMoviePanel1";
            this.userLoginWithMoviePanel1.Size = new System.Drawing.Size(1280, 84);
            this.userLoginWithMoviePanel1.TabIndex = 2;
            // 
            // UserLoginPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Margin = new System.Windows.Forms.Padding(27, 21, 27, 21);
            this.Name = "UserLoginPanel";
            this.Load += new System.EventHandler(this.UserLoginPanel_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnReturn;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtPwd;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserName;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtUserName;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive btnLogin;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive btnCancel;
        private System.Windows.Forms.Panel panelUseKey;
        private System.Windows.Forms.Panel panelUseRfid;
        private HiPiaoTerminal.UserControlEx.UserLoginWithMoviePanel userLoginWithMoviePanel1;

    }
}
