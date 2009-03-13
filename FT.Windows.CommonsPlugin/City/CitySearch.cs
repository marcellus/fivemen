using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class CitySearch : FT.Windows.Forms.DataSearchControl
    {
        public CitySearch()
        {
            InitializeComponent();
            this.EntityType = typeof(City);
            this.DetailFormType = typeof(CityBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(City);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("市名称", 140);
            this.CreateColumn("市代码", 80);
            this.CreateColumn("所属省份");
        }

        protected override string GetPrintField()
        {
            return "c_text as 市名称,c_code as 市代码,c_father_code as 所属省份代码";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 380,100 };
            //return base.GetPrintWidths();
        }
    }
}

