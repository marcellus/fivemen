namespace HiPiaoTerminal.BuyTicket
{
    partial class ShowWelcomePanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbBalance = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbPoints = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbCoupons = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbUserName = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.BackColor = System.Drawing.Color.Transparent;
            this.lbBalance.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.lbBalance.Location = new System.Drawing.Point(302, 13);
            this.lbBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(189, 27);
            this.lbBalance.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbBalance.TabIndex = 1;
            this.lbBalance.Text = "账户余额：{0}元";
            // 
            // lbPoints
            // 
            this.lbPoints.AutoSize = true;
            this.lbPoints.BackColor = System.Drawing.Color.Transparent;
            this.lbPoints.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.lbPoints.Location = new System.Drawing.Point(302, 41);
            this.lbPoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPoints.Name = "lbPoints";
            this.lbPoints.Size = new System.Drawing.Size(117, 27);
            this.lbPoints.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbPoints.TabIndex = 1;
            this.lbPoints.Text = "积分：{0}";
            // 
            // lbCoupons
            // 
            this.lbCoupons.AutoSize = true;
            this.lbCoupons.BackColor = System.Drawing.Color.Transparent;
            this.lbCoupons.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCoupons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.lbCoupons.Location = new System.Drawing.Point(17, 41);
            this.lbCoupons.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCoupons.Name = "lbCoupons";
            this.lbCoupons.Size = new System.Drawing.Size(277, 27);
            this.lbCoupons.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbCoupons.TabIndex = 1;
            this.lbCoupons.Text = "兑换券：{0} 抵扣券：{1}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 27);
            this.label2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label2.TabIndex = 1;
            this.label2.Text = "欢迎回来";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("方正兰亭纤黑简体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.Location = new System.Drawing.Point(119, 13);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(82, 27);
            this.lbUserName.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "label1";
            // 
            // ShowWelcomePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.ShowWelcomeBack;
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.lbPoints);
            this.Controls.Add(this.lbCoupons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUserName);
            this.Font = new System.Drawing.Font("方正兰亭黑简体", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(0)))));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "ShowWelcomePanel";
            this.Size = new System.Drawing.Size(527, 80);
            this.Load += new System.EventHandler(this.ShowWelcomePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbUserName;
        private FT.Windows.Controls.LabelEx.SimpleLabel label2;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbPoints;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbCoupons;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbBalance;
    }
}
