namespace FT.Windows.CommonsPlugin
{
    partial class DictBrower
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbValid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGroupType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbValid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbGroupType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 272);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(94, 151);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(255, 94);
            this.txtDescription.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "备注";
            // 
            // cbValid
            // 
            this.cbValid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValid.FormattingEnabled = true;
            this.cbValid.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cbValid.Location = new System.Drawing.Point(94, 122);
            this.cbValid.Name = "cbValid";
            this.cbValid.Size = new System.Drawing.Size(255, 20);
            this.cbValid.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "是否有效";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(94, 90);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(255, 21);
            this.txtValue.TabIndex = 5;
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据值";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(94, 57);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(255, 21);
            this.txtText.TabIndex = 3;
            this.txtText.Validating += new System.ComponentModel.CancelEventHandler(this.txtText_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据文本";
            // 
            // cbGroupType
            // 
            this.cbGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupType.FormattingEnabled = true;
            this.cbGroupType.Location = new System.Drawing.Point(94, 29);
            this.cbGroupType.Name = "cbGroupType";
            this.cbGroupType.Size = new System.Drawing.Size(255, 20);
            this.cbGroupType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据类别";
            // 
            // DictBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(425, 330);
            this.Controls.Add(this.groupBox1);
            this.Name = "DictBrower";
            this.Text = "基础数据";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGroupType;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbValid;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
