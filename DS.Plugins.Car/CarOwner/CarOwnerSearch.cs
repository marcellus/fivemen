using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarOwnerSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarOwnerSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(CarOwner);
            this.DetailFormType = typeof(CarOwnerBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarOwner);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("��������", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("���֤������", 160);
            this.CreateColumn("סַ");

        }
    }
}

