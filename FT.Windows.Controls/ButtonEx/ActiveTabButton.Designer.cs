namespace FT.Windows.Controls.ButtonEx
{
    partial class ActiveTabButton
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
            this.lbHintText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHintText
            // 
            this.lbHintText.BackColor = System.Drawing.Color.Transparent;
            this.lbHintText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHintText.Font = new System.Drawing.Font("方正兰亭黑简体", 21F);
            this.lbHintText.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbHintText.Location = new System.Drawing.Point(0, 0);
            this.lbHintText.Name = "lbHintText";
            this.lbHintText.Size = new System.Drawing.Size(223, 70);
            this.lbHintText.TabIndex = 0;
            this.lbHintText.Text = "label1";
            this.lbHintText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHintText.Click += new System.EventHandler(this.lbHintText_Click);
            // 
            // ActiveTabButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbHintText);
            this.Name = "ActiveTabButton";
            this.Size = new System.Drawing.Size(223, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHintText;
    }
}
