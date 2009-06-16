using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarOutSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarOutSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(CarOut);
            this.DetailFormType = typeof(CarOutBrowser);
        }
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("∫≈¬Î∫≈≈∆");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
           
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = " ‰»Î∫≈¬Î∫≈≈∆∞¥ªÿ≥µ≤È—Ø";
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
            this.pager.EntityType = typeof(CarOut);
            this.pager.OrderField = "id";
        }

        
    }
}

