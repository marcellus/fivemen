namespace DS.Plugins.Student
{
    partial class StudentSystemConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentSystemConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkSubjectIs4 = new System.Windows.Forms.CheckBox();
            this.txtSubject2To3Days = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubject1To2Days = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegToSubject1 = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkSubjectIs4);
            this.groupBox1.Controls.Add(this.txtSubject2To3Days);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRegToSubject1);
            this.groupBox1.Controls.Add(this.txtSubject1To2Days);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "天";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "天";
            // 
            // checkSubjectIs4
            // 
            this.checkSubjectIs4.AutoSize = true;
            this.checkSubjectIs4.Location = new System.Drawing.Point(24, 117);
            this.checkSubjectIs4.Name = "checkSubjectIs4";
            this.checkSubjectIs4.Size = new System.Drawing.Size(132, 16);
            this.checkSubjectIs4.TabIndex = 4;
            this.checkSubjectIs4.Text = "是否分桩考和场地考";
            this.checkSubjectIs4.UseVisualStyleBackColor = true;
            // 
            // txtSubject2To3Days
            // 
            this.txtSubject2To3Days.Location = new System.Drawing.Point(165, 85);
            this.txtSubject2To3Days.Name = "txtSubject2To3Days";
            this.txtSubject2To3Days.Size = new System.Drawing.Size(67, 21);
            this.txtSubject2To3Days.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "科目二到科目三考试间隔";
            // 
            // txtSubject1To2Days
            // 
            this.txtSubject1To2Days.Location = new System.Drawing.Point(165, 57);
            this.txtSubject1To2Days.Name = "txtSubject1To2Days";
            this.txtSubject1To2Days.Size = new System.Drawing.Size(67, 21);
            this.txtSubject1To2Days.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科目一到科目二考试间隔";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(109, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "报名到科目一考试间隔";
            // 
            // txtRegToSubject1
            // 
            this.txtRegToSubject1.Location = new System.Drawing.Point(165, 29);
            this.txtRegToSubject1.Name = "txtRegToSubject1";
            this.txtRegToSubject1.Size = new System.Drawing.Size(67, 21);
            this.txtRegToSubject1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "天";
            // 
            // StudentSystemConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 224);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentSystemConfigForm";
            this.Text = "考试时间配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSubjectIs4;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtSubject2To3Days;
        private System.Windows.Forms.Label label2;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtSubject1To2Days;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtRegToSubject1;
        private System.Windows.Forms.Label label5;
    }
}