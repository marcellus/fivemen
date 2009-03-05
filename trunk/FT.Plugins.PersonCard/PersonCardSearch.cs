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
            this.CreateColumn("姓名",80);
            this.CreateColumn("昵称", 80);
            this.CreateColumn("性别", 80);
            this.CreateColumn("出生年月", 100);
            this.CreateColumn("固话", 80);
            this.CreateColumn("手机", 80);
            this.CreateColumn("联系邮箱", 160);
            this.CreateColumn("分组名称");
            
        }
    }
}

