using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class XiangSearch : FT.Windows.Forms.DataSearchControl
    {
        public XiangSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Xiang);
            this.DetailFormType = typeof(XiangBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Xiang);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("所属辖区", 120);
            this.CreateColumn("数据文本", 120);
            this.CreateColumn("数据代码", 120);
            this.CreateColumn("是否有效");
        }

        protected override string GetPrintField()
        {
            return @"c_text as 数据文本, c_value as 数据代码, c_valid as 是否有效
            ,c_blongarea as 所属辖区";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 180, 180, 80 };
            //return base.GetPrintWidths();
        }
    }
}

