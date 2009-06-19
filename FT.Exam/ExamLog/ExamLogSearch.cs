using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Exam
{
    public partial class ExamLogSearch : FT.Windows.Forms.DataSearchControl
    {

        protected override void ShowDetail(int index)
        {

            ExamLog log=pager.Lists[this.dataGridView1.SelectedRows[0].Index] as ExamLog;
            if(log!=null)
            {
                Form form = new UserExamDetail(log.Id.ToString());
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
           
        }

        public ExamLogSearch()
        {
            InitializeComponent();
            this.AddSearch();
            this.EntityType = typeof(ExamLog);
            //this.DetailFormType = typeof(ExamLogBrowser);
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnUpdate.Visible = false;
        }
        private ToolStripTextBox txt;
        private void AddSearch()
        {

            this.toolStrip1.Items.Add("���֤������");
            txt = new System.Windows.Forms.ToolStripTextBox();
            txt.KeyDown += new KeyEventHandler(txt_KeyDown);
            txt.Width = 140;
            txt.ToolTipText = "�������֤�����밴�س���ѯ";
            this.toolStrip1.Items.Add(txt);
        }
        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string condition = " c_idcard = '" + txt.Text.Trim() + "'";
                this.SetConditions(condition);
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        public void SetUserIdCard(string idcard)
        {
            txt.Text = idcard;
            string condition = " c_idcard = '" + txt.Text.Trim() + "'";
            this.SetConditions(condition);
        }

        #region �������̳�
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(ExamLog);
            this.pager.OrderField = "id"; 
        }
        #endregion
    }
}

