namespace InputDevMonitor
{
    partial class Form1
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
            this.btnBarReader = new System.Windows.Forms.Button();
            this.btnIdCardReader = new System.Windows.Forms.Button();
            this.btnStartIdCardReader = new System.Windows.Forms.Button();
            this.btnStartBarReader = new System.Windows.Forms.Button();
            this.lbBarReaderHint = new System.Windows.Forms.Label();
            this.lbIdCardReaderHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBarReader
            // 
            this.btnBarReader.Location = new System.Drawing.Point(29, 29);
            this.btnBarReader.Name = "btnBarReader";
            this.btnBarReader.Size = new System.Drawing.Size(238, 36);
            this.btnBarReader.TabIndex = 0;
            this.btnBarReader.Text = "条码扫描设置";
            this.btnBarReader.UseVisualStyleBackColor = true;
            this.btnBarReader.Click += new System.EventHandler(this.btnBarReader_Click);
            // 
            // btnIdCardReader
            // 
            this.btnIdCardReader.Location = new System.Drawing.Point(29, 71);
            this.btnIdCardReader.Name = "btnIdCardReader";
            this.btnIdCardReader.Size = new System.Drawing.Size(238, 37);
            this.btnIdCardReader.TabIndex = 1;
            this.btnIdCardReader.Text = "二代证阅读器设置";
            this.btnIdCardReader.UseVisualStyleBackColor = true;
            this.btnIdCardReader.Click += new System.EventHandler(this.btnIdCardReader_Click);
            // 
            // btnStartIdCardReader
            // 
            this.btnStartIdCardReader.Location = new System.Drawing.Point(379, 71);
            this.btnStartIdCardReader.Name = "btnStartIdCardReader";
            this.btnStartIdCardReader.Size = new System.Drawing.Size(75, 37);
            this.btnStartIdCardReader.TabIndex = 2;
            this.btnStartIdCardReader.Text = "启动";
            this.btnStartIdCardReader.UseVisualStyleBackColor = true;
            this.btnStartIdCardReader.Click += new System.EventHandler(this.btnStartIdCardReader_Click);
            // 
            // btnStartBarReader
            // 
            this.btnStartBarReader.Location = new System.Drawing.Point(379, 29);
            this.btnStartBarReader.Name = "btnStartBarReader";
            this.btnStartBarReader.Size = new System.Drawing.Size(75, 37);
            this.btnStartBarReader.TabIndex = 2;
            this.btnStartBarReader.Text = "启动";
            this.btnStartBarReader.UseVisualStyleBackColor = true;
            this.btnStartBarReader.Click += new System.EventHandler(this.btnCodeBarReader_Click);
            // 
            // lbBarReaderHint
            // 
            this.lbBarReaderHint.AutoSize = true;
            this.lbBarReaderHint.Font = new System.Drawing.Font("宋体", 12F);
            this.lbBarReaderHint.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbBarReaderHint.Location = new System.Drawing.Point(273, 37);
            this.lbBarReaderHint.Name = "lbBarReaderHint";
            this.lbBarReaderHint.Size = new System.Drawing.Size(104, 16);
            this.lbBarReaderHint.TabIndex = 3;
            this.lbBarReaderHint.Text = "状态：未启动";
            // 
            // lbIdCardReaderHint
            // 
            this.lbIdCardReaderHint.AutoSize = true;
            this.lbIdCardReaderHint.Font = new System.Drawing.Font("宋体", 12F);
            this.lbIdCardReaderHint.ForeColor = System.Drawing.Color.YellowGreen;
            this.lbIdCardReaderHint.Location = new System.Drawing.Point(273, 79);
            this.lbIdCardReaderHint.Name = "lbIdCardReaderHint";
            this.lbIdCardReaderHint.Size = new System.Drawing.Size(104, 16);
            this.lbIdCardReaderHint.TabIndex = 3;
            this.lbIdCardReaderHint.Text = "状态：未启动";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 266);
            this.Controls.Add(this.lbIdCardReaderHint);
            this.Controls.Add(this.lbBarReaderHint);
            this.Controls.Add(this.btnStartBarReader);
            this.Controls.Add(this.btnStartIdCardReader);
            this.Controls.Add(this.btnIdCardReader);
            this.Controls.Add(this.btnBarReader);
            this.Name = "Form1";
            this.Text = "输入设备监控";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBarReader;
        private System.Windows.Forms.Button btnIdCardReader;
        private System.Windows.Forms.Button btnStartIdCardReader;
        private System.Windows.Forms.Button btnStartBarReader;
        private System.Windows.Forms.Label lbBarReaderHint;
        private System.Windows.Forms.Label lbIdCardReaderHint;
    }
}

