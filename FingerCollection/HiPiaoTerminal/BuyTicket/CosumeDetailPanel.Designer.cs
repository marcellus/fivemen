namespace HiPiaoTerminal.BuyTicket
{
    partial class CosumeDetailPanel
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
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbCinema = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbNum = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbDate = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbRoom = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbAllFee = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbAccountMoney = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Location = new System.Drawing.Point(258, 54);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(0, 12);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 0;
            // 
            // lbCinema
            // 
            this.lbCinema.AutoSize = true;
            this.lbCinema.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCinema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbCinema.Location = new System.Drawing.Point(231, 111);
            this.lbCinema.Name = "lbCinema";
            this.lbCinema.Size = new System.Drawing.Size(111, 27);
            this.lbCinema.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbCinema.TabIndex = 0;
            this.lbCinema.Text = "影院：{0}";
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbMovieName.Location = new System.Drawing.Point(231, 152);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(141, 27);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 0;
            this.lbMovieName.Text = "影片：{0}{1}";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbNum.Location = new System.Drawing.Point(231, 232);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(118, 27);
            this.lbNum.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbNum.TabIndex = 0;
            this.lbNum.Text = "票张:{0}张";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbDate.Location = new System.Drawing.Point(231, 191);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(208, 27);
            this.lbDate.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "日期/时间/：{0}/{1}";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbRoom.Location = new System.Drawing.Point(231, 273);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(185, 27);
            this.lbRoom.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbRoom.TabIndex = 0;
            this.lbRoom.Text = "影厅/座位:{0}/{1}";
            // 
            // lbAllFee
            // 
            this.lbAllFee.AutoSize = true;
            this.lbAllFee.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAllFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbAllFee.Location = new System.Drawing.Point(231, 314);
            this.lbAllFee.Name = "lbAllFee";
            this.lbAllFee.Size = new System.Drawing.Size(180, 27);
            this.lbAllFee.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbAllFee.TabIndex = 0;
            this.lbAllFee.Text = "消费金额：{0}元";
            // 
            // lbAccountMoney
            // 
            this.lbAccountMoney.AutoSize = true;
            this.lbAccountMoney.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAccountMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(124)))), ((int)(((byte)(123)))));
            this.lbAccountMoney.Location = new System.Drawing.Point(231, 355);
            this.lbAccountMoney.Name = "lbAccountMoney";
            this.lbAccountMoney.Size = new System.Drawing.Size(180, 27);
            this.lbAccountMoney.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbAccountMoney.TabIndex = 0;
            this.lbAccountMoney.Text = "账户余额：{0}元";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(-15, -15);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_CosumeDetail_Sure;
            this.pictureBox1.Location = new System.Drawing.Point(291, 450);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 111);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_CosumeDetail_Hint;
            this.pictureBox2.Location = new System.Drawing.Point(325, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 71);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // CosumeDetailPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.lbMovieName);
            this.Controls.Add(this.lbCinema);
            this.Controls.Add(this.lbAccountMoney);
            this.Controls.Add(this.lbAllFee);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.simpleLabel1);
            this.Name = "CosumeDetailPanel";
            this.Size = new System.Drawing.Size(875, 594);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbCinema;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbNum;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbDate;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbRoom;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbAllFee;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbAccountMoney;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
