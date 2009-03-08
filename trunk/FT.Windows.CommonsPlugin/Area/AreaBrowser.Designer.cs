namespace FT.Windows.CommonsPlugin
{
    partial class AreaBrowser
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
            this.cbFatherCodeValue = new System.Windows.Forms.ComboBox();
            this.cbProvinceCodeValue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFatherCodeValue);
            this.groupBox1.Controls.Add(this.cbProvinceCodeValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // cbFatherCodeValue
            // 
            this.cbFatherCodeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFatherCodeValue.FormattingEnabled = true;
            this.cbFatherCodeValue.Location = new System.Drawing.Point(78, 106);
            this.cbFatherCodeValue.Name = "cbFatherCodeValue";
            this.cbFatherCodeValue.Size = new System.Drawing.Size(211, 20);
            this.cbFatherCodeValue.TabIndex = 9;
            // 
            // cbProvinceCodeValue
            // 
            this.cbProvinceCodeValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinceCodeValue.FormattingEnabled = true;
            this.cbProvinceCodeValue.Location = new System.Drawing.Point(78, 77);
            this.cbProvinceCodeValue.Name = "cbProvinceCodeValue";
            this.cbProvinceCodeValue.Size = new System.Drawing.Size(211, 20);
            this.cbProvinceCodeValue.TabIndex = 9;
            this.cbProvinceCodeValue.SelectedIndexChanged += new System.EventHandler(this.cbProvinceCodeValue_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "所属市";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "所属省份";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(78, 48);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(211, 21);
            this.txtCode.TabIndex = 7;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "县区代码";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(78, 21);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(211, 21);
            this.txtText.TabIndex = 5;
            this.txtText.Validating += new System.ComponentModel.CancelEventHandler(this.txtText_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "县区名称";
            // 
            // AreaBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(350, 200);
            this.Controls.Add(this.groupBox1);
            this.Name = "AreaBrowser";
            this.Text = "县区信息";
            this.Load += new System.EventHandler(this.AreaBrowser_Load);
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
        private System.Windows.Forms.ComboBox cbProvinceCodeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFatherCodeValue;
        private System.Windows.Forms.Label label5;
    }
}
