namespace FT.Windows.ExternalTool
{
    partial class IdCardSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdCardSearchForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn15To18 = new System.Windows.Forms.Button();
            this.btnValidator = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbArea);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(17, 149);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(437, 129);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.ForeColor = System.Drawing.Color.Blue;
            this.lbArea.Location = new System.Drawing.Point(128, 52);
            this.lbArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(0, 15);
            this.lbArea.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "身份证归属地";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnValidator);
            this.groupBox1.Controls.Add(this.btn15To18);
            this.groupBox1.Controls.Add(this.txtIdCard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(437, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入按回车";
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(128, 25);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(217, 24);
            this.txtIdCard.TabIndex = 1;
            this.txtIdCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCard_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "身份证前6位";
            // 
            // btn15To18
            // 
            this.btn15To18.Location = new System.Drawing.Point(27, 64);
            this.btn15To18.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn15To18.Name = "btn15To18";
            this.btn15To18.Size = new System.Drawing.Size(156, 29);
            this.btn15To18.TabIndex = 2;
            this.btn15To18.Text = "15位升级到18位";
            this.btn15To18.UseVisualStyleBackColor = true;
            this.btn15To18.Click += new System.EventHandler(this.btn15To18_Click);
            // 
            // btnValidator
            // 
            this.btnValidator.Font = new System.Drawing.Font("宋体", 9F);
            this.btnValidator.Location = new System.Drawing.Point(229, 64);
            this.btnValidator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnValidator.Name = "btnValidator";
            this.btnValidator.Size = new System.Drawing.Size(156, 29);
            this.btnValidator.TabIndex = 2;
            this.btnValidator.Text = "18位身份证验证";
            this.btnValidator.UseVisualStyleBackColor = true;
            this.btnValidator.Click += new System.EventHandler(this.btnValidator_Click);
            // 
            // IdCardSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 301);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdCardSearchForm";
            this.Text = "身份证地区查询";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn15To18;
        private System.Windows.Forms.Button btnValidator;
    }
}