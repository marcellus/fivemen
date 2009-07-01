namespace FT.Windows.Forms
{
    partial class CaptureImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureImage));
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelSelect = new System.Windows.Forms.Label();
            this.panelSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSource
            // 
            this.panelSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSource.Controls.Add(this.panelSelect);
            this.panelSource.Location = new System.Drawing.Point(48, 15);
            this.panelSource.Margin = new System.Windows.Forms.Padding(4);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(256, 192);
            this.panelSource.TabIndex = 0;
            // 
            // panelSelect
            // 
            this.panelSelect.BackColor = System.Drawing.Color.Transparent;
            this.panelSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelect.Location = new System.Drawing.Point(67, 8);
            this.panelSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(133, 173);
            this.panelSelect.TabIndex = 3;
            this.panelSelect.DoubleClick += new System.EventHandler(this.panelSelect_DoubleClick);
            this.panelSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSelect_MouseDown);
            this.panelSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSelect_MouseMove);
            this.panelSelect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSelect_MouseUp);
            // 
            // CaptureImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 236);
            this.Controls.Add(this.panelSource);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureImage";
            this.ShowInTaskbar = false;
            this.Text = "图片裁剪窗口";
            this.Load += new System.EventHandler(this.CaptureImage_Load);
            this.panelSource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Label panelSelect;
    }
}