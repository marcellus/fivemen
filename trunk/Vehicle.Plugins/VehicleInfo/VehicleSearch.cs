using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Print;
using FT.Windows.Forms;
using FT.Commons.Cache;


namespace Vehicle.Plugins
{
    public partial class VehicleSearch : FT.Windows.Forms.DataSearchControl
    {
        public VehicleSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(VehicleInfo);
            this.DetailFormType = typeof(VehicleBrowser);
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);
            this.dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseDown);
        }
        void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            //this.mouseClickRow = e.RowIndex;
        }

        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                BaseVehicleInfoPrinter printer = null;
                if (e.KeyCode == Keys.F1)
                {
                    printer = new F1Printer(vehicle);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    printer = new F2ExcelPrinter(vehicle);
                    printer.PaintPrinter();
                    return;
                }
                else if (e.KeyCode == Keys.F3)
                {
                    printer = new F3Printer(vehicle);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    printer = new F4Printer(vehicle);

                }
                else if (e.KeyCode == Keys.F5)
                {
                    printer = new F5Printer(vehicle);
                    //printer = new F5Printer(this.student);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    printer = new F6ExcelPrinter(vehicle);
                    printer.PaintPrinter();
                    return;
                }
                else if (e.KeyCode == Keys.F7)
                {
                    printer = new F7ExcelPrinter(vehicle);
                    printer.PaintPrinter();
                    return;
                }
                if (printer != null)
                {
                    this.Print(printer);
                    //commonPrinter.ShowPreviewPrinter();
                }
            }
            //throw new Exception("The method or operation is not implemented.");
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

        private bool IsChecked()
        {
            return this.dataGridView1.SelectedRows.Count > 0;
        }

        private void Print(IPrinter printer)
        {
            CommonPrinter commonPrinter = new CommonPrinter(printer);
            //commonPrinter.ShowPreviewPrinter();
            GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            if (printSetting.PrintModel == "直接打")
            {
                commonPrinter.Print();
            }
            else if (printSetting.PrintModel == "选择打印机")
            {
                commonPrinter.ShowPreviewPrinter();
            }
            else
            {
                commonPrinter.Preview();
            }
        }

        


        

        private void 套打全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F1Printer printer = new F1Printer(vehicle);
                this.Print(printer);
            }
        }

        private void 直接打抵押表F7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F7ExcelPrinter printer = new F7ExcelPrinter(vehicle);
                printer.PaintPrinter();
            }
        }

        private void 直接打申请表F6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F6ExcelPrinter printer = new F6ExcelPrinter(vehicle);
                printer.PaintPrinter();
            }
        }

        private void 打印二维条码F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F5Printer printer = new F5Printer(vehicle);
                this.Print(printer);
            }
        }

        private void 套打抵押表F4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F4Printer printer = new F4Printer(vehicle);
                this.Print(printer);
            }
        }

        private void 套打申请表F3toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F3Printer printer = new F3Printer(vehicle);
                this.Print(printer);
            }
        }

        private void 直接打全部F2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F2ExcelPrinter printer = new F2ExcelPrinter(vehicle);
                printer.PaintPrinter();
            }
        }
    }
}

