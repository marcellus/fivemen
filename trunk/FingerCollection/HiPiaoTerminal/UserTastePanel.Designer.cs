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
            this.btnQuickBuyTicket = new System.Windows.Forms.PictureBox();
            this.btnQuickRegister = new System.Windows.Forms.PictureBox();
            this.btnReturnHome = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickBuyTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuickBuyTicket
            // 
            this.btnQuickBuyTicket.Image = global::HiPiaoTerminal.Properties.Resources.QuickBuyTicket;
            this.btnQuickBuyTicket.Location = new System.Drawing.Point(967, 30);
            this.btnQuickBuyTicket.Name = "btnQuickBuyTicket";
            this.btnQuickBuyTicket.Size = new System.Drawing.Size(190, 64);
            this.btnQuickBuyTicket.TabIndex = 2;
            this.btnQuickBuyTicket.TabStop = false;
            this.btnQuickBuyTicket.Click += new System.EventHandler(this.btnQuickBuyTicket_Click);
            // 
            // btnQuickRegister
            // 
            this.btnQuickRegister.Image = global::HiPiaoTerminal.Properties.Resources.QuickRegister;
            this.btnQuickRegister.Location = new System.Drawing.Point(753, 30);
            this.btnQuickRegister.Name = "btnQuickRegister";
            this.btnQuickRegister.Size = new System.Drawing.Size(190, 64);
            this.btnQuickRegister.TabIndex = 2;
            this.btnQuickRegister.TabStop = false;
            this.btnQuickRegister.Click += new System.EventHandler(this.btnQuickRegister_Click);
            // 
            // btnReturnHome
            // 
            this.btnReturnHome.Image = global::HiPiaoTerminal.Properties.Resources.ReturnHome;
            this.btnReturnHome.Location = new System.Drawing.Point(541, 30);
            this.btnReturnHome.Name = "btnReturnHome";
            this.btnReturnHome.Size = new System.Drawing.Size(190, 64);
            this.btnReturnHome.TabIndex = 2;
            this.btnReturnHome.TabStop = false;
            this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::HiPiaoTerminal.Properties.Resources.Refresh;
            this.btnRefresh.Location = new System.Drawing.Point(319, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 64);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGo
            // 
            this.btnGo.Image = global::HiPiaoTerminal.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(216, 30);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(80, 64);
            this.btnGo.TabIndex = 2;
            this.btnGo.TabStop = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::HiPiaoTerminal.Properties.Resources.Back;
            this.btnBack.Location = new System.Drawing.Point(135, 30);
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
            this.webBrowser1.Size = new System.Drawing.Size(1280, 860);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.btnQuickBuyTicket);
            this.panelHeader.Controls.Add(this.btnGo);
            this.panelHeader.Controls.Add(this.btnQuickRegister);
            this.panelHeader.Controls.Add(this.btnBack);
            this.panelHeader.Controls.Add(this.btnReturnHome);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1280, 100);
            this.panelHeader.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.webBrowser1);
            this.panelContent.Location = new System.Drawing.Point(0, 100);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1280, 860);
            this.panelContent.TabIndex = 2;
            // 
            // UserTastePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "UserTastePanel";
            this.Size = new System.Drawing.Size(1280, 960);
            this.Load += new System.EventHandler(this.UserTastePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickBuyTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuickRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.PictureBox btnGo;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox btnReturnHome;
        private System.Windows.Forms.PictureBox btnQuickRegister;
        private System.Windows.Forms.PictureBox btnQuickBuyTicket;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
    }
}
