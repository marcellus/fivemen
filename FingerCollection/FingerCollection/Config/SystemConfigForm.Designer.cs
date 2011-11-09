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
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(194, 281);
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
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "主机IP：";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(111, 31);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(314, 21);
            this.txtHostName.TabIndex = 2;
            this.txtHostName.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品ID：";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(111, 68);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(314, 21);
            this.txtProductID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "使用端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(111, 115);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(314, 21);
            this.txtPort.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "验证用户：";
            // 
            // txtAuthenID
            // 
            this.txtAuthenID.Location = new System.Drawing.Point(111, 160);
            this.txtAuthenID.Name = "txtAuthenID";
            this.txtAuthenID.Size = new System.Drawing.Size(314, 21);
            this.txtAuthenID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "验证密码：";
            // 
            // txtAuthenPwd
            // 
            this.txtAuthenPwd.Location = new System.Drawing.Point(111, 199);
            this.txtAuthenPwd.Name = "txtAuthenPwd";
            this.txtAuthenPwd.Size = new System.Drawing.Size(314, 21);
            this.txtAuthenPwd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "DLL名称：";
            // 
            // txtXSDevName
            // 
            this.txtXSDevName.Location = new System.Drawing.Point(111, 234);
            this.txtXSDevName.Name = "txtXSDevName";
            this.txtXSDevName.Size = new System.Drawing.Size(314, 21);
            this.txtXSDevName.TabIndex = 2;
            // 
            // SystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 325);
            this.Controls.Add(this.txtXSDevName);
            this.Controls.Add(this.txtAuthenPwd);
            this.Controls.Add(this.txtAuthenID);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
    }
}