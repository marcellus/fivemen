namespace HiPiaoTerminal.BuyTicket
{
    partial class FullScreenSeatSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPrice = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieDetail = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMovieName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPlanInfo = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnSure = new System.Windows.Forms.PictureBox();
            this.panelSeats = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(175)))), ((int)(((byte)(17)))));
            this.label3.Font = new System.Drawing.Font("方正兰亭黑简体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(82, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1105, 29);
            this.label3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label3.TabIndex = 16;
            this.label3.Text = "屏幕";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.lbPrice.Location = new System.Drawing.Point(1021, 46);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(120, 32);
            this.lbPrice.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPrice.TabIndex = 15;
            this.lbPrice.Text = "{0}元/张";
            this.lbPrice.Click += new System.EventHandler(this.lbPrice_Click);
            // 
            // lbMovieDetail
            // 
            this.lbMovieDetail.AutoSize = true;
            this.lbMovieDetail.Font = new System.Drawing.Font("方正兰亭黑简体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieDetail.ForeColor = System.Drawing.Color.White;
            this.lbMovieDetail.Location = new System.Drawing.Point(454, 51);
            this.lbMovieDetail.Name = "lbMovieDetail";
            this.lbMovieDetail.Size = new System.Drawing.Size(135, 22);
            this.lbMovieDetail.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieDetail.TabIndex = 14;
            this.lbMovieDetail.Text = "{0} {1} {2}分钟";
            // 
            // lbMovieName
            // 
            this.lbMovieName.AutoSize = true;
            this.lbMovieName.Font = new System.Drawing.Font("方正兰亭粗黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMovieName.ForeColor = System.Drawing.Color.White;
            this.lbMovieName.Location = new System.Drawing.Point(186, 46);
            this.lbMovieName.Name = "lbMovieName";
            this.lbMovieName.Size = new System.Drawing.Size(99, 32);
            this.lbMovieName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMovieName.TabIndex = 13;
            this.lbMovieName.Text = "电影名";
            // 
            // lbPlanInfo
            // 
            this.lbPlanInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbPlanInfo.Font = new System.Drawing.Font("方正兰亭黑简体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPlanInfo.Location = new System.Drawing.Point(6, 2);
            this.lbPlanInfo.Name = "lbPlanInfo";
            this.lbPlanInfo.Size = new System.Drawing.Size(247, 32);
            this.lbPlanInfo.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPlanInfo.TabIndex = 18;
            this.lbPlanInfo.Text = "{0} {1} {2}";
            this.lbPlanInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_PlanDetail;
            this.panel1.Controls.Add(this.lbPlanInfo);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(721, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 42);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Hint;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1128, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 97);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Cancel;
            this.btnCancel.ErrorImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Sure;
            this.btnCancel.Location = new System.Drawing.Point(673, 652);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(284, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Sure;
            this.btnSure.ErrorImage = global::HiPiaoTerminal.Properties.Resources.BuyTicket_FullScreen_Sure;
            this.btnSure.Location = new System.Drawing.Point(325, 652);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(284, 54);
            this.btnSure.TabIndex = 0;
            this.btnSure.TabStop = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // panelSeats
            // 
            this.panelSeats.AutoScroll = true;
            this.panelSeats.Location = new System.Drawing.Point(82, 144);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(1040, 488);
            this.panelSeats.TabIndex = 20;
            // 
            // FullScreenSeatSelectorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1272, 746);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbMovieDetail);
            this.Controls.Add(this.lbMovieName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenSeatSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FullScreenSeatSelectorForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnSure;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.LabelEx.SimpleLabel label3;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPrice;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieDetail;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMovieName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPlanInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSeats;
    }
}