using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Vehicle.Plugins
{
    public partial class VehicleSearch : FT.Windows.Forms.DataSearchControl
    {
        public VehicleSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(VehicleInfo);
            this.DetailFormType = typeof(VehicleBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(VehicleInfo);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("登记时间", 160);
            this.CreateColumn("车辆识别码", 130);
            this.CreateColumn("中文品牌", 100);
            this.CreateColumn("车辆型号", 100);
            this.CreateColumn("所有人姓名");
        }

        protected override string GetPrintField()
        {
            return "firstregdate as 登记时间,tecclsbm as 车辆识别码,teczwpp as 中文品牌,TecClxh as 车辆型号,c_base_syr_name as 所有人姓名";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 160, 130 ,100,100};
            //return base.GetPrintWidths();
        }

        private void 直接打申请表F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打印二维条码F3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
/// <summary>
/// 套打申请表
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

