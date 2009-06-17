namespace FT.Commons
{
    partial class CustomConfirmBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomConfirmBox));
            this.lbHint = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHint
            // 
            this.lbHint.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.lbHint.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbHint.Location = new System.Drawing.Point(16, 44);
            this.lbHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(385, 40);
            this.lbHint.TabIndex = 3;
            this.lbHint.Text = "label1";
            this.lbHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(42, 116);
            this.btnSure.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(133, 36);
            this.btnSure.TabIndex = 1;
            this.btnSure.Text = "是";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 116);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "否";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CustomConfirmBox
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 190);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomConfirmBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomConfirmBox_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCancel;
    }
}