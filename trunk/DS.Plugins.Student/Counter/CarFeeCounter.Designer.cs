namespace DS.Plugins.Student
{
    partial class CarFeeCounter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHmhp = new System.Windows.Forms.TextBox();
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
            this.splitContainer2.Panel1.Controls.Add(this.txtHmhp);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Font = new System.Drawing.Font("宋体", 11F);
            this.dateBetweenPanel1.Location = new System.Drawing.Point(9, 8);
            this.dateBetweenPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(371, 82);
            this.dateBetweenPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "号码号牌";
            // 
            // txtHmhp
            // 
            this.txtHmhp.Location = new System.Drawing.Point(92, 82);
            this.txtHmhp.Name = "txtHmhp";
            this.txtHmhp.Size = new System.Drawing.Size(115, 24);
            this.txtHmhp.TabIndex = 2;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(387, 39);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "详细";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // CarFeeCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "CarFeeCounter";
            this.groupSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FT.Windows.Forms.CommonPanel.DateBetweenPanel dateBetweenPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHmhp;
        private System.Windows.Forms.Button btnDetail;
    }
}
