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
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserName = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.txtPwd = new HiPiaoTerminal.UserControlEx.UserInputPanel();
            this.lbPwd = new System.Windows.Forms.Label();
            this.btnLogin = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive();
            this.btnCancel = new HiPiaoTerminal.UserControlEx.LabelButtonWithActive();
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
            this.panelContent.Controls.Add(this.btnCancel);
            this.panelContent.Controls.Add(this.btnLogin);
            this.panelContent.Controls.Add(this.lbPwd);
            this.panelContent.Controls.Add(this.txtPwd);
            this.panelContent.Controls.Add(this.lbUserName);
            this.panelContent.Controls.Add(this.txtUserName);
            this.panelContent.Size = new System.Drawing.Size(1280, 484);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(1413, 856);
            this.splitContainer1.SplitterDistance = 717;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Accout_UserLogin_Home;
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
            this.pictureBox2.Location = new System.Drawing.Point(415, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(644, 83);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1099, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(162, 83);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭黑简体", 26F);
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbUserName.Location = new System.Drawing.Point(178, 54);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(122, 40);
            this.lbUserName.TabIndex = 11;
            this.lbUserName.Text = "用户名";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 21F);
            this.txtUserName.Hint = "用户名/手机号码";
            this.txtUserName.Location = new System.Drawing.Point(329, 36);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(0);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.RelativeLabel = this.lbUserName;
            this.txtUserName.Size = new System.Drawing.Size(352, 74);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtPwd.Font = new System.Drawing.Font("宋体", 21F);
            this.txtPwd.Hint = "账户密码";
            this.txtPwd.Location = new System.Drawing.Point(329, 144);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(0);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.RelativeLabel = this.lbPwd;
            this.txtPwd.Size = new System.Drawing.Size(352, 74);
            this.txtPwd.TabIndex = 10;
            this.txtPwd.onSubTextChanged += new HiPiaoTerminal.UserControlEx.UserInputPanel.OnSubTextChanged(this.txtUserName_onSubTextChanged);
            // 
            // lbPwd
            // 
            this.lbPwd.AutoSize = true;
            this.lbPwd.Font = new System.Drawing.Font("方正兰亭黑简体", 26F);
            this.lbPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbPwd.Location = new System.Drawing.Point(178, 162);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(127, 40);
            this.lbPwd.TabIndex = 11;
            this.lbPwd.Text = "密    码";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.IsActived = false;
            this.btnLogin.Location = new System.Drawing.Point(212, 275);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(268, 95);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "登   录";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("方正兰亭黑简体", 36F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.IsActived = true;
            this.btnCancel.Location = new System.Drawing.Point(560, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(268, 95);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取    消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // UserLoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(27, 21, 27, 21);
            this.Name = "UserLoginPanel";
            this.Size = new System.Drawing.Size(1413, 856);
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
        private System.Windows.Forms.Label lbPwd;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtPwd;
        private System.Windows.Forms.Label lbUserName;
        private HiPiaoTerminal.UserControlEx.UserInputPanel txtUserName;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive btnLogin;
        private HiPiaoTerminal.UserControlEx.LabelButtonWithActive btnCancel;

    }
}
