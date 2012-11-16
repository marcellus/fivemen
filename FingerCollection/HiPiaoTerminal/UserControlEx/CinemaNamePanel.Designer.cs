namespace HiPiaoTerminal.UserControlEx
{
    partial class CinemaNamePanel
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
            this.simpleLabel1 = new FT.Windows.Controls.LabelEx.SimpleLabel();
            this.SuspendLayout();
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Font = new System.Drawing.Font("方正兰亭细黑_GBK", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.simpleLabel1.Location = new System.Drawing.Point(5, 7);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(184, 28);
            this.simpleLabel1.Skin = FT.Windows.Controls.SimpleSkinType.Custom;
            this.simpleLabel1.TabIndex = 7;
            this.simpleLabel1.Text = "simpleLabel1";
            // 
            // CinemaNamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleLabel1);
            this.Name = "CinemaNamePanel";
            this.Size = new System.Drawing.Size(251, 48);
            this.Load += new System.EventHandler(this.CinemaNamePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Controls.LabelEx.SimpleLabel simpleLabel1;
    }
}
