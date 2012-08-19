namespace PrinterTest
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
            this.btnEspon532PrinterTest = new System.Windows.Forms.Button();
            this.btnWindowPrinterTest = new System.Windows.Forms.Button();
            this.btnTemplatePrinterTest = new System.Windows.Forms.Button();
            this.btnLPT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEspon532PrinterTest
            // 
            this.btnEspon532PrinterTest.Location = new System.Drawing.Point(21, 36);
            this.btnEspon532PrinterTest.Name = "btnEspon532PrinterTest";
            this.btnEspon532PrinterTest.Size = new System.Drawing.Size(109, 91);
            this.btnEspon532PrinterTest.TabIndex = 0;
            this.btnEspon532PrinterTest.Text = "串口打印机测试";
            this.btnEspon532PrinterTest.UseVisualStyleBackColor = true;
            this.btnEspon532PrinterTest.Click += new System.EventHandler(this.btnEspon532PrinterTest_Click);
            // 
            // btnWindowPrinterTest
            // 
            this.btnWindowPrinterTest.Location = new System.Drawing.Point(21, 140);
            this.btnWindowPrinterTest.Name = "btnWindowPrinterTest";
            this.btnWindowPrinterTest.Size = new System.Drawing.Size(109, 91);
            this.btnWindowPrinterTest.TabIndex = 1;
            this.btnWindowPrinterTest.Text = "操作系统打印测试";
            this.btnWindowPrinterTest.UseVisualStyleBackColor = true;
            this.btnWindowPrinterTest.Click += new System.EventHandler(this.btnWindowPrinterTest_Click);
            // 
            // btnTemplatePrinterTest
            // 
            this.btnTemplatePrinterTest.Location = new System.Drawing.Point(161, 140);
            this.btnTemplatePrinterTest.Name = "btnTemplatePrinterTest";
            this.btnTemplatePrinterTest.Size = new System.Drawing.Size(109, 91);
            this.btnTemplatePrinterTest.TabIndex = 1;
            this.btnTemplatePrinterTest.Text = "模板打印测试";
            this.btnTemplatePrinterTest.UseVisualStyleBackColor = true;
            this.btnTemplatePrinterTest.Click += new System.EventHandler(this.btnTemplatePrinterTest_Click);
            // 
            // btnLPT
            // 
            this.btnLPT.Location = new System.Drawing.Point(161, 36);
            this.btnLPT.Name = "btnLPT";
            this.btnLPT.Size = new System.Drawing.Size(109, 91);
            this.btnLPT.TabIndex = 0;
            this.btnLPT.Text = "并口打印机测试";
            this.btnLPT.UseVisualStyleBackColor = true;
            this.btnLPT.Click += new System.EventHandler(this.btnLPT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 91);
            this.button1.TabIndex = 0;
            this.button1.Text = "影票打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 258);
            this.Controls.Add(this.btnTemplatePrinterTest);
            this.Controls.Add(this.btnWindowPrinterTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLPT);
            this.Controls.Add(this.btnEspon532PrinterTest);
            this.Name = "Form1";
            this.Text = "打印机测试程序";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEspon532PrinterTest;
        private System.Windows.Forms.Button btnWindowPrinterTest;
        private System.Windows.Forms.Button btnTemplatePrinterTest;
        private System.Windows.Forms.Button btnLPT;
        private System.Windows.Forms.Button button1;
    }
}

