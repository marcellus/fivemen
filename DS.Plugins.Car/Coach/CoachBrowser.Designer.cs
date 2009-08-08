namespace DS.Plugins.Car
{
    partial class CoachBrowser
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
            this.personDetail1 = new FT.Windows.Forms.PersonDetail();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCoachId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDriverId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.cbHmhp = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personDetail1
            // 
            this.personDetail1.Location = new System.Drawing.Point(3, 75);
            this.personDetail1.Name = "personDetail1";
            this.personDetail1.Size = new System.Drawing.Size(515, 319);
            this.personDetail1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "教练证号";
            // 
            // txtCoachId
            // 
            this.txtCoachId.Location = new System.Drawing.Point(100, 20);
            this.txtCoachId.Name = "txtCoachId";
            this.txtCoachId.Size = new System.Drawing.Size(125, 24);
            this.txtCoachId.TabIndex = 1;
            this.txtCoachId.Validating += new System.ComponentModel.CancelEventHandler(this.txtCoachId_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "驾驶证编号";
            // 
            // txtDriverId
            // 
            this.txtDriverId.Location = new System.Drawing.Point(344, 20);
            this.txtDriverId.Name = "txtDriverId";
            this.txtDriverId.Size = new System.Drawing.Size(162, 24);
            this.txtDriverId.TabIndex = 2;
            this.txtDriverId.Validating += new System.ComponentModel.CancelEventHandler(this.txtDriverId_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "教练车";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "准驾车型";
            // 
            // cbCarType
            // 
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Location = new System.Drawing.Point(100, 48);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(125, 23);
            this.cbCarType.TabIndex = 3;
            // 
            // cbHmhp
            // 
            this.cbHmhp.FormattingEnabled = true;
            this.cbHmhp.Location = new System.Drawing.Point(344, 48);
            this.cbHmhp.Name = "cbHmhp";
            this.cbHmhp.Size = new System.Drawing.Size(162, 23);
            this.cbHmhp.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbCarType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCoachId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.personDetail1);
            this.groupBox1.Controls.Add(this.cbHmhp);
            this.groupBox1.Controls.Add(this.txtDriverId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 404);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // CoachBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(538, 445);
            this.Controls.Add(this.groupBox1);
            this.Name = "CoachBrowser";
            this.Text = "教练信息";
            this.Load += new System.EventHandler(this.CoachBrowser_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FT.Windows.Forms.PersonDetail personDetail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCoachId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDriverId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.ComboBox cbHmhp;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
