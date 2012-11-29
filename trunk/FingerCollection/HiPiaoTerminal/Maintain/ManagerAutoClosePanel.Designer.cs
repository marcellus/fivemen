namespace HiPiaoTerminal.Maintain
{
    partial class ManagerAutoClosePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerAutoClosePanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.txtOpenMinute = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.txtCloseHour = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.txtCloseMinute = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.checkClose = new FT.Windows.Controls.ButtonEx.CheckButton();
            this.checkOpen = new FT.Windows.Controls.ButtonEx.CheckButton();
            this.txtOpenHour = new HiPiaoTerminal.UserControlEx.NumberInputControl();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.btnCancelSave = new System.Windows.Forms.PictureBox();
            this.btnKeepSave = new System.Windows.Forms.PictureBox();
            this.lbReturnMsg = new FT.Windows.Controls.LabelEx.SimpleLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeepSave)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 68);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(341, 462);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(345, 55);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Location = new System.Drawing.Point(341, 270);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(345, 55);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(283, 357);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(180, 80);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.Location = new System.Drawing.Point(282, 538);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(180, 80);
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.Location = new System.Drawing.Point(480, 552);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(13, 40);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            // 
            // txtOpenMinute
            // 
            this.txtOpenMinute.BackColor = System.Drawing.SystemColors.Window;
            this.txtOpenMinute.Font = new System.Drawing.Font("宋体", 29F);
            this.txtOpenMinute.Location = new System.Drawing.Point(726, 534);
            this.txtOpenMinute.Margin = new System.Windows.Forms.Padding(10);
            this.txtOpenMinute.MaxNum = 60;
            this.txtOpenMinute.MinNum = 0;
            this.txtOpenMinute.MinNumPadLen = 2;
            this.txtOpenMinute.Name = "txtOpenMinute";
            this.txtOpenMinute.Size = new System.Drawing.Size(191, 92);
            this.txtOpenMinute.TabIndex = 8;
            this.txtOpenMinute.Visible = false;
            // 
            // txtCloseHour
            // 
            this.txtCloseHour.BackColor = System.Drawing.SystemColors.Window;
            this.txtCloseHour.Font = new System.Drawing.Font("宋体", 29F);
            this.txtCloseHour.Location = new System.Drawing.Point(506, 357);
            this.txtCloseHour.Margin = new System.Windows.Forms.Padding(10);
            this.txtCloseHour.MaxNum = 24;
            this.txtCloseHour.MinNum = 0;
            this.txtCloseHour.MinNumPadLen = 2;
            this.txtCloseHour.Name = "txtCloseHour";
            this.txtCloseHour.Size = new System.Drawing.Size(191, 92);
            this.txtCloseHour.TabIndex = 8;
            // 
            // txtCloseMinute
            // 
            this.txtCloseMinute.BackColor = System.Drawing.SystemColors.Window;
            this.txtCloseMinute.Font = new System.Drawing.Font("宋体", 29F);
            this.txtCloseMinute.Location = new System.Drawing.Point(726, 357);
            this.txtCloseMinute.Margin = new System.Windows.Forms.Padding(10);
            this.txtCloseMinute.MaxNum = 60;
            this.txtCloseMinute.MinNum = 0;
            this.txtCloseMinute.MinNumPadLen = 2;
            this.txtCloseMinute.Name = "txtCloseMinute";
            this.txtCloseMinute.Size = new System.Drawing.Size(191, 92);
            this.txtCloseMinute.TabIndex = 8;
            // 
            // checkClose
            // 
            this.checkClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkClose.BackgroundImage")));
            this.checkClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkClose.Checked = false;
            this.checkClose.Location = new System.Drawing.Point(282, 276);
            this.checkClose.Name = "checkClose";
            this.checkClose.Size = new System.Drawing.Size(38, 38);
            this.checkClose.TabIndex = 9;
            this.checkClose.UseVisualStyleBackColor = true;
            // 
            // checkOpen
            // 
            this.checkOpen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkOpen.BackgroundImage")));
            this.checkOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkOpen.Checked = false;
            this.checkOpen.Location = new System.Drawing.Point(283, 472);
            this.checkOpen.Name = "checkOpen";
            this.checkOpen.Size = new System.Drawing.Size(38, 38);
            this.checkOpen.TabIndex = 9;
            this.checkOpen.UseVisualStyleBackColor = true;
            this.checkOpen.Visible = false;
            // 
            // txtOpenHour
            // 
            this.txtOpenHour.BackColor = System.Drawing.SystemColors.Window;
            this.txtOpenHour.Font = new System.Drawing.Font("宋体", 29F);
            this.txtOpenHour.Location = new System.Drawing.Point(506, 534);
            this.txtOpenHour.Margin = new System.Windows.Forms.Padding(10);
            this.txtOpenHour.MaxNum = 24;
            this.txtOpenHour.MinNum = 0;
            this.txtOpenHour.MinNumPadLen = 2;
            this.txtOpenHour.Name = "txtOpenHour";
            this.txtOpenHour.Size = new System.Drawing.Size(191, 92);
            this.txtOpenHour.TabIndex = 8;
            this.txtOpenHour.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox8.BackgroundImage")));
            this.pictureBox8.Location = new System.Drawing.Point(700, 552);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(13, 40);
            this.pictureBox8.TabIndex = 6;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.BackgroundImage")));
            this.pictureBox9.Location = new System.Drawing.Point(480, 374);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(13, 40);
            this.pictureBox9.TabIndex = 6;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.BackgroundImage")));
            this.pictureBox10.Location = new System.Drawing.Point(700, 374);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(13, 40);
            this.pictureBox10.TabIndex = 6;
            this.pictureBox10.TabStop = false;
            // 
            // btnCancelSave
            // 
            this.btnCancelSave.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Cancel_Save;
            this.btnCancelSave.Location = new System.Drawing.Point(667, 700);
            this.btnCancelSave.Name = "btnCancelSave";
            this.btnCancelSave.Size = new System.Drawing.Size(220, 68);
            this.btnCancelSave.TabIndex = 19;
            this.btnCancelSave.TabStop = false;
            this.btnCancelSave.Click += new System.EventHandler(this.btnCancelSave_Click);
            // 
            // btnKeepSave
            // 
            this.btnKeepSave.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Keep_Save;
            this.btnKeepSave.Location = new System.Drawing.Point(394, 700);
            this.btnKeepSave.Name = "btnKeepSave";
            this.btnKeepSave.Size = new System.Drawing.Size(220, 68);
            this.btnKeepSave.TabIndex = 18;
            this.btnKeepSave.TabStop = false;
            this.btnKeepSave.Click += new System.EventHandler(this.btnKeepSave_Click);
            // 
            // lbReturnMsg
            // 
            this.lbReturnMsg.AutoSize = true;
            this.lbReturnMsg.BackColor = System.Drawing.SystemColors.Window;
            this.lbReturnMsg.Font = new System.Drawing.Font("方正兰亭黑简体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReturnMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbReturnMsg.Location = new System.Drawing.Point(324, 270);
            this.lbReturnMsg.Name = "lbReturnMsg";
            this.lbReturnMsg.Size = new System.Drawing.Size(0, 32);
            this.lbReturnMsg.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbReturnMsg.TabIndex = 20;
            // 
            // ManagerAutoClosePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbReturnMsg);
            this.Controls.Add(this.checkOpen);
            this.Controls.Add(this.txtOpenHour);
            this.Controls.Add(this.checkClose);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.txtCloseHour);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtCloseMinute);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.txtOpenMinute);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.btnKeepSave);
            this.Controls.Add(this.btnCancelSave);
            this.Name = "ManagerAutoClosePanel";
            this.Load += new System.EventHandler(this.ManagerAutoClosePanel_Load);
            this.Controls.SetChildIndex(this.btnCancelSave, 0);
            this.Controls.SetChildIndex(this.btnKeepSave, 0);
            this.Controls.SetChildIndex(this.pictureBox10, 0);
            this.Controls.SetChildIndex(this.pictureBox8, 0);
            this.Controls.SetChildIndex(this.pictureBox9, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.txtOpenMinute, 0);
            this.Controls.SetChildIndex(this.pictureBox7, 0);
            this.Controls.SetChildIndex(this.txtCloseMinute, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.txtCloseHour, 0);
            this.Controls.SetChildIndex(this.pictureBox6, 0);
            this.Controls.SetChildIndex(this.checkClose, 0);
            this.Controls.SetChildIndex(this.txtOpenHour, 0);
            this.Controls.SetChildIndex(this.checkOpen, 0);
            this.Controls.SetChildIndex(this.lbReturnMsg, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeepSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtOpenMinute;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtCloseHour;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtCloseMinute;
        private FT.Windows.Controls.ButtonEx.CheckButton checkClose;
        private FT.Windows.Controls.ButtonEx.CheckButton checkOpen;
        private HiPiaoTerminal.UserControlEx.NumberInputControl txtOpenHour;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox btnCancelSave;
        private System.Windows.Forms.PictureBox btnKeepSave;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbReturnMsg;
    }
}
