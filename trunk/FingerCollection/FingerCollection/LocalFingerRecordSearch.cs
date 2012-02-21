using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FingerCollection
{
    public partial class LocalFingerRecordSearch : FT.Windows.Forms.DataSearchControl
    {
        private TextBox tx;
        public LocalFingerRecordSearch(TextBox tx)
        {
            InitializeComponent();
            this.tx = tx;
            this.AddSearch();
            this.EntityType = typeof(LocalFingerRecordObject);
            this.btnDelete.Visible = false;
            this.btnExport.Visible = false;
            this.btnAdd.Visible = false;
            this.btnUpdate.Visible = false;
            this.dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }
        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
               // this.dataGridView1_SelectionChanged
              //  int i = this.dataGridView1.SelectedRows[0].Index;
               // LocalFingerRecordObject student = this.pager.Lists[i] as LocalFingerRecordObject;
                string txt = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.tx.Text = txt;
            }
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(LocalFingerRecordObject);
            this.pager.OrderField = "id";
        }
        private ToolStripTextBox txt;
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("姓名");
            txt = new System.Windows.Forms.ToolStripTextBox();
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "输入姓名按回车查询";
            this.toolStrip1.Items.Add(txt);
             
        }



        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string condition = " c_name like '" + txt.Text.Trim() + "%'";
                this.SetConditions(condition);
            }
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
