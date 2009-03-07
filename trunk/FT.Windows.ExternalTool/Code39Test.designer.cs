namespace FT.Windows.ExternalTool
{
    partial class Code39Test
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
            this.txtOrgCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCode39 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.Location = new System.Drawing.Point(34, 32);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.Size = new System.Drawing.Size(248, 21);
            this.txtOrgCode.TabIndex = 0;
            this.txtOrgCode.Text = "320522197004200045";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "39编码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelCode39
            // 
            this.panelCode39.Location = new System.Drawing.Point(34, 88);
            this.panelCode39.Name = "panelCode39";
            this.panelCode39.Size = new System.Drawing.Size(407, 224);
            this.panelCode39.TabIndex = 2;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 324);
            this.Controls.Add(this.panelCode39);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOrgCode);
            this.Name = "Form4";
            this.Text = "一维39码测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrgCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelCode39;
    }
}