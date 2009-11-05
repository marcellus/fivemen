namespace PhotoCutMonitor
{
    partial class SystemConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfigForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStartY = new System.Windows.Forms.TextBox();
            this.txtCutWidth = new System.Windows.Forms.TextBox();
            this.txtCutLength = new System.Windows.Forms.TextBox();
            this.txtStartX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCutPath = new System.Windows.Forms.TextBox();
            this.btnCutPath = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkIsRar = new System.Windows.Forms.CheckBox();
            this.checkAutoStart = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonitorTimes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonitorPath = new System.Windows.Forms.TextBox();
            this.btnMonitorPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBakPath = new System.Windows.Forms.TextBox();
            this.btnBakPath = new System.Windows.Forms.Button();
            this.txtKitWidth = new System.Windows.Forms.TextBox();
            this.txtKitHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(275, 377);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKitWidth);
            this.groupBox1.Controls.Add(this.txtKitHeight);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtStartY);
            this.groupBox1.Controls.Add(this.txtCutWidth);
            this.groupBox1.Controls.Add(this.txtCutLength);
            this.groupBox1.Controls.Add(this.txtStartX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCutPath);
            this.groupBox1.Controls.Add(this.btnCutPath);
            this.groupBox1.Location = new System.Drawing.Point(19, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(620, 130);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片裁剪后路径配置";
            // 
            // txtStartY
            // 
            this.txtStartY.Location = new System.Drawing.Point(280, 53);
            this.txtStartY.Name = "txtStartY";
            this.txtStartY.Size = new System.Drawing.Size(100, 21);
            this.txtStartY.TabIndex = 7;
            // 
            // txtCutWidth
            // 
            this.txtCutWidth.Location = new System.Drawing.Point(280, 86);
            this.txtCutWidth.Name = "txtCutWidth";
            this.txtCutWidth.Size = new System.Drawing.Size(100, 21);
            this.txtCutWidth.TabIndex = 7;
            // 
            // txtCutLength
            // 
            this.txtCutLength.Location = new System.Drawing.Point(81, 87);
            this.txtCutLength.Name = "txtCutLength";
            this.txtCutLength.Size = new System.Drawing.Size(100, 21);
            this.txtCutLength.TabIndex = 7;
            this.txtCutLength.TextChanged += new System.EventHandler(this.txtCutLength_TextChanged);
            // 
            // txtStartX
            // 
            this.txtStartX.Location = new System.Drawing.Point(81, 53);
            this.txtStartX.Name = "txtStartX";
            this.txtStartX.Size = new System.Drawing.Size(100, 21);
            this.txtStartX.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "起始坐标Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "裁剪后的宽";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "裁剪后的长";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "起始坐标X";
            // 
            // txtCutPath
            // 
            this.txtCutPath.Location = new System.Drawing.Point(9, 25);
            this.txtCutPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtCutPath.Name = "txtCutPath";
            this.txtCutPath.ReadOnly = true;
            this.txtCutPath.Size = new System.Drawing.Size(489, 21);
            this.txtCutPath.TabIndex = 5;
            // 
            // btnCutPath
            // 
            this.btnCutPath.Location = new System.Drawing.Point(520, 25);
            this.btnCutPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnCutPath.Name = "btnCutPath";
            this.btnCutPath.Size = new System.Drawing.Size(73, 29);
            this.btnCutPath.TabIndex = 4;
            this.btnCutPath.Text = "配置";
            this.btnCutPath.UseVisualStyleBackColor = true;
            this.btnCutPath.Click += new System.EventHandler(this.btnCutPath_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkIsRar);
            this.groupBox2.Controls.Add(this.checkAutoStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMonitorTimes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMonitorPath);
            this.groupBox2.Controls.Add(this.btnMonitorPath);
            this.groupBox2.Location = new System.Drawing.Point(19, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(620, 98);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "监控图片路径配置";
            // 
            // checkIsRar
            // 
            this.checkIsRar.AutoSize = true;
            this.checkIsRar.Location = new System.Drawing.Point(326, 63);
            this.checkIsRar.Name = "checkIsRar";
            this.checkIsRar.Size = new System.Drawing.Size(60, 16);
            this.checkIsRar.TabIndex = 3;
            this.checkIsRar.Text = "压缩包";
            this.checkIsRar.UseVisualStyleBackColor = true;
            // 
            // checkAutoStart
            // 
            this.checkAutoStart.AutoSize = true;
            this.checkAutoStart.Location = new System.Drawing.Point(237, 63);
            this.checkAutoStart.Name = "checkAutoStart";
            this.checkAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkAutoStart.TabIndex = 3;
            this.checkAutoStart.Text = "自动启动";
            this.checkAutoStart.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "毫秒";
            // 
            // txtMonitorTimes
            // 
            this.txtMonitorTimes.Location = new System.Drawing.Point(115, 60);
            this.txtMonitorTimes.Name = "txtMonitorTimes";
            this.txtMonitorTimes.Size = new System.Drawing.Size(57, 21);
            this.txtMonitorTimes.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "监控时间间隔";
            // 
            // txtMonitorPath
            // 
            this.txtMonitorPath.Location = new System.Drawing.Point(9, 25);
            this.txtMonitorPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonitorPath.Name = "txtMonitorPath";
            this.txtMonitorPath.ReadOnly = true;
            this.txtMonitorPath.Size = new System.Drawing.Size(489, 21);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBakPath);
            this.groupBox3.Controls.Add(this.btnBakPath);
            this.groupBox3.Location = new System.Drawing.Point(19, 274);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(620, 81);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图片备份路径配置";
            // 
            // txtBakPath
            // 
            this.txtBakPath.Location = new System.Drawing.Point(9, 25);
            this.txtBakPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtBakPath.Name = "txtBakPath";
            this.txtBakPath.ReadOnly = true;
            this.txtBakPath.Size = new System.Drawing.Size(489, 21);
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
            // txtKitWidth
            // 
            this.txtKitWidth.Location = new System.Drawing.Point(485, 86);
            this.txtKitWidth.Name = "txtKitWidth";
            this.txtKitWidth.Size = new System.Drawing.Size(100, 21);
            this.txtKitWidth.TabIndex = 10;
            // 
            // txtKitHeight
            // 
            this.txtKitHeight.Location = new System.Drawing.Point(485, 58);
            this.txtKitHeight.Name = "txtKitHeight";
            this.txtKitHeight.Size = new System.Drawing.Size(100, 21);
            this.txtKitHeight.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "缩放后的宽";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "缩放后的长";
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 427);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfigForm";
            this.Text = "系统配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCutPath;
        private System.Windows.Forms.Button btnCutPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkAutoStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonitorTimes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonitorPath;
        private System.Windows.Forms.Button btnMonitorPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBakPath;
        private System.Windows.Forms.Button btnBakPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartY;
        private System.Windows.Forms.TextBox txtStartX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCutWidth;
        private System.Windows.Forms.TextBox txtCutLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkIsRar;
        private System.Windows.Forms.TextBox txtKitWidth;
        private System.Windows.Forms.TextBox txtKitHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}