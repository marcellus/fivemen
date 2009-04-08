namespace FT.Commons.TcpIp
{
    partial class TcpClientMockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpClientMockForm));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtAccept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(13, 36);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(256, 47);
            this.txtMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "待发送的消息内容";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(129, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtAccept
            // 
            this.txtAccept.BackColor = System.Drawing.SystemColors.Control;
            this.txtAccept.Location = new System.Drawing.Point(13, 107);
            this.txtAccept.Multiline = true;
            this.txtAccept.Name = "txtAccept";
            this.txtAccept.Size = new System.Drawing.Size(256, 154);
            this.txtAccept.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "接收到的消息";
            // 
            // btnConsole
            // 
            this.btnConsole.Location = new System.Drawing.Point(211, 4);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(58, 23);
            this.btnConsole.TabIndex = 5;
            this.btnConsole.Text = "控制台";
            this.btnConsole.UseVisualStyleBackColor = true;
            this.btnConsole.Click += new System.EventHandler(this.btnConsole_Click);
            // 
            // TcpClientMockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnConsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccept);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TcpClientMockForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tcp客户端模拟程序";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsole;
    }
}