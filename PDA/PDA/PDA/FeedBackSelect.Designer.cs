namespace PDA
{
    partial class FeedBackSelect
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
            this.btn_ReadTempFile = new System.Windows.Forms.Button();
            this.btn_NewFeedBackBill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ReadTempFile
            // 
            this.btn_ReadTempFile.BackColor = System.Drawing.Color.Beige;
            this.btn_ReadTempFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_ReadTempFile.Location = new System.Drawing.Point(38, 46);
            this.btn_ReadTempFile.Name = "btn_ReadTempFile";
            this.btn_ReadTempFile.Size = new System.Drawing.Size(159, 40);
            this.btn_ReadTempFile.TabIndex = 0;
            this.btn_ReadTempFile.Text = "读取临时文件";
            this.btn_ReadTempFile.Click += new System.EventHandler(this.btn_ReadTempFile_Click);
            // 
            // btn_NewFeedBackBill
            // 
            this.btn_NewFeedBackBill.BackColor = System.Drawing.Color.Beige;
            this.btn_NewFeedBackBill.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_NewFeedBackBill.Location = new System.Drawing.Point(38, 151);
            this.btn_NewFeedBackBill.Name = "btn_NewFeedBackBill";
            this.btn_NewFeedBackBill.Size = new System.Drawing.Size(159, 40);
            this.btn_NewFeedBackBill.TabIndex = 1;
            this.btn_NewFeedBackBill.Text = "新退料单";
            this.btn_NewFeedBackBill.Click += new System.EventHandler(this.btn_NewFeedBackBill_Click);
            // 
            // FeedBackSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.btn_NewFeedBackBill);
            this.Controls.Add(this.btn_ReadTempFile);
            this.Name = "FeedBackSelect";
            this.Text = "退料清点";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ReadTempFile;
        private System.Windows.Forms.Button btn_NewFeedBackBill;
    }
}