namespace FT.Windows.Forms
{
    partial class EntityBrowser
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityBrowser));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateColumnDefine = new System.Windows.Forms.Button();
            this.txtClassCnName = new System.Windows.Forms.TextBox();
            this.txtClassFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerateColumnDefine);
            this.groupBox1.Controls.Add(this.txtClassCnName);
            this.groupBox1.Controls.Add(this.txtClassFullName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("����", 11F);
            this.groupBox1.Location = new System.Drawing.Point(13, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 136);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������Ϣ";
            // 
            // btnGenerateColumnDefine
            // 
            this.btnGenerateColumnDefine.Location = new System.Drawing.Point(151, 94);
            this.btnGenerateColumnDefine.Name = "btnGenerateColumnDefine";
            this.btnGenerateColumnDefine.Size = new System.Drawing.Size(125, 23);
            this.btnGenerateColumnDefine.TabIndex = 3;
            this.btnGenerateColumnDefine.Text = "�����ж���ģ��";
            this.btnGenerateColumnDefine.UseVisualStyleBackColor = true;
            this.btnGenerateColumnDefine.Click += new System.EventHandler(this.btnGenerateColumnDefine_Click);
            // 
            // txtClassCnName
            // 
            this.txtClassCnName.Location = new System.Drawing.Point(78, 55);
            this.txtClassCnName.Name = "txtClassCnName";
            this.txtClassCnName.Size = new System.Drawing.Size(321, 24);
            this.txtClassCnName.TabIndex = 2;
            // 
            // txtClassFullName
            // 
            this.txtClassFullName.Location = new System.Drawing.Point(79, 21);
            this.txtClassFullName.Name = "txtClassFullName";
            this.txtClassFullName.Size = new System.Drawing.Size(321, 24);
            this.txtClassFullName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "������";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "����";
            // 
            // EntityBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(452, 223);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntityBrowser";
            this.Text = "ģ���������";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateColumnDefine;
        private System.Windows.Forms.TextBox txtClassCnName;
        private System.Windows.Forms.TextBox txtClassFullName;
    }
}
