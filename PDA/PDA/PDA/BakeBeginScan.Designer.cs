namespace PDA
{
    partial class BakeBeginScan
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
            this.txt_Detail = new System.Windows.Forms.TextBox();
            this.txt_Disk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Detail
            // 
            this.txt_Detail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Detail.Location = new System.Drawing.Point(8, 39);
            this.txt_Detail.Multiline = true;
            this.txt_Detail.Name = "txt_Detail";
            this.txt_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Detail.Size = new System.Drawing.Size(222, 201);
            this.txt_Detail.TabIndex = 6;
            // 
            // txt_Disk
            // 
            this.txt_Disk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_Disk.Location = new System.Drawing.Point(65, 11);
            this.txt_Disk.Name = "txt_Disk";
            this.txt_Disk.Size = new System.Drawing.Size(165, 21);
            this.txt_Disk.TabIndex = 5;
            this.txt_Disk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Disk_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "料盘：";
            // 
            // BakeBeginScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(238, 270);
            this.Controls.Add(this.txt_Detail);
            this.Controls.Add(this.txt_Disk);
            this.Controls.Add(this.label1);
            this.Name = "BakeBeginScan";
            this.Text = "开始烘烤扫描";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Detail;
        private System.Windows.Forms.TextBox txt_Disk;
        private System.Windows.Forms.Label label1;
    }
}