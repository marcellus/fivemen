namespace HiPiaoTerminal.BuyTicket
{
    partial class MovieSelectorPanel
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
            this.showWelcomePanel1 = new HiPiaoTerminal.BuyTicket.ShowWelcomePanel();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTomorrow = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnThreeDay = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnToday = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
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
            this.splitContainer1.Panel2.Controls.Add(this.btnTomorrow);
            this.splitContainer1.Panel2.Controls.Add(this.btnThreeDay);
            this.splitContainer1.Panel2.Controls.Add(this.btnToday);
            this.splitContainer1.Panel2.Controls.Add(this.showWelcomePanel1);
            this.splitContainer1.SplitterDistance = 821;
            // 
            // showWelcomePanel1
            // 
            this.showWelcomePanel1.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showWelcomePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.showWelcomePanel1.Location = new System.Drawing.Point(237, 31);
            this.showWelcomePanel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.showWelcomePanel1.Name = "showWelcomePanel1";
            this.showWelcomePanel1.Size = new System.Drawing.Size(530, 80);
            this.showWelcomePanel1.TabIndex = 1;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1068, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Select_Movie;
            this.pictureBox1.Location = new System.Drawing.Point(243, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(815, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Home;
            this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 84);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnTomorrow
            // 
            this.btnTomorrow.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTomorrow.ForeColor = System.Drawing.Color.White;
            this.btnTomorrow.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnTomorrow.Location = new System.Drawing.Point(971, 31);
            this.btnTomorrow.Name = "btnTomorrow";
            this.btnTomorrow.Size = new System.Drawing.Size(118, 81);
            this.btnTomorrow.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnTomorrow.TabIndex = 9;
            this.btnTomorrow.Text = "   明天   {0}";
            this.btnTomorrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThreeDay
            // 
            this.btnThreeDay.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnThreeDay.ForeColor = System.Drawing.Color.White;
            this.btnThreeDay.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnThreeDay.Location = new System.Drawing.Point(1115, 31);
            this.btnThreeDay.Name = "btnThreeDay";
            this.btnThreeDay.Size = new System.Drawing.Size(118, 81);
            this.btnThreeDay.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnThreeDay.TabIndex = 7;
            this.btnThreeDay.Text = "   后天   {0}";
            this.btnThreeDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnToday
            // 
            this.btnToday.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Today;
            this.btnToday.Location = new System.Drawing.Point(827, 31);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(118, 81);
            this.btnToday.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnToday.TabIndex = 8;
            this.btnToday.Text = "   今天   {0}";
            this.btnToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MovieSelectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.Name = "MovieSelectorPanel";
            this.Load += new System.EventHandler(this.MovieSelectorPanel_Load);
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShowWelcomePanel showWelcomePanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnTomorrow;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnThreeDay;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnToday;
    }
}
