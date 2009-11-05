using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoachCar
{
    public partial class CoachCarSearchControl : FT.Windows.Forms.DataSearchControl
    {
        public CoachCarSearchControl()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(CoachCarInfo);
            this.DetailFormType = typeof(CoachCarBrowser);
        }
        private void AddSearch()
        {
            this.toolStrip1.Items.Add("�ؼ���");
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();

            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "��������,���֤�ţ����ţ�����֤�Ű��س���ѯ";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_keyWords like '%" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CoachCarInfo);
            this.pager.OrderField = "id";
        }
       

        protected override string  GetExportTitle()
{
 	  return "�麣�и���ѵ��λ��������Ա�볡�ǼǱ�";
}

    }
}

