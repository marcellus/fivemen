namespace HiPiaoTerminal.CommonForm
{
    partial class ConfirmForm
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
            this.lbMsg2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnSure = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg2
            // 
            this.lbMsg2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg2.Location = new System.Drawing.Point(4, 100);
            this.lbMsg2.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg2.Name = "lbMsg2";
            this.lbMsg2.Size = new System.Drawing.Size(544, 38);
            this.lbMsg2.TabIndex = 6;
            this.lbMsg2.Text = "label1";
            this.lbMsg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnCancel;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(329, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 57);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSure
            // 
            this.btnSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnSure;
            this.btnSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSure.Location = new System.Drawing.Point(89, 204);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(143, 57);
            this.btnSure.TabIndex = 7;
            this.btnSure.TabStop = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(553, 314);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lbMsg2);
            this.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "ConfirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfirmForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfirmForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMsg2;
        private System.Windows.Forms.PictureBox btnSure;
        private System.Windows.Forms.PictureBox btnClose;
    }
}