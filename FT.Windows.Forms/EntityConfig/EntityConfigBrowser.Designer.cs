namespace FT.Windows.Forms
{
    partial class EntityConfigBrowser
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
            this.cbClassCnName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.txtDetailWidth = new System.Windows.Forms.TextBox();
            this.txtExportWidth = new System.Windows.Forms.TextBox();
            this.txtPrintedWidth = new System.Windows.Forms.TextBox();
            this.checkShowInDetail = new System.Windows.Forms.CheckBox();
            this.checkIsExportExcel = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkIsPrinted = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeaderWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeaderName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPropertyName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClassCnName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOrderNum);
            this.groupBox1.Controls.Add(this.txtDetailWidth);
            this.groupBox1.Controls.Add(this.txtExportWidth);
            this.groupBox1.Controls.Add(this.txtPrintedWidth);
            this.groupBox1.Controls.Add(this.checkShowInDetail);
            this.groupBox1.Controls.Add(this.checkIsExportExcel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkIsPrinted);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHeaderWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHeaderName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbPropertyName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 179);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������Ϣ";
            // 
            // cbClassCnName
            // 
            this.cbClassCnName.BackColor = System.Drawing.SystemColors.Control;
            this.cbClassCnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassCnName.Enabled = false;
            this.cbClassCnName.FormattingEnabled = true;
            this.cbClassCnName.Location = new System.Drawing.Point(79, 24);
            this.cbClassCnName.Name = "cbClassCnName";
            this.cbClassCnName.Size = new System.Drawing.Size(121, 20);
            this.cbClassCnName.TabIndex = 11;
            this.cbClassCnName.SelectedIndexChanged += new System.EventHandler(this.cbClassCnName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "ģ������";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "������";
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Location = new System.Drawing.Point(304, 130);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.Size = new System.Drawing.Size(121, 21);
            this.txtOrderNum.TabIndex = 8;
            // 
            // txtDetailWidth
            // 
            this.txtDetailWidth.Location = new System.Drawing.Point(184, 130);
            this.txtDetailWidth.Name = "txtDetailWidth";
            this.txtDetailWidth.Size = new System.Drawing.Size(67, 21);
            this.txtDetailWidth.TabIndex = 8;
            // 
            // txtExportWidth
            // 
            this.txtExportWidth.Location = new System.Drawing.Point(359, 98);
            this.txtExportWidth.Name = "txtExportWidth";
            this.txtExportWidth.Size = new System.Drawing.Size(66, 21);
            this.txtExportWidth.TabIndex = 8;
            // 
            // txtPrintedWidth
            // 
            this.txtPrintedWidth.Location = new System.Drawing.Point(149, 98);
            this.txtPrintedWidth.Name = "txtPrintedWidth";
            this.txtPrintedWidth.Size = new System.Drawing.Size(66, 21);
            this.txtPrintedWidth.TabIndex = 8;
            // 
            // checkShowInDetail
            // 
            this.checkShowInDetail.AutoSize = true;
            this.checkShowInDetail.Location = new System.Drawing.Point(11, 132);
            this.checkShowInDetail.Name = "checkShowInDetail";
            this.checkShowInDetail.Size = new System.Drawing.Size(108, 16);
            this.checkShowInDetail.TabIndex = 7;
            this.checkShowInDetail.Text = "�Ƿ���ʾ���б�";
            this.checkShowInDetail.UseVisualStyleBackColor = true;
            // 
            // checkIsExportExcel
            // 
            this.checkIsExportExcel.AutoSize = true;
            this.checkIsExportExcel.Location = new System.Drawing.Point(222, 100);
            this.checkIsExportExcel.Name = "checkIsExportExcel";
            this.checkIsExportExcel.Size = new System.Drawing.Size(72, 16);
            this.checkIsExportExcel.TabIndex = 7;
            this.checkIsExportExcel.Text = "�Ƿ񵼳�";
            this.checkIsExportExcel.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "�б���";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "�������";
            // 
            // checkIsPrinted
            // 
            this.checkIsPrinted.AutoSize = true;
            this.checkIsPrinted.Location = new System.Drawing.Point(12, 100);
            this.checkIsPrinted.Name = "checkIsPrinted";
            this.checkIsPrinted.Size = new System.Drawing.Size(72, 16);
            this.checkIsPrinted.TabIndex = 7;
            this.checkIsPrinted.Text = "�Ƿ��ӡ";
            this.checkIsPrinted.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "��ӡ���";
            // 
            // txtHeaderWidth
            // 
            this.txtHeaderWidth.Location = new System.Drawing.Point(302, 60);
            this.txtHeaderWidth.Name = "txtHeaderWidth";
            this.txtHeaderWidth.Size = new System.Drawing.Size(121, 21);
            this.txtHeaderWidth.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "��ͷ���";
            // 
            // txtHeaderName
            // 
            this.txtHeaderName.Location = new System.Drawing.Point(79, 60);
            this.txtHeaderName.Name = "txtHeaderName";
            this.txtHeaderName.Size = new System.Drawing.Size(121, 21);
            this.txtHeaderName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "��ͷ����";
            // 
            // cbPropertyName
            // 
            this.cbPropertyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPropertyName.FormattingEnabled = true;
            this.cbPropertyName.Location = new System.Drawing.Point(302, 24);
            this.cbPropertyName.Name = "cbPropertyName";
            this.cbPropertyName.Size = new System.Drawing.Size(121, 20);
            this.cbPropertyName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "��������";
            // 
            // EntityConfigBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(452, 234);
            this.Controls.Add(this.groupBox1);
            this.Name = "EntityConfigBrowser";
            this.Text = "ģ��������";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPropertyName;
        private System.Windows.Forms.TextBox txtHeaderName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeaderWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkIsPrinted;
        private System.Windows.Forms.TextBox txtPrintedWidth;
        private System.Windows.Forms.TextBox txtExportWidth;
        private System.Windows.Forms.CheckBox checkIsExportExcel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkShowInDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbClassCnName;
        private System.Windows.Forms.TextBox txtDetailWidth;
        private System.Windows.Forms.Label label9;
    }
}
