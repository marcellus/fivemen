namespace HiPiaoTerminal.BuyTicket
{
    partial class MovieSeatSelectorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieSeatSelectorPanel));
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieDetail = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.processPanel1 = new FT.Windows.Controls.PanelEx.ProcessPanel();
            this.lbProcessHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.panelSeat = new System.Windows.Forms.Panel();
            this.panelSelectedSeat = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbPlanInfo = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTotalPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTotalNum = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnPay = new System.Windows.Forms.PictureBox();
            this.showWelcomePanel1 = new HiPiaoTerminal.BuyTicket.ShowWelcomePanel();
            this.btnDoubleToFullScreen = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoubleToFullScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.btnDoubleToFullScreen);
            this.panelContent.Controls.Add(this.panelSeat);
            this.panelContent.Controls.Add(this.lbProcessHint);
            this.panelContent.Controls.Add(this.processPanel1);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.panelSelectedSeat);
            this.panelContent.Controls.Add(this.lbPrice);
            this.panelContent.Controls.Add(this.panel3);
            this.panelContent.Controls.Add(this.lbMovieDetail);
            this.panelContent.Controls.Add(this.lbMovieName);
            this.panelContent.Controls.Add(this.pictureBox3);
            this.panelContent.Location = new System.Drawing.Point(0, 121);
            this.panelContent.Size = new System.Drawing.Size(1280, 682);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.btnPay);
            this.splitContainer1.Panel2.Controls.Add(this.showWelcomePanel1);
            this.splitContainer1.SplitterDistance = 827;
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbMovieName.Location = new System.Drawing.Point(124, 33);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(99, 32);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 1;
            this.lbMovieName.Text = "电影名";
            // 
            // lbMovieDetail
            // 
            this.lbMovieDetail.AutoSize = true;
            this.lbMovieDetail.Font = new System.Drawing.Font("方正兰亭黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieDetail.Location = new System.Drawing.Point(398, 37);
            this.lbMovieDetail.Name = "lbMovieDetail";
            this.lbMovieDetail.Size = new System.Drawing.Size(135, 22);
            this.lbMovieDetail.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieDetail.TabIndex = 2;
            this.lbMovieDetail.Text = "{0} {1} {2}分钟";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(820, 33);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(120, 32);
            this.lbPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPrice.TabIndex = 4;
            this.lbPrice.Text = "{0}元/张";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(175)))), ((int)(((byte)(17)))));
            this.label3.Font = new System.Drawing.Font("方正兰亭黑简体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(124, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(813, 29);
            this.label3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label3.TabIndex = 7;
            this.label3.Text = "屏幕";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // processPanel1
            // 
            this.processPanel1.Location = new System.Drawing.Point(551, 10);
            this.processPanel1.Name = "processPanel1";
            this.processPanel1.Size = new System.Drawing.Size(179, 23);
            this.processPanel1.TabIndex = 8;
            // 
            // lbProcessHint
            // 
            this.lbProcessHint.AutoSize = true;
            this.lbProcessHint.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbProcessHint.Location = new System.Drawing.Point(237, 5);
            this.lbProcessHint.Name = "lbProcessHint";
            this.lbProcessHint.Size = new System.Drawing.Size(323, 32);
            this.lbProcessHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbProcessHint.TabIndex = 9;
            this.lbProcessHint.Text = "正在加载座位图，请稍候";
            // 
            // panelSeat
            // 
            this.panelSeat.AutoScroll = true;
            this.panelSeat.Location = new System.Drawing.Point(124, 124);
            this.panelSeat.Name = "panelSeat";
            this.panelSeat.Size = new System.Drawing.Size(813, 555);
            this.panelSeat.TabIndex = 10;
            this.panelSeat.DoubleClick += new System.EventHandler(this.panelSeat_DoubleClick);
            // 
            // panelSelectedSeat
            // 
            this.panelSelectedSeat.AutoScroll = true;
            this.panelSelectedSeat.BackColor = System.Drawing.SystemColors.Window;
            this.panelSelectedSeat.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_SelectedSeat_Panel;
            this.panelSelectedSeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSelectedSeat.Location = new System.Drawing.Point(994, 177);
            this.panelSelectedSeat.Name = "panelSelectedSeat";
            this.panelSelectedSeat.Size = new System.Drawing.Size(228, 276);
            this.panelSelectedSeat.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_SiteHint;
            this.panel3.Controls.Add(this.lbPlanInfo);
            this.panel3.Location = new System.Drawing.Point(581, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 32);
            this.panel3.TabIndex = 3;
            // 
            // lbPlanInfo
            // 
            this.lbPlanInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbPlanInfo.Font = new System.Drawing.Font("方正兰亭黑简体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPlanInfo.Location = new System.Drawing.Point(3, 0);
            this.lbPlanInfo.Name = "lbPlanInfo";
            this.lbPlanInfo.Size = new System.Drawing.Size(217, 32);
            this.lbPlanInfo.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPlanInfo.TabIndex = 0;
            this.lbPlanInfo.Text = "{0} {1} {2}";
            this.lbPlanInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Sell_Flag_White;
            this.pictureBox3.Location = new System.Drawing.Point(997, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(228, 138);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Home;
            this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 84);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1055, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Select_Position;
            this.pictureBox1.Location = new System.Drawing.Point(243, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(815, 83);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Ticket_TotalNum;
            this.panel2.Controls.Add(this.lbTotalPrice);
            this.panel2.Controls.Add(this.lbTotalNum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(860, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 89);
            this.panel2.TabIndex = 5;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTotalPrice.Location = new System.Drawing.Point(101, 48);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(75, 32);
            this.lbTotalPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTotalPrice.TabIndex = 0;
            this.lbTotalPrice.Text = "0.00";
            // 
            // lbTotalNum
            // 
            this.lbTotalNum.AutoSize = true;
            this.lbTotalNum.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTotalNum.Location = new System.Drawing.Point(101, 13);
            this.lbTotalNum.Name = "lbTotalNum";
            this.lbTotalNum.Size = new System.Drawing.Size(80, 32);
            this.lbTotalNum.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTotalNum.TabIndex = 0;
            this.lbTotalNum.Text = "{0}张";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 32);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 0;
            this.label2.Text = "总价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 32);
            this.label1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label1.TabIndex = 0;
            this.label1.Text = "已选：";
            // 
            // btnPay
            // 
            this.btnPay.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Ticket_Pay;
            this.btnPay.Location = new System.Drawing.Point(1063, 30);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(161, 89);
            this.btnPay.TabIndex = 6;
            this.btnPay.TabStop = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // showWelcomePanel1
            // 
            this.showWelcomePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showWelcomePanel1.BackgroundImage")));
            this.showWelcomePanel1.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showWelcomePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.showWelcomePanel1.Location = new System.Drawing.Point(252, 30);
            this.showWelcomePanel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.showWelcomePanel1.Name = "showWelcomePanel1";
            this.showWelcomePanel1.Size = new System.Drawing.Size(527, 80);
            this.showWelcomePanel1.TabIndex = 4;
            // 
            // btnDoubleToFullScreen
            // 
            this.btnDoubleToFullScreen.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Click;
            this.btnDoubleToFullScreen.Location = new System.Drawing.Point(1019, 560);
            this.btnDoubleToFullScreen.Name = "btnDoubleToFullScreen";
            this.btnDoubleToFullScreen.Size = new System.Drawing.Size(260, 78);
            this.btnDoubleToFullScreen.TabIndex = 11;
            this.btnDoubleToFullScreen.TabStop = false;
            this.btnDoubleToFullScreen.DoubleClick += new System.EventHandler(this.panelSeat_DoubleClick);
            this.btnDoubleToFullScreen.Click += new System.EventHandler(this.btnDoubleToFullScreen_Click);
            // 
            // MovieSeatSelectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.Name = "MovieSeatSelectorPanel";
            this.Load += new System.EventHandler(this.MovieSeatSelectorPanel_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoubleToFullScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ShowWelcomePanel showWelcomePanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnPay;
        private FT.Windows.Controls.LabelEx.SimpleLabel label1;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTotalPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTotalNum;
        private System.Windows.Forms.PictureBox pictureBox3;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieDetail;
        private System.Windows.Forms.Panel panel3;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPlanInfo;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPrice;
        private System.Windows.Forms.Panel panelSelectedSeat;
        private FT.Windows.Controls.LabelEx.SimpleLabel label3;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbProcessHint;
        private FT.Windows.Controls.PanelEx.ProcessPanel processPanel1;
        private System.Windows.Forms.Panel panelSeat;
        private System.Windows.Forms.PictureBox btnDoubleToFullScreen;

    }
}
