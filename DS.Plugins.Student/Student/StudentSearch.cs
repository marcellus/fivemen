using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class StudentSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(StudentInfo);
            this.DetailFormType = typeof(StudentBrowser);
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentInfo);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤��", 120);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("׼�̳���", 80);
            this.CreateColumn("�������", 80);
            this.CreateColumn("����֤��", 100);
            this.CreateColumn("��ʻ֤���");
        }

        private bool IsChecked()
        {
            return this.dataGridView1.SelectedRows.Count >0;
        }

        private void �״�ȫ��4��F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }
        }

        private void �״�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void �״��������ʻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void �״��������ʻԱ��ѵѧԱ�ǼǱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void �״�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void �״�ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void ֱ�Ӵ��������ʻ֤�����F7��OfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void �״��ҵ֤��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }
    }
}

