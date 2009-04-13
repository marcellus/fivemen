using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class StudentFeeSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentFeeSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(StudentFee);
            this.DetailFormType = typeof(StudentFeeBrowser);
        }
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("学员姓名");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "输入姓名按回车查询";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_name like '" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentFee);
            this.pager.OrderField = "id";
        }

        
    }
}

