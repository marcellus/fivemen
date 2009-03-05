using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class UserSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public UserSearchControl()
        {
            InitializeComponent();
            this.EntityType = typeof(Entity.User);
            this.DetailFormType=typeof(UserBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Entity.User);
            this.pager.OrderField = "id";
            //this.pager.PageSize = 3;
           // DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "姓名";
            //col1.DataPropertyName = "Name1";
            //col1.Name = "Name";
           // this.dataGridView1.Columns.Add(col1);
            
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("登录名", 80);
            this.CreateColumn("是否有效", 80);
            this.CreateColumn("备注");
        }
    }
}

