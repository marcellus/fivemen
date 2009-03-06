using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarOutSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarOutSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(CarOut);
            this.DetailFormType = typeof(CarOutBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarOut);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("出车时间", 140);
            this.CreateColumn("出车原因");
        }
    }
}

