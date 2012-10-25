namespace HiPiaoTerminal.CommonForm
{
    partial class MessagePanelSecond
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
            this.lbMsg2 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.lbMsg1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picSure = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg2
            // 
            this.lbMsg2.Font = new System.Drawing.Font("微软雅黑", 33.25F, System.Drawing.FontStyle.Bold);
            this.lbMsg2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg2.Location = new System.Drawing.Point(6, 183);
            this.lbMsg2.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg2.Name = "lbMsg2";
            this.lbMsg2.Size = new System.Drawing.Size(792, 64);
            this.lbMsg2.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg2.TabIndex = 11;
            this.lbMsg2.Text = "label1";
            this.lbMsg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMsg1
            // 
            this.lbMsg1.Font = new System.Drawing.Font("微软雅黑", 33.25F, System.Drawing.FontStyle.Bold);
            this.lbMsg1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg1.Location = new System.Drawing.Point(8, 92);
            this.lbMsg1.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg1.Name = "lbMsg1";
            this.lbMsg1.Size = new System.Drawing.Size(790, 63);
            this.lbMsg1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg1.TabIndex = 12;
            this.lbMsg1.Text = "网络故障，请向影院工作人员垂询！";
            this.lbMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSure
            // 
            this.picSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnSure_Second;
            this.picSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSure.Location = new System.Drawing.Point(231, 325);
            this.picSure.Margin = new System.Windows.Forms.Padding(27, 32, 27, 32);
            this.picSure.Name = "picSure";
            this.picSure.Size = new System.Drawing.Size(294, 110);
            this.picSure.TabIndex = 10;
            this.picSure.TabStop = false;
            this.picSure.Click += new System.EventHandler(this.picSure_Click);
            // 
            // MessagePanelSeccond
            // 
            this.Controls.Add(this.lbMsg2);
            this.Controls.Add(this.lbMsg1);
            this.Controls.Add(this.picSure);
            this.Name = "MessagePanelSeccond";
            this.Size = new System.Drawing.Size(804, 492);
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg2;
        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg1;
        private System.Windows.Forms.PictureBox picSure;
    }
}
