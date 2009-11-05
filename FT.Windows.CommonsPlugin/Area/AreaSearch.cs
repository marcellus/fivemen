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
            //this.AddSearch();
            this.EntityType = typeof(Area);
            this.DetailFormType = typeof(AreaBrowser);
        }
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("输入省市县地区名称");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();

            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "请输入省市县地区名称按回车查询";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_hmhp like '%" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
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
            this.CreateColumn("县区名称", 140);
            this.CreateColumn("县区代码", 80);
            this.CreateColumn("所属省份", 80);
            this.CreateColumn("所属市");
        }

        protected override string GetPrintField()
        {
            return "c_text as 区县名称,c_code as 区县代码,c_father_code as 所属市代码";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 380, 100 };
            //return base.GetPrintWidths();
        }
    }
}

