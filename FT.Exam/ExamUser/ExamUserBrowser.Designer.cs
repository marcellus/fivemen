namespace FT.Exam
{
    partial class ExamUserBrowser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNotPassCount = new System.Windows.Forms.Label();
            this.lbPassCount = new System.Windows.Forms.Label();
            this.lbAllCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNotPassCount);
            this.groupBox1.Controls.Add(this.lbPassCount);
            this.groupBox1.Controls.Add(this.lbAllCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIdCard);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("����", 11F);
            this.groupBox1.Location = new System.Drawing.Point(13, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������Ϣ";
            // 
            // lbNotPassCount
            // 
            this.lbNotPassCount.AutoSize = true;
            this.lbNotPassCount.Location = new System.Drawing.Point(120, 154);
            this.lbNotPassCount.Name = "lbNotPassCount";
            this.lbNotPassCount.Size = new System.Drawing.Size(15, 15);
            this.lbNotPassCount.TabIndex = 5;
            this.lbNotPassCount.Text = "0";
            // 
            // lbPassCount
            // 
            this.lbPassCount.AutoSize = true;
            this.lbPassCount.Location = new System.Drawing.Point(120, 124);
            this.lbPassCount.Name = "lbPassCount";
            this.lbPassCount.Size = new System.Drawing.Size(15, 15);
            this.lbPassCount.TabIndex = 5;
            this.lbPassCount.Text = "0";
            // 
            // lbAllCount
            // 
            this.lbAllCount.AutoSize = true;
            this.lbAllCount.Location = new System.Drawing.Point(120, 94);
            this.lbAllCount.Name = "lbAllCount";
            this.lbAllCount.Size = new System.Drawing.Size(15, 15);
            this.lbAllCount.TabIndex = 5;
            this.lbAllCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "���ϸ����";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "�ϸ����";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "�����ܴ���";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(117, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(272, 24);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "����";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(117, 22);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(272, 24);
            this.txtIdCard.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "���֤������";
            // 
            // ExamUserBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(452, 267);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExamUserBrowser";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbAllCount;
        private System.Windows.Forms.Label lbNotPassCount;
        private System.Windows.Forms.Label lbPassCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}
