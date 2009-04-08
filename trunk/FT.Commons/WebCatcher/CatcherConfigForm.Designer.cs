namespace FT.Commons.WebCatcher
{
    partial class CatcherConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatcherConfigForm));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCatcherClassName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBegin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbParaType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkLoginWithCookie = new System.Windows.Forms.CheckBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtCookieFormat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDownDir = new System.Windows.Forms.TextBox();
            this.btnDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "保存配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDir);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDownDir);
            this.groupBox1.Controls.Add(this.txtCatcherClassName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBegin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbParaType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本配置,如需参数使用{0}代替";
            // 
            // txtCatcherClassName
            // 
            this.txtCatcherClassName.Location = new System.Drawing.Point(68, 74);
            this.txtCatcherClassName.Name = "txtCatcherClassName";
            this.txtCatcherClassName.Size = new System.Drawing.Size(419, 21);
            this.txtCatcherClassName.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtCatcherClassName, " 填写捕获的类名");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "蜘蛛类";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(400, 43);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(86, 21);
            this.txtEnd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "参数终止";
            // 
            // txtBegin
            // 
            this.txtBegin.Location = new System.Drawing.Point(231, 43);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.Size = new System.Drawing.Size(86, 21);
            this.txtBegin.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtBegin, "参数类型是日期的时候，格式是yyyy-MM-dd");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "参数起始";
            // 
            // cbParaType
            // 
            this.cbParaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParaType.FormattingEnabled = true;
            this.cbParaType.Items.AddRange(new object[] {
            "无",
            "整数",
            "日期"});
            this.cbParaType.Location = new System.Drawing.Point(68, 44);
            this.cbParaType.Name = "cbParaType";
            this.cbParaType.Size = new System.Drawing.Size(86, 20);
            this.cbParaType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "参数类型";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(68, 18);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(419, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLoginUrl);
            this.groupBox2.Controls.Add(this.txtCookieFormat);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.checkLoginWithCookie);
            this.groupBox2.Controls.Add(this.txtPwd);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登陆配置,不用登录则不填";
            // 
            // checkLoginWithCookie
            // 
            this.checkLoginWithCookie.AutoSize = true;
            this.checkLoginWithCookie.Location = new System.Drawing.Point(19, 19);
            this.checkLoginWithCookie.Name = "checkLoginWithCookie";
            this.checkLoginWithCookie.Size = new System.Drawing.Size(84, 16);
            this.checkLoginWithCookie.TabIndex = 11;
            this.checkLoginWithCookie.Text = "登陆Cookie";
            this.checkLoginWithCookie.UseVisualStyleBackColor = true;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(365, 17);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(120, 21);
            this.txtPwd.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "密码";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(167, 17);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(132, 21);
            this.txtUID.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "用户名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cookie格式化字符串";
            // 
            // txtCookieFormat
            // 
            this.txtCookieFormat.Location = new System.Drawing.Point(136, 40);
            this.txtCookieFormat.Name = "txtCookieFormat";
            this.txtCookieFormat.Size = new System.Drawing.Size(351, 21);
            this.txtCookieFormat.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "登陆地址";
            // 
            // txtLoginUrl
            // 
            this.txtLoginUrl.Location = new System.Drawing.Point(69, 66);
            this.txtLoginUrl.Name = "txtLoginUrl";
            this.txtLoginUrl.Size = new System.Drawing.Size(418, 21);
            this.txtLoginUrl.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "下载路径";
            // 
            // txtDownDir
            // 
            this.txtDownDir.Location = new System.Drawing.Point(67, 103);
            this.txtDownDir.Name = "txtDownDir";
            this.txtDownDir.ReadOnly = true;
            this.txtDownDir.Size = new System.Drawing.Size(372, 21);
            this.txtDownDir.TabIndex = 10;
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(445, 100);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(39, 23);
            this.btnDir.TabIndex = 11;
            this.btnDir.Text = "...";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // CatcherConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 282);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatcherConfigForm";
            this.Text = "蜘蛛配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbParaType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBegin;
        private System.Windows.Forms.TextBox txtCatcherClassName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkLoginWithCookie;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtLoginUrl;
        private System.Windows.Forms.TextBox txtCookieFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.TextBox txtDownDir;
    }
}