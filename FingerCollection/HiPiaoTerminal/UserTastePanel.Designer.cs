namespace HiPiaoTerminal
{
    partial class UserTastePanel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnQuickBuyTicket = new System.Windows.Forms.PictureBox();
            this.btnQuickRegister = new System.Windows.Forms.PictureBox();
            this.btnReturnHome = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickBuyTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnQuickBuyTicket);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuickRegister);
            this.splitContainer1.Panel1.Controls.Add(this.btnReturnHome);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btnGo);
            this.splitContainer1.Panel1.Controls.Add(this.btnBack);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 960);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnQuickBuyTicket
            // 
            this.btnQuickBuyTicket.Image = global::HiPiaoTerminal.Properties.Resources.QuickBuyTicket;
            this.btnQuickBuyTicket.Location = new System.Drawing.Point(1026, 24);
            this.btnQuickBuyTicket.Name = "btnQuickBuyTicket";
            this.btnQuickBuyTicket.Size = new System.Drawing.Size(190, 64);
            this.btnQuickBuyTicket.TabIndex = 2;
            this.btnQuickBuyTicket.TabStop = false;
            this.btnQuickBuyTicket.Click += new System.EventHandler(this.btnQuickBuyTicket_Click);
            // 
            // btnQuickRegister
            // 
            this.btnQuickRegister.Image = global::HiPiaoTerminal.Properties.Resources.QuickRegister;
            this.btnQuickRegister.Location = new System.Drawing.Point(798, 24);
            this.btnQuickRegister.Name = "btnQuickRegister";
            this.btnQuickRegister.Size = new System.Drawing.Size(190, 64);
            this.btnQuickRegister.TabIndex = 2;
            this.btnQuickRegister.TabStop = false;
            this.btnQuickRegister.Click += new System.EventHandler(this.btnQuickRegister_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.Image = global::HiPiaoTerminal.Properties.Resources.ReturnHome;
            this.btnReturnHome.Location = new System.Drawing.Point(570, 24);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(190, 64);
            this.btnReturnHome.TabIndex = 2;
            this.btnReturnHome.TabStop = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::HiPiaoTerminal.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(353, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 64);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGo
            // 
            this.btnGo.Image = global::HiPiaoTerminal.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(231, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(80, 64);
            this.btnGo.TabIndex = 2;
            this.btnGo.TabStop = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::HiPiaoTerminal.Properties.Resources.Back;
            this.btnBack.Location = new System.Drawing.Point(138, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 64);
            this.btnBack.TabIndex = 2;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1280, 856);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // UserTastePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserTastePanel";
            this.Size = new System.Drawing.Size(1280, 960);
            this.Load += new System.EventHandler(this.UserTastePanel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickBuyTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.PictureBox btnGo;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox btnReturnHome;
        private System.Windows.Forms.PictureBox btnQuickRegister;
        private System.Windows.Forms.PictureBox btnQuickBuyTicket;
    }
}
