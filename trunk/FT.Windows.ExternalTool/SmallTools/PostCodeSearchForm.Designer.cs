namespace FT.Windows.ExternalTool
{
    partial class PostCodeSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostCodeSearchForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDetail2 = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lbSearchCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAreaCode = new System.Windows.Forms.Label();
            this.lbPostCode = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSearchCount);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.txtAreaCode);
            this.groupBox1.Controls.Add(this.txtPostCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入任意一个待查内容并回车";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "邮编";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "区号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "地区";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "详细地址";
            // 
            // lbDetail2
            // 
            this.lbDetail2.AutoSize = true;
            this.lbDetail2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbDetail2.Location = new System.Drawing.Point(93, 89);
            this.lbDetail2.Name = "lbDetail2";
            this.lbDetail2.Size = new System.Drawing.Size(0, 15);
            this.lbDetail2.TabIndex = 4;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(93, 28);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(217, 24);
            this.txtPostCode.TabIndex = 5;
            this.txtPostCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPostCode_KeyDown);
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(93, 66);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(217, 24);
            this.txtAreaCode.TabIndex = 6;
            this.txtAreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPostCode_KeyDown);
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(93, 102);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(217, 24);
            this.txtArea.TabIndex = 7;
            this.txtArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPostCode_KeyDown);
            // 
            // lbSearchCount
            // 
            this.lbSearchCount.AutoSize = true;
            this.lbSearchCount.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbSearchCount.Location = new System.Drawing.Point(93, 149);
            this.lbSearchCount.Name = "lbSearchCount";
            this.lbSearchCount.Size = new System.Drawing.Size(0, 15);
            this.lbSearchCount.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbPostCode);
            this.groupBox2.Controls.Add(this.lbAreaCode);
            this.groupBox2.Controls.Add(this.lbDetail2);
            this.groupBox2.Location = new System.Drawing.Point(13, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "区号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "邮编";
            // 
            // lbAreaCode
            // 
            this.lbAreaCode.AutoSize = true;
            this.lbAreaCode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbAreaCode.Location = new System.Drawing.Point(93, 54);
            this.lbAreaCode.Name = "lbAreaCode";
            this.lbAreaCode.Size = new System.Drawing.Size(0, 15);
            this.lbAreaCode.TabIndex = 4;
            // 
            // lbPostCode
            // 
            this.lbPostCode.AutoSize = true;
            this.lbPostCode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbPostCode.Location = new System.Drawing.Point(93, 20);
            this.lbPostCode.Name = "lbPostCode";
            this.lbPostCode.Size = new System.Drawing.Size(0, 15);
            this.lbPostCode.TabIndex = 4;
            // 
            // PostCodeSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 379);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostCodeSearchForm";
            this.Text = "邮编区号查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDetail2;
        private System.Windows.Forms.Label lbSearchCount;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtAreaCode;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPostCode;
        private System.Windows.Forms.Label lbAreaCode;
    }
}