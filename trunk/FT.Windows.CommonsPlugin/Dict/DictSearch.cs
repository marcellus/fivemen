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
            this.EntityType = typeof(Dict);
            this.DetailFormType = typeof(DictBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Dict);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("数据类别", 100);
            this.CreateColumn("数据文本",240);
            this.CreateColumn("数据代码", 100);
            this.CreateColumn("是否有效", 100);
            this.CreateColumn("备注");

        }

        protected override string GetPrintField()
        {
            return @"c_text as 数据文本, c_value as 数据代码, c_valid as 是否有效
            ,c_grouptype as 所属类别";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 240, 180, 80 };
            //return base.GetPrintWidths();
        }
    }
}

