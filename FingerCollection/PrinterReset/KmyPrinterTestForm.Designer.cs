namespace PrinterReset
{
    partial class KmyPrinterTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnOpenKey = new System.Windows.Forms.Button();
            this.btnCloseKey = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOpenKeyType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeyResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(58, 21);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 21);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口";
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(124, 21);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPort.TabIndex = 2;
            this.btnOpenPort.Text = "打开端口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnOpenKey
            // 
            this.btnOpenKey.Location = new System.Drawing.Point(124, 50);
            this.btnOpenKey.Name = "btnOpenKey";
            this.btnOpenKey.Size = new System.Drawing.Size(75, 23);
            this.btnOpenKey.TabIndex = 2;
            this.btnOpenKey.Text = "打开键盘";
            this.btnOpenKey.UseVisualStyleBackColor = true;
            this.btnOpenKey.Click += new System.EventHandler(this.btnOpenKey_Click);
            // 
            // btnCloseKey
            // 
            this.btnCloseKey.Location = new System.Drawing.Point(205, 50);
            this.btnCloseKey.Name = "btnCloseKey";
            this.btnCloseKey.Size = new System.Drawing.Size(75, 23);
            this.btnCloseKey.TabIndex = 2;
            this.btnCloseKey.Text = "关闭键盘";
            this.btnCloseKey.UseVisualStyleBackColor = true;
            // 
            // btnClosePort
            // 
            this.btnClosePort.Location = new System.Drawing.Point(205, 21);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(75, 23);
            this.btnClosePort.TabIndex = 2;
            this.btnClosePort.Text = "关闭端口";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "键盘参数";
            // 
            // cbOpenKeyType
            // 
            this.cbOpenKeyType.FormattingEnabled = true;
            this.cbOpenKeyType.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbOpenKeyType.Location = new System.Drawing.Point(72, 50);
            this.cbOpenKeyType.Name = "cbOpenKeyType";
            this.cbOpenKeyType.Size = new System.Drawing.Size(46, 20);
            this.cbOpenKeyType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "按键结果：";
            // 
            // txtKeyResult
            // 
            this.txtKeyResult.Location = new System.Drawing.Point(12, 99);
            this.txtKeyResult.Multiline = true;
            this.txtKeyResult.Name = "txtKeyResult";
            this.txtKeyResult.Size = new System.Drawing.Size(268, 141);
            this.txtKeyResult.TabIndex = 0;
            // 
            // KmyPrinterTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOpenKeyType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnCloseKey);
            this.Controls.Add(this.btnOpenKey);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKeyResult);
            this.Controls.Add(this.txtPort);
            this.Name = "KmyPrinterTestForm";
            this.Text = "凯明杨金属键盘测试工具";
            this.Load += new System.EventHandler(this.KmyPrinterTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnOpenKey;
        private System.Windows.Forms.Button btnCloseKey;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOpenKeyType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeyResult;
    }
}