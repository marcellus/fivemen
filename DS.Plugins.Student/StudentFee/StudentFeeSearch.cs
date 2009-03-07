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

