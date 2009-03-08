using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class ProvinceSearch : FT.Windows.Forms.DataSearchControl
    {
        public ProvinceSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Province);
            this.DetailFormType = typeof(ProvinceBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Province);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("省份名称");
            this.CreateColumn("省份代码");
            
        }
    }
}

