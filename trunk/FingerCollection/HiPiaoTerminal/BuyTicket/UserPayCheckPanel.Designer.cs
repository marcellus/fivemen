namespace HiPiaoTerminal.BuyTicket
{
    partial class UserPayCheckPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPayCheckPanel));
            this.showWelcomePanel1 = new HiPiaoTerminal.BuyTicket.ShowWelcomePanel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.lbTimeHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDateHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieInfo = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRoom = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTime = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDate = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbSeats = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picAdImage = new System.Windows.Forms.PictureBox();
            this.simpleLabel7 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketPriceHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketCount = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketCountHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel12 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketTotalPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketTotalPriceHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.btnConfirmPay = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.cinemaNamePanel1 = new HiPiaoTerminal.UserControlEx.CinemaNamePanel();
            this.panelContent.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.cinemaNamePanel1);
            this.panelContent.Controls.Add(this.panelDetail);
            this.panelContent.Controls.Add(this.simpleLabel7);
            this.panelContent.Controls.Add(this.lbTicketCount);
            this.panelContent.Controls.Add(this.lbTicketTotalPrice);
            this.panelContent.Controls.Add(this.lbTicketPrice);
            this.panelContent.Controls.Add(this.lbTicketTotalPriceHint);
            this.panelContent.Controls.Add(this.lbTicketCountHint);
            this.panelContent.Controls.Add(this.simpleLabel12);
            this.panelContent.Controls.Add(this.lbTicketPriceHint);
            this.panelContent.Location = new System.Drawing.Point(0, 259);
            this.panelContent.Size = new System.Drawing.Size(1280, 542);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.btnHome);
            this.panelHeader.Size = new System.Drawing.Size(1280, 261);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirmPay);
            this.splitContainer1.Panel2.Controls.Add(this.showWelcomePanel1);
            this.splitContainer1.SplitterDistance = 830;
            // 
            // showWelcomePanel1
            // 
            this.showWelcomePanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.showWelcomePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showWelcomePanel1.BackgroundImage")));
            this.showWelcomePanel1.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showWelcomePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.showWelcomePanel1.Location = new System.Drawing.Point(251, 33);
            this.showWelcomePanel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.showWelcomePanel1.Name = "showWelcomePanel1";
            this.showWelcomePanel1.Size = new System.Drawing.Size(527, 80);
            this.showWelcomePanel1.TabIndex = 0;
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDetail.Controls.Add(this.lbTimeHint);
            this.panelDetail.Controls.Add(this.lbDateHint);
            this.panelDetail.Controls.Add(this.lbMovieInfo);
            this.panelDetail.Controls.Add(this.lbRoom);
            this.panelDetail.Controls.Add(this.lbTime);
            this.panelDetail.Controls.Add(this.lbDate);
            this.panelDetail.Controls.Add(this.lbSeats);
            this.panelDetail.Controls.Add(this.lbMovieName);
            this.panelDetail.Controls.Add(this.picAdImage);
            this.panelDetail.Location = new System.Drawing.Point(62, 67);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1163, 140);
            this.panelDetail.TabIndex = 0;
            // 
            // lbTimeHint
            // 
            this.lbTimeHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lbTimeHint.Location = new System.Drawing.Point(942, 5);
            this.lbTimeHint.Name = "lbTimeHint";
            this.lbTimeHint.Size = new System.Drawing.Size(5, 50);
            this.lbTimeHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTimeHint.TabIndex = 2;
            this.lbTimeHint.Text = "simpleLabel2";
            // 
            // lbDateHint
            // 
            this.lbDateHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lbDateHint.Location = new System.Drawing.Point(621, 5);
            this.lbDateHint.Name = "lbDateHint";
            this.lbDateHint.Size = new System.Drawing.Size(5, 50);
            this.lbDateHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDateHint.TabIndex = 2;
            this.lbDateHint.Text = "simpleLabel2";
            // 
            // lbMovieInfo
            // 
            this.lbMovieInfo.AutoSize = true;
            this.lbMovieInfo.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbMovieInfo.Location = new System.Drawing.Point(106, 56);
            this.lbMovieInfo.Name = "lbMovieInfo";
            this.lbMovieInfo.Size = new System.Drawing.Size(136, 22);
            this.lbMovieInfo.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieInfo.TabIndex = 1;
            this.lbMovieInfo.Text = "{0}{1}{2}分钟";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("方正兰亭纤黑简体", 39F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbRoom.Location = new System.Drawing.Point(973, 8);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(133, 61);
            this.lbRoom.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRoom.TabIndex = 1;
            this.lbRoom.Text = "影厅";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("方正兰亭纤黑简体", 39F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTime.Location = new System.Drawing.Point(659, 8);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(239, 61);
            this.lbTime.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "播放时间";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("方正兰亭纤黑简体", 39F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbDate.Location = new System.Drawing.Point(372, 8);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(272, 61);
            this.lbDate.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDate.TabIndex = 1;
            this.lbDate.Text = "1播放时间";
            // 
            // lbSeats
            // 
            this.lbSeats.AutoSize = true;
            this.lbSeats.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.lbSeats.Location = new System.Drawing.Point(372, 69);
            this.lbSeats.Name = "lbSeats";
            this.lbSeats.Size = new System.Drawing.Size(142, 32);
            this.lbSeats.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbSeats.TabIndex = 1;
            this.lbSeats.Text = "座位：{0}";
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbMovieName.Location = new System.Drawing.Point(104, 14);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(363, 32);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 1;
            this.lbMovieName.Text = "电影名称电影名称电影名称";
            // 
            // picAdImage
            // 
            this.picAdImage.Location = new System.Drawing.Point(4, 4);
            this.picAdImage.Name = "picAdImage";
            this.picAdImage.Size = new System.Drawing.Size(93, 131);
            this.picAdImage.TabIndex = 0;
            this.picAdImage.TabStop = false;
            // 
            // simpleLabel7
            // 
            this.simpleLabel7.AutoSize = true;
            this.simpleLabel7.Font = new System.Drawing.Font("方正兰亭纤黑简体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(64)))));
            this.simpleLabel7.Location = new System.Drawing.Point(58, 373);
            this.simpleLabel7.Name = "simpleLabel7";
            this.simpleLabel7.Size = new System.Drawing.Size(304, 23);
            this.simpleLabel7.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel7.TabIndex = 1;
            this.simpleLabel7.Text = "温馨提示：一经购买，不可退换";
            // 
            // lbTicketPrice
            // 
            this.lbTicketPrice.AutoSize = true;
            this.lbTicketPrice.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTicketPrice.Location = new System.Drawing.Point(51, 215);
            this.lbTicketPrice.Name = "lbTicketPrice";
            this.lbTicketPrice.Size = new System.Drawing.Size(114, 70);
            this.lbTicketPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketPrice.TabIndex = 1;
            this.lbTicketPrice.Text = "{0}";
            // 
            // lbTicketPriceHint
            // 
            this.lbTicketPriceHint.AutoSize = true;
            this.lbTicketPriceHint.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketPriceHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbTicketPriceHint.Location = new System.Drawing.Point(160, 217);
            this.lbTicketPriceHint.Name = "lbTicketPriceHint";
            this.lbTicketPriceHint.Size = new System.Drawing.Size(250, 70);
            this.lbTicketPriceHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketPriceHint.TabIndex = 1;
            this.lbTicketPriceHint.Text = "元/张,共";
            // 
            // lbTicketCount
            // 
            this.lbTicketCount.AutoSize = true;
            this.lbTicketCount.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTicketCount.Location = new System.Drawing.Point(413, 215);
            this.lbTicketCount.Name = "lbTicketCount";
            this.lbTicketCount.Size = new System.Drawing.Size(114, 70);
            this.lbTicketCount.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketCount.TabIndex = 1;
            this.lbTicketCount.Text = "{0}";
            // 
            // lbTicketCountHint
            // 
            this.lbTicketCountHint.AutoSize = true;
            this.lbTicketCountHint.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketCountHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbTicketCountHint.Location = new System.Drawing.Point(527, 215);
            this.lbTicketCountHint.Name = "lbTicketCountHint";
            this.lbTicketCountHint.Size = new System.Drawing.Size(91, 70);
            this.lbTicketCountHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketCountHint.TabIndex = 1;
            this.lbTicketCountHint.Text = "张";
            // 
            // simpleLabel12
            // 
            this.simpleLabel12.AutoSize = true;
            this.simpleLabel12.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.simpleLabel12.Location = new System.Drawing.Point(50, 287);
            this.simpleLabel12.Name = "simpleLabel12";
            this.simpleLabel12.Size = new System.Drawing.Size(213, 70);
            this.simpleLabel12.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel12.TabIndex = 1;
            this.simpleLabel12.Text = "合计：";
            // 
            // lbTicketTotalPrice
            // 
            this.lbTicketTotalPrice.AutoSize = true;
            this.lbTicketTotalPrice.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTicketTotalPrice.Location = new System.Drawing.Point(234, 287);
            this.lbTicketTotalPrice.Name = "lbTicketTotalPrice";
            this.lbTicketTotalPrice.Size = new System.Drawing.Size(114, 70);
            this.lbTicketTotalPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketTotalPrice.TabIndex = 1;
            this.lbTicketTotalPrice.Text = "{0}";
            // 
            // lbTicketTotalPriceHint
            // 
            this.lbTicketTotalPriceHint.AutoSize = true;
            this.lbTicketTotalPriceHint.Font = new System.Drawing.Font("方正兰亭纤黑简体", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTicketTotalPriceHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbTicketTotalPriceHint.Location = new System.Drawing.Point(357, 287);
            this.lbTicketTotalPriceHint.Name = "lbTicketTotalPriceHint";
            this.lbTicketTotalPriceHint.Size = new System.Drawing.Size(91, 70);
            this.lbTicketTotalPriceHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketTotalPriceHint.TabIndex = 1;
            this.lbTicketTotalPriceHint.Text = "元";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_ConfirmTickets;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(62, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1163, 133);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1059, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_CheckInfo_Hint;
            this.pictureBox1.Location = new System.Drawing.Point(244, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(814, 83);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_ReturnHome;
            this.btnHome.Location = new System.Drawing.Point(0, 40);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(248, 83);
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnConfirmPay
            // 
            this.btnConfirmPay.Font = new System.Drawing.Font("方正兰亭黑简体", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmPay.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPay.Image = global::HiPiaoTerminal.Properties.Resources.BuyTick_ConfirmPay;
            this.btnConfirmPay.Location = new System.Drawing.Point(938, 33);
            this.btnConfirmPay.Name = "btnConfirmPay";
            this.btnConfirmPay.Size = new System.Drawing.Size(280, 88);
            this.btnConfirmPay.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnConfirmPay.TabIndex = 1;
            this.btnConfirmPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirmPay.Click += new System.EventHandler(this.btnConfirmPay_Click);
            // 
            // cinemaNamePanel1
            // 
            this.cinemaNamePanel1.LeftAlign = true;
            this.cinemaNamePanel1.Location = new System.Drawing.Point(120, 21);
            this.cinemaNamePanel1.LocationX = 40;
            this.cinemaNamePanel1.LocationY = 8;
            this.cinemaNamePanel1.Margin = new System.Windows.Forms.Padding(729, 397, 729, 397);
            this.cinemaNamePanel1.Name = "cinemaNamePanel1";
            this.cinemaNamePanel1.Size = new System.Drawing.Size(14457, 133);
            this.cinemaNamePanel1.TabIndex = 2;
            // 
            // UserPayCheckPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "UserPayCheckPanel";
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ShowWelcomePanel showWelcomePanel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnConfirmPay;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.PictureBox picAdImage;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieInfo;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDate;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDateHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTimeHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRoom;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTime;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbSeats;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel7;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketPriceHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketCount;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketCountHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel12;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketTotalPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketTotalPriceHint;
        private HiPiaoTerminal.UserControlEx.CinemaNamePanel cinemaNamePanel1;
    }
}
