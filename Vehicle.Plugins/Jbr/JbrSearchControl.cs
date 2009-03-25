using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehicle.Plugins
{
    public partial class JbrSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public JbrSearchControl()
        {
            InitializeComponent();
            this.EntityType = typeof(Jbr);
            this.DetailFormType = typeof(JbrBrowser);
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Jbr);
            this.pager.OrderField = "id";
        }

        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤������", 120);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("סַ");
           
        }

        protected override string GetPrintField()
        {
            return @"c_name as ����,c_idcard as ���֤������,c_sex as �Ա�,
            c_birthday as  ��������,c_phone as �̻�,
c_mobile as �ֻ�";
        }

        protected override int[] GetPrintWidths()
        {
            return new int[] { 100, 160, 60, 120, 120, };
            //return base.GetPrintWidths();
        }
    }
}

