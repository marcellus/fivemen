namespace Jxc.Plugin
{
    partial class SellRecordBrowser
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
            this.dateSellDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDunShu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZhiShu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.dateSellDate);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDunShu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtZhiShu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbTypeName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 275);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lbStoreNum
            // 
            this.lbStoreNum.AutoSize = true;
            this.lbStoreNum.Location = new System.Drawing.Point(89, 105);
            this.lbStoreNum.Name = "lbStoreNum";
            this.lbStoreNum.Size = new System.Drawing.Size(0, 15);
            this.lbStoreNum.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "���п��";
            // 
            // dateSellDate
            // 
            this.dateSellDate.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.dateSellDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateSellDate.Location = new System.Drawing.Point(89, 17);
            this.dateSellDate.Name = "dateSellDate";
            this.dateSellDate.Size = new System.Drawing.Size(196, 24);
            this.dateSellDate.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrice.Location = new System.Drawing.Point(89, 224);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(196, 24);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "�ܼ�";
            // 
            // txtDunShu
            // 
            this.txtDunShu.BackColor = System.Drawing.SystemColors.Control;
            this.txtDunShu.Location = new System.Drawing.Point(89, 181);
            this.txtDunShu.Name = "txtDunShu";
            this.txtDunShu.Size = new System.Drawing.Size(196, 24);
            this.txtDunShu.TabIndex = 7;
            this.txtDunShu.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "����";
            // 
            // txtZhiShu
            // 
            this.txtZhiShu.Location = new System.Drawing.Point(89, 138);
            this.txtZhiShu.Name = "txtZhiShu";
            this.txtZhiShu.Size = new System.Drawing.Size(196, 24);
            this.txtZhiShu.TabIndex = 5;
            this.txtZhiShu.TextChanged += new System.EventHandler(this.txtZhiShu_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "֧��";
            // 
            // cbTypeName
            // 
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Location = new System.Drawing.Point(89, 63);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(196, 23);
            this.cbTypeName.TabIndex = 3;
            this.cbTypeName.SelectedValueChanged += new System.EventHandler(this.cbTypeName_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 67);
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
            this.label2.Text = "��������";
            // 
            // SellRecordBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(366, 332);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("����", 11F);
            this.Name = "SellRecordBrowser";
            this.Text = "���ۼ�¼����";
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
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDunShu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZhiShu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateSellDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStoreNum;
    }
}
