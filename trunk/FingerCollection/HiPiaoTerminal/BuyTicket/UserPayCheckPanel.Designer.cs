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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.showWelcomePanel1 = new HiPiaoTerminal.BuyTicket.ShowWelcomePanel();
            this.btnConfirmPay = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(0, 261);
            this.panelContent.Size = new System.Drawing.Size(1280, 542);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.btnReturn);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.btnHome);
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirmPay);
            this.splitContainer1.Panel2.Controls.Add(this.showWelcomePanel1);
            this.splitContainer1.SplitterDistance = 821;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_Check_Hint;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1280, 136);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Register_ReturnBack;
            this.btnReturn.Location = new System.Drawing.Point(1098, 33);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(160, 83);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_CheckInfo_Hint;
            this.pictureBox1.Location = new System.Drawing.Point(244, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(814, 83);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_ReturnHome;
            this.btnHome.Location = new System.Drawing.Point(0, 33);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(248, 83);
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // showWelcomePanel1
            // 
            this.showWelcomePanel1.BackColor = System.Drawing.SystemColors.Control;
            this.showWelcomePanel1.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showWelcomePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.showWelcomePanel1.Location = new System.Drawing.Point(244, 31);
            this.showWelcomePanel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.showWelcomePanel1.Name = "showWelcomePanel1";
            this.showWelcomePanel1.Size = new System.Drawing.Size(530, 80);
            this.showWelcomePanel1.TabIndex = 0;
            // 
            // btnConfirmPay
            // 
            this.btnConfirmPay.Font = new System.Drawing.Font("方正兰亭黑简体", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmPay.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPay.Image = global::HiPiaoTerminal.Properties.Resources.Account_FeeDetail_DateHeaderHint;
            this.btnConfirmPay.Location = new System.Drawing.Point(969, 36);
            this.btnConfirmPay.Name = "btnConfirmPay";
            this.btnConfirmPay.Size = new System.Drawing.Size(220, 70);
            this.btnConfirmPay.TabIndex = 1;
            this.btnConfirmPay.Text = "确认支付";
            this.btnConfirmPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirmPay.Click += new System.EventHandler(this.btnConfirmPay_Click);
            // 
            // UserPayCheckPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 32F);
            this.Name = "UserPayCheckPanel";
            this.panelHeader.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Label btnConfirmPay;
    }
}
