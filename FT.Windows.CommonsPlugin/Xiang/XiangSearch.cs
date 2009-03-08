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
            this.CreateColumn("����Ͻ��", 120);
            this.CreateColumn("�����ı�", 120);
            this.CreateColumn("���ݴ���", 120);
            this.CreateColumn("�Ƿ���Ч");
        }
    }
}

