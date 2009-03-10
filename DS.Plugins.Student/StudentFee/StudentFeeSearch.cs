using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class StudentFeeSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentFeeSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(StudentFee);
            this.DetailFormType = typeof(StudentFeeBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentFee);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤������", 120);
            this.CreateColumn("����ʱ��", 140);
            this.CreateColumn("���ý��", 80);
            this.CreateColumn("�������", 100);
            this.CreateColumn("��ע");
        }
    }
}

