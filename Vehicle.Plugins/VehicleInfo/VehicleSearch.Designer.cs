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
            this.�״��Ѻ��F4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ֱ�Ӵ��Ѻ��F5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�״�ȫ��F6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ֱ�Ӵ������F1ToolStripMenuItem,
            this.��ӡ��ά����F3ToolStripMenuItem,
            this.�״��Ѻ��F4ToolStripMenuItem,
            this.ֱ�Ӵ��Ѻ��F5ToolStripMenuItem,
            this.�״�ȫ��F6ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 136);
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
            // �״��Ѻ��F4ToolStripMenuItem
            // 
            this.�״��Ѻ��F4ToolStripMenuItem.Name = "�״��Ѻ��F4ToolStripMenuItem";
            this.�״��Ѻ��F4ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.�״��Ѻ��F4ToolStripMenuItem.Text = "�״�-��Ѻ��F4��";
            // 
            // ֱ�Ӵ��Ѻ��F5ToolStripMenuItem
            // 
            this.ֱ�Ӵ��Ѻ��F5ToolStripMenuItem.Name = "ֱ�Ӵ��Ѻ��F5ToolStripMenuItem";
            this.ֱ�Ӵ��Ѻ��F5ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ֱ�Ӵ��Ѻ��F5ToolStripMenuItem.Text = "ֱ�Ӵ򣭵�Ѻ��F5��";
            // 
            // �״�ȫ��F6ToolStripMenuItem
            // 
            this.�״�ȫ��F6ToolStripMenuItem.Name = "�״�ȫ��F6ToolStripMenuItem";
            this.�״�ȫ��F6ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.�״�ȫ��F6ToolStripMenuItem.Text = "�״�ȫ��-��F6��";
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
        private System.Windows.Forms.ToolStripMenuItem �״��Ѻ��F4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ֱ�Ӵ��Ѻ��F5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �״�ȫ��F6ToolStripMenuItem;
    }
}
