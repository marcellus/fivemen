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
            this.AddSearch();
            this.EntityType = typeof(CarInfo);
            this.DetailFormType = typeof(CarBrowser);
        }

        private void AddSearch()
        {
            this.toolStrip1.Items.Add("�������");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
            
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "���������ư��س���ѯ";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_hmhp like '" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CarInfo);
            this.pager.OrderField = "id";
        }
/*
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
        }*/
    }
}

