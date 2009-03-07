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
            this.CreateColumn("姓名", 80);
            this.CreateColumn("身份证号", 120);
            this.CreateColumn("性别", 80);
            this.CreateColumn("固话", 80);
            this.CreateColumn("手机", 80);
            this.CreateColumn("准教车型", 80);
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("教练证号", 100);
            this.CreateColumn("驾驶证编号");
        }

        private bool IsChecked()
        {
            return this.dataGridView1.SelectedRows.Count >0;
        }

        private void 套打全部4张F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }
        }

        private void 套打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 套打机动车驾驶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 套打机动车驾驶员培训学员登记表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 套打ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 套打ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 直接打机动车驾驶证申请表F7需OfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }

        private void 套打结业证明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
            }

        }
    }
}

