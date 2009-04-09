using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarFeeSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarFeeSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(CarFee);
            this.DetailFormType = typeof(CarFeeBrowser);
        }
        private void AddSearch()
        {
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "输入号码号牌按回车查询";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_hmhp like '" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarFee);
            this.pager.OrderField = "id";
        }
        /*
        protected override void SettingGridStyle()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("号码号牌", 80);
            this.CreateColumn("费用时间", 140);
            this.CreateColumn("费用金额", 80);
            this.CreateColumn("费用类别", 100);
            this.CreateColumn("备注");
        }*/
    }
}

