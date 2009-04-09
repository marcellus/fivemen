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
            this.EntityType = typeof(Dict);
            this.DetailFormType = typeof(DictBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Dict);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("�������", 100);
            this.CreateColumn("�����ı�",240);
            this.CreateColumn("���ݴ���", 100);
            this.CreateColumn("�Ƿ���Ч", 100);
            this.CreateColumn("��ע");

        }

        protected override string GetPrintField()
        {
            return @"c_text as �����ı�, c_value as ���ݴ���, c_valid as �Ƿ���Ч
            ,c_grouptype as �������";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 240, 180, 80 };
            //return base.GetPrintWidths();
        }
    }
}

