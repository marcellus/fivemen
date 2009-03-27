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
            this.CreateColumn("���", 80);
            this.CreateColumn("������ȫ��", 180);
            this.CreateColumn("ʵ����������");
           
        }
    }
}

