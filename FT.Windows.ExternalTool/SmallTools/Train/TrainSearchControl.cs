using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.ExternalTool
{
    public partial class TrainSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public TrainSearchControl()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(Train);
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnAdd.Visible = false;
            //this.DetailFormType = typeof(PersonCardBrowser);
        }

        private ToolStripTextBox txt1;
        private ToolStripTextBox txt2;
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("车次");
            txt1 = new System.Windows.Forms.ToolStripTextBox();

            txt1.KeyDown += new KeyEventHandler(txt1_KeyDown);
            txt1.ToolTipText = "输入车次按回车查询";
            this.toolStrip1.Items.Add(txt1);

            this.toolStrip1.Items.Add("站名");
            txt2 = new System.Windows.Forms.ToolStripTextBox();

            txt2.KeyDown += new KeyEventHandler(txt2_KeyDown);
            txt2.ToolTipText = "输入站名按回车查询";
            this.toolStrip1.Items.Add(txt2);

        }

        void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string condition = " cc = '" + txt1.Text.Trim() + "'";
                this.SetConditions(condition);
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string condition = " exsits(select station_train_code from table_train_stoptime as b where b.station_train_code like '%%') = '" + txt1.Text.Trim() + "'";
                this.SetConditions(condition);
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Train);
            this.pager.OrderField = "cc";
            //this.pager.PageSize = 3;
            // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "姓名";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
            // this.dataGridView1.Columns.Add(col1);

        }

        protected override void ShowDetail(int index)
        {
            Form form = new Form();
            
            TrainStopTimeSearchControl control = new TrainStopTimeSearchControl();
            Train train = pager.Lists[index] as Train;
            if (train != null)
            {
                form.Text = "车次"+train.Cc+"停站信息";
                control.SetConditions("station_train_code like '%" + train.Cc + "%'");
            }
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);
            form.Show();
        }

    }
}

