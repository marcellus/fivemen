namespace FT.Windows.ExternalTool.DevTools
{
    partial class WindowPrinterTest
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEndPrint = new System.Windows.Forms.Button();
            this.btnBeginPrint = new System.Windows.Forms.Button();
            this.txtPrintTotalNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrintContent = new System.Windows.Forms.TextBox();
            this.lbHint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrintThreadSeconds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtPrintThreadSeconds);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnEndPrint);
            this.groupBox3.Controls.Add(this.btnBeginPrint);
            this.groupBox3.Controls.Add(this.txtPrintTotalNum);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPrintContent);
            this.groupBox3.Location = new System.Drawing.Point(22, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 92);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印机压力测试";
            // 
            // btnEndPrint
            // 
            this.btnEndPrint.Enabled = false;
            this.btnEndPrint.Location = new System.Drawing.Point(122, 63);
            this.btnEndPrint.Name = "btnEndPrint";
            this.btnEndPrint.Size = new System.Drawing.Size(75, 23);
            this.btnEndPrint.TabIndex = 13;
            this.btnEndPrint.Text = "停止打印";
            this.btnEndPrint.UseVisualStyleBackColor = true;
            this.btnEndPrint.Click += new System.EventHandler(this.btnEndPrint_Click);
            // 
            // btnBeginPrint
            // 
            this.btnBeginPrint.Location = new System.Drawing.Point(11, 63);
            this.btnBeginPrint.Name = "btnBeginPrint";
            this.btnBeginPrint.Size = new System.Drawing.Size(75, 23);
            this.btnBeginPrint.TabIndex = 13;
            this.btnBeginPrint.Text = "开始打印";
            this.btnBeginPrint.UseVisualStyleBackColor = true;
            this.btnBeginPrint.Click += new System.EventHandler(this.btnBeginPrint_Click);
            // 
            // txtPrintTotalNum
            // 
            this.txtPrintTotalNum.Location = new System.Drawing.Point(351, 25);
            this.txtPrintTotalNum.Name = "txtPrintTotalNum";
            this.txtPrintTotalNum.Size = new System.Drawing.Size(52, 21);
            this.txtPrintTotalNum.TabIndex = 12;
            this.txtPrintTotalNum.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "打印页数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "打印内容";
            // 
            // txtPrintContent
            // 
            this.txtPrintContent.Location = new System.Drawing.Point(68, 26);
            this.txtPrintContent.Name = "txtPrintContent";
            this.txtPrintContent.Size = new System.Drawing.Size(201, 21);
            this.txtPrintContent.TabIndex = 10;
            this.txtPrintContent.Text = "1234567890一二三四五六七八九十";
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Location = new System.Drawing.Point(22, 120);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(0, 12);
            this.lbHint.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "秒";
            // 
            // txtPrintThreadSeconds
            // 
            this.txtPrintThreadSeconds.Location = new System.Drawing.Point(351, 55);
            this.txtPrintThreadSeconds.Name = "txtPrintThreadSeconds";
            this.txtPrintThreadSeconds.Size = new System.Drawing.Size(52, 21);
            this.txtPrintThreadSeconds.TabIndex = 17;
            this.txtPrintThreadSeconds.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "打印间隔";
            // 
            // WindowPrinterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 145);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.groupBox3);
            this.Name = "WindowPrinterTest";
            this.Text = "操作系统打印机测试";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEndPrint;
        private System.Windows.Forms.Button btnBeginPrint;
        private System.Windows.Forms.TextBox txtPrintTotalNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrintContent;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrintThreadSeconds;
        private System.Windows.Forms.Label label4;
    }
}