namespace HiPiaoTerminal.CommonForm
{
    partial class UnLockPanel
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
            this.txtManagePwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbReturnMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnUnLock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUnLock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtManagePwd
            // 
            this.txtManagePwd.Font = new System.Drawing.Font("宋体", 23F);
            this.txtManagePwd.Location = new System.Drawing.Point(25, 100);
            this.txtManagePwd.Name = "txtManagePwd";
            this.txtManagePwd.PasswordChar = '*';
            this.txtManagePwd.Size = new System.Drawing.Size(354, 42);
            this.txtManagePwd.TabIndex = 4;
            this.txtManagePwd.TextChanged += new System.EventHandler(this.txtManagePwd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 23F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(19, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入解锁密码";
            // 
            // lbReturnMsg
            // 
            this.lbReturnMsg.AutoSize = true;
            this.lbReturnMsg.Font = new System.Drawing.Font("宋体", 18F);
            this.lbReturnMsg.ForeColor = System.Drawing.Color.Red;
            this.lbReturnMsg.Location = new System.Drawing.Point(19, 16);
            this.lbReturnMsg.Name = "lbReturnMsg";
            this.lbReturnMsg.Size = new System.Drawing.Size(0, 24);
            this.lbReturnMsg.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnCancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Location = new System.Drawing.Point(224, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUnLock
            // 
            this.btnUnLock.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnSure;
            this.btnUnLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUnLock.Location = new System.Drawing.Point(36, 177);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(135, 50);
            this.btnUnLock.TabIndex = 6;
            this.btnUnLock.TabStop = false;
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // UnLockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.lbReturnMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUnLock);
            this.Controls.Add(this.txtManagePwd);
            this.Controls.Add(this.label1);
            this.Name = "UnLockPanel";
            this.Size = new System.Drawing.Size(415, 264);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUnLock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtManagePwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnUnLock;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.Label lbReturnMsg;
    }
}
