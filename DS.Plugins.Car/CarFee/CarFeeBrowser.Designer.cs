namespace DS.Plugins.Car
{
    partial class CarFeeBrowser
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateFeeDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHmhp = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateFeeDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbHmhp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFeeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("����", 11F);
            this.groupBox1.Location = new System.Drawing.Point(2, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 253);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(114, 100);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(200, 24);
            this.txtFee.TabIndex = 10;
            this.txtFee.Validating += new System.ComponentModel.CancelEventHandler(this.txtFee_Validating);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(114, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 113);
            this.txtDescription.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "��ע";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "���ý��";
            // 
            // dateFeeDate
            // 
            this.dateFeeDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateFeeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFeeDate.Location = new System.Drawing.Point(114, 73);
            this.dateFeeDate.Name = "dateFeeDate";
            this.dateFeeDate.Size = new System.Drawing.Size(200, 24);
            this.dateFeeDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "����ʱ��";
            // 
            // cbHmhp
            // 
            this.cbHmhp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHmhp.FormattingEnabled = true;
            this.cbHmhp.Location = new System.Drawing.Point(114, 45);
            this.cbHmhp.Name = "cbHmhp";
            this.cbHmhp.Size = new System.Drawing.Size(200, 23);
            this.cbHmhp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "���Ƴ���";
            // 
            // cbFeeType
            // 
            this.cbFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFeeType.FormattingEnabled = true;
            this.cbFeeType.Location = new System.Drawing.Point(114, 18);
            this.cbFeeType.Name = "cbFeeType";
            this.cbFeeType.Size = new System.Drawing.Size(200, 23);
            this.cbFeeType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "�������";
            // 
            // CarFeeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(358, 296);
            this.Controls.Add(this.groupBox1);
            this.Name = "CarFeeBrowser";
            this.Text = "��������";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateFeeDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbHmhp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFeeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtFee;
    }
}
