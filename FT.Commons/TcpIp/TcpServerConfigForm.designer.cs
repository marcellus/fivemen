namespace FT.Commons.TcpIp
{
    partial class TcpServerConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpServerConfigForm));
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDefaultStart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(83, 76);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(138, 21);
            this.txtPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "监听端口";
            // 
            // cbDefaultStart
            // 
            this.cbDefaultStart.AutoSize = true;
            this.cbDefaultStart.Location = new System.Drawing.Point(22, 20);
            this.cbDefaultStart.Name = "cbDefaultStart";
            this.cbDefaultStart.Size = new System.Drawing.Size(96, 16);
            this.cbDefaultStart.TabIndex = 1;
            this.cbDefaultStart.Text = "是否默认开启";
            this.cbDefaultStart.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDefaultStart);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 119);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置信息";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(83, 42);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(138, 21);
            this.txtIp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "本机使用IP";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(95, 172);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(109, 25);
            this.btnSure.TabIndex = 4;
            this.btnSure.Text = "保存";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // TcpServerConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 209);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TcpServerConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器配置";
            this.Load += new System.EventHandler(this.TcpServerConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbDefaultStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIp;
    }
}
