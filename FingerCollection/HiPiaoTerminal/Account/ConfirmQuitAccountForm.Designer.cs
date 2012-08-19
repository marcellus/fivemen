namespace HiPiaoTerminal.Account
{
    partial class ConfirmQuitAccountForm
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
            this.btnConfirmQuitAccount = new System.Windows.Forms.PictureBox();
            this.btnSure = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmQuitAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmQuitAccount
            // 
            this.btnConfirmQuitAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmQuitAccount.Location = new System.Drawing.Point(106, 98);
            this.btnConfirmQuitAccount.Name = "btnConfirmQuitAccount";
            this.btnConfirmQuitAccount.Size = new System.Drawing.Size(599, 142);
            this.btnConfirmQuitAccount.TabIndex = 0;
            this.btnConfirmQuitAccount.TabStop = false;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(76, 322);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(298, 115);
            this.btnSure.TabIndex = 1;
            this.btnSure.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(437, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(298, 115);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            // 
            // ConfirmQuitAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnConfirmQuitAccount);
            this.Name = "ConfirmQuitAccountForm";
            this.Load += new System.EventHandler(this.ConfirmQuitAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmQuitAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnConfirmQuitAccount;
        private System.Windows.Forms.PictureBox btnSure;
        private System.Windows.Forms.PictureBox btnCancel;
    }
}
