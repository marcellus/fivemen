using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.ExternalTool
{
    public partial class TrainStopTimeSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public TrainStopTimeSearchControl()
        {
            InitializeComponent();
            this.EntityType = typeof(TrainStopTime);
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnAdd.Visible = false;
            //this.DetailFormType = typeof(PersonCardBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(TrainStopTime);
            this.pager.OrderField = "station_no";
            //this.pager.PageSize = 3;
            // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "ÐÕÃû";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
            // this.dataGridView1.Columns.Add(col1);

        }
        protected override void ShowDetail(int index)
        {
            
        }
    }
}

