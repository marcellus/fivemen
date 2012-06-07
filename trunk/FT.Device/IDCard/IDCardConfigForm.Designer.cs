namespace FT.Device.IDCard
{
    partial class IDCardConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDCardConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiniSecond = new FT.Windows.Controls.TextBoxEx.NumberInput();
            this.label1 = new System.Windows.Forms.Label();
            this.checkUseIDCard = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkAddReturn = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAddReturn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMiniSecond);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkUseIDCard);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本配置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "毫秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.OliveDrab;
            this.label4.Location = new System.Drawing.Point(31, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "扫描间隔越小越耗系统资源";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(31, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "1000毫秒等于1秒";
            // 
            // txtMiniSecond
            // 
            this.txtMiniSecond.Location = new System.Drawing.Point(97, 59);
            this.txtMiniSecond.Name = "txtMiniSecond";
            this.txtMiniSecond.Size = new System.Drawing.Size(100, 25);
            this.txtMiniSecond.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "扫描间隔";
            // 
            // checkUseIDCard
            // 
            this.checkUseIDCard.AutoSize = true;
            this.checkUseIDCard.Checked = true;
            this.checkUseIDCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUseIDCard.Location = new System.Drawing.Point(30, 32);
            this.checkUseIDCard.Name = "checkUseIDCard";
            this.checkUseIDCard.Size = new System.Drawing.Size(131, 19);
            this.checkUseIDCard.TabIndex = 0;
            this.checkUseIDCard.Text = "开启二代证使用";
            this.checkUseIDCard.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSave.Location = new System.Drawing.Point(98, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkAddReturn
            // 
            this.checkAddReturn.AutoSize = true;
            this.checkAddReturn.Location = new System.Drawing.Point(177, 32);
            this.checkAddReturn.Name = "checkAddReturn";
            this.checkAddReturn.Size = new System.Drawing.Size(71, 19);
            this.checkAddReturn.TabIndex = 5;
            this.checkAddReturn.Text = "加回车";
            this.checkAddReturn.UseVisualStyleBackColor = true;
            // 
            // IDCardConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IDCardConfigForm";
            this.Text = "二代证配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkUseIDCard;
        private System.Windows.Forms.Label label1;
        private FT.Windows.Controls.TextBoxEx.NumberInput txtMiniSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkAddReturn;
    }
}