using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Car
{
    public partial class CarSearch : FT.Windows.Forms.DataSearchControl
    {
        public CarSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(CarInfo);
            this.DetailFormType = typeof(CarBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarInfo);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("��������", 80);
            this.CreateColumn("����Ʒ��", 80);
            this.CreateColumn("�������", 80);
            this.CreateColumn("��������", 80);
            this.CreateColumn("����״̬", 80);
            this.CreateColumn("����������", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("���ʱ��", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("ת��ʱ��", 100).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("·�ѹ�������", 130).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("��ͬǩ��ʱ��", 130).DefaultCellStyle.Format = "yyyy-MM-dd";
            this.CreateColumn("�Ƿ������");
            this.CreateColumn("�Ƿ��Գ�");
        }
    }
}

