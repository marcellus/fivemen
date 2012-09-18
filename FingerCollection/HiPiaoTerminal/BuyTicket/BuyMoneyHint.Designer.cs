namespace HiPiaoTerminal.BuyTicket
{
    partial class BuyMoneyHint
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
            this.btnQuitAccout = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuitAccout
            // 
            this.btnQuitAccout.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitAccout.Location = new System.Drawing.Point(85, 340);
            this.btnQuitAccout.Name = "btnQuitAccout";
            this.btnQuitAccout.Size = new System.Drawing.Size(274, 94);
            this.btnQuitAccout.TabIndex = 0;
            this.btnQuitAccout.Click += new System.EventHandler(this.btnQuitAccout_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(449, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(274, 94);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BuyMoneyHint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BuyTick_Money_Hint;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuitAccout);
            this.Name = "BuyMoneyHint";
            this.Size = new System.Drawing.Size(805, 490);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btnQuitAccout;
        private System.Windows.Forms.Label btnCancel;

    }
}
