namespace HiPiaoTerminal.Account
{
    partial class MyAccountPanel
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAccountPanel));
            this.btnFeeDetailInfo = new FT.Windows.Controls.ButtonEx.ActiveTabButton();
            this.btnModifyPwd = new FT.Windows.Controls.ButtonEx.ActiveTabButton();
            this.btnAccountInfo = new FT.Windows.Controls.ButtonEx.ActiveTabButton();
            this.btnReturnHome = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.btnQuitAccount = new System.Windows.Forms.PictureBox();
            this.btnGoBuyTicket = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGoBuyTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.btnReturnHome);
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnQuitAccount);
            this.splitContainer1.Panel2.Controls.Add(this.btnGoBuyTicket);
            this.splitContainer1.SplitterDistance = 815;
            // 
            // btnFeeDetailInfo
            // 
            this.btnFeeDetailInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFeeDetailInfo.BackgroundImage")));
            this.btnFeeDetailInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFeeDetailInfo.Font = new System.Drawing.Font("方正兰亭黑简体", 28F);
            this.btnFeeDetailInfo.ForeColor = System.Drawing.Color.White;
            this.btnFeeDetailInfo.IsActive = false;
            this.btnFeeDetailInfo.Location = new System.Drawing.Point(357, 154);
            this.btnFeeDetailInfo.Margin = new System.Windows.Forms.Padding(243, 149, 243, 149);
            this.btnFeeDetailInfo.Name = "btnFeeDetailInfo";
            this.btnFeeDetailInfo.Size = new System.Drawing.Size(222, 70);
            this.btnFeeDetailInfo.TabIndex = 1;
            this.btnFeeDetailInfo.TabText = "消费记录";
            this.btnFeeDetailInfo.Click += new System.EventHandler(this.btnFeeDetailInfo_Click);
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.BackgroundImage")));
            this.btnModifyPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModifyPwd.ForeColor = System.Drawing.Color.White;
            this.btnModifyPwd.IsActive = false;
            this.btnModifyPwd.Location = new System.Drawing.Point(629, 154);
            this.btnModifyPwd.Margin = new System.Windows.Forms.Padding(243, 149, 243, 149);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(222, 70);
            this.btnModifyPwd.TabIndex = 2;
            this.btnModifyPwd.TabText = "修改密码";
            this.btnModifyPwd.Load += new System.EventHandler(this.btnModifyPwd_Load);
            this.btnModifyPwd.Click += new System.EventHandler(this.btnModifyPwd_Click);
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccountInfo.BackgroundImage")));
            this.btnAccountInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccountInfo.Font = new System.Drawing.Font("方正兰亭黑简体", 28F);
            this.btnAccountInfo.IsActive = false;
            this.btnAccountInfo.Location = new System.Drawing.Point(85, 154);
            this.btnAccountInfo.Margin = new System.Windows.Forms.Padding(243, 149, 243, 149);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.Size = new System.Drawing.Size(222, 70);
            this.btnAccountInfo.TabIndex = 0;
            this.btnAccountInfo.TabText = "账户信息";
            this.btnAccountInfo.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_HomePage;
            this.btnReturnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturnHome.Location = new System.Drawing.Point(0, 40);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(411, 83);
            this.btnReturnHome.TabIndex = 0;
            this.btnReturnHome.TabStop = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_SiteHint;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(411, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 83);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1060, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnQuitAccount
            // 
            this.btnQuitAccount.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_QuitAccount;
            this.btnQuitAccount.Location = new System.Drawing.Point(632, 31);
            this.btnQuitAccount.Name = "btnQuitAccount";
            this.btnQuitAccount.Size = new System.Drawing.Size(281, 88);
            this.btnQuitAccount.TabIndex = 1;
            this.btnQuitAccount.TabStop = false;
            this.btnQuitAccount.Click += new System.EventHandler(this.btnQuitAccount_Click);
            // 
            // btnGoBuyTicket
            // 
            this.btnGoBuyTicket.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_GoBuyTicket;
            this.btnGoBuyTicket.Location = new System.Drawing.Point(940, 31);
            this.btnGoBuyTicket.Name = "btnGoBuyTicket";
            this.btnGoBuyTicket.Size = new System.Drawing.Size(279, 88);
            this.btnGoBuyTicket.TabIndex = 1;
            this.btnGoBuyTicket.TabStop = false;
            this.btnGoBuyTicket.Click += new System.EventHandler(this.btnGoBuyTicket_Click);
            // 
            // MyAccountPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.Controls.Add(this.btnFeeDetailInfo);
            this.Controls.Add(this.btnModifyPwd);
            this.Controls.Add(this.btnAccountInfo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MyAccountPanel";
            this.Load += new System.EventHandler(this.MyAccountPanel_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnAccountInfo, 0);
            this.Controls.SetChildIndex(this.btnModifyPwd, 0);
            this.Controls.SetChildIndex(this.btnFeeDetailInfo, 0);
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGoBuyTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.ButtonEx.ActiveTabButton btnAccountInfo;
        private FT.Windows.Controls.ButtonEx.ActiveTabButton btnModifyPwd;
        private FT.Windows.Controls.ButtonEx.ActiveTabButton btnFeeDetailInfo;
        private System.Windows.Forms.PictureBox btnReturnHome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox btnQuitAccount;
        private System.Windows.Forms.PictureBox btnGoBuyTicket;

    }
}
