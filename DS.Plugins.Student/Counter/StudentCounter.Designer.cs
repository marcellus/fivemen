namespace DS.Plugins.Student
{
    partial class StudentCounter
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
            this.dateBetweenPanel1 = new FT.Windows.Forms.CommonPanel.DateBetweenPanel();
            this.checkDay = new System.Windows.Forms.CheckBox();
            this.checkMonth = new System.Windows.Forms.CheckBox();
            this.btnDetail = new System.Windows.Forms.Button();
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
            this.splitContainer2.Panel1.Controls.Add(this.btnDetail);
            this.splitContainer2.Panel1.Controls.Add(this.checkMonth);
            this.splitContainer2.Panel1.Controls.Add(this.checkDay);
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Location = new System.Drawing.Point(13, 14);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(251, 63);
            this.dateBetweenPanel1.TabIndex = 0;
            // 
            // checkDay
            // 
            this.checkDay.AutoSize = true;
            this.checkDay.Location = new System.Drawing.Point(307, 17);
            this.checkDay.Name = "checkDay";
            this.checkDay.Size = new System.Drawing.Size(48, 16);
            this.checkDay.TabIndex = 1;
            this.checkDay.Text = "按天";
            this.checkDay.UseVisualStyleBackColor = true;
            this.checkDay.CheckedChanged += new System.EventHandler(this.checkDay_CheckedChanged);
            // 
            // checkMonth
            // 
            this.checkMonth.AutoSize = true;
            this.checkMonth.Checked = true;
            this.checkMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMonth.Location = new System.Drawing.Point(307, 37);
            this.checkMonth.Name = "checkMonth";
            this.checkMonth.Size = new System.Drawing.Size(48, 16);
            this.checkMonth.TabIndex = 2;
            this.checkMonth.Text = "按月";
            this.checkMonth.UseVisualStyleBackColor = true;
            this.checkMonth.CheckedChanged += new System.EventHandler(this.checkMonth_CheckedChanged);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(307, 59);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "详细";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // StudentCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "StudentCounter";
            this.groupSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Forms.CommonPanel.DateBetweenPanel dateBetweenPanel1;
        private System.Windows.Forms.CheckBox checkDay;
        private System.Windows.Forms.CheckBox checkMonth;
        private System.Windows.Forms.Button btnDetail;
    }
}
