namespace Vehicle.Plugins
{
    partial class JbrBrowser
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
            this.personDetail1 = new FT.Windows.Forms.PersonDetail();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // personDetail1
            // 
            this.personDetail1.Location = new System.Drawing.Point(14, 52);
            this.personDetail1.Name = "personDetail1";
            this.personDetail1.Size = new System.Drawing.Size(391, 259);
            this.personDetail1.TabIndex = 3;
            // 
            // JbrBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(452, 337);
            this.Controls.Add(this.personDetail1);
            this.Name = "JbrBrowser";
            this.Text = "��������Ϣ";
            this.Controls.SetChildIndex(this.personDetail1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Forms.PersonDetail personDetail1;
    }
}
