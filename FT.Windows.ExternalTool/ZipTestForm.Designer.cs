namespace FT.Windows.ExternalTool
{
    partial class ZipTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipTestForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZipDir = new System.Windows.Forms.TextBox();
            this.btnZipDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnZipDir = new System.Windows.Forms.TextBox();
            this.btnUnzipDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZipFile = new System.Windows.Forms.TextBox();
            this.btnZipFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnZipFile = new System.Windows.Forms.TextBox();
            this.btnUnZipFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUnZip = new System.Windows.Forms.Button();
            this.btnZip = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZip);
            this.groupBox1.Controls.Add(this.txtZipFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnZipFile);
            this.groupBox1.Controls.Add(this.btnZipDir);
            this.groupBox1.Controls.Add(this.txtZipDir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "压缩目录选择";
            // 
            // txtZipDir
            // 
            this.txtZipDir.Location = new System.Drawing.Point(14, 32);
            this.txtZipDir.Name = "txtZipDir";
            this.txtZipDir.ReadOnly = true;
            this.txtZipDir.Size = new System.Drawing.Size(190, 21);
            this.txtZipDir.TabIndex = 1;
            // 
            // btnZipDir
            // 
            this.btnZipDir.Location = new System.Drawing.Point(211, 29);
            this.btnZipDir.Name = "btnZipDir";
            this.btnZipDir.Size = new System.Drawing.Size(43, 23);
            this.btnZipDir.TabIndex = 2;
            this.btnZipDir.Text = "...";
            this.btnZipDir.UseVisualStyleBackColor = true;
            this.btnZipDir.Click += new System.EventHandler(this.btnZipDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "解压目录选择";
            // 
            // txtUnZipDir
            // 
            this.txtUnZipDir.Location = new System.Drawing.Point(14, 33);
            this.txtUnZipDir.Name = "txtUnZipDir";
            this.txtUnZipDir.ReadOnly = true;
            this.txtUnZipDir.Size = new System.Drawing.Size(190, 21);
            this.txtUnZipDir.TabIndex = 4;
            // 
            // btnUnzipDir
            // 
            this.btnUnzipDir.Location = new System.Drawing.Point(211, 33);
            this.btnUnzipDir.Name = "btnUnzipDir";
            this.btnUnzipDir.Size = new System.Drawing.Size(43, 23);
            this.btnUnzipDir.TabIndex = 2;
            this.btnUnzipDir.Text = "...";
            this.btnUnzipDir.UseVisualStyleBackColor = true;
            this.btnUnzipDir.Click += new System.EventHandler(this.btnUnzipDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "压缩成Zip文件：";
            // 
            // txtZipFile
            // 
            this.txtZipFile.Location = new System.Drawing.Point(14, 80);
            this.txtZipFile.Name = "txtZipFile";
            this.txtZipFile.ReadOnly = true;
            this.txtZipFile.Size = new System.Drawing.Size(190, 21);
            this.txtZipFile.TabIndex = 6;
            // 
            // btnZipFile
            // 
            this.btnZipFile.Location = new System.Drawing.Point(211, 78);
            this.btnZipFile.Name = "btnZipFile";
            this.btnZipFile.Size = new System.Drawing.Size(43, 23);
            this.btnZipFile.TabIndex = 2;
            this.btnZipFile.Text = "...";
            this.btnZipFile.UseVisualStyleBackColor = true;
            this.btnZipFile.Click += new System.EventHandler(this.btnZipFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "待解压的Zip文件";
            // 
            // txtUnZipFile
            // 
            this.txtUnZipFile.Location = new System.Drawing.Point(16, 77);
            this.txtUnZipFile.Name = "txtUnZipFile";
            this.txtUnZipFile.ReadOnly = true;
            this.txtUnZipFile.Size = new System.Drawing.Size(188, 21);
            this.txtUnZipFile.TabIndex = 8;
            // 
            // btnUnZipFile
            // 
            this.btnUnZipFile.Location = new System.Drawing.Point(211, 75);
            this.btnUnZipFile.Name = "btnUnZipFile";
            this.btnUnZipFile.Size = new System.Drawing.Size(43, 23);
            this.btnUnZipFile.TabIndex = 2;
            this.btnUnZipFile.Text = "...";
            this.btnUnZipFile.UseVisualStyleBackColor = true;
            this.btnUnZipFile.Click += new System.EventHandler(this.btnUnZipFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnZip);
            this.groupBox2.Controls.Add(this.txtUnZipFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnUnzipDir);
            this.groupBox2.Controls.Add(this.btnUnZipFile);
            this.groupBox2.Controls.Add(this.txtUnZipDir);
            this.groupBox2.Location = new System.Drawing.Point(13, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unzip";
            // 
            // btnUnZip
            // 
            this.btnUnZip.Location = new System.Drawing.Point(96, 100);
            this.btnUnZip.Name = "btnUnZip";
            this.btnUnZip.Size = new System.Drawing.Size(75, 23);
            this.btnUnZip.TabIndex = 9;
            this.btnUnZip.Text = "开始解压";
            this.btnUnZip.UseVisualStyleBackColor = true;
            this.btnUnZip.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(96, 113);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(75, 23);
            this.btnZip.TabIndex = 10;
            this.btnZip.Text = "开始压缩";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(48, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(169, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // ZipTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 324);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZipTestForm";
            this.Text = "压缩解压";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZipDir;
        private System.Windows.Forms.TextBox txtZipDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnZipDir;
        private System.Windows.Forms.Button btnUnzipDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZipFile;
        private System.Windows.Forms.Button btnZipFile;
        private System.Windows.Forms.TextBox txtUnZipFile;
        private System.Windows.Forms.Button btnUnZipFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUnZip;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
    }
}