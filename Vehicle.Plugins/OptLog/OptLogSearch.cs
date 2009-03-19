using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehicle.Plugins
{
    public partial class OptLogSearch : FT.Windows.Forms.DataSearchControl
    {
        public OptLogSearch()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
            this.EntityType = typeof(OptLog);
            //this.DetailFormType = typeof(VehicleBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(OptLog);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����ʶ����", 130);
            this.CreateColumn("������", 80);
            this.CreateColumn("����ʱ��", 160);
            this.CreateColumn("�������");
        }

        protected override string GetPrintField()
        {
            return "c_clsbm as ����ʶ����,c_operator as ������,date_optdate as ����ʱ��,c_opdetail as �������";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 130, 80,160 };
            //return base.GetPrintWidths();
        }
    }
}

