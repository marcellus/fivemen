using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FT.Windows.Forms
{
    public partial class EntityConfigSearch : FT.Windows.Forms.DataSearchControl
    {
        public EntityConfigSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(EntityColumnDefine);
            this.DetailFormType = typeof(EntityConfigBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(EntityColumnDefine);
            this.pager.OrderField = "id";
        }
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("模板类别");
            ToolStripComboBox cb = new ToolStripComboBox();
            cb.Font = new Font("宋体",11f);
            cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            cb.ToolTipText = "选择类别进行查询模板后配置";
            this.toolStrip1.Items.Add(cb);
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(EntityDefine));
            EntityDefine define;
            for(int i=0;i<lists.Count;i++)
            {
                define=lists[i] as EntityDefine;
                cb.Items.Add(define.ClassCnName);
            }
            

        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox cb = sender as ToolStripComboBox;
            this.SetConditions(" c_class_cn_name = '" + cb.Text.Trim() + "'");
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

