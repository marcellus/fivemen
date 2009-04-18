namespace FT.Commons.Win32
{
    partial class SetWindowEnv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetWindowEnv));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJaveHome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtM2Home = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClassPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCatalinaHome = new System.Windows.Forms.TextBox();
            this.btnReadFromReg = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCatalinaHome);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtClassPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtM2Home);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtJaveHome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本配置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "JAVA_HOME";
            // 
            // txtJaveHome
            // 
            this.txtJaveHome.Location = new System.Drawing.Point(108, 27);
            this.txtJaveHome.Name = "txtJaveHome";
            this.txtJaveHome.Size = new System.Drawing.Size(338, 21);
            this.txtJaveHome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "M2_HOME";
            // 
            // txtM2Home
            // 
            this.txtM2Home.Location = new System.Drawing.Point(108, 58);
            this.txtM2Home.Name = "txtM2Home";
            this.txtM2Home.Size = new System.Drawing.Size(338, 21);
            this.txtM2Home.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(108, 89);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(338, 21);
            this.txtPath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "classpath";
            // 
            // txtClassPath
            // 
            this.txtClassPath.Location = new System.Drawing.Point(108, 120);
            this.txtClassPath.Name = "txtClassPath";
            this.txtClassPath.Size = new System.Drawing.Size(338, 21);
            this.txtClassPath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "catalina_home";
            // 
            // txtCatalinaHome
            // 
            this.txtCatalinaHome.Location = new System.Drawing.Point(108, 151);
            this.txtCatalinaHome.Name = "txtCatalinaHome";
            this.txtCatalinaHome.Size = new System.Drawing.Size(338, 21);
            this.txtCatalinaHome.TabIndex = 9;
            // 
            // btnReadFromReg
            // 
            this.btnReadFromReg.Location = new System.Drawing.Point(12, 216);
            this.btnReadFromReg.Name = "btnReadFromReg";
            this.btnReadFromReg.Size = new System.Drawing.Size(103, 23);
            this.btnReadFromReg.TabIndex = 1;
            this.btnReadFromReg.Text = "从注册表读取";
            this.btnReadFromReg.UseVisualStyleBackColor = true;
            this.btnReadFromReg.Click += new System.EventHandler(this.btnReadFromReg_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(389, 216);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // SetWindowEnv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 273);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnReadFromReg);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetWindowEnv";
            this.Text = "设置环境变量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtM2Home;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJaveHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCatalinaHome;
        private System.Windows.Forms.Button btnReadFromReg;
        private System.Windows.Forms.Button btnApply;
    }
}