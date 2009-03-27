using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms
{
    public partial class EntityConfigSearch : FT.Windows.Forms.DataSearchControl
    {
        public EntityConfigSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(EntityColumnDefine);
            this.DetailFormType = typeof(EntityConfigBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(EntityColumnDefine);
            this.pager.OrderField = "id";
        }
/*
        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("属性名称", 80);
            this.CreateColumn("列头名称", 120);
            this.CreateColumn("列头宽度", 80);
            this.CreateColumn("是否打印", 30);
            this.CreateColumn("打印宽度", 80);
            this.CreateColumn("是否导出", 30);
            this.CreateColumn("导出宽度", 80);
            this.CreateColumn("是否显示", 30);
            this.CreateColumn("排列顺序", 10);
            this.CreateColumn("关联实体名称");
        }*/
    }
}

