namespace Vehicle.Plugins
{
    partial class VehicleSearch
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ֱ�Ӵ������F1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ӡ��ά����F3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ֱ�Ӵ������F1ToolStripMenuItem,
            this.��ӡ��ά����F3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "�״�-�����F1��";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ֱ�Ӵ������F1ToolStripMenuItem
            // 
            this.ֱ�Ӵ������F1ToolStripMenuItem.Name = "ֱ�Ӵ������F1ToolStripMenuItem";
            this.ֱ�Ӵ������F1ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ֱ�Ӵ������F1ToolStripMenuItem.Text = "ֱ�Ӵ������F2��";
            this.ֱ�Ӵ������F1ToolStripMenuItem.Click += new System.EventHandler(this.ֱ�Ӵ������F1ToolStripMenuItem_Click);
            // 
            // ��ӡ��ά����F3ToolStripMenuItem
            // 
            this.��ӡ��ά����F3ToolStripMenuItem.Name = "��ӡ��ά����F3ToolStripMenuItem";
            this.��ӡ��ά����F3ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.��ӡ��ά����F3ToolStripMenuItem.Text = "��ӡ����ά���루F3��";
            this.��ӡ��ά����F3ToolStripMenuItem.Click += new System.EventHandler(this.��ӡ��ά����F3ToolStripMenuItem_Click);
            // 
            // VehicleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "VehicleSearch";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ֱ�Ӵ������F1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ӡ��ά����F3ToolStripMenuItem;
    }
}
