namespace FT.Commons
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            this.button1 = new System.Windows.Forms.Button();
            this.lbHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbHint
            // 
            this.lbHint.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.lbHint.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbHint.Location = new System.Drawing.Point(9, 9);
            this.lbHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(277, 67);
            this.lbHint.TabIndex = 1;
            this.lbHint.Text = "label1";
            this.lbHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomMessageBox
            // 
            this.AcceptButton = this.button1;
            this.Appearance.Font = new System.Drawing.Font("宋体", 11F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 113);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "窗口提示";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbHint;
    }
}