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
            this.CreateColumn("��������", 80);
            this.CreateColumn("��ͷ����", 120);
            this.CreateColumn("��ͷ���", 80);
            this.CreateColumn("�Ƿ��ӡ", 30);
            this.CreateColumn("��ӡ���", 80);
            this.CreateColumn("�Ƿ񵼳�", 30);
            this.CreateColumn("�������", 80);
            this.CreateColumn("�Ƿ���ʾ", 30);
            this.CreateColumn("����˳��", 10);
            this.CreateColumn("����ʵ������");
        }*/
    }
}

