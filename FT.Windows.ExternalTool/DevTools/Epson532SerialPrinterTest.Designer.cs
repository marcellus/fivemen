namespace FT.Windows.ExternalTool.DevTools
{
    partial class Epson532SerialPrinterTest
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
            this.lbHotHint = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHotGetState = new System.Windows.Forms.Button();
            this.btnHotCloseDevice = new System.Windows.Forms.Button();
            this.btnHotOpenDevice = new System.Windows.Forms.Button();
            this.txtHotPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHotCutPaper = new System.Windows.Forms.Button();
            this.btnHotChangeLine = new System.Windows.Forms.Button();
            this.txtHotPrintText = new System.Windows.Forms.TextBox();
            this.btnHotPrintLine = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEndPrint = new System.Windows.Forms.Button();
            this.btnBeginPrint = new System.Windows.Forms.Button();
            this.txtPrintTotalNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrintContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrintThreadSeconds = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHotHint
            // 
            this.lbHotHint.AutoSize = true;
            this.lbHotHint.Location = new System.Drawing.Point(25, 9);
            this.lbHotHint.Name = "lbHotHint";
            this.lbHotHint.Size = new System.Drawing.Size(0, 12);
            this.lbHotHint.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHotGetState);
            this.groupBox1.Controls.Add(this.btnHotCloseDevice);
            this.groupBox1.Controls.Add(this.btnHotOpenDevice);
            this.groupBox1.Controls.Add(this.txtHotPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // btnHotGetState
            // 
            this.btnHotGetState.Enabled = false;
            this.btnHotGetState.Location = new System.Drawing.Point(327, 15);
            this.btnHotGetState.Name = "btnHotGetState";
            this.btnHotGetState.Size = new System.Drawing.Size(75, 23);
            this.btnHotGetState.TabIndex = 4;
            this.btnHotGetState.Text = "获取状态";
            this.btnHotGetState.UseVisualStyleBackColor = true;
            this.btnHotGetState.Click += new System.EventHandler(this.btnHotGetState_Click);
            // 
            // btnHotCloseDevice
            // 
            this.btnHotCloseDevice.Enabled = false;
            this.btnHotCloseDevice.Location = new System.Drawing.Point(223, 15);
            this.btnHotCloseDevice.Name = "btnHotCloseDevice";
            this.btnHotCloseDevice.Size = new System.Drawing.Size(75, 23);
            this.btnHotCloseDevice.TabIndex = 3;
            this.btnHotCloseDevice.Text = "关闭串口";
            this.btnHotCloseDevice.UseVisualStyleBackColor = true;
            this.btnHotCloseDevice.Click += new System.EventHandler(this.btnHotCloseDevice_Click);
            // 
            // btnHotOpenDevice
            // 
            this.btnHotOpenDevice.Location = new System.Drawing.Point(108, 15);
            this.btnHotOpenDevice.Name = "btnHotOpenDevice";
            this.btnHotOpenDevice.Size = new System.Drawing.Size(75, 23);
            this.btnHotOpenDevice.TabIndex = 2;
            this.btnHotOpenDevice.Text = "打开串口";
            this.btnHotOpenDevice.UseVisualStyleBackColor = true;
            this.btnHotOpenDevice.Click += new System.EventHandler(this.btnHotOpenDevice_Click);
            // 
            // txtHotPort
            // 
            this.txtHotPort.Location = new System.Drawing.Point(42, 18);
            this.txtHotPort.Name = "txtHotPort";
            this.txtHotPort.Size = new System.Drawing.Size(35, 21);
            this.txtHotPort.TabIndex = 1;
            this.txtHotPort.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口";
            // 
            // btnHotCutPaper
            // 
            this.btnHotCutPaper.Enabled = false;
            this.btnHotCutPaper.Location = new System.Drawing.Point(376, 14);
            this.btnHotCutPaper.Name = "btnHotCutPaper";
            this.btnHotCutPaper.Size = new System.Drawing.Size(75, 23);
            this.btnHotCutPaper.TabIndex = 12;
            this.btnHotCutPaper.Text = "切纸";
            this.btnHotCutPaper.UseVisualStyleBackColor = true;
            this.btnHotCutPaper.Click += new System.EventHandler(this.btnHotCutPaper_Click);
            // 
            // btnHotChangeLine
            // 
            this.btnHotChangeLine.Enabled = false;
            this.btnHotChangeLine.Location = new System.Drawing.Point(295, 14);
            this.btnHotChangeLine.Name = "btnHotChangeLine";
            this.btnHotChangeLine.Size = new System.Drawing.Size(75, 23);
            this.btnHotChangeLine.TabIndex = 11;
            this.btnHotChangeLine.Text = "走纸";
            this.btnHotChangeLine.UseVisualStyleBackColor = true;
            this.btnHotChangeLine.Click += new System.EventHandler(this.btnHotChangeLine_Click);
            // 
            // txtHotPrintText
            // 
            this.txtHotPrintText.Location = new System.Drawing.Point(88, 14);
            this.txtHotPrintText.Name = "txtHotPrintText";
            this.txtHotPrintText.Size = new System.Drawing.Size(201, 21);
            this.txtHotPrintText.TabIndex = 10;
            this.txtHotPrintText.Text = "1234567890一二三四五六七八九十";
            // 
            // btnHotPrintLine
            // 
            this.btnHotPrintLine.Enabled = false;
            this.btnHotPrintLine.Location = new System.Drawing.Point(7, 14);
            this.btnHotPrintLine.Name = "btnHotPrintLine";
            this.btnHotPrintLine.Size = new System.Drawing.Size(75, 23);
            this.btnHotPrintLine.TabIndex = 9;
            this.btnHotPrintLine.Text = "打印文字";
            this.btnHotPrintLine.UseVisualStyleBackColor = true;
            this.btnHotPrintLine.Click += new System.EventHandler(this.btnHotPrintLine_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHotPrintLine);
            this.groupBox2.Controls.Add(this.btnHotCutPaper);
            this.groupBox2.Controls.Add(this.txtHotPrintText);
            this.groupBox2.Controls.Add(this.btnHotChangeLine);
            this.groupBox2.Location = new System.Drawing.Point(27, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 43);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印机操作";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnEndPrint);
            this.groupBox3.Controls.Add(this.btnBeginPrint);
            this.groupBox3.Controls.Add(this.txtPrintThreadSeconds);
            this.groupBox3.Controls.Add(this.txtPrintTotalNum);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPrintContent);
            this.groupBox3.Location = new System.Drawing.Point(27, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 92);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "打印机压力测试";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnEndPrint
            // 
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
            this.txtPrintTotalNum.Size = new System.Drawing.Size(40, 21);
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
            this.label3.Text = "打印行数";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "打印间隔";
            // 
            // txtPrintThreadSeconds
            // 
            this.txtPrintThreadSeconds.Location = new System.Drawing.Point(394, 55);
            this.txtPrintThreadSeconds.Name = "txtPrintThreadSeconds";
            this.txtPrintThreadSeconds.Size = new System.Drawing.Size(40, 21);
            this.txtPrintThreadSeconds.TabIndex = 12;
            this.txtPrintThreadSeconds.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "秒";
            // 
            // Epon532SerialPrinterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 307);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbHotHint);
            this.Name = "Epon532SerialPrinterTest";
            this.Text = "爱普生532串口小票打印机测试";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHotHint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHotGetState;
        private System.Windows.Forms.Button btnHotCloseDevice;
        private System.Windows.Forms.Button btnHotOpenDevice;
        private System.Windows.Forms.TextBox txtHotPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHotCutPaper;
        private System.Windows.Forms.Button btnHotChangeLine;
        private System.Windows.Forms.TextBox txtHotPrintText;
        private System.Windows.Forms.Button btnHotPrintLine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrintContent;
        private System.Windows.Forms.TextBox txtPrintTotalNum;
        private System.Windows.Forms.Button btnBeginPrint;
        private System.Windows.Forms.Button btnEndPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPrintThreadSeconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}