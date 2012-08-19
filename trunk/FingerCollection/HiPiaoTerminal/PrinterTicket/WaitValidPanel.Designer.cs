namespace HiPiaoTerminal.PrinterTicket
{
    partial class WaitValidPanel
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
            this.components = new System.ComponentModel.Container();
            this.processPanel1 = new FT.Windows.Controls.PanelEx.ProcessPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // processPanel1
            // 
            this.processPanel1.Location = new System.Drawing.Point(184, 364);
            this.processPanel1.Name = "processPanel1";
            this.processPanel1.Size = new System.Drawing.Size(186, 23);
            this.processPanel1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Print_Wait_Valid;
            this.pictureBox1.Location = new System.Drawing.Point(88, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(437, 349);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WaitValidPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.processPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "WaitValidPanel";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.WaitValidPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private FT.Windows.Controls.PanelEx.ProcessPanel processPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}
