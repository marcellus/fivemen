namespace HiPiaoTerminal.Account
{
    partial class BindMobileSuccessPanel
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
            this.lbUserName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMobile = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.simpleLabel3 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.btnBuyTicket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuyTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 36F);
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbUserName.Location = new System.Drawing.Point(268, 277);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(279, 55);
            this.lbUserName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "用户名：{0}";
            // 
            // lbMobile
            // 
            this.lbMobile.AutoSize = true;
            this.lbMobile.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 36F);
            this.lbMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.lbMobile.Location = new System.Drawing.Point(268, 339);
            this.lbMobile.Name = "lbMobile";
            this.lbMobile.Size = new System.Drawing.Size(279, 55);
            this.lbMobile.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMobile.TabIndex = 2;
            this.lbMobile.Text = "手机号：{0}";
            // 
            // simpleLabel3
            // 
            this.simpleLabel3.AutoSize = true;
            this.simpleLabel3.Font = new System.Drawing.Font("方正兰亭粗黑简体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.simpleLabel3.Location = new System.Drawing.Point(186, 80);
            this.simpleLabel3.Name = "simpleLabel3";
            this.simpleLabel3.Size = new System.Drawing.Size(623, 110);
            this.simpleLabel3.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel3.TabIndex = 2;
            this.simpleLabel3.Text = "手机绑定成功";
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.BindMobile_Success_BuyTicket;
            this.btnBuyTicket.Location = new System.Drawing.Point(354, 475);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(294, 111);
            this.btnBuyTicket.TabIndex = 3;
            this.btnBuyTicket.TabStop = false;
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // BindMobileSuccessPanel
            // 
            this.Controls.Add(this.btnBuyTicket);
            this.Controls.Add(this.lbMobile);
            this.Controls.Add(this.simpleLabel3);
            this.Controls.Add(this.lbUserName);
            this.Name = "BindMobileSuccessPanel";
            this.Size = new System.Drawing.Size(996, 700);
            ((System.ComponentModel.ISupportInitialize)(this.btnBuyTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserName;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMobile;
        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel3;
        private System.Windows.Forms.PictureBox btnBuyTicket;
    }
}
