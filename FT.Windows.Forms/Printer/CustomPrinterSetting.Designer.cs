namespace FT.Windows.Forms
{
    partial class CustomPrinterSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPrinterSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtBottom = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPageName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbPrintModel = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPrintModel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRight);
            this.groupBox1.Controls.Add(this.txtBottom);
            this.groupBox1.Controls.Add(this.txtLeft);
            this.groupBox1.Controls.Add(this.txtTop);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbPageName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置信息";
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(188, 78);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(63, 21);
            this.txtRight.TabIndex = 6;
            this.txtRight.Text = "10";
            this.txtRight.Validating += new System.ComponentModel.CancelEventHandler(this.txtRight_Validating);
            // 
            // txtBottom
            // 
            this.txtBottom.Location = new System.Drawing.Point(70, 78);
            this.txtBottom.Name = "txtBottom";
            this.txtBottom.Size = new System.Drawing.Size(63, 21);
            this.txtBottom.TabIndex = 6;
            this.txtBottom.Text = "10";
            this.txtBottom.Validating += new System.ComponentModel.CancelEventHandler(this.txtBottom_Validating);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(186, 50);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(63, 21);
            this.txtLeft.TabIndex = 6;
            this.txtLeft.Text = "10";
            this.txtLeft.Validating += new System.ComponentModel.CancelEventHandler(this.txtLeft_Validating);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(70, 50);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(63, 21);
            this.txtTop.TabIndex = 6;
            this.txtTop.Text = "10";
            this.txtTop.Validating += new System.ComponentModel.CancelEventHandler(this.txtTop_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "右边距";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "左边距";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "下边距";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "上边距";
            // 
            // cbPageName
            // 
            this.cbPageName.FormattingEnabled = true;
            this.cbPageName.Items.AddRange(new object[] {
            "A4",
            "A3",
            "A5"});
            this.cbPageName.Location = new System.Drawing.Point(70, 23);
            this.cbPageName.Name = "cbPageName";
            this.cbPageName.Size = new System.Drawing.Size(179, 20);
            this.cbPageName.TabIndex = 1;
            this.cbPageName.Text = "A4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "纸型";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(109, 169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "打印方式";
            // 
            // cbPrintModel
            // 
            this.cbPrintModel.FormattingEnabled = true;
            this.cbPrintModel.Items.AddRange(new object[] {
            "直接打",
            "打印预览",
            "选择打印机"});
            this.cbPrintModel.Location = new System.Drawing.Point(71, 105);
            this.cbPrintModel.Name = "cbPrintModel";
            this.cbPrintModel.Size = new System.Drawing.Size(178, 20);
            this.cbPrintModel.TabIndex = 8;
            // 
            // CustomPrinterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPrinterSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统全局打印配置";
            this.Load += new System.EventHandler(this.CustomPrinterSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtBottom;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPrintModel;
    }
}