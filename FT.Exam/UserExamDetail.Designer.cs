namespace FT.Exam
{
    partial class UserExamDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserExamDetail));
            this.lbWelcome = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.题号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.试题内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标准答案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.考生答案 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.答案A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.答案B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.答案C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.答案D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.图片路径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbRealAnswer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUserAnswer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(31, 16);
            this.lbWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(294, 15);
            this.lbWelcome.TabIndex = 0;
            this.lbWelcome.Text = "XX人在xx时刻考试详细记录，考试分数为：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbRealAnswer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbUserAnswer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTopic);
            this.groupBox1.Controls.Add(this.picImage);
            this.groupBox1.Location = new System.Drawing.Point(17, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(656, 522);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Location = new System.Drawing.Point(78, 202);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(15, 15);
            this.lbNum.TabIndex = 25;
            this.lbNum.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "题号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(31, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 270);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "全部";
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
            this.考生答案,
            this.答案A,
            this.答案B,
            this.答案C,
            this.答案D,
            this.图片路径});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(588, 247);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // 题号
            // 
            this.题号.DataPropertyName = "题号";
            this.题号.HeaderText = "题号";
            this.题号.Name = "题号";
            this.题号.ReadOnly = true;
            // 
            // 试题内容
            // 
            this.试题内容.DataPropertyName = "试题内容";
            this.试题内容.HeaderText = "试题内容";
            this.试题内容.Name = "试题内容";
            this.试题内容.ReadOnly = true;
            this.试题内容.Width = 240;
            // 
            // 标准答案
            // 
            this.标准答案.DataPropertyName = "标准答案";
            this.标准答案.HeaderText = "标准答案";
            this.标准答案.Name = "标准答案";
            this.标准答案.ReadOnly = true;
            // 
            // 考生答案
            // 
            this.考生答案.DataPropertyName = "考生答案";
            this.考生答案.HeaderText = "考生答案";
            this.考生答案.Name = "考生答案";
            this.考生答案.ReadOnly = true;
            // 
            // 答案A
            // 
            this.答案A.DataPropertyName = "答案A";
            this.答案A.HeaderText = "答案A";
            this.答案A.Name = "答案A";
            this.答案A.ReadOnly = true;
            this.答案A.Visible = false;
            // 
            // 答案B
            // 
            this.答案B.DataPropertyName = "答案B";
            this.答案B.HeaderText = "答案B";
            this.答案B.Name = "答案B";
            this.答案B.ReadOnly = true;
            this.答案B.Visible = false;
            // 
            // 答案C
            // 
            this.答案C.DataPropertyName = "答案C";
            this.答案C.HeaderText = "答案C";
            this.答案C.Name = "答案C";
            this.答案C.ReadOnly = true;
            this.答案C.Visible = false;
            // 
            // 答案D
            // 
            this.答案D.DataPropertyName = "答案D";
            this.答案D.HeaderText = "答案D";
            this.答案D.Name = "答案D";
            this.答案D.ReadOnly = true;
            this.答案D.Visible = false;
            // 
            // 图片路径
            // 
            this.图片路径.DataPropertyName = "图片路径";
            this.图片路径.HeaderText = "图片路径";
            this.图片路径.Name = "图片路径";
            this.图片路径.ReadOnly = true;
            this.图片路径.Visible = false;
            // 
            // lbRealAnswer
            // 
            this.lbRealAnswer.AutoSize = true;
            this.lbRealAnswer.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbRealAnswer.ForeColor = System.Drawing.Color.Blue;
            this.lbRealAnswer.Location = new System.Drawing.Point(332, 202);
            this.lbRealAnswer.Name = "lbRealAnswer";
            this.lbRealAnswer.Size = new System.Drawing.Size(75, 19);
            this.lbRealAnswer.TabIndex = 22;
            this.lbRealAnswer.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "标准答案";
            // 
            // lbUserAnswer
            // 
            this.lbUserAnswer.AutoSize = true;
            this.lbUserAnswer.BackColor = System.Drawing.SystemColors.Control;
            this.lbUserAnswer.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lbUserAnswer.ForeColor = System.Drawing.Color.DarkRed;
            this.lbUserAnswer.Location = new System.Drawing.Point(186, 202);
            this.lbUserAnswer.Name = "lbUserAnswer";
            this.lbUserAnswer.Size = new System.Drawing.Size(75, 19);
            this.lbUserAnswer.TabIndex = 20;
            this.lbUserAnswer.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "考生答案";
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(31, 24);
            this.txtTopic.Multiline = true;
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.ReadOnly = true;
            this.txtTopic.Size = new System.Drawing.Size(446, 156);
            this.txtTopic.TabIndex = 18;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(483, 21);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(133, 157);
            this.picImage.TabIndex = 17;
            this.picImage.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "题号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "试题内容";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "标准答案";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "考生答案";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "答案A";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "答案B";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "答案C";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "答案D";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "图片路径";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // UserExamDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbWelcome);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserExamDetail";
            this.Text = "考试详细记录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbRealAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUserAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn 题号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 试题内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 标准答案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 考生答案;
        private System.Windows.Forms.DataGridViewTextBoxColumn 答案A;
        private System.Windows.Forms.DataGridViewTextBoxColumn 答案B;
        private System.Windows.Forms.DataGridViewTextBoxColumn 答案C;
        private System.Windows.Forms.DataGridViewTextBoxColumn 答案D;
        private System.Windows.Forms.DataGridViewTextBoxColumn 图片路径;
    }
}