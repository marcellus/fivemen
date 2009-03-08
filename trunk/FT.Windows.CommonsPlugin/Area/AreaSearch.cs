using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class AreaSearch : FT.Windows.Forms.DataSearchControl
    {
        public AreaSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Area);
            this.DetailFormType = typeof(AreaBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Area);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("县区名称", 140);
            this.CreateColumn("县区代码", 80);
            this.CreateColumn("所属省份", 80);
            this.CreateColumn("所属市");
        }
    }
}

