namespace HiPiaoTerminal.Account
{
    partial class NotifyBindMobilePanel
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
            this.panelBack = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Label();
            this.panelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_NotifyBindMobile_Back;
            this.panelBack.Controls.Add(this.btnSure);
            this.panelBack.Controls.Add(this.btnCancel);
            this.panelBack.Location = new System.Drawing.Point(48, 65);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(892, 568);
            this.panelBack.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(492, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(279, 96);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.Location = new System.Drawing.Point(123, 461);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(279, 96);
            this.btnSure.TabIndex = 0;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // NotifyBindMobilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.panelBack);
            this.Name = "NotifyBindMobilePanel";
            this.Size = new System.Drawing.Size(996, 700);
            this.panelBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Label btnCancel;
        private System.Windows.Forms.Label btnSure;
    }
}
