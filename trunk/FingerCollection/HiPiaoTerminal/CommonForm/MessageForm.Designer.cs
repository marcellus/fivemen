namespace HiPiaoTerminal.CommonForm
{
    partial class MessageForm
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
            this.lbMsg2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMsg1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picSure = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg2
            // 
            this.lbMsg2.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg2.Location = new System.Drawing.Point(2, 103);
            this.lbMsg2.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg2.Name = "lbMsg2";
            this.lbMsg2.Size = new System.Drawing.Size(544, 38);
            this.lbMsg2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg2.TabIndex = 5;
            this.lbMsg2.Text = "label1";
            this.lbMsg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMsg1
            // 
            this.lbMsg1.Font = new System.Drawing.Font("方正兰亭纤黑简体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg1.Location = new System.Drawing.Point(2, 45);
            this.lbMsg1.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg1.Name = "lbMsg1";
            this.lbMsg1.Size = new System.Drawing.Size(544, 38);
            this.lbMsg1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg1.TabIndex = 6;
            this.lbMsg1.Text = "网络故障，请向影院工作人员垂询！";
            this.lbMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSure
            // 
            this.picSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnSure;
            this.picSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSure.Location = new System.Drawing.Point(162, 182);
            this.picSure.Margin = new System.Windows.Forms.Padding(27, 32, 27, 32);
            this.picSure.Name = "picSure";
            this.picSure.Size = new System.Drawing.Size(189, 77);
            this.picSure.TabIndex = 4;
            this.picSure.TabStop = false;
            this.picSure.Click += new System.EventHandler(this.picSure_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.lbMsg2);
            this.Controls.Add(this.lbMsg1);
            this.Controls.Add(this.picSure);
            this.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg2;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg1;
        private System.Windows.Forms.PictureBox picSure;
    }
}