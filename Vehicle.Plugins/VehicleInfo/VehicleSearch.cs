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
            this.CreateColumn("�Ǽ�ʱ��", 160);
            this.CreateColumn("����ʶ����", 130);
            this.CreateColumn("����Ʒ��", 100);
            this.CreateColumn("�����ͺ�", 100);
            this.CreateColumn("����������");
        }

        protected override string GetPrintField()
        {
            return "firstregdate as �Ǽ�ʱ��,tecclsbm as ����ʶ����,teczwpp as ����Ʒ��,TecClxh as �����ͺ�,c_base_syr_name as ����������";
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
            if (printSetting.PrintModel == "ֱ�Ӵ�")
            {
                commonPrinter.Print();
            }
            else if (printSetting.PrintModel == "ѡ���ӡ��")
            {
                commonPrinter.ShowPreviewPrinter();
            }
            else
            {
                commonPrinter.Preview();
            }
        }

        


        

        private void �״�ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F1Printer printer = new F1Printer(vehicle);
                this.Print(printer);
            }
        }

        private void ֱ�Ӵ��Ѻ��F7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F7ExcelPrinter printer = new F7ExcelPrinter(vehicle);
                printer.PaintPrinter();
            }
        }

        private void ֱ�Ӵ������F6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F6ExcelPrinter printer = new F6ExcelPrinter(vehicle);
                printer.PaintPrinter();
            }
        }

        private void ��ӡ��ά����F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F5Printer printer = new F5Printer(vehicle);
                this.Print(printer);
            }
        }

        private void �״��Ѻ��F4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F4Printer printer = new F4Printer(vehicle);
                this.Print(printer);
            }
        }

        private void �״������F3toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.IsChecked())
            {
                int i = this.dataGridView1.SelectedRows[0].Index;
                VehicleInfo vehicle = this.pager.Lists[i] as VehicleInfo;
                F3Printer printer = new F3Printer(vehicle);
                this.Print(printer);
            }
        }

        private void ֱ�Ӵ�ȫ��F2ToolStripMenuItem_Click(object sender, EventArgs e)
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

