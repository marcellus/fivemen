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
        private TextBox tbName;
        private TextBox tbLsh;
        private ComboBox cbLocaltype;
        private ComboBox cbCartype;

        public string GetMyCondition()
        {
            return this.pager.Condition;
        }

        public void SetMyConditon(string condition)
        {
            //this.btn.PerformClick();
            this.SetConditions(condition);
            this.SetConditions(condition+" ");
            
             //this.pager.Search();
            
          //  this.
        }

        public LocalFingerRecordSearch(TextBox tx,TextBox tbName,TextBox tbLsh,ComboBox cbLocaltype,ComboBox cbCartype)
        {
            InitializeComponent();
            this.isSelfBinding = false;
            this.tx = tx;
            this.tbName = tbName;
            this.tbLsh = tbLsh;
            this.cbLocaltype = cbLocaltype;
            this.cbCartype = cbCartype;
            this.AddSearch();
            this.EntityType = typeof(LocalFingerRecordObject);
            this.btnDelete.Visible = false;
            this.btnExport.Visible = false;
            this.btnAdd.Visible = false;
            this.btnUpdate.Visible = false;
           // this.dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            this.dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    // this.dataGridView1_SelectionChanged
                    //  int i = this.dataGridView1.SelectedRows[0].Index;
                    // LocalFingerRecordObject student = this.pager.Lists[i] as LocalFingerRecordObject;
                    tbName.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    tx.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    tbLsh.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    cbCartype.SelectedValue = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                    cbLocaltype.SelectedValue = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();

                }
            }
            catch (Exception ex) { }
        }

        void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
            {
                object obj= this.dataGridView1.Rows[j].Cells[2].Value==null?string.Empty: this.dataGridView1.Rows[j].Cells[2].Value;
                string txt =obj.ToString();
                if (string.IsNullOrEmpty(txt))
                {
                    this.dataGridView1.Rows[j].Cells[2].Style.BackColor = Color.Red;
                }
                else
                {
                    this.dataGridView1.Rows[j].Cells[2].Style.BackColor = Control.DefaultBackColor;
                }
            }
            

            //throw new NotImplementedException();
        }
        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
               // this.dataGridView1_SelectionChanged
              //  int i = this.dataGridView1.SelectedRows[0].Index;
               // LocalFingerRecordObject student = this.pager.Lists[i] as LocalFingerRecordObject;
                tbName.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tx.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tbLsh.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                cbCartype.SelectedValue = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
                cbLocaltype.SelectedValue = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
                
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
