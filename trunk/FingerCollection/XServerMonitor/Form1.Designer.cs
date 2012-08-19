namespace XServerMonitor
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonitorPath = new System.Windows.Forms.TextBox();
            this.btnFolderSelector = new System.Windows.Forms.Button();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.btnStopMonitor = new System.Windows.Forms.Button();
            this.lbHint = new System.Windows.Forms.Label();
            this.lbLogContent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimerSecond = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbUseTimes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonitorLine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogDays = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "监控文件夹：";
            // 
            // txtMonitorPath
            // 
            this.txtMonitorPath.Location = new System.Drawing.Point(31, 53);
            this.txtMonitorPath.Name = "txtMonitorPath";
            this.txtMonitorPath.ReadOnly = true;
            this.txtMonitorPath.Size = new System.Drawing.Size(402, 21);
            this.txtMonitorPath.TabIndex = 1;
            // 
            // btnFolderSelector
            // 
            this.btnFolderSelector.Location = new System.Drawing.Point(455, 53);
            this.btnFolderSelector.Name = "btnFolderSelector";
            this.btnFolderSelector.Size = new System.Drawing.Size(53, 23);
            this.btnFolderSelector.TabIndex = 2;
            this.btnFolderSelector.Text = "选择";
            this.btnFolderSelector.UseVisualStyleBackColor = true;
            this.btnFolderSelector.Click += new System.EventHandler(this.btnFolderSelector_Click);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.Location = new System.Drawing.Point(31, 145);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnStartMonitor.TabIndex = 3;
            this.btnStartMonitor.Text = "开启监控";
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.Enabled = false;
            this.btnStopMonitor.Location = new System.Drawing.Point(251, 145);
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnStopMonitor.TabIndex = 3;
            this.btnStopMonitor.Text = "停止监控";
            this.btnStopMonitor.UseVisualStyleBackColor = true;
            this.btnStopMonitor.Click += new System.EventHandler(this.btnStopMonitor_Click);
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Location = new System.Drawing.Point(31, 188);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(113, 12);
            this.lbHint.TabIndex = 4;
            this.lbHint.Text = "监控行数和监控时间";
            // 
            // lbLogContent
            // 
            this.lbLogContent.AutoSize = true;
            this.lbLogContent.Location = new System.Drawing.Point(31, 215);
            this.lbLogContent.Name = "lbLogContent";
            this.lbLogContent.Size = new System.Drawing.Size(53, 12);
            this.lbLogContent.TabIndex = 5;
            this.lbLogContent.Text = "监控内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "监控时间";
            // 
            // txtTimerSecond
            // 
            this.txtTimerSecond.Location = new System.Drawing.Point(100, 82);
            this.txtTimerSecond.Name = "txtTimerSecond";
            this.txtTimerSecond.Size = new System.Drawing.Size(68, 21);
            this.txtTimerSecond.TabIndex = 7;
            this.txtTimerSecond.Text = "2000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "毫秒";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbUseTimes
            // 
            this.lbUseTimes.AutoSize = true;
            this.lbUseTimes.Location = new System.Drawing.Point(378, 156);
            this.lbUseTimes.Name = "lbUseTimes";
            this.lbUseTimes.Size = new System.Drawing.Size(101, 12);
            this.lbUseTimes.TabIndex = 4;
            this.lbUseTimes.Text = "读取日志一次耗时";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "监控最大行数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "行";
            // 
            // txtMonitorLine
            // 
            this.txtMonitorLine.Location = new System.Drawing.Point(304, 83);
            this.txtMonitorLine.Name = "txtMonitorLine";
            this.txtMonitorLine.Size = new System.Drawing.Size(68, 21);
            this.txtMonitorLine.TabIndex = 7;
            this.txtMonitorLine.Text = "2000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "保留日志天数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "天";
            // 
            // txtLogDays
            // 
            this.txtLogDays.Location = new System.Drawing.Point(114, 110);
            this.txtLogDays.Name = "txtLogDays";
            this.txtLogDays.Size = new System.Drawing.Size(54, 21);
            this.txtLogDays.TabIndex = 7;
            this.txtLogDays.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 242);
            this.Controls.Add(this.txtMonitorLine);
            this.Controls.Add(this.txtLogDays);
            this.Controls.Add(this.txtTimerSecond);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbLogContent);
            this.Controls.Add(this.lbUseTimes);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.btnStopMonitor);
            this.Controls.Add(this.btnStartMonitor);
            this.Controls.Add(this.btnFolderSelector);
            this.Controls.Add(this.txtMonitorPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "XServer监控自动重启程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonitorPath;
        private System.Windows.Forms.Button btnFolderSelector;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.Button btnStopMonitor;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Label lbLogContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimerSecond;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbUseTimes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonitorLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLogDays;
    }
}

