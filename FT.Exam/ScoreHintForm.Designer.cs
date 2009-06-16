namespace FT.Exam
{
    partial class ScoreHintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreHintForm));
            this.lbName = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbHint = new System.Windows.Forms.Label();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnErrorReturn = new System.Windows.Forms.Button();
            this.lbHint3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(13, 35);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(91, 15);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "XX先生/女士";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(53, 72);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(188, 15);
            this.lbScore.TabIndex = 1;
            this.lbScore.Text = "您当前的考试成绩为90分。";
            // 
            // lbHint
            // 
            this.lbHint.AutoSize = true;
            this.lbHint.Location = new System.Drawing.Point(53, 102);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(150, 15);
            this.lbHint.TabIndex = 2;
            this.lbHint.Text = "恭喜您通过本次考试!";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(31, 166);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 3;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnErrorReturn
            // 
            this.btnErrorReturn.Location = new System.Drawing.Point(222, 166);
            this.btnErrorReturn.Name = "btnErrorReturn";
            this.btnErrorReturn.Size = new System.Drawing.Size(75, 23);
            this.btnErrorReturn.TabIndex = 4;
            this.btnErrorReturn.Text = "错题回顾";
            this.btnErrorReturn.UseVisualStyleBackColor = true;
            this.btnErrorReturn.Click += new System.EventHandler(this.btnErrorReturn_Click);
            // 
            // lbHint3
            // 
            this.lbHint3.AutoSize = true;
            this.lbHint3.Location = new System.Drawing.Point(56, 131);
            this.lbHint3.Name = "lbHint3";
            this.lbHint3.Size = new System.Drawing.Size(0, 15);
            this.lbHint3.TabIndex = 5;
            // 
            // ScoreHintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 230);
            this.Controls.Add(this.lbHint3);
            this.Controls.Add(this.btnErrorReturn);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.lbHint);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.lbName);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScoreHintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩提示窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbHint;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnErrorReturn;
        private System.Windows.Forms.Label lbHint3;
    }
}