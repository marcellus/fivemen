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
            this.CreateColumn("身份证明号码", 120);
            this.CreateColumn("费用时间", 140);
            this.CreateColumn("费用金额", 80);
            this.CreateColumn("费用类别", 100);
            this.CreateColumn("备注");
        }
    }
}

