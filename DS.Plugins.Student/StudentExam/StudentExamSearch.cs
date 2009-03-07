using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class StudentExamSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentExamSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(StudentExam);
            this.DetailFormType = typeof(StudentExamBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentExam);
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
    }
}

