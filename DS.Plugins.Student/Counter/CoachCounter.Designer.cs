namespace DS.Plugins.Student
{
    partial class CoachCounter
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.dateBetweenPanel1 = new FT.Windows.Forms.CommonPanel.DateBetweenPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSubject = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
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
            this.splitContainer2.Panel1.Controls.Add(this.txtName);
            this.splitContainer2.Panel1.Controls.Add(this.checkSubject);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Location = new System.Drawing.Point(15, 8);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(251, 63);
            this.dateBetweenPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "��������";
            // 
            // checkSubject
            // 
            this.checkSubject.AutoSize = true;
            this.checkSubject.Checked = true;
            this.checkSubject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSubject.Location = new System.Drawing.Point(286, 23);
            this.checkSubject.Name = "checkSubject";
            this.checkSubject.Size = new System.Drawing.Size(60, 16);
            this.checkSubject.TabIndex = 3;
            this.checkSubject.Text = "�ֿ�Ŀ";
            this.checkSubject.UseVisualStyleBackColor = true;
            this.checkSubject.CheckedChanged += new System.EventHandler(this.checkSubject_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(112, 21);
            this.txtName.TabIndex = 4;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(371, 19);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "��ϸ";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // CoachCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "CoachCounter";
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
        private System.Windows.Forms.CheckBox checkSubject;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDetail;
    }
}
