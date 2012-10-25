namespace HiPiaoTerminal.UserRegister
{
    partial class UserNeedKnowInfoPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNeedKnowInfoPanel));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnSure = new System.Windows.Forms.PictureBox();
            this.btnRemark = new FT.Windows.Controls.ButtonEx.ActiveWithArrowButton();
            this.btnPrivatePolicy = new FT.Windows.Controls.ButtonEx.ActiveWithArrowButton();
            this.btnMemberProtocol = new FT.Windows.Controls.ButtonEx.ActiveWithArrowButton();
            this.btnWebSiteProtocol = new FT.Windows.Controls.ButtonEx.ActiveWithArrowButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(273, 20);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(704, 549);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnSure
            // 
            this.btnSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BtnConfirm;
            this.btnSure.Location = new System.Drawing.Point(493, 599);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(228, 70);
            this.btnSure.TabIndex = 4;
            this.btnSure.TabStop = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnRemark
            // 
            this.btnRemark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemark.BackgroundImage")));
            this.btnRemark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemark.ButtonText = " 免责申明";
            this.btnRemark.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnRemark.IsActive = false;
            this.btnRemark.Location = new System.Drawing.Point(2, 288);
            this.btnRemark.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(218, 65);
            this.btnRemark.TabIndex = 2;
            this.btnRemark.Load += new System.EventHandler(this.btnRemark_Load);
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // btnPrivatePolicy
            // 
            this.btnPrivatePolicy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrivatePolicy.BackgroundImage")));
            this.btnPrivatePolicy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrivatePolicy.ButtonText = " 隐私条款";
            this.btnPrivatePolicy.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnPrivatePolicy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnPrivatePolicy.IsActive = false;
            this.btnPrivatePolicy.Location = new System.Drawing.Point(2, 217);
            this.btnPrivatePolicy.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrivatePolicy.Name = "btnPrivatePolicy";
            this.btnPrivatePolicy.Size = new System.Drawing.Size(218, 65);
            this.btnPrivatePolicy.TabIndex = 2;
            this.btnPrivatePolicy.Click += new System.EventHandler(this.btnPrivatePolicy_Click);
            // 
            // btnMemberProtocol
            // 
            this.btnMemberProtocol.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMemberProtocol.BackgroundImage")));
            this.btnMemberProtocol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMemberProtocol.ButtonText = " 会员服务协议";
            this.btnMemberProtocol.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnMemberProtocol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnMemberProtocol.IsActive = false;
            this.btnMemberProtocol.Location = new System.Drawing.Point(2, 146);
            this.btnMemberProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.btnMemberProtocol.Name = "btnMemberProtocol";
            this.btnMemberProtocol.Size = new System.Drawing.Size(218, 65);
            this.btnMemberProtocol.TabIndex = 1;
            this.btnMemberProtocol.Click += new System.EventHandler(this.btnMemberProtocol_Click);
            // 
            // btnWebSiteProtocol
            // 
            this.btnWebSiteProtocol.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWebSiteProtocol.BackgroundImage")));
            this.btnWebSiteProtocol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWebSiteProtocol.ButtonText = " 网站服务协议";
            this.btnWebSiteProtocol.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.btnWebSiteProtocol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.btnWebSiteProtocol.IsActive = false;
            this.btnWebSiteProtocol.Location = new System.Drawing.Point(2, 75);
            this.btnWebSiteProtocol.Margin = new System.Windows.Forms.Padding(0);
            this.btnWebSiteProtocol.Name = "btnWebSiteProtocol";
            this.btnWebSiteProtocol.Size = new System.Drawing.Size(218, 65);
            this.btnWebSiteProtocol.TabIndex = 0;
            this.btnWebSiteProtocol.Click += new System.EventHandler(this.btnWebSiteProtocol_Click);
            // 
            // UserNeedKnowInfoPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnRemark);
            this.Controls.Add(this.btnPrivatePolicy);
            this.Controls.Add(this.btnMemberProtocol);
            this.Controls.Add(this.btnWebSiteProtocol);
            this.Name = "UserNeedKnowInfoPanel";
            this.Size = new System.Drawing.Size(990, 688);
            this.Load += new System.EventHandler(this.UserNeedKnowInfoPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.ButtonEx.ActiveWithArrowButton btnRemark;
        private FT.Windows.Controls.ButtonEx.ActiveWithArrowButton btnPrivatePolicy;
        private FT.Windows.Controls.ButtonEx.ActiveWithArrowButton btnMemberProtocol;
        private FT.Windows.Controls.ButtonEx.ActiveWithArrowButton btnWebSiteProtocol;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox btnSure;
    }
}
