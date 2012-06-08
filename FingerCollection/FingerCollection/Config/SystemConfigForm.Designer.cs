namespace FingerCollection.Config
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthenID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthenPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXSDevName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSchoolCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFTPUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFTPName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUploadFilePre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFTPPwd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLeftPoint = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTopPoint = new System.Windows.Forms.TextBox();
            this.checkIsPrintSchool = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "主机IP：";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(111, 9);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(314, 21);
            this.txtHostName.TabIndex = 2;
            this.txtHostName.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品ID：";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(111, 46);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(72, 21);
            this.txtProductID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "使用端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(111, 83);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(72, 21);
            this.txtPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "验证用户：";
            // 
            // txtAuthenID
            // 
            this.txtAuthenID.Location = new System.Drawing.Point(111, 120);
            this.txtAuthenID.Name = "txtAuthenID";
            this.txtAuthenID.Size = new System.Drawing.Size(72, 21);
            this.txtAuthenID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "验证密码：";
            // 
            // txtAuthenPwd
            // 
            this.txtAuthenPwd.Location = new System.Drawing.Point(111, 157);
            this.txtAuthenPwd.Name = "txtAuthenPwd";
            this.txtAuthenPwd.Size = new System.Drawing.Size(72, 21);
            this.txtAuthenPwd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "DLL名称：";
            // 
            // txtXSDevName
            // 
            this.txtXSDevName.Location = new System.Drawing.Point(111, 194);
            this.txtXSDevName.Name = "txtXSDevName";
            this.txtXSDevName.Size = new System.Drawing.Size(314, 21);
            this.txtXSDevName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "驾校名称：";
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(111, 231);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(314, 21);
            this.txtSchoolName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "驾校代码：";
            // 
            // txtSchoolCode
            // 
            this.txtSchoolCode.Location = new System.Drawing.Point(111, 268);
            this.txtSchoolCode.Name = "txtSchoolCode";
            this.txtSchoolCode.Size = new System.Drawing.Size(314, 21);
            this.txtSchoolCode.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "FTP的Url：";
            // 
            // txtFTPUrl
            // 
            this.txtFTPUrl.Location = new System.Drawing.Point(248, 46);
            this.txtFTPUrl.Name = "txtFTPUrl";
            this.txtFTPUrl.Size = new System.Drawing.Size(177, 21);
            this.txtFTPUrl.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "FTP用户名：";
            // 
            // txtFTPName
            // 
            this.txtFTPName.Location = new System.Drawing.Point(260, 86);
            this.txtFTPName.Name = "txtFTPName";
            this.txtFTPName.Size = new System.Drawing.Size(165, 21);
            this.txtFTPName.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "上传文件前缀：";
            // 
            // txtUploadFilePre
            // 
            this.txtUploadFilePre.Location = new System.Drawing.Point(273, 157);
            this.txtUploadFilePre.Name = "txtUploadFilePre";
            this.txtUploadFilePre.Size = new System.Drawing.Size(152, 21);
            this.txtUploadFilePre.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(189, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "FTP密码：";
            // 
            // txtFTPPwd
            // 
            this.txtFTPPwd.Location = new System.Drawing.Point(260, 126);
            this.txtFTPPwd.Name = "txtFTPPwd";
            this.txtFTPPwd.PasswordChar = '*';
            this.txtFTPPwd.Size = new System.Drawing.Size(165, 21);
            this.txtFTPPwd.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "打印左边距：";
            // 
            // txtLeftPoint
            // 
            this.txtLeftPoint.Location = new System.Drawing.Point(111, 301);
            this.txtLeftPoint.Name = "txtLeftPoint";
            this.txtLeftPoint.Size = new System.Drawing.Size(61, 21);
            this.txtLeftPoint.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(189, 304);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "上边距：";
            // 
            // txtTopPoint
            // 
            this.txtTopPoint.Location = new System.Drawing.Point(260, 301);
            this.txtTopPoint.Name = "txtTopPoint";
            this.txtTopPoint.Size = new System.Drawing.Size(61, 21);
            this.txtTopPoint.TabIndex = 2;
            // 
            // checkIsPrintSchool
            // 
            this.checkIsPrintSchool.AutoSize = true;
            this.checkIsPrintSchool.Location = new System.Drawing.Point(344, 305);
            this.checkIsPrintSchool.Name = "checkIsPrintSchool";
            this.checkIsPrintSchool.Size = new System.Drawing.Size(108, 16);
            this.checkIsPrintSchool.TabIndex = 3;
            this.checkIsPrintSchool.Text = "是否打印学校名";
            this.checkIsPrintSchool.UseVisualStyleBackColor = true;
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 379);
            this.Controls.Add(this.checkIsPrintSchool);
            this.Controls.Add(this.txtTopPoint);
            this.Controls.Add(this.txtLeftPoint);
            this.Controls.Add(this.txtSchoolCode);
            this.Controls.Add(this.txtSchoolName);
            this.Controls.Add(this.txtXSDevName);
            this.Controls.Add(this.txtAuthenPwd);
            this.Controls.Add(this.txtAuthenID);
            this.Controls.Add(this.txtFTPPwd);
            this.Controls.Add(this.txtUploadFilePre);
            this.Controls.Add(this.txtFTPName);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtFTPUrl);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "SystemConfigForm";
            this.Text = "系统属性配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthenID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuthenPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXSDevName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSchoolCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFTPUrl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFTPName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUploadFilePre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFTPPwd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLeftPoint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTopPoint;
        private System.Windows.Forms.CheckBox checkIsPrintSchool;
    }
}