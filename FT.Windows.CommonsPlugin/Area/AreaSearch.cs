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
            this.CreateColumn("��������", 140);
            this.CreateColumn("��������", 80);
            this.CreateColumn("����ʡ��", 80);
            this.CreateColumn("������");
        }

        protected override string GetPrintField()
        {
            return "c_text as ��������,c_code as ���ش���,c_father_code as �����д���";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 380, 100 };
            //return base.GetPrintWidths();
        }
    }
}

