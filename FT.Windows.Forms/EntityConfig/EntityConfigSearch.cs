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
            this.toolStrip1.Items.Add("ģ�����");
            ToolStripComboBox cb = new ToolStripComboBox();
            cb.Font = new Font("����",11f);
            cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            cb.ToolTipText = "ѡ�������в�ѯģ�������";
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

