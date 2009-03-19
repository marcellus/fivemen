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

        private void ֱ�Ӵ������F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ��ӡ��ά����F3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
/// <summary>
/// �״������
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

