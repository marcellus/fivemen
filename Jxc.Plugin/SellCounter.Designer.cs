namespace Jxc.Plugin
{
    partial class SellCounter
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
            this.btnDetail = new System.Windows.Forms.Button();
            this.dateBetweenPanel1 = new FT.Windows.Forms.CommonPanel.DateBetweenPanel();
            this.checkGroupTypeName = new System.Windows.Forms.CheckBox();
            this.checkFrom = new System.Windows.Forms.CheckBox();
            this.btnInDetail = new System.Windows.Forms.Button();
            this.groupSearch.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSearch
            // 
            this.groupSearch.Size = new System.Drawing.Size(898, 160);
            // 
            // btnSearch
            // 
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.checkFrom);
            this.splitContainer2.Panel1.Controls.Add(this.checkGroupTypeName);
            this.splitContainer2.Panel1.Controls.Add(this.btnInDetail);
            this.splitContainer2.Panel1.Controls.Add(this.btnDetail);
            this.splitContainer2.Panel1.Controls.Add(this.dateBetweenPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(892, 137);
            this.splitContainer2.SplitterDistance = 677;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(382, 65);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(116, 23);
            this.btnDetail.TabIndex = 6;
            this.btnDetail.Text = "��ϸ���ۼ�¼";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // dateBetweenPanel1
            // 
            this.dateBetweenPanel1.Font = new System.Drawing.Font("����", 11F);
            this.dateBetweenPanel1.Location = new System.Drawing.Point(4, 15);
            this.dateBetweenPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dateBetweenPanel1.Name = "dateBetweenPanel1";
            this.dateBetweenPanel1.Size = new System.Drawing.Size(371, 82);
            this.dateBetweenPanel1.TabIndex = 5;
            // 
            // checkGroupTypeName
            // 
            this.checkGroupTypeName.AutoSize = true;
            this.checkGroupTypeName.Location = new System.Drawing.Point(382, 15);
            this.checkGroupTypeName.Name = "checkGroupTypeName";
            this.checkGroupTypeName.Size = new System.Drawing.Size(131, 19);
            this.checkGroupTypeName.TabIndex = 7;
            this.checkGroupTypeName.Text = "�Ƿ�ֲ�Ʒ���";
            this.checkGroupTypeName.UseVisualStyleBackColor = true;
            this.checkGroupTypeName.Visible = false;
            // 
            // checkFrom
            // 
            this.checkFrom.AutoSize = true;
            this.checkFrom.Location = new System.Drawing.Point(382, 39);
            this.checkFrom.Name = "checkFrom";
            this.checkFrom.Size = new System.Drawing.Size(101, 19);
            this.checkFrom.TabIndex = 8;
            this.checkFrom.Text = "�Ƿ�ֻ�Դ";
            this.checkFrom.UseVisualStyleBackColor = true;
            this.checkFrom.Visible = false;
            // 
            // btnInDetail
            // 
            this.btnInDetail.Location = new System.Drawing.Point(525, 65);
            this.btnInDetail.Name = "btnInDetail";
            this.btnInDetail.Size = new System.Drawing.Size(116, 23);
            this.btnInDetail.TabIndex = 6;
            this.btnInDetail.Text = "��ϸ����¼";
            this.btnInDetail.UseVisualStyleBackColor = true;
            this.btnInDetail.Click += new System.EventHandler(this.btnInDetail_Click);
            // 
            // SellCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "SellCounter";
            this.Size = new System.Drawing.Size(898, 556);
            this.groupSearch.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetail;
        private FT.Windows.Forms.CommonPanel.DateBetweenPanel dateBetweenPanel1;
        private System.Windows.Forms.CheckBox checkGroupTypeName;
        private System.Windows.Forms.CheckBox checkFrom;
        private System.Windows.Forms.Button btnInDetail;
    }
}
