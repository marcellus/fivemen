namespace FT.Commons.WebCatcher
{
    partial class RegexTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegexTest));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetSource = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageSource = new System.Windows.Forms.TextBox();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.lbregx = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetSource);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGetSource
            // 
            this.btnGetSource.Location = new System.Drawing.Point(378, 12);
            this.btnGetSource.Name = "btnGetSource";
            this.btnGetSource.Size = new System.Drawing.Size(75, 23);
            this.btnGetSource.TabIndex = 2;
            this.btnGetSource.Text = "获取源码";
            this.btnGetSource.UseVisualStyleBackColor = true;
            this.btnGetSource.Click += new System.EventHandler(this.btnGetSource_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(43, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(329, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网址";
            // 
            // txtPageSource
            // 
            this.txtPageSource.Location = new System.Drawing.Point(12, 249);
            this.txtPageSource.Multiline = true;
            this.txtPageSource.Name = "txtPageSource";
            this.txtPageSource.Size = new System.Drawing.Size(476, 263);
            this.txtPageSource.TabIndex = 1;
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(84, 71);
            this.txtRegex.Multiline = true;
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(404, 51);
            this.txtRegex.TabIndex = 2;
            // 
            // lbregx
            // 
            this.lbregx.AutoSize = true;
            this.lbregx.Location = new System.Drawing.Point(13, 80);
            this.lbregx.Name = "lbregx";
            this.lbregx.Size = new System.Drawing.Size(65, 12);
            this.lbregx.TabIndex = 3;
            this.lbregx.Text = "正则表达式";
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(15, 99);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(63, 23);
            this.btnMatch.TabIndex = 4;
            this.btnMatch.Text = "匹配";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 128);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(473, 97);
            this.txtResult.TabIndex = 5;
            // 
            // RegexTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 549);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.lbregx);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.txtPageSource);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegexTest";
            this.Text = "正则表达式测试";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetSource;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtPageSource;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label lbregx;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.TextBox txtResult;
    }
}