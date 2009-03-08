using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class CunSearch : FT.Windows.Forms.DataSearchControl
    {
        public CunSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Cun);
            this.DetailFormType = typeof(CunBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Cun);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("所属辖区", 120);
            this.CreateColumn("所属乡镇");
            this.CreateColumn("数据文本", 120);
            this.CreateColumn("数据代码", 120);
            this.CreateColumn("是否有效");
        }
    }
}

