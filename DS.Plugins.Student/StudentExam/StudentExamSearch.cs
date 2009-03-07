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
    }
}

