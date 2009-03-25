using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehicle.Plugins
{
    public partial class JbrSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public JbrSearchControl()
        {
            InitializeComponent();
            this.EntityType = typeof(Jbr);
            this.DetailFormType = typeof(JbrBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Jbr);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("姓名", 80);
            this.CreateColumn("身份证明号码", 120);
            this.CreateColumn("性别", 80);
            this.CreateColumn("固话", 80);
            this.CreateColumn("手机", 80);
            this.CreateColumn("住址");
           
        }

        protected override string GetPrintField()
        {
            return @"c_name as 姓名,c_idcard as 身份证明号码,c_sex as 性别,
            c_birthday as  出生年月,c_phone as 固话,
c_mobile as 手机";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 100, 160, 60, 120, 120, };
            //return base.GetPrintWidths();
        }
    }
}

