namespace DS.Plugins.Student
{
    partial class StudentExamBrowser
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
            this.txtScore = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.dateExamDate = new System.Windows.Forms.DateTimePicker();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtExamPerson = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAllowExamDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExamId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCoachName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewCarType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbIdCard = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtScore);
            this.groupBox1.Controls.Add(this.dateExamDate);
            this.groupBox1.Controls.Add(this.cbResult);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtExamPerson);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAllowExamDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtExamId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCoachName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNewCarType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbIdCard);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(2, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 253);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(73, 197);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(100, 21);
            this.txtScore.TabIndex = 32;
            this.txtScore.Validating += new System.ComponentModel.CancelEventHandler(this.txtScore_Validating);
            // 
            // dateExamDate
            // 
            this.dateExamDate.Location = new System.Drawing.Point(269, 133);
            this.dateExamDate.Name = "dateExamDate";
            this.dateExamDate.Size = new System.Drawing.Size(100, 21);
            this.dateExamDate.TabIndex = 36;
            // 
            // cbResult
            // 
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Items.AddRange(new object[] {
            "�ϸ�",
            "���ϸ�"});
            this.cbResult.Location = new System.Drawing.Point(269, 198);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(100, 20);
            this.cbResult.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(208, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "���Խ��";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = " ���Գɼ�";
            // 
            // txtExamPerson
            // 
            this.txtExamPerson.Location = new System.Drawing.Point(269, 165);
            this.txtExamPerson.Name = "txtExamPerson";
            this.txtExamPerson.Size = new System.Drawing.Size(100, 21);
            this.txtExamPerson.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "����Ա";
            // 
            // cbSubject
            // 
            this.cbSubject.BackColor = System.Drawing.SystemColors.Control;
            this.cbSubject.Enabled = false;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(73, 166);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(100, 20);
            this.cbSubject.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "���Կ�Ŀ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "��������";
            // 
            // txtAllowExamDate
            // 
            this.txtAllowExamDate.Enabled = false;
            this.txtAllowExamDate.Location = new System.Drawing.Point(73, 133);
            this.txtAllowExamDate.Name = "txtAllowExamDate";
            this.txtAllowExamDate.Size = new System.Drawing.Size(100, 21);
            this.txtAllowExamDate.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "׼������";
            // 
            // txtExamId
            // 
            this.txtExamId.Enabled = false;
            this.txtExamId.Location = new System.Drawing.Point(269, 101);
            this.txtExamId.Name = "txtExamId";
            this.txtExamId.Size = new System.Drawing.Size(100, 21);
            this.txtExamId.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "׼��֤��";
            // 
            // txtCoachName
            // 
            this.txtCoachName.Enabled = false;
            this.txtCoachName.Location = new System.Drawing.Point(73, 101);
            this.txtCoachName.Name = "txtCoachName";
            this.txtCoachName.Size = new System.Drawing.Size(100, 21);
            this.txtCoachName.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "����Ա";
            // 
            // txtNewCarType
            // 
            this.txtNewCarType.Enabled = false;
            this.txtNewCarType.Location = new System.Drawing.Point(269, 69);
            this.txtNewCarType.Name = "txtNewCarType";
            this.txtNewCarType.Size = new System.Drawing.Size(100, 21);
            this.txtNewCarType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "ѧϰ����";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(73, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "����";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 21);
            this.textBox1.TabIndex = 11;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "���ҵ����֤����";
            // 
            // cbIdCard
            // 
            this.cbIdCard.FormattingEnabled = true;
            this.cbIdCard.Location = new System.Drawing.Point(130, 45);
            this.cbIdCard.Name = "cbIdCard";
            this.cbIdCard.Size = new System.Drawing.Size(200, 20);
            this.cbIdCard.TabIndex = 13;
            this.cbIdCard.TextChanged += new System.EventHandler(this.cbIdCard_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "ѧ�����֤����";
            // 
            // StudentExamBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(404, 301);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudentExamBrowser";
            this.Text = "ѧԱ������Ϣ";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbIdCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewCarType;
        private System.Windows.Forms.TextBox txtCoachName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExamId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAllowExamDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtExamPerson;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.DateTimePicker dateExamDate;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtScore;
    }
}
