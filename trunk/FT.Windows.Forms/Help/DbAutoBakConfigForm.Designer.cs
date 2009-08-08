namespace FT.Windows.Forms
{
    partial class DbAutoBakConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbAutoBakConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBakCount = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label1 = new System.Windows.Forms.Label();
            this.checkAutoBak = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBakCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkAutoBak);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(7, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本配置";
            // 
            // txtBakCount
            // 
            this.txtBakCount.Location = new System.Drawing.Point(146, 45);
            this.txtBakCount.Name = "txtBakCount";
            this.txtBakCount.Size = new System.Drawing.Size(100, 24);
            this.txtBakCount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "保留备份文件数";
            // 
            // checkAutoBak
            // 
            this.checkAutoBak.AutoSize = true;
            this.checkAutoBak.Checked = true;
            this.checkAutoBak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoBak.Location = new System.Drawing.Point(25, 21);
            this.checkAutoBak.Name = "checkAutoBak";
            this.checkAutoBak.Size = new System.Drawing.Size(116, 19);
            this.checkAutoBak.TabIndex = 0;
            this.checkAutoBak.Text = "开启自动备份";
            this.checkAutoBak.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSave.Location = new System.Drawing.Point(109, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DbAutoBakConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 152);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbAutoBakConfigForm";
            this.Text = "数据自动备份配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkAutoBak;
        private System.Windows.Forms.Label label1;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtBakCount;
        private System.Windows.Forms.Button btnSave;
    }
}