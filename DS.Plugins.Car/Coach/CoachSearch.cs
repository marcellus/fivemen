using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CoachSearch : FT.Windows.Forms.DataSearchControl
    {
        public CoachSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Coach);
            this.DetailFormType = typeof(CoachBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Coach);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤��", 120);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("׼�̳���", 80);
            this.CreateColumn("�������", 80);
            this.CreateColumn("����֤��", 100);
            this.CreateColumn("��ʻ֤���");
        }
    }
}

