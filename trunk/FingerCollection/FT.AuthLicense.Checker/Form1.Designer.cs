namespace FT.AuthLicense.Checker
{
    partial class Form1
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
            this.txtUserNum = new System.Windows.Forms.TextBox();
            this.txtRightCode = new System.Windows.Forms.TextBox();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAppName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTerminalNum = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTerminalNum);
            this.groupBox1.Controls.Add(this.txtUserNum);
            this.groupBox1.Controls.Add(this.txtRightCode);
            this.groupBox1.Controls.Add(this.txtMAC);
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbAppName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 267);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "授权信息填写";
            // 
            // txtUserNum
            // 
            this.txtUserNum.Location = new System.Drawing.Point(118, 180);
            this.txtUserNum.Name = "txtUserNum";
            this.txtUserNum.ReadOnly = true;
            this.txtUserNum.Size = new System.Drawing.Size(282, 21);
            this.txtUserNum.TabIndex = 3;
            this.txtUserNum.Text = "10";
            // 
            // txtRightCode
            // 
            this.txtRightCode.Location = new System.Drawing.Point(118, 143);
            this.txtRightCode.Name = "txtRightCode";
            this.txtRightCode.ReadOnly = true;
            this.txtRightCode.Size = new System.Drawing.Size(282, 21);
            this.txtRightCode.TabIndex = 3;
            // 
            // txtMAC
            // 
            this.txtMAC.Location = new System.Drawing.Point(118, 106);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(282, 21);
            this.txtMAC.TabIndex = 3;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(118, 69);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(282, 21);
            this.txtCompany.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "授权用户数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "授权码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "机器码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "授权单位名称";
            // 
            // cbAppName
            // 
            this.cbAppName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppName.FormattingEnabled = true;
            this.cbAppName.Items.AddRange(new object[] {
            "YuanTuoTerminalWeb",
            "HipiaoTerminalWinForm"});
            this.cbAppName.Location = new System.Drawing.Point(118, 32);
            this.cbAppName.Name = "cbAppName";
            this.cbAppName.Size = new System.Drawing.Size(282, 20);
            this.cbAppName.TabIndex = 1;
            this.cbAppName.SelectedIndexChanged += new System.EventHandler(this.cbAppName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "应用名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "授权用户数量";
            // 
            // txtTerminalNum
            // 
            this.txtTerminalNum.Location = new System.Drawing.Point(118, 217);
            this.txtTerminalNum.Name = "txtTerminalNum";
            this.txtTerminalNum.ReadOnly = true;
            this.txtTerminalNum.Size = new System.Drawing.Size(282, 21);
            this.txtTerminalNum.TabIndex = 3;
            this.txtTerminalNum.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(465, 294);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "授权查看器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUserNum;
        private System.Windows.Forms.TextBox txtRightCode;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTerminalNum;
        private System.Windows.Forms.Label label6;
    }
}

