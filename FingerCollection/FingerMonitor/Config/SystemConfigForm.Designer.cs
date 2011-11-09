namespace FingerMonitor.Config
{
    partial class SystemConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonitorPath = new System.Windows.Forms.TextBox();
            this.btnMonitorPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonitorTimes = new System.Windows.Forms.TextBox();
            this.checkAutoStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTnsName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOraUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOraPwd = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "监控路径：";
            // 
            // txtMonitorPath
            // 
            this.txtMonitorPath.Location = new System.Drawing.Point(119, 13);
            this.txtMonitorPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonitorPath.Name = "txtMonitorPath";
            this.txtMonitorPath.ReadOnly = true;
            this.txtMonitorPath.Size = new System.Drawing.Size(433, 27);
            this.txtMonitorPath.TabIndex = 1;
            // 
            // btnMonitorPath
            // 
            this.btnMonitorPath.Location = new System.Drawing.Point(581, 13);
            this.btnMonitorPath.Name = "btnMonitorPath";
            this.btnMonitorPath.Size = new System.Drawing.Size(95, 27);
            this.btnMonitorPath.TabIndex = 2;
            this.btnMonitorPath.Text = "配置";
            this.btnMonitorPath.UseVisualStyleBackColor = true;
            this.btnMonitorPath.Click += new System.EventHandler(this.btnMonitorPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "监控时间间隔";
            // 
            // txtMonitorTimes
            // 
            this.txtMonitorTimes.Location = new System.Drawing.Point(138, 55);
            this.txtMonitorTimes.Name = "txtMonitorTimes";
            this.txtMonitorTimes.Size = new System.Drawing.Size(80, 27);
            this.txtMonitorTimes.TabIndex = 4;
            this.txtMonitorTimes.Text = "2000";
            // 
            // checkAutoStart
            // 
            this.checkAutoStart.AutoSize = true;
            this.checkAutoStart.Location = new System.Drawing.Point(293, 60);
            this.checkAutoStart.Name = "checkAutoStart";
            this.checkAutoStart.Size = new System.Drawing.Size(99, 22);
            this.checkAutoStart.TabIndex = 5;
            this.checkAutoStart.Text = "自动启动";
            this.checkAutoStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "毫秒";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOraPwd);
            this.groupBox1.Controls.Add(this.txtOraUser);
            this.groupBox1.Controls.Add(this.txtTnsName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指纹库配置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "TNS";
            // 
            // txtTnsName
            // 
            this.txtTnsName.Location = new System.Drawing.Point(84, 27);
            this.txtTnsName.Name = "txtTnsName";
            this.txtTnsName.Size = new System.Drawing.Size(456, 27);
            this.txtTnsName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "用户名";
            // 
            // txtOraUser
            // 
            this.txtOraUser.Location = new System.Drawing.Point(84, 65);
            this.txtOraUser.Name = "txtOraUser";
            this.txtOraUser.Size = new System.Drawing.Size(456, 27);
            this.txtOraUser.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "密码";
            // 
            // txtOraPwd
            // 
            this.txtOraPwd.Location = new System.Drawing.Point(84, 98);
            this.txtOraPwd.Name = "txtOraPwd";
            this.txtOraPwd.PasswordChar = '*';
            this.txtOraPwd.Size = new System.Drawing.Size(456, 27);
            this.txtOraPwd.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 301);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkAutoStart);
            this.Controls.Add(this.txtMonitorTimes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMonitorPath);
            this.Controls.Add(this.txtMonitorPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SystemConfigForm";
            this.Text = "系统配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonitorPath;
        private System.Windows.Forms.Button btnMonitorPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonitorTimes;
        private System.Windows.Forms.CheckBox checkAutoStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOraPwd;
        private System.Windows.Forms.TextBox txtOraUser;
        private System.Windows.Forms.TextBox txtTnsName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}