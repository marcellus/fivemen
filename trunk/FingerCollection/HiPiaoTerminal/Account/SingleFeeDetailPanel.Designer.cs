namespace HiPiaoTerminal.Account
{
    partial class SingleFeeDetailPanel
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbDate = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbNum = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbCinema = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbAllFee = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRoom = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_CosumeDetail_Hint;
            this.pictureBox2.Location = new System.Drawing.Point(334, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 71);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_FeeDetail_Return;
            this.pictureBox1.Location = new System.Drawing.Point(300, 449);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 111);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbDate.Location = new System.Drawing.Point(180, 191);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(173, 27);
            this.lbDate.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDate.TabIndex = 8;
            this.lbDate.Text = "日期/时间：{0}";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbNum.Location = new System.Drawing.Point(180, 232);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(125, 27);
            this.lbNum.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbNum.TabIndex = 9;
            this.lbNum.Text = "票张:{0}张";
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbMovieName.Location = new System.Drawing.Point(180, 152);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(150, 27);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 7;
            this.lbMovieName.Text = "影片：{0}{1}";
            // 
            // lbCinema
            // 
            this.lbCinema.AutoSize = true;
            this.lbCinema.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCinema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbCinema.Location = new System.Drawing.Point(180, 111);
            this.lbCinema.Name = "lbCinema";
            this.lbCinema.Size = new System.Drawing.Size(117, 27);
            this.lbCinema.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbCinema.TabIndex = 3;
            this.lbCinema.Text = "影院：{0}";
            // 
            // lbAllFee
            // 
            this.lbAllFee.AutoSize = true;
            this.lbAllFee.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAllFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbAllFee.Location = new System.Drawing.Point(180, 314);
            this.lbAllFee.Name = "lbAllFee";
            this.lbAllFee.Size = new System.Drawing.Size(189, 27);
            this.lbAllFee.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbAllFee.TabIndex = 5;
            this.lbAllFee.Text = "消费金额：{0}元";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbRoom.Location = new System.Drawing.Point(180, 273);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(214, 27);
            this.lbRoom.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRoom.TabIndex = 4;
            this.lbRoom.Text = "影厅/座位：{0}/{1}";
            // 
            // SingleFeeDetailPanel
            // 
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.lbMovieName);
            this.Controls.Add(this.lbCinema);
            this.Controls.Add(this.lbAllFee);
            this.Controls.Add(this.lbRoom);
            this.Name = "SingleFeeDetailPanel";
            this.Size = new System.Drawing.Size(875, 594);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDate;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbNum;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbCinema;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbAllFee;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRoom;
    }
}
