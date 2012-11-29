namespace HiPiaoTerminal.CommonForm
{
    partial class SelectSeatMessageFirst
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
            this.lbMsg1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.picSure = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg1
            // 
            this.lbMsg1.Font = new System.Drawing.Font("方正兰亭纤黑简体", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMsg1.Location = new System.Drawing.Point(27, 47);
            this.lbMsg1.Margin = new System.Windows.Forms.Padding(27, 0, 27, 0);
            this.lbMsg1.Name = "lbMsg1";
            this.lbMsg1.Size = new System.Drawing.Size(571, 63);
            this.lbMsg1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.lbMsg1.TabIndex = 11;
            this.lbMsg1.Text = "温馨提示，请勿间隔选座！";
            this.lbMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSure
            // 
            this.picSure.BackgroundImage = global::HiPiaoTerminal.Properties.Resources.btnSure;
            this.picSure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSure.Location = new System.Drawing.Point(140, 154);
            this.picSure.Margin = new System.Windows.Forms.Padding(27, 32, 27, 32);
            this.picSure.Name = "picSure";
            this.picSure.Size = new System.Drawing.Size(297, 111);
            this.picSure.TabIndex = 10;
            this.picSure.TabStop = false;
            this.picSure.Click += new System.EventHandler(this.picSure_Click);
            // 
            // SelectSeatMessageFirst
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbMsg1);
            this.Controls.Add(this.picSure);
            this.Name = "SelectSeatMessageFirst";
            this.Size = new System.Drawing.Size(604, 297);
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel lbMsg1;
        private System.Windows.Forms.PictureBox picSure;
    }
}
