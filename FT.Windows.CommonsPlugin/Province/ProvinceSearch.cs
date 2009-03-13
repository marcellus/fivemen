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
            this.CreateColumn("ʡ������");
            this.CreateColumn("ʡ�ݴ���");
            
        }

        protected override string GetPrintField()
        {
            return "c_text as ʡ������,c_code as ʡ�ݴ���";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 380 };
            //return base.GetPrintWidths();
        }
    }
}

