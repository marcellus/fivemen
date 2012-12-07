namespace PrinterReset
{
    partial class HiPiaoTcpTestForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtRecieve = new System.Windows.Forms.TextBox();
            this.txtValidCode = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtFlag = new System.Windows.Forms.TextBox();
            this.btnGetTicket = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(106, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "断开连接";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 41);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(191, 44);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(209, 64);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送内容";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtRecieve
            // 
            this.txtRecieve.Location = new System.Drawing.Point(12, 130);
            this.txtRecieve.Multiline = true;
            this.txtRecieve.Name = "txtRecieve";
            this.txtRecieve.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecieve.Size = new System.Drawing.Size(499, 124);
            this.txtRecieve.TabIndex = 2;
            // 
            // txtValidCode
            // 
            this.txtValidCode.Location = new System.Drawing.Point(93, 101);
            this.txtValidCode.Name = "txtValidCode";
            this.txtValidCode.Size = new System.Drawing.Size(47, 21);
            this.txtValidCode.TabIndex = 3;
            this.txtValidCode.Text = "246947";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(12, 101);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(75, 21);
            this.txtMobile.TabIndex = 3;
            this.txtMobile.Text = "18618405975";
            this.txtMobile.TextChanged += new System.EventHandler(this.txtMobile_TextChanged);
            // 
            // txtFlag
            // 
            this.txtFlag.Location = new System.Drawing.Point(146, 101);
            this.txtFlag.Name = "txtFlag";
            this.txtFlag.Size = new System.Drawing.Size(35, 21);
            this.txtFlag.TabIndex = 3;
            this.txtFlag.Text = "1";
            // 
            // btnGetTicket
            // 
            this.btnGetTicket.Location = new System.Drawing.Point(205, 101);
            this.btnGetTicket.Name = "btnGetTicket";
            this.btnGetTicket.Size = new System.Drawing.Size(75, 23);
            this.btnGetTicket.TabIndex = 0;
            this.btnGetTicket.Text = "发送取票";
            this.btnGetTicket.UseVisualStyleBackColor = true;
            this.btnGetTicket.Click += new System.EventHandler(this.btnGetTicket_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(177, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 29);
            this.label1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(311, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 43);
            this.panel1.TabIndex = 6;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(235, 13);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 21);
            this.txtIp.TabIndex = 7;
            this.txtIp.Text = "119.10.114.212";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(383, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "2907";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "端口";
            // 
            // HiPiaoTcpTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 266);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtFlag);
            this.Controls.Add(this.txtValidCode);
            this.Controls.Add(this.txtRecieve);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnGetTicket);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Name = "HiPiaoTcpTestForm";
            this.Text = "HiPiaoTcpTestForm";
            this.Load += new System.EventHandler(this.HiPiaoTcpTestForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtRecieve;
        private System.Windows.Forms.TextBox txtValidCode;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtFlag;
        private System.Windows.Forms.Button btnGetTicket;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}