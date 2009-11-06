namespace FtDbConnectionTest
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDbType = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtAfterProcess = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtNeedProcess = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.txtConnString);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbDbType);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "链接设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(237, 246);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "测试链接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtConnString
            // 
            this.txtConnString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnString.Location = new System.Drawing.Point(44, 132);
            this.txtConnString.Multiline = true;
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(468, 56);
            this.txtConnString.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "链接字符串：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "数据库类别：";
            // 
            // cbDbType
            // 
            this.cbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDbType.FormattingEnabled = true;
            this.cbDbType.Items.AddRange(new object[] {
            "Sqlserver",
            "Oracle",
            "Access"});
            this.cbDbType.Location = new System.Drawing.Point(134, 61);
            this.cbDbType.Name = "cbDbType";
            this.cbDbType.Size = new System.Drawing.Size(121, 20);
            this.cbDbType.TabIndex = 4;
            this.cbDbType.SelectedIndexChanged += new System.EventHandler(this.cbDbType_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "查询语句测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.tbSql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(546, 339);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(216, 151);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "执行查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tbSql
            // 
            this.tbSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSql.Location = new System.Drawing.Point(0, 0);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.Size = new System.Drawing.Size(546, 145);
            this.tbSql.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(546, 161);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtAfterProcess);
            this.tabPage3.Controls.Add(this.btnDecrypt);
            this.tabPage3.Controls.Add(this.btnEncrypt);
            this.tabPage3.Controls.Add(this.txtNeedProcess);
            this.tabPage3.Location = new System.Drawing.Point(4, 35);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(552, 345);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "字符串加密";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtAfterProcess
            // 
            this.txtAfterProcess.Location = new System.Drawing.Point(47, 202);
            this.txtAfterProcess.Multiline = true;
            this.txtAfterProcess.Name = "txtAfterProcess";
            this.txtAfterProcess.Size = new System.Drawing.Size(445, 104);
            this.txtAfterProcess.TabIndex = 3;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(285, 152);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(108, 152);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtNeedProcess
            // 
            this.txtNeedProcess.Location = new System.Drawing.Point(47, 22);
            this.txtNeedProcess.Multiline = true;
            this.txtNeedProcess.Name = "txtNeedProcess";
            this.txtNeedProcess.Size = new System.Drawing.Size(445, 105);
            this.txtNeedProcess.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.txtFileName);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.txtIp);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Location = new System.Drawing.Point(4, 35);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(552, 345);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "数据共享配置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(115, 54);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(153, 21);
            this.txtIp.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(115, 112);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(316, 21);
            this.txtFileName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "配置文件名";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 384);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "数据库链接测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox tbSql;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDbType;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtAfterProcess;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtNeedProcess;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileName;
    }
}

