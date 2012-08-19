namespace HiPiaoTerminal.Account
{
    partial class UIdOrPwdErrorPanel
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
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnModify = new System.Windows.Forms.PictureBox();
            this.btnConfirmQuitAccount = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmQuitAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(295, 112);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_Modify;
            this.btnModify.Location = new System.Drawing.Point(71, 300);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(295, 112);
            this.btnModify.TabIndex = 4;
            this.btnModify.TabStop = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnConfirmQuitAccount
            // 
            this.btnConfirmQuitAccount.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.Account_UidOrPwd_Error;
            this.btnConfirmQuitAccount.Location = new System.Drawing.Point(71, 75);
            this.btnConfirmQuitAccount.Name = "btnConfirmQuitAccount";
            this.btnConfirmQuitAccount.Size = new System.Drawing.Size(650, 100);
            this.btnConfirmQuitAccount.TabIndex = 2;
            this.btnConfirmQuitAccount.TabStop = false;
            // 
            // UIdOrPwdErrorForm
            // 
           
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnConfirmQuitAccount);
            this.Name = "UIdOrPwdErrorForm";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmQuitAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox btnModify;
        private System.Windows.Forms.PictureBox btnConfirmQuitAccount;
    }
}
