namespace DS.Plugins.Car
{
    partial class CarFeeBrowser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFeeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHmhp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFeeDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtFee);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateFeeDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbHmhp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFeeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 253);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "费用类别";
            // 
            // cbFeeType
            // 
            this.cbFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFeeType.FormattingEnabled = true;
            this.cbFeeType.Location = new System.Drawing.Point(109, 18);
            this.cbFeeType.Name = "cbFeeType";
            this.cbFeeType.Size = new System.Drawing.Size(200, 20);
            this.cbFeeType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "车牌车号";
            // 
            // cbHmhp
            // 
            this.cbHmhp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHmhp.FormattingEnabled = true;
            this.cbHmhp.Location = new System.Drawing.Point(109, 45);
            this.cbHmhp.Name = "cbHmhp";
            this.cbHmhp.Size = new System.Drawing.Size(200, 20);
            this.cbHmhp.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "费用时间";
            // 
            // dateFeeDate
            // 
            this.dateFeeDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateFeeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFeeDate.Location = new System.Drawing.Point(109, 73);
            this.dateFeeDate.Name = "dateFeeDate";
            this.dateFeeDate.Size = new System.Drawing.Size(200, 21);
            this.dateFeeDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "费用金额";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(109, 100);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(200, 21);
            this.txtFee.TabIndex = 7;
            this.txtFee.Validating += new System.ComponentModel.CancelEventHandler(this.txtFee_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "备注";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(109, 128);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 113);
            this.txtDescription.TabIndex = 9;
            // 
            // CarFeeBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(358, 296);
            this.Controls.Add(this.groupBox1);
            this.Name = "CarFeeBrowser";
            this.Text = "车辆费用";
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
        private System.Windows.Forms.TextBox txtFee;
    }
}
