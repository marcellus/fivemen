namespace PDA
{
    partial class PickSelect
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
            this.btn_ScanNewPick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ReadTempFile
            // 
            this.btn_ReadTempFile.BackColor = System.Drawing.Color.Beige;
            this.btn_ReadTempFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_ReadTempFile.Location = new System.Drawing.Point(39, 45);
            this.btn_ReadTempFile.Name = "btn_ReadTempFile";
            this.btn_ReadTempFile.Size = new System.Drawing.Size(159, 40);
            this.btn_ReadTempFile.TabIndex = 0;
            this.btn_ReadTempFile.Text = "读取临时文件";
            this.btn_ReadTempFile.Click += new System.EventHandler(this.btn_ReadTempFile_Click);
            // 
            // btn_ScanNewPick
            // 
            this.btn_ScanNewPick.BackColor = System.Drawing.Color.Beige;
            this.btn_ScanNewPick.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btn_ScanNewPick.Location = new System.Drawing.Point(39, 157);
            this.btn_ScanNewPick.Name = "btn_ScanNewPick";
            this.btn_ScanNewPick.Size = new System.Drawing.Size(159, 40);
            this.btn_ScanNewPick.TabIndex = 1;
            this.btn_ScanNewPick.Text = "扫描新拣货单";
            this.btn_ScanNewPick.Click += new System.EventHandler(this.btn_ScanNewPick_Click);
            // 
            // PickSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.btn_ScanNewPick);
            this.Controls.Add(this.btn_ReadTempFile);
            this.Name = "PickSelect";
            this.Text = "拣货";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ReadTempFile;
        private System.Windows.Forms.Button btn_ScanNewPick;
    }
}