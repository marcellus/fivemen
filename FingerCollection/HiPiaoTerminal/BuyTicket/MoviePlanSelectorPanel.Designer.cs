namespace HiPiaoTerminal.BuyTicket
{
    partial class MoviePlanSelectorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoviePlanSelectorPanel));
            this.showWelcomePanel1 = new HiPiaoTerminal.BuyTicket.ShowWelcomePanel();
            this.lbName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbOtherName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDirector = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbScreenWriter = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMainActor = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbType = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbNational = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbLanguage = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbLength = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picMovieAdImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTomorrow = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnThreeDay = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnToday = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbProcessHint = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.processPanel1 = new FT.Windows.Controls.PanelEx.ProcessPanel();
            this.panelContent.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMovieAdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.lbProcessHint);
            this.panelContent.Controls.Add(this.processPanel1);
            this.panelContent.Controls.Add(this.lbLength);
            this.panelContent.Controls.Add(this.lbLanguage);
            this.panelContent.Controls.Add(this.lbNational);
            this.panelContent.Controls.Add(this.lbType);
            this.panelContent.Controls.Add(this.lbMainActor);
            this.panelContent.Controls.Add(this.lbScreenWriter);
            this.panelContent.Controls.Add(this.lbDirector);
            this.panelContent.Controls.Add(this.lbOtherName);
            this.panelContent.Controls.Add(this.lbName);
            this.panelContent.Controls.Add(this.picMovieAdImage);
            this.panelContent.Font = new System.Drawing.Font("方正兰亭纤黑简体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelContent.Location = new System.Drawing.Point(0, 144);
            this.panelContent.Size = new System.Drawing.Size(1280, 659);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Size = new System.Drawing.Size(1280, 144);
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
            this.showWelcomePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showWelcomePanel1.BackgroundImage")));
            this.showWelcomePanel1.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showWelcomePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.showWelcomePanel1.Location = new System.Drawing.Point(252, 30);
            this.showWelcomePanel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.showWelcomePanel1.Name = "showWelcomePanel1";
            this.showWelcomePanel1.Size = new System.Drawing.Size(527, 80);
            this.showWelcomePanel1.TabIndex = 3;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(245, 4);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(99, 32);
            this.lbName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbName.TabIndex = 1;
            this.lbName.Text = "label1";
            // 
            // lbOtherName
            // 
            this.lbOtherName.AutoSize = true;
            this.lbOtherName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOtherName.Location = new System.Drawing.Point(245, 33);
            this.lbOtherName.Name = "lbOtherName";
            this.lbOtherName.Size = new System.Drawing.Size(76, 27);
            this.lbOtherName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbOtherName.TabIndex = 1;
            this.lbOtherName.Text = "label1";
            // 
            // lbDirector
            // 
            this.lbDirector.AutoSize = true;
            this.lbDirector.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDirector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbDirector.Location = new System.Drawing.Point(245, 69);
            this.lbDirector.Name = "lbDirector";
            this.lbDirector.Size = new System.Drawing.Size(93, 22);
            this.lbDirector.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDirector.TabIndex = 1;
            this.lbDirector.Text = "导演：{0}";
            // 
            // lbScreenWriter
            // 
            this.lbScreenWriter.AutoSize = true;
            this.lbScreenWriter.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbScreenWriter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbScreenWriter.Location = new System.Drawing.Point(245, 91);
            this.lbScreenWriter.Name = "lbScreenWriter";
            this.lbScreenWriter.Size = new System.Drawing.Size(93, 22);
            this.lbScreenWriter.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbScreenWriter.TabIndex = 1;
            this.lbScreenWriter.Text = "编剧：{0}";
            // 
            // lbMainActor
            // 
            this.lbMainActor.AutoSize = true;
            this.lbMainActor.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMainActor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbMainActor.Location = new System.Drawing.Point(245, 113);
            this.lbMainActor.Name = "lbMainActor";
            this.lbMainActor.Size = new System.Drawing.Size(93, 22);
            this.lbMainActor.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMainActor.TabIndex = 1;
            this.lbMainActor.Text = "主演：{0}";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbType.Location = new System.Drawing.Point(245, 135);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(93, 22);
            this.lbType.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbType.TabIndex = 1;
            this.lbType.Text = "类型：{0}";
            // 
            // lbNational
            // 
            this.lbNational.AutoSize = true;
            this.lbNational.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNational.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbNational.Location = new System.Drawing.Point(245, 157);
            this.lbNational.Name = "lbNational";
            this.lbNational.Size = new System.Drawing.Size(93, 22);
            this.lbNational.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbNational.TabIndex = 1;
            this.lbNational.Text = "国家：{0}";
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbLanguage.Location = new System.Drawing.Point(245, 179);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(93, 22);
            this.lbLanguage.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbLanguage.TabIndex = 1;
            this.lbLanguage.Text = "语言：{0}";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Font = new System.Drawing.Font("方正兰亭纤黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.lbLength.Location = new System.Drawing.Point(245, 201);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(131, 22);
            this.lbLength.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbLength.TabIndex = 1;
            this.lbLength.Text = "片长：{0}分钟";
            // 
            // picMovieAdImage
            // 
            this.picMovieAdImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMovieAdImage.Location = new System.Drawing.Point(64, 11);
            this.picMovieAdImage.Name = "picMovieAdImage";
            this.picMovieAdImage.Size = new System.Drawing.Size(177, 240);
            this.picMovieAdImage.TabIndex = 0;
            this.picMovieAdImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Home;
            this.pictureBox2.Location = new System.Drawing.Point(0, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(243, 84);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1059, 40);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.TabStop = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Site_Select_Movie;
            this.pictureBox1.Location = new System.Drawing.Point(243, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(815, 83);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnTomorrow
            // 
            this.btnTomorrow.Font = new System.Drawing.Font("方正兰亭粗黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTomorrow.ForeColor = System.Drawing.Color.White;
            this.btnTomorrow.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnTomorrow.Location = new System.Drawing.Point(953, 30);
            this.btnTomorrow.Name = "btnTomorrow";
            this.btnTomorrow.Size = new System.Drawing.Size(118, 81);
            this.btnTomorrow.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnTomorrow.TabIndex = 6;
            this.btnTomorrow.Text = "   明天   {0}";
            this.btnTomorrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTomorrow.Click += new System.EventHandler(this.btnTomorrow_Click);
            // 
            // btnThreeDay
            // 
            this.btnThreeDay.Font = new System.Drawing.Font("方正兰亭粗黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnThreeDay.ForeColor = System.Drawing.Color.White;
            this.btnThreeDay.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnThreeDay.Location = new System.Drawing.Point(1101, 30);
            this.btnThreeDay.Name = "btnThreeDay";
            this.btnThreeDay.Size = new System.Drawing.Size(118, 81);
            this.btnThreeDay.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnThreeDay.TabIndex = 4;
            this.btnThreeDay.Text = "   后天   {0}";
            this.btnThreeDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThreeDay.Click += new System.EventHandler(this.btnThreeDay_Click);
            // 
            // btnToday
            // 
            this.btnToday.Font = new System.Drawing.Font("方正兰亭粗黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Image = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Select_Day_Today;
            this.btnToday.Location = new System.Drawing.Point(805, 30);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(118, 81);
            this.btnToday.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.btnToday.TabIndex = 5;
            this.btnToday.Text = "   今天   {0}";
            this.btnToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // lbProcessHint
            // 
            this.lbProcessHint.AutoSize = true;
            this.lbProcessHint.Font = new System.Drawing.Font("方正兰亭纤黑简体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProcessHint.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbProcessHint.Location = new System.Drawing.Point(404, 198);
            this.lbProcessHint.Name = "lbProcessHint";
            this.lbProcessHint.Size = new System.Drawing.Size(274, 24);
            this.lbProcessHint.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbProcessHint.TabIndex = 11;
            this.lbProcessHint.Text = "正在加载排期信息，请稍候";
            // 
            // processPanel1
            // 
            this.processPanel1.Location = new System.Drawing.Point(743, 192);
            this.processPanel1.Name = "processPanel1";
            this.processPanel1.Size = new System.Drawing.Size(179, 23);
            this.processPanel1.TabIndex = 10;
            // 
            // MoviePlanSelectorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "MoviePlanSelectorPanel";
            this.Load += new System.EventHandler(this.MoviePlanSelectorPanel_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMovieAdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ShowWelcomePanel showWelcomePanel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnTomorrow;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnToday;
        private FT.Windows.Controls.LabelEx.SimpleLabel btnThreeDay;
        private System.Windows.Forms.PictureBox picMovieAdImage;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbOtherName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDirector;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbLanguage;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbNational;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbType;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMainActor;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbScreenWriter;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbLength;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbProcessHint;
        private FT.Windows.Controls.PanelEx.ProcessPanel processPanel1;
    }
}
