namespace FT.Windows.CommonsPlugin
{
    partial class XiangBrowser
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
            this.group1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbValid = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBlongArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group1
            // 
            this.group1.Controls.Add(this.txtDescription);
            this.group1.Controls.Add(this.cbValid);
            this.group1.Controls.Add(this.txtValue);
            this.group1.Controls.Add(this.label6);
            this.group1.Controls.Add(this.label5);
            this.group1.Controls.Add(this.label4);
            this.group1.Controls.Add(this.txtText);
            this.group1.Controls.Add(this.label3);
            this.group1.Controls.Add(this.cbBlongArea);
            this.group1.Controls.Add(this.label2);
            this.group1.Location = new System.Drawing.Point(12, 43);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(288, 238);
            this.group1.TabIndex = 3;
            this.group1.TabStop = false;
            this.group1.Text = "基本信息";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 134);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 92);
            this.txtDescription.TabIndex = 9;
            // 
            // cbValid
            // 
            this.cbValid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValid.FormattingEnabled = true;
            this.cbValid.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cbValid.Location = new System.Drawing.Point(81, 106);
            this.cbValid.Name = "cbValid";
            this.cbValid.Size = new System.Drawing.Size(181, 20);
            this.cbValid.TabIndex = 8;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(81, 77);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(181, 21);
            this.txtValue.TabIndex = 7;
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "是否有效";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "乡镇代码";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(81, 48);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(181, 21);
            this.txtText.TabIndex = 3;
            this.txtText.Validating += new System.ComponentModel.CancelEventHandler(this.txtText_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "乡镇名称";
            // 
            // cbBlongArea
            // 
            this.cbBlongArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlongArea.FormattingEnabled = true;
            this.cbBlongArea.Location = new System.Drawing.Point(81, 20);
            this.cbBlongArea.Name = "cbBlongArea";
            this.cbBlongArea.Size = new System.Drawing.Size(181, 20);
            this.cbBlongArea.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "所属辖区";
            // 
            // XiangBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(316, 288);
            this.Controls.Add(this.group1);
            this.Name = "XiangBrowser";
            this.Text = "乡镇信息";
            this.Controls.SetChildIndex(this.group1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBlongArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbValid;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
