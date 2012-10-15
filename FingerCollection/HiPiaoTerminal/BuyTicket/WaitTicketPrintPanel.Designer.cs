namespace HiPiaoTerminal.BuyTicket
{
    partial class WaitTicketPrintPanel
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.lbTotalPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTotalNum = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTicketPriceHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTimeHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDateHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieInfo = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRoom = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbTime = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDate = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbSeats = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picAdImage = new System.Windows.Forms.PictureBox();
            this.adShowPanel1 = new HiPiaoTerminal.UserControlEx.AdShowPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.processPanel1 = new FT.Windows.Controls.PanelEx.ProcessPanel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.panelContent.Controls.Add(this.adShowPanel1);
            this.panelContent.Location = new System.Drawing.Point(0, 241);
            this.panelContent.Size = new System.Drawing.Size(1280, 586);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelDetail);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.btnHome);
            this.panelHeader.Size = new System.Drawing.Size(1220, 241);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel2.Controls.Add(this.processPanel1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(60, 109);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 32);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "正在打印";
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDetail.Controls.Add(this.lbTotalPrice);
            this.panelDetail.Controls.Add(this.lbPrice);
            this.panelDetail.Controls.Add(this.lbTotalNum);
            this.panelDetail.Controls.Add(this.simpleLabel3);
            this.panelDetail.Controls.Add(this.simpleLabel2);
            this.panelDetail.Controls.Add(this.label2);
            this.panelDetail.Controls.Add(this.lbTicketPriceHint);
            this.panelDetail.Controls.Add(this.lbTimeHint);
            this.panelDetail.Controls.Add(this.lbDateHint);
            this.panelDetail.Controls.Add(this.lbMovieInfo);
            this.panelDetail.Controls.Add(this.lbRoom);
            this.panelDetail.Controls.Add(this.lbTime);
            this.panelDetail.Controls.Add(this.lbDate);
            this.panelDetail.Controls.Add(this.lbSeats);
            this.panelDetail.Controls.Add(this.lbMovieName);
            this.panelDetail.Controls.Add(this.picAdImage);
            this.panelDetail.Location = new System.Drawing.Point(59, 144);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1160, 90);
            this.panelDetail.TabIndex = 6;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPrice.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTotalPrice.Location = new System.Drawing.Point(1001, 48);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(79, 32);
            this.lbTotalPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTotalPrice.TabIndex = 5;
            this.lbTotalPrice.Text = "0.00";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(875, 17);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(51, 32);
            this.lbPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPrice.TabIndex = 6;
            this.lbPrice.Text = "00";
            // 
            // lbTotalNum
            // 
            this.lbTotalNum.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalNum.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTotalNum.Location = new System.Drawing.Point(1031, 17);
            this.lbTotalNum.Name = "lbTotalNum";
            this.lbTotalNum.Size = new System.Drawing.Size(52, 32);
            this.lbTotalNum.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTotalNum.TabIndex = 6;
            this.lbTotalNum.Text = "00";
            // 
            // simpleLabel3
            // 
            this.simpleLabel3.AutoSize = true;
            this.simpleLabel3.BackColor = System.Drawing.Color.Transparent;
            this.simpleLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.simpleLabel3.Location = new System.Drawing.Point(1076, 49);
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Size = new System.Drawing.Size(43, 32);
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel3.TabIndex = 3;
            this.simpleLabel3.Text = "元";
            // 
            // simpleLabel2
            // 
            this.simpleLabel2.AutoSize = true;
            this.simpleLabel2.BackColor = System.Drawing.Color.Transparent;
            this.simpleLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.simpleLabel2.Location = new System.Drawing.Point(1076, 17);
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Size = new System.Drawing.Size(43, 32);
            this.simpleLabel2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel2.TabIndex = 4;
            this.simpleLabel2.Text = "张";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label2.Location = new System.Drawing.Point(875, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 32);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 3;
            this.label2.Text = "合计：";
            // 
            // lbTicketPriceHint
            // 
            this.lbTicketPriceHint.AutoSize = true;
            this.lbTicketPriceHint.BackColor = System.Drawing.Color.Transparent;
            this.lbTicketPriceHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbTicketPriceHint.Location = new System.Drawing.Point(922, 17);
            this.lbTicketPriceHint.Name = "lbTicketPriceHint";
            this.lbTicketPriceHint.Size = new System.Drawing.Size(115, 32);
            this.lbTicketPriceHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTicketPriceHint.TabIndex = 4;
            this.lbTicketPriceHint.Text = "元/张 共";
            // 
            // lbTimeHint
            // 
            this.lbTimeHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lbTimeHint.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimeHint.Location = new System.Drawing.Point(670, 14);
            this.lbTimeHint.Name = "lbTimeHint";
            this.lbTimeHint.Size = new System.Drawing.Size(5, 32);
            this.lbTimeHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTimeHint.TabIndex = 2;
            this.lbTimeHint.Text = "simpleLabel2";
            // 
            // lbDateHint
            // 
            this.lbDateHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lbDateHint.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDateHint.Location = new System.Drawing.Point(484, 14);
            this.lbDateHint.Name = "lbDateHint";
            this.lbDateHint.Size = new System.Drawing.Size(5, 32);
            this.lbDateHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDateHint.TabIndex = 2;
            this.lbDateHint.Text = "simpleLabel2";
            // 
            // lbMovieInfo
            // 
            this.lbMovieInfo.AutoSize = true;
            this.lbMovieInfo.Font = new System.Drawing.Font("方正兰亭黑简体", 14F);
            this.lbMovieInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbMovieInfo.Location = new System.Drawing.Point(76, 56);
            this.lbMovieInfo.Name = "lbMovieInfo";
            this.lbMovieInfo.Size = new System.Drawing.Size(125, 22);
            this.lbMovieInfo.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieInfo.TabIndex = 1;
            this.lbMovieInfo.Text = "{0}{1}{2}分钟";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbRoom.Location = new System.Drawing.Point(701, 14);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(73, 33);
            this.lbRoom.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRoom.TabIndex = 1;
            this.lbRoom.Text = "影厅";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbTime.Location = new System.Drawing.Point(522, 14);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(131, 33);
            this.lbTime.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "播放时间";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbDate.Location = new System.Drawing.Point(332, 14);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(149, 33);
            this.lbDate.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDate.TabIndex = 1;
            this.lbDate.Text = "1播放时间";
            // 
            // lbSeats
            // 
            this.lbSeats.AutoSize = true;
            this.lbSeats.Font = new System.Drawing.Font("方正兰亭黑简体", 16F);
            this.lbSeats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.lbSeats.Location = new System.Drawing.Point(332, 52);
            this.lbSeats.Name = "lbSeats";
            this.lbSeats.Size = new System.Drawing.Size(107, 26);
            this.lbSeats.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbSeats.TabIndex = 1;
            this.lbSeats.Text = "座位：{0}";
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbMovieName.Location = new System.Drawing.Point(76, 14);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(351, 32);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 1;
            this.lbMovieName.Text = "电影名称电影名称电影名称";
            // 
            // picAdImage
            // 
            this.picAdImage.Location = new System.Drawing.Point(4, 4);
            this.picAdImage.Name = "picAdImage";
            this.picAdImage.Size = new System.Drawing.Size(58, 80);
            this.picAdImage.TabIndex = 0;
            this.picAdImage.TabStop = false;
            // 
            // adShowPanel1
            // 
            this.adShowPanel1.AdType = "所有位置";
            this.adShowPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.adShowPanel1.Interval = 500;
            this.adShowPanel1.Location = new System.Drawing.Point(63, 0);
            this.adShowPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.adShowPanel1.Name = "adShowPanel1";
            this.adShowPanel1.Size = new System.Drawing.Size(1155, 584);
            this.adShowPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_Print_Hint_Process;
            this.pictureBox2.ErrorImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_Print_Hint_Process;
            this.pictureBox2.Location = new System.Drawing.Point(225, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(842, 76);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_PaySuccess_Return;
            this.btnReturn.Location = new System.Drawing.Point(1060, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_PaySuccess_Site;
            this.pictureBox1.Location = new System.Drawing.Point(248, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 83);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_PaySuccess_Home;
            this.btnHome.Location = new System.Drawing.Point(60, 40);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(190, 83);
            this.btnHome.TabIndex = 3;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // processPanel1
            // 
            this.processPanel1.Location = new System.Drawing.Point(526, 104);
            this.processPanel1.Name = "processPanel1";
            this.processPanel1.Size = new System.Drawing.Size(186, 23);
            this.processPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(19, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 3;
            // 
            // WaitTicketPrintPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.linkLabel1);
            this.Margin = new System.Windows.Forms.Padding(27, 21, 27, 21);
            this.Name = "WaitTicketPrintPanel";
            this.Load += new System.EventHandler(this.WaitTicketPrintPanel_Load);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.panelContent.ResumeLayout(false);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelDetail;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTimeHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDateHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieInfo;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRoom;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTime;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDate;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbSeats;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private System.Windows.Forms.PictureBox picAdImage;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTotalPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTotalNum;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbTicketPriceHint;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel2;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
        private HiPiaoTerminal.UserControlEx.AdShowPanel adShowPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FT.Windows.Controls.PanelEx.ProcessPanel processPanel1;
        private System.Windows.Forms.Panel panel2;
    }
}
