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
            this.CreateColumn("�������", 100);
            this.CreateColumn("�����ı�");
            this.CreateColumn("���ݴ���", 100);
            this.CreateColumn("�Ƿ���Ч", 100);
            this.CreateColumn("��ע");

        }
    }
}

