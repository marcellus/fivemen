using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardSearch : FT.Windows.Forms.DataSearchControl
    {
        public PersonCardSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Card);
            this.DetailFormType=typeof(PersonCardBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType=typeof(Card);
            this.pager.OrderField = "id";
            this.pager.PageSize = 3;
           // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "ÐÕÃû";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
           // this.dataGridView1.Columns.Add(col1);
            
        }
    }
}

