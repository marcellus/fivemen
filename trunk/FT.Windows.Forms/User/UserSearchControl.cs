using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms
{
    public partial class UserSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public UserSearchControl()
        {
            InitializeComponent();
            this.EntityType = typeof(User);
            this.DetailFormType=typeof(UserBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(User);
            this.pager.OrderField = "id";
            //this.pager.PageSize = 3;
           // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "ÐÕÃû";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
           // this.dataGridView1.Columns.Add(col1);
            
        }

       
    }
}

