namespace FT.Exam
{
    partial class TopicShow
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
            this.lbNum = new System.Windows.Forms.Label();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.BackColor = System.Drawing.Color.Transparent;
            this.lbNum.Location = new System.Drawing.Point(3, 3);
            this.lbNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(15, 15);
            this.lbNum.TabIndex = 0;
            this.lbNum.Text = "1";
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.BackColor = System.Drawing.Color.Transparent;
            this.lbAnswer.Font = new System.Drawing.Font("宋体", 11F);
            this.lbAnswer.ForeColor = System.Drawing.Color.Brown;
            this.lbAnswer.Location = new System.Drawing.Point(15, 15);
            this.lbAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(15, 15);
            this.lbAnswer.TabIndex = 1;
            this.lbAnswer.Text = "A";
            // 
            // TopicShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbAnswer);
            this.Controls.Add(this.lbNum);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TopicShow";
            this.Size = new System.Drawing.Size(45, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Label lbAnswer;
    }
}
