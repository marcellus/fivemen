namespace Jxc.Plugin
{
    partial class InRecordBrowser
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
            this.lbStoreNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateInDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDunShu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZhiShu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbId
            // 
            this.lbId.Location = new System.Drawing.Point(16, 351);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Size = new System.Drawing.Size(0, 15);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStoreNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateInDate);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDunShu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtZhiShu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbFrom);
            this.groupBox1.Controls.Add(this.cbTypeName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 322);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbStoreNum
            // 
            this.lbStoreNum.AutoSize = true;
            this.lbStoreNum.Location = new System.Drawing.Point(89, 141);
            this.lbStoreNum.Name = "lbStoreNum";
            this.lbStoreNum.Size = new System.Drawing.Size(0, 15);
            this.lbStoreNum.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "���п��";
            // 
            // dateInDate
            // 
            this.dateInDate.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.dateInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInDate.Location = new System.Drawing.Point(89, 17);
            this.dateInDate.Name = "dateInDate";
            this.dateInDate.Size = new System.Drawing.Size(196, 24);
            this.dateInDate.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrice.Location = new System.Drawing.Point(89, 260);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(196, 24);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "�ܼ�";
            // 
            // txtDunShu
            // 
            this.txtDunShu.BackColor = System.Drawing.SystemColors.Control;
            this.txtDunShu.Location = new System.Drawing.Point(89, 217);
            this.txtDunShu.Name = "txtDunShu";
            this.txtDunShu.Size = new System.Drawing.Size(196, 24);
            this.txtDunShu.TabIndex = 7;
            this.txtDunShu.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "����";
            // 
            // txtZhiShu
            // 
            this.txtZhiShu.Location = new System.Drawing.Point(89, 174);
            this.txtZhiShu.Name = "txtZhiShu";
            this.txtZhiShu.Size = new System.Drawing.Size(196, 24);
            this.txtZhiShu.TabIndex = 5;
            this.txtZhiShu.TextChanged += new System.EventHandler(this.txtZhiShu_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "֧��";
            // 
            // cbTypeName
            // 
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Location = new System.Drawing.Point(89, 99);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(196, 23);
            this.cbTypeName.TabIndex = 3;
            this.cbTypeName.SelectedValueChanged += new System.EventHandler(this.cbTypeName_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "��Ʒ����";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "�������";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "��Ʒ��Դ";
            // 
            // cbFrom
            // 
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(89, 58);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(196, 23);
            this.cbFrom.TabIndex = 3;
            this.cbFrom.SelectedValueChanged += new System.EventHandler(this.cbTypeName_SelectedValueChanged);
            // 
            // InRecordBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(392, 383);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("����", 11F);
            this.Name = "InRecordBrowser";
            this.Text = "����¼����";
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
        private System.Windows.Forms.Label lbStoreNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateInDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDunShu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZhiShu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label label8;
    }
}
