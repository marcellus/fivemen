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
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.dateBetweenPanel1 = new FT.Windows.Forms.CommonPanel.DateBetweenPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecommend = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteColumn = new System.Windows.Forms.Button();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.groupSearch.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSearch
            // 
            this.groupSearch.Size = new System.Drawing.Size(729, 160);
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cbColumn);
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteColumn);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer2.Panel1.Controls.Add(this.txtRecommend);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            this.splitContainer2.Panel1.Controls.Add(this.txtIdCard);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(723, 137);
            this.splitContainer2.SplitterDistance = 549;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "身份证号码";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(99, 79);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(171, 24);
            this.txtIdCard.TabIndex = 5;
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Font = new System.Drawing.Font("宋体", 11F);
            this.dateBetweenPanel1.Location = new System.Drawing.Point(15, 7);
            this.dateBetweenPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(354, 65);
            this.dateBetweenPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "推荐人姓名";
            // 
            // txtRecommend
            // 
            this.txtRecommend.Location = new System.Drawing.Point(406, 79);
            this.txtRecommend.Name = "txtRecommend";
            this.txtRecommend.Size = new System.Drawing.Size(128, 24);
            this.txtRecommend.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(471, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "添加列";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.Location = new System.Drawing.Point(378, 47);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteColumn.TabIndex = 10;
            this.btnDeleteColumn.Text = "删除列";
            this.btnDeleteColumn.UseVisualStyleBackColor = true;
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // cbColumn
            // 
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(378, 19);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(121, 23);
            this.cbColumn.TabIndex = 11;
            // 
            // SimpleStudentCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "SimpleStudentCounter";
            this.Size = new System.Drawing.Size(729, 556);
            this.groupSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label2;
        private FT.Windows.Forms.CommonPanel.DateBetweenPanel dateBetweenPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecommend;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteColumn;
        private System.Windows.Forms.ComboBox cbColumn;

    }
}
