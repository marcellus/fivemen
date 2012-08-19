namespace FT.Windows.Controls.ButtonEx
{
    partial class ActiveWithArrowButton
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
            this.lbHintText.AutoSize = true;
            this.lbHintText.BackColor = System.Drawing.Color.Transparent;
            this.lbHintText.Location = new System.Drawing.Point(19, 19);
            this.lbHintText.Name = "lbHintText";
            this.lbHintText.Size = new System.Drawing.Size(79, 30);
            this.lbHintText.TabIndex = 0;
            this.lbHintText.Text = "label1";
            this.lbHintText.Click += new System.EventHandler(this.lbHintText_Click);
            // 
            // ActiveWithArrowButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbHintText);
            this.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ActiveWithArrowButton";
            this.Size = new System.Drawing.Size(218, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHintText;
    }
}
