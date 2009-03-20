namespace DS.Plugins.Student
{
    partial class SimpleStudentCounter
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
            this.lbBegin = new System.Windows.Forms.Label();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.cbWeek = new System.Windows.Forms.CheckBox();
            this.cbMonth = new System.Windows.Forms.CheckBox();
            this.cbSeason = new System.Windows.Forms.CheckBox();
            this.groupSearch.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cbSeason);
            this.splitContainer2.Panel1.Controls.Add(this.cbMonth);
            this.splitContainer2.Panel1.Controls.Add(this.cbWeek);
            this.splitContainer2.Panel1.Controls.Add(this.txtIdCard);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dateEnd);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dateBegin);
            this.splitContainer2.Panel1.Controls.Add(this.lbBegin);
            // 
            // lbBegin
            // 
            this.lbBegin.AutoSize = true;
            this.lbBegin.Location = new System.Drawing.Point(25, 19);
            this.lbBegin.Name = "lbBegin";
            this.lbBegin.Size = new System.Drawing.Size(53, 12);
            this.lbBegin.TabIndex = 0;
            this.lbBegin.Text = "起始日期";
            // 
            // dateBegin
            // 
            this.dateBegin.Location = new System.Drawing.Point(94, 15);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Size = new System.Drawing.Size(171, 21);
            this.dateBegin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "截止日期";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(94, 40);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(171, 21);
            this.dateEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "身份证号码";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(94, 65);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(171, 21);
            this.txtIdCard.TabIndex = 5;
            // 
            // cbWeek
            // 
            this.cbWeek.AutoSize = true;
            this.cbWeek.Location = new System.Drawing.Point(330, 17);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(60, 16);
            this.cbWeek.TabIndex = 6;
            this.cbWeek.Text = "周汇总";
            this.cbWeek.UseVisualStyleBackColor = true;
            this.cbWeek.CheckedChanged += new System.EventHandler(this.cbWeek_CheckedChanged);
            // 
            // cbMonth
            // 
            this.cbMonth.AutoSize = true;
            this.cbMonth.Location = new System.Drawing.Point(330, 42);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(60, 16);
            this.cbMonth.TabIndex = 7;
            this.cbMonth.Text = "月汇总";
            this.cbMonth.UseVisualStyleBackColor = true;
            this.cbMonth.CheckedChanged += new System.EventHandler(this.cbMonth_CheckedChanged);
            // 
            // cbSeason
            // 
            this.cbSeason.AutoSize = true;
            this.cbSeason.Location = new System.Drawing.Point(330, 67);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(72, 16);
            this.cbSeason.TabIndex = 8;
            this.cbSeason.Text = "季度汇总";
            this.cbSeason.UseVisualStyleBackColor = true;
            this.cbSeason.CheckedChanged += new System.EventHandler(this.cbSeason_CheckedChanged);
            // 
            // SimpleStudentCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "SimpleStudentCounter";
            this.groupSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.CheckBox cbWeek;
        private System.Windows.Forms.CheckBox cbMonth;
        private System.Windows.Forms.CheckBox cbSeason;

    }
}
