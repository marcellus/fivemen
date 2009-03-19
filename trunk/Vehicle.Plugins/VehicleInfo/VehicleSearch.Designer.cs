namespace Vehicle.Plugins
{
    partial class VehicleSearch
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.直接打申请表F1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印二维条码F3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.直接打申请表F1ToolStripMenuItem,
            this.打印二维条码F3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "套打-申请表（F1）";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 直接打申请表F1ToolStripMenuItem
            // 
            this.直接打申请表F1ToolStripMenuItem.Name = "直接打申请表F1ToolStripMenuItem";
            this.直接打申请表F1ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.直接打申请表F1ToolStripMenuItem.Text = "直接打－申请表（F2）";
            this.直接打申请表F1ToolStripMenuItem.Click += new System.EventHandler(this.直接打申请表F1ToolStripMenuItem_Click);
            // 
            // 打印二维条码F3ToolStripMenuItem
            // 
            this.打印二维条码F3ToolStripMenuItem.Name = "打印二维条码F3ToolStripMenuItem";
            this.打印二维条码F3ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.打印二维条码F3ToolStripMenuItem.Text = "打印－二维条码（F3）";
            this.打印二维条码F3ToolStripMenuItem.Click += new System.EventHandler(this.打印二维条码F3ToolStripMenuItem_Click);
            // 
            // VehicleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "VehicleSearch";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 直接打申请表F1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印二维条码F3ToolStripMenuItem;
    }
}
