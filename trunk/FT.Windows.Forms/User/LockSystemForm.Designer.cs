namespace FT.Windows.Forms
{
    partial class LockSystemForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnlock);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 13F);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入解锁密码：";
            // 
            // btnUnlock
            // 
            this.btnUnlock.Image = global::FT.Windows.Forms.Properties.Resources.Login;
            this.btnUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnlock.Location = new System.Drawing.Point(48, 48);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(17, 21);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(162, 27);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // LockSystemForm
            // 
            this.AcceptButton = this.btnUnlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 89);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockSystemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统锁定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.TextBox txtPassword;
    }
}