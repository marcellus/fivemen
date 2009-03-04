namespace FT.Windows.Forms
{
    partial class ConditionBuildForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFields = new System.Windows.Forms.ComboBox();
            this.cbOperations = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioAnd = new System.Windows.Forms.RadioButton();
            this.radioOr = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.radioOr);
            this.groupBox1.Controls.Add(this.radioAnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtConditions);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.cbOperations);
            this.groupBox1.Controls.Add(this.cbFields);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "值";
            // 
            // cbFields
            // 
            this.cbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFields.FormattingEnabled = true;
            this.cbFields.Location = new System.Drawing.Point(7, 44);
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new System.Drawing.Size(103, 20);
            this.cbFields.TabIndex = 3;
            // 
            // cbOperations
            // 
            this.cbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperations.FormattingEnabled = true;
            this.cbOperations.Location = new System.Drawing.Point(132, 43);
            this.cbOperations.Name = "cbOperations";
            this.cbOperations.Size = new System.Drawing.Size(58, 20);
            this.cbOperations.TabIndex = 4;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(208, 42);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 21);
            this.txtValue.TabIndex = 5;
            // 
            // txtConditions
            // 
            this.txtConditions.Location = new System.Drawing.Point(7, 103);
            this.txtConditions.Multiline = true;
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.ReadOnly = true;
            this.txtConditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConditions.Size = new System.Drawing.Size(350, 124);
            this.txtConditions.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "查询语句";
            // 
            // radioAnd
            // 
            this.radioAnd.AutoSize = true;
            this.radioAnd.Checked = true;
            this.radioAnd.Location = new System.Drawing.Point(7, 69);
            this.radioAnd.Name = "radioAnd";
            this.radioAnd.Size = new System.Drawing.Size(35, 16);
            this.radioAnd.TabIndex = 8;
            this.radioAnd.TabStop = true;
            this.radioAnd.Text = "和";
            this.radioAnd.UseVisualStyleBackColor = true;
            this.radioAnd.CheckedChanged += new System.EventHandler(this.radioAnd_CheckedChanged);
            // 
            // radioOr
            // 
            this.radioOr.AutoSize = true;
            this.radioOr.Location = new System.Drawing.Point(48, 69);
            this.radioOr.Name = "radioOr";
            this.radioOr.Size = new System.Drawing.Size(35, 16);
            this.radioOr.TabIndex = 9;
            this.radioOr.TabStop = true;
            this.radioOr.Text = "或";
            this.radioOr.UseVisualStyleBackColor = true;
            this.radioOr.CheckedChanged += new System.EventHandler(this.radioOr_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(315, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(9, 257);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(145, 258);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 2;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(284, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "统计该条件下有几条数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConditionBuildForm
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 292);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConditionBuildForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询条件构造窗体";
            this.Load += new System.EventHandler(this.ConditionBuildForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbOperations;
        private System.Windows.Forms.ComboBox cbFields;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.RadioButton radioAnd;
        private System.Windows.Forms.RadioButton radioOr;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
    }
}