namespace DS.Plugins.Student
{
    partial class StudentFeeBrowser
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
            this.txtFee = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.lbName = new System.Windows.Forms.Label();
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateFeeDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIdCard = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFeeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFee);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.textbox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateFeeDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbIdCard);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFeeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 283);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(109, 135);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(200, 21);
            this.txtFee.TabIndex = 6;
            this.txtFee.Validating += new System.ComponentModel.CancelEventHandler(this.txtFee_Validating);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(314, 84);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 12);
            this.lbName.TabIndex = 12;
            // 
            // textbox1
            // 
            this.textbox1.Location = new System.Drawing.Point(109, 48);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(200, 21);
            this.textbox1.TabIndex = 1;
            this.textbox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textbox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "���ҵ����֤����";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 162);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 113);
            this.txtDescription.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "��ע";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "���ý��";
            // 
            // dateFeeDate
            // 
            this.dateFeeDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateFeeDate.Enabled = false;
            this.dateFeeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFeeDate.Location = new System.Drawing.Point(109, 107);
            this.dateFeeDate.Name = "dateFeeDate";
            this.dateFeeDate.Size = new System.Drawing.Size(200, 21);
            this.dateFeeDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "����ʱ��";
            // 
            // cbIdCard
            // 
            this.cbIdCard.FormattingEnabled = true;
            this.cbIdCard.Location = new System.Drawing.Point(109, 79);
            this.cbIdCard.Name = "cbIdCard";
            this.cbIdCard.Size = new System.Drawing.Size(200, 20);
            this.cbIdCard.TabIndex = 3;
            this.cbIdCard.TextChanged += new System.EventHandler(this.cbIdCard_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "ѧ�����֤����";
            // 
            // cbFeeType
            // 
            this.cbFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFeeType.FormattingEnabled = true;
            this.cbFeeType.Location = new System.Drawing.Point(109, 18);
            this.cbFeeType.Name = "cbFeeType";
            this.cbFeeType.Size = new System.Drawing.Size(200, 20);
            this.cbFeeType.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "�������";
            // 
            // StudentFeeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(396, 335);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentFeeBrowser";
            this.Text = "ѧԱ�ɷ���Ϣ";
            this.Load += new System.EventHandler(this.StudentFeeBrowser_Load);
            this.Controls.SetChildIndex(this.lbId, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateFeeDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbIdCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFeeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.Label lbName;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtFee;
    }
}
