namespace FT.Exam
{
    partial class ErrorReturnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReturnForm));
            this.picImage = new System.Windows.Forms.PictureBox();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUserAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRealAnswer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.题号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.试题内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标准答案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.考生答案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(455, 15);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(133, 157);
            this.picImage.TabIndex = 8;
            this.picImage.TabStop = false;
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(3, 18);
            this.txtTopic.Multiline = true;
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.ReadOnly = true;
            this.txtTopic.Size = new System.Drawing.Size(446, 156);
            this.txtTopic.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "考生答案";
            // 
            // lbUserAnswer
            // 
            this.lbUserAnswer.AutoSize = true;
            this.lbUserAnswer.BackColor = System.Drawing.SystemColors.Control;
            this.lbUserAnswer.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbUserAnswer.ForeColor = System.Drawing.Color.DarkRed;
            this.lbUserAnswer.Location = new System.Drawing.Point(158, 196);
            this.lbUserAnswer.Name = "lbUserAnswer";
            this.lbUserAnswer.Size = new System.Drawing.Size(75, 19);
            this.lbUserAnswer.TabIndex = 11;
            this.lbUserAnswer.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "标准答案";
            // 
            // lbRealAnswer
            // 
            this.lbRealAnswer.AutoSize = true;
            this.lbRealAnswer.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbRealAnswer.ForeColor = System.Drawing.Color.Blue;
            this.lbRealAnswer.Location = new System.Drawing.Point(304, 196);
            this.lbRealAnswer.Name = "lbRealAnswer";
            this.lbRealAnswer.Size = new System.Drawing.Size(75, 19);
            this.lbRealAnswer.TabIndex = 13;
            this.lbRealAnswer.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 253);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "错题";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.题号,
            this.试题内容,
            this.标准答案,
            this.考生答案});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(588, 230);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // 题号
            // 
            this.题号.HeaderText = "题号";
            this.题号.Name = "题号";
            this.题号.ReadOnly = true;
            // 
            // 试题内容
            // 
            this.试题内容.HeaderText = "试题内容";
            this.试题内容.Name = "试题内容";
            this.试题内容.ReadOnly = true;
            this.试题内容.Width = 240;
            // 
            // 标准答案
            // 
            this.标准答案.HeaderText = "标准答案";
            this.标准答案.Name = "标准答案";
            this.标准答案.ReadOnly = true;
            // 
            // 考生答案
            // 
            this.考生答案.HeaderText = "考生答案";
            this.考生答案.Name = "考生答案";
            this.考生答案.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "题号";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Location = new System.Drawing.Point(50, 196);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(15, 15);
            this.lbNum.TabIndex = 16;
            this.lbNum.Text = "1";
            // 
            // ErrorReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 494);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbRealAnswer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbUserAnswer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTopic);
            this.Controls.Add(this.picImage);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorReturnForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "错题回顾";
            this.Load += new System.EventHandler(this.ErrorReturnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUserAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRealAnswer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn 题号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 试题内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标准答案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 考生答案;
    }
}