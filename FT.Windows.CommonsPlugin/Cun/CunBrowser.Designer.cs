namespace FT.Windows.CommonsPlugin
{
    partial class CunBrowser
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
            this.cbBlongArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbXiang = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbValid = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.cbValid);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbXiang);
            this.groupBox1.Controls.Add(this.cbBlongArea);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 276);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������Ϣ";
            // 
            // cbBlongArea
            // 
            this.cbBlongArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlongArea.FormattingEnabled = true;
            this.cbBlongArea.Location = new System.Drawing.Point(82, 24);
            this.cbBlongArea.Name = "cbBlongArea";
            this.cbBlongArea.Size = new System.Drawing.Size(181, 20);
            this.cbBlongArea.TabIndex = 5;
            this.cbBlongArea.SelectedIndexChanged += new System.EventHandler(this.cbBlongArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "����Ͻ��";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "��������";
            // 
            // cbXiang
            // 
            this.cbXiang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXiang.FormattingEnabled = true;
            this.cbXiang.Location = new System.Drawing.Point(82, 50);
            this.cbXiang.Name = "cbXiang";
            this.cbXiang.Size = new System.Drawing.Size(181, 20);
            this.cbXiang.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(82, 166);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 92);
            this.txtDescription.TabIndex = 17;
            // 
            // cbValid
            // 
            this.cbValid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValid.FormattingEnabled = true;
            this.cbValid.Items.AddRange(new object[] {
            "��Ч",
            "��Ч"});
            this.cbValid.Location = new System.Drawing.Point(82, 138);
            this.cbValid.Name = "cbValid";
            this.cbValid.Size = new System.Drawing.Size(181, 20);
            this.cbValid.TabIndex = 16;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(82, 109);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(181, 21);
            this.txtValue.TabIndex = 15;
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "��ע";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "�Ƿ���Ч";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "���ί����";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(82, 80);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(181, 21);
            this.txtText.TabIndex = 11;
            this.txtText.Validating += new System.ComponentModel.CancelEventHandler(this.txtText_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "���ί����";
            // 
            // CunBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(310, 318);
            this.Controls.Add(this.groupBox1);
            this.Name = "CunBrowser";
            this.Text = "���ί��Ϣ";
            this.Load += new System.EventHandler(this.CunBrowser_Load);
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
        private System.Windows.Forms.ComboBox cbBlongArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbXiang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbValid;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label7;
    }
}
