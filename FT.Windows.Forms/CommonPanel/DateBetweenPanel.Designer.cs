namespace FT.Windows.Forms.CommonPanel
{
    partial class DateBetweenPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.checkWeek = new System.Windows.Forms.CheckBox();
            this.checkMonth = new System.Windows.Forms.CheckBox();
            this.cbSeason = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // dateBegin
            // 
            this.dateBegin.Location = new System.Drawing.Point(62, 3);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Size = new System.Drawing.Size(113, 21);
            this.dateBegin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(62, 36);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(113, 21);
            this.dateEnd.TabIndex = 3;
            // 
            // checkWeek
            // 
            this.checkWeek.AutoSize = true;
            this.checkWeek.Location = new System.Drawing.Point(187, 3);
            this.checkWeek.Name = "checkWeek";
            this.checkWeek.Size = new System.Drawing.Size(60, 16);
            this.checkWeek.TabIndex = 4;
            this.checkWeek.Text = "按星期";
            this.checkWeek.UseVisualStyleBackColor = true;
            this.checkWeek.CheckedChanged += new System.EventHandler(this.checkWeek_CheckedChanged);
            // 
            // checkMonth
            // 
            this.checkMonth.AutoSize = true;
            this.checkMonth.Location = new System.Drawing.Point(187, 22);
            this.checkMonth.Name = "checkMonth";
            this.checkMonth.Size = new System.Drawing.Size(60, 16);
            this.checkMonth.TabIndex = 5;
            this.checkMonth.Text = "按月份";
            this.checkMonth.UseVisualStyleBackColor = true;
            this.checkMonth.CheckedChanged += new System.EventHandler(this.checkMonth_CheckedChanged);
            // 
            // cbSeason
            // 
            this.cbSeason.FormattingEnabled = true;
            this.cbSeason.Items.AddRange(new object[] {
            "请选择",
            "季度一",
            "季度二",
            "季度三",
            "季度四"});
            this.cbSeason.Location = new System.Drawing.Point(187, 40);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(60, 20);
            this.cbSeason.TabIndex = 6;
            this.cbSeason.SelectedIndexChanged += new System.EventHandler(this.cbSeason_SelectedIndexChanged);
            // 
            // DateBetweenPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSeason);
            this.Controls.Add(this.checkMonth);
            this.Controls.Add(this.checkWeek);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateBegin);
            this.Controls.Add(this.label1);
            this.Name = "DateBetweenPanel";
            this.Size = new System.Drawing.Size(251, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.CheckBox checkWeek;
        private System.Windows.Forms.CheckBox checkMonth;
        private System.Windows.Forms.ComboBox cbSeason;
    }
}
