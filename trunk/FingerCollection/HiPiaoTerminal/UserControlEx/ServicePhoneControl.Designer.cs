namespace HiPiaoTerminal.UserControlEx
{
    partial class ServicePhoneControl
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
            this.lbServicePhone = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.label1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // lbServicePhone
            // 
            this.lbServicePhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbServicePhone.AutoSize = true;
            this.lbServicePhone.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbServicePhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(202)))), ((int)(((byte)(14)))));
            this.lbServicePhone.Location = new System.Drawing.Point(58, 47);
            this.lbServicePhone.Name = "lbServicePhone";
            this.lbServicePhone.Size = new System.Drawing.Size(150, 28);
            this.lbServicePhone.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbServicePhone.TabIndex = 3;
            this.lbServicePhone.Text = "440-5566-444";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(73, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 41);
            this.label1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.label1.TabIndex = 2;
            this.label1.Text = "服务热线";
            // 
            // ServicePhoneControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lbServicePhone);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Name = "ServicePhoneControl";
            this.Size = new System.Drawing.Size(224, 75);
            this.Load += new System.EventHandler(this.ServicePhoneControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbServicePhone;
        private FT.Windows.Controls.LabelEx.SimpleLabel label1;
    }
}
