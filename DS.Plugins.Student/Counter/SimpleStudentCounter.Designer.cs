namespace DS.Plugins.Student
{
    partial class SimpleStudentCounter
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.dateBetweenPanel1 = new FT.Windows.Forms.CommonPanel.DateBetweenPanel();
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
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            this.splitContainer2.Panel1.Controls.Add(this.txtIdCard);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "���֤����";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(77, 71);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(171, 21);
            this.txtIdCard.TabIndex = 5;
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Location = new System.Drawing.Point(15, 7);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(251, 63);
            this.dateBetweenPanel1.TabIndex = 6;
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

        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label2;
        private FT.Windows.Forms.CommonPanel.DateBetweenPanel dateBetweenPanel1;

    }
}
