namespace DS.Plugins.Car
{
    partial class CarOutBrowser
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
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateOutDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHmhp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateOutDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbHmhp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 214);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(112, 93);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(199, 97);
            this.txtReason.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "出车原因";
            // 
            // dateOutDate
            // 
            this.dateOutDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOutDate.Location = new System.Drawing.Point(112, 56);
            this.dateOutDate.Name = "dateOutDate";
            this.dateOutDate.Size = new System.Drawing.Size(199, 21);
            this.dateOutDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "出车时间";
            // 
            // cbHmhp
            // 
            this.cbHmhp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHmhp.FormattingEnabled = true;
            this.cbHmhp.Location = new System.Drawing.Point(112, 25);
            this.cbHmhp.Name = "cbHmhp";
            this.cbHmhp.Size = new System.Drawing.Size(199, 20);
            this.cbHmhp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "号码号牌";
            // 
            // CarOutBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(355, 260);
            this.Controls.Add(this.groupBox1);
            this.Name = "CarOutBrowser";
            this.Text = "出车记录";
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
        private System.Windows.Forms.ComboBox cbHmhp;
        private System.Windows.Forms.DateTimePicker dateOutDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReason;
    }
}
