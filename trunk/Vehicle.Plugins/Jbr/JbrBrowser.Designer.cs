namespace Vehicle.Plugins
{
    partial class JbrBrowser
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
            this.personDetail1 = new FT.Windows.Forms.PersonDetail();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // personDetail1
            // 
            this.personDetail1.Location = new System.Drawing.Point(14, 52);
            this.personDetail1.Name = "personDetail1";
            this.personDetail1.Size = new System.Drawing.Size(391, 259);
            this.personDetail1.TabIndex = 3;
            // 
            // JbrBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(452, 337);
            this.Controls.Add(this.personDetail1);
            this.Name = "JbrBrowser";
            this.Text = "经办人信息";
            this.Controls.SetChildIndex(this.personDetail1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Forms.PersonDetail personDetail1;
    }
}
