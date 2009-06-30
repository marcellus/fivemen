namespace PhotoMonitor
{
    partial class SystemMonitorConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemMonitorConfig));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkHintImport = new System.Windows.Forms.CheckBox();
            this.checkAutoStart = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonitorTimes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonitorPath = new System.Windows.Forms.TextBox();
            this.btnMonitorPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBakPath = new System.Windows.Forms.TextBox();
            this.btnBakPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtServiceWriteSn = new System.Windows.Forms.TextBox();
            this.txtServiceReadSn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkHintImport);
            this.groupBox2.Controls.Add(this.checkAutoStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMonitorTimes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMonitorPath);
            this.groupBox2.Controls.Add(this.btnMonitorPath);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(620, 98);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "监控图片路径配置";
            // 
            // checkHintImport
            // 
            this.checkHintImport.AutoSize = true;
            this.checkHintImport.Location = new System.Drawing.Point(363, 65);
            this.checkHintImport.Name = "checkHintImport";
            this.checkHintImport.Size = new System.Drawing.Size(146, 19);
            this.checkHintImport.TabIndex = 4;
            this.checkHintImport.Text = "是否提示导入照片";
            this.checkHintImport.UseVisualStyleBackColor = true;
            // 
            // checkAutoStart
            // 
            this.checkAutoStart.AutoSize = true;
            this.checkAutoStart.Location = new System.Drawing.Point(238, 65);
            this.checkAutoStart.Name = "checkAutoStart";
            this.checkAutoStart.Size = new System.Drawing.Size(86, 19);
            this.checkAutoStart.TabIndex = 3;
            this.checkAutoStart.Text = "自动启动";
            this.checkAutoStart.UseVisualStyleBackColor = true;
            this.checkAutoStart.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "毫秒";
            // 
            // txtMonitorTimes
            // 
            this.txtMonitorTimes.Location = new System.Drawing.Point(115, 60);
            this.txtMonitorTimes.Name = "txtMonitorTimes";
            this.txtMonitorTimes.Size = new System.Drawing.Size(57, 24);
            this.txtMonitorTimes.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "监控时间间隔";
            // 
            // txtMonitorPath
            // 
            this.txtMonitorPath.Location = new System.Drawing.Point(9, 25);
            this.txtMonitorPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonitorPath.Name = "txtMonitorPath";
            this.txtMonitorPath.ReadOnly = true;
            this.txtMonitorPath.Size = new System.Drawing.Size(489, 24);
            this.txtMonitorPath.TabIndex = 1;
            // 
            // btnMonitorPath
            // 
            this.btnMonitorPath.Location = new System.Drawing.Point(520, 25);
            this.btnMonitorPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonitorPath.Name = "btnMonitorPath";
            this.btnMonitorPath.Size = new System.Drawing.Size(73, 29);
            this.btnMonitorPath.TabIndex = 4;
            this.btnMonitorPath.Text = "配置";
            this.btnMonitorPath.UseVisualStyleBackColor = true;
            this.btnMonitorPath.Click += new System.EventHandler(this.btnMonitorPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBakPath);
            this.groupBox1.Controls.Add(this.btnBakPath);
            this.groupBox1.Location = new System.Drawing.Point(13, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(620, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片备份路径配置";
            // 
            // txtBakPath
            // 
            this.txtBakPath.Location = new System.Drawing.Point(9, 25);
            this.txtBakPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBakPath.Name = "txtBakPath";
            this.txtBakPath.ReadOnly = true;
            this.txtBakPath.Size = new System.Drawing.Size(489, 24);
            this.txtBakPath.TabIndex = 5;
            // 
            // btnBakPath
            // 
            this.btnBakPath.Location = new System.Drawing.Point(520, 25);
            this.btnBakPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBakPath.Name = "btnBakPath";
            this.btnBakPath.Size = new System.Drawing.Size(73, 29);
            this.btnBakPath.TabIndex = 4;
            this.btnBakPath.Text = "配置";
            this.btnBakPath.UseVisualStyleBackColor = true;
            this.btnBakPath.Click += new System.EventHandler(this.btnBakPath_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtServiceWriteSn);
            this.groupBox3.Controls.Add(this.txtServiceReadSn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtServiceIp);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(620, 148);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接口信息配置";
            // 
            // txtServiceWriteSn
            // 
            this.txtServiceWriteSn.Location = new System.Drawing.Point(100, 105);
            this.txtServiceWriteSn.Name = "txtServiceWriteSn";
            this.txtServiceWriteSn.Size = new System.Drawing.Size(481, 24);
            this.txtServiceWriteSn.TabIndex = 8;
            // 
            // txtServiceReadSn
            // 
            this.txtServiceReadSn.Location = new System.Drawing.Point(100, 70);
            this.txtServiceReadSn.Name = "txtServiceReadSn";
            this.txtServiceReadSn.Size = new System.Drawing.Size(481, 24);
            this.txtServiceReadSn.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "接口写入Sn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "接口读取Sn";
            // 
            // txtServiceIp
            // 
            this.txtServiceIp.Location = new System.Drawing.Point(100, 35);
            this.txtServiceIp.Name = "txtServiceIp";
            this.txtServiceIp.Size = new System.Drawing.Size(481, 24);
            this.txtServiceIp.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SystemMonitorConfig
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 406);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemMonitorConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMonitorPath;
        private System.Windows.Forms.Button btnMonitorPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBakPath;
        private System.Windows.Forms.Button btnBakPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtServiceIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceReadSn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServiceWriteSn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonitorTimes;
        private System.Windows.Forms.CheckBox checkAutoStart;
        private System.Windows.Forms.CheckBox checkHintImport;
        private System.Windows.Forms.Button btnSave;
    }
}