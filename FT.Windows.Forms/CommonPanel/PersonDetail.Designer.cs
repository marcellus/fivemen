namespace FT.Windows.Forms
{
    partial class PersonDetail
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateBirthday = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.dateEmployDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(73, 162);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(306, 87);
            this.txtDescription.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "备注";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(73, 127);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(306, 21);
            this.txtAddress.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "联系地址";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(73, 69);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(125, 21);
            this.txtIdCard.TabIndex = 38;
            this.txtIdCard.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCard_Validating);
            this.txtIdCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCard_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "身份证号";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(254, 41);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(125, 21);
            this.txtPhone.TabIndex = 36;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "固话";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(254, 70);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(125, 21);
            this.txtMobile.TabIndex = 39;
            this.txtMobile.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobile_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "手机";
            // 
            // dateBirthday
            // 
            this.dateBirthday.CustomFormat = "yyyy-MM-dd";
            this.dateBirthday.Location = new System.Drawing.Point(73, 40);
            this.dateBirthday.Name = "dateBirthday";
            this.dateBirthday.Size = new System.Drawing.Size(125, 21);
            this.dateBirthday.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "生日";
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbSex.Location = new System.Drawing.Point(254, 9);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(125, 20);
            this.cbSex.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "性别";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(73, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 21);
            this.txtName.TabIndex = 32;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "入职时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 49;
            this.label10.Text = "状态";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "在职",
            "离职"});
            this.cbState.Location = new System.Drawing.Point(254, 98);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(125, 20);
            this.cbState.TabIndex = 41;
            // 
            // dateEmployDate
            // 
            this.dateEmployDate.Location = new System.Drawing.Point(73, 98);
            this.dateEmployDate.Name = "dateEmployDate";
            this.dateEmployDate.Size = new System.Drawing.Size(125, 21);
            this.dateEmployDate.TabIndex = 40;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PersonDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateEmployDate);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIdCard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateBirthday);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Name = "PersonDetail";
            this.Size = new System.Drawing.Size(391, 259);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateBirthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.DateTimePicker dateEmployDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
