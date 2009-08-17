namespace DS.Plugins.Student
{
    partial class DriverPicCapture
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

     

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverPicCapture));
            this.btnDeviceSet = new System.Windows.Forms.Button();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIdCardType = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnPathSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPicPath = new System.Windows.Forms.TextBox();
            this.picPic = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.btnExportPathSet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeviceSet
            // 
            this.btnDeviceSet.Location = new System.Drawing.Point(267, 16);
            this.btnDeviceSet.Name = "btnDeviceSet";
            this.btnDeviceSet.Size = new System.Drawing.Size(75, 23);
            this.btnDeviceSet.TabIndex = 0;
            this.btnDeviceSet.Text = "配置外设";
            this.btnDeviceSet.UseVisualStyleBackColor = true;
            this.btnDeviceSet.Click += new System.EventHandler(this.btnDeviceSet_Click);
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(6, 18);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(255, 24);
            this.txtIdCard.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbIdCardType);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnBegin);
            this.groupBox1.Controls.Add(this.txtIdCard);
            this.groupBox1.Controls.Add(this.btnDeviceSet);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 77);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入要采集人的身份证明号码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "身份证明名称";
            // 
            // cbIdCardType
            // 
            this.cbIdCardType.FormattingEnabled = true;
            this.cbIdCardType.Location = new System.Drawing.Point(115, 44);
            this.cbIdCardType.Margin = new System.Windows.Forms.Padding(2);
            this.cbIdCardType.Name = "cbIdCardType";
            this.cbIdCardType.Size = new System.Drawing.Size(152, 23);
            this.cbIdCardType.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(402, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(48, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(348, 16);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(48, 23);
            this.btnBegin.TabIndex = 3;
            this.btnBegin.Text = "采集";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnPathSet
            // 
            this.btnPathSet.Location = new System.Drawing.Point(390, 20);
            this.btnPathSet.Name = "btnPathSet";
            this.btnPathSet.Size = new System.Drawing.Size(55, 23);
            this.btnPathSet.TabIndex = 4;
            this.btnPathSet.Text = "配置";
            this.btnPathSet.UseVisualStyleBackColor = true;
            this.btnPathSet.Click += new System.EventHandler(this.btnPathSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPicPath);
            this.groupBox2.Controls.Add(this.btnPathSet);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox2.Location = new System.Drawing.Point(13, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 57);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置图像采集路径";
            // 
            // txtPicPath
            // 
            this.txtPicPath.Location = new System.Drawing.Point(7, 20);
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.ReadOnly = true;
            this.txtPicPath.Size = new System.Drawing.Size(368, 24);
            this.txtPicPath.TabIndex = 5;
            // 
            // picPic
            // 
            this.picPic.Location = new System.Drawing.Point(180, 224);
            this.picPic.Name = "picPic";
            this.picPic.Size = new System.Drawing.Size(99, 138);
            this.picPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPic.TabIndex = 6;
            this.picPic.TabStop = false;
            this.picPic.Click += new System.EventHandler(this.picPic_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtExportPath);
            this.groupBox3.Controls.Add(this.btnExportPathSet);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox3.Location = new System.Drawing.Point(12, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 57);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配置图像导出路径";
            // 
            // txtExportPath
            // 
            this.txtExportPath.Location = new System.Drawing.Point(7, 20);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.ReadOnly = true;
            this.txtExportPath.Size = new System.Drawing.Size(368, 24);
            this.txtExportPath.TabIndex = 5;
            // 
            // btnExportPathSet
            // 
            this.btnExportPathSet.Location = new System.Drawing.Point(390, 20);
            this.btnExportPathSet.Name = "btnExportPathSet";
            this.btnExportPathSet.Size = new System.Drawing.Size(55, 23);
            this.btnExportPathSet.TabIndex = 4;
            this.btnExportPathSet.Text = "配置";
            this.btnExportPathSet.UseVisualStyleBackColor = true;
            this.btnExportPathSet.Click += new System.EventHandler(this.btnExportPathSet_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(12, 257);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 18);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DriverPicCapture
            // 
            this.Appearance.Font = new System.Drawing.Font("宋体", 9F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 390);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picPic);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverPicCapture";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "照片采集";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeviceSet;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPathSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPicPath;
        private System.Windows.Forms.PictureBox picPic;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button btnExportPathSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIdCardType;
    }
}