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
            this.CreateColumn("车辆识别码", 130);
            this.CreateColumn("操作人", 80);
            this.CreateColumn("操作时间", 160);
            this.CreateColumn("具体操作");
        }

        protected override string GetPrintField()
        {
            return "c_clsbm as 车辆识别码,c_operator as 操作人,date_optdate as 操作时间,c_opdetail as 具体操作";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 130, 80,160 };
            //return base.GetPrintWidths();
        }
    }
}

