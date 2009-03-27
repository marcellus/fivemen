using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace FT.Windows.Forms
{
    public partial class EntitySearch : FT.Windows.Forms.DataSearchControl
    {
        public EntitySearch()
        {
            InitializeComponent();
            this.EntityType = typeof(EntityDefine);
            this.DetailFormType = typeof(EntityBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(EntityDefine);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("编号", 80);
            this.CreateColumn("关联类全称", 180);
            this.CreateColumn("实体中文名称");
           
        }
    }
}

