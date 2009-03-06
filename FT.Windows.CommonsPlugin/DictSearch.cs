using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class DictSearch : FT.Windows.Forms.DataSearchControl
    {
        public DictSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Entity.Dict);
            this.DetailFormType = typeof(DictBrower);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Entity.Dict);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("数据类别", 100);
            this.CreateColumn("数据文本");
            this.CreateColumn("数据代码", 100);
            this.CreateColumn("是否有效", 100);
            this.CreateColumn("备注");

        }
    }
}

