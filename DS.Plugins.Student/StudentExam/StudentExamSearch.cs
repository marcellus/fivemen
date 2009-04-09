using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class StudentExamSearch : FT.Windows.Forms.DataSearchControl
    {
        public StudentExamSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(StudentExam);
            this.DetailFormType = typeof(StudentExamBrowser);
        }

        private void AddSearch()
        {
            ToolStripTextBox txt = new System.Windows.Forms.ToolStripTextBox();
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.ToolTipText = "�����������س���ѯ";
            this.toolStrip1.Items.Add(txt);

        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox txt = sender as ToolStripTextBox;
                this.SetConditions(" c_name like '" + txt.Text.Trim() + "%'");
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(StudentExam);
            this.pager.OrderField = "id";
        }
        /*
        protected override void SettingGridStyle()
        {

            this.dataGridView1.AutoGenerateColumns = false;
            this.CreateColumn("����", 80);
            this.CreateColumn("���֤������", 120);
            this.CreateColumn("�Ա�", 80);
            this.CreateColumn("�̻�", 80);
            this.CreateColumn("�ֻ�", 80);
            this.CreateColumn("׼�̳���", 80);
            this.CreateColumn("�������", 80);
            this.CreateColumn("����֤��", 100);
            this.CreateColumn("��ʻ֤���");
        }*/
    }
}

