namespace FT.Windows.ExternalTool
{
    partial class RuntimeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShowDomainAssembly = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowControlName = new System.Windows.Forms.Button();
            this.txtControlName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCreateInstance = new System.Windows.Forms.Button();
            this.txtReflectClass = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLoggerName = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShowDomainAssembly);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看Domain的程序集";
            // 
            // ShowDomainAssembly
            // 
            this.ShowDomainAssembly.Location = new System.Drawing.Point(47, 21);
            this.ShowDomainAssembly.Name = "ShowDomainAssembly";
            this.ShowDomainAssembly.Size = new System.Drawing.Size(75, 23);
            this.ShowDomainAssembly.TabIndex = 0;
            this.ShowDomainAssembly.Text = "查看程序集";
            this.ShowDomainAssembly.UseVisualStyleBackColor = true;
            this.ShowDomainAssembly.Click += new System.EventHandler(this.ShowDomainAssembly_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Location = new System.Drawing.Point(13, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查看内容";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(16, 21);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(575, 183);
            this.txtResult.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShowControlName);
            this.groupBox3.Controls.Add(this.txtControlName);
            this.groupBox3.Location = new System.Drawing.Point(269, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 56);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "请输入控件类名";
            // 
            // btnShowControlName
            // 
            this.btnShowControlName.Location = new System.Drawing.Point(244, 19);
            this.btnShowControlName.Name = "btnShowControlName";
            this.btnShowControlName.Size = new System.Drawing.Size(103, 23);
            this.btnShowControlName.TabIndex = 1;
            this.btnShowControlName.Text = "显示子控件Name";
            this.btnShowControlName.UseVisualStyleBackColor = true;
            this.btnShowControlName.Click += new System.EventHandler(this.btnShowControlName_Click);
            // 
            // txtControlName
            // 
            this.txtControlName.Location = new System.Drawing.Point(7, 21);
            this.txtControlName.Name = "txtControlName";
            this.txtControlName.Size = new System.Drawing.Size(231, 21);
            this.txtControlName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreateInstance);
            this.groupBox4.Controls.Add(this.txtReflectClass);
            this.groupBox4.Location = new System.Drawing.Point(13, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 56);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "请输入待反射类名";
            // 
            // btnCreateInstance
            // 
            this.btnCreateInstance.Location = new System.Drawing.Point(256, 19);
            this.btnCreateInstance.Name = "btnCreateInstance";
            this.btnCreateInstance.Size = new System.Drawing.Size(91, 23);
            this.btnCreateInstance.TabIndex = 1;
            this.btnCreateInstance.Text = "创建实例";
            this.btnCreateInstance.UseVisualStyleBackColor = true;
            this.btnCreateInstance.Click += new System.EventHandler(this.btnCreateInstance_Click);
            // 
            // txtReflectClass
            // 
            this.txtReflectClass.Location = new System.Drawing.Point(7, 21);
            this.txtReflectClass.Name = "txtReflectClass";
            this.txtReflectClass.Size = new System.Drawing.Size(231, 21);
            this.txtReflectClass.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.txtLoggerName);
            this.groupBox5.Location = new System.Drawing.Point(13, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(353, 42);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "输入要创建的logger-Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "创建Logger";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLoggerName
            // 
            this.txtLoggerName.Location = new System.Drawing.Point(7, 15);
            this.txtLoggerName.Name = "txtLoggerName";
            this.txtLoggerName.Size = new System.Drawing.Size(231, 21);
            this.txtLoggerName.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.btnCreateTable);
            this.groupBox6.Controls.Add(this.txtTableName);
            this.groupBox6.Location = new System.Drawing.Point(372, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 100);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "建表";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(17, 19);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(215, 21);
            this.txtTableName.TabIndex = 0;
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(17, 62);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTable.TabIndex = 1;
            this.btnCreateTable.Text = "建表";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RuntimeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 418);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuntimeView";
            this.Text = "运行时查看器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtControlName;
        private System.Windows.Forms.Button btnShowControlName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCreateInstance;
        private System.Windows.Forms.TextBox txtReflectClass;
        private System.Windows.Forms.Button ShowDomainAssembly;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLoggerName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button button2;
    }
}