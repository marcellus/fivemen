using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class ConditionBuildForm : Form
    {
        public ConditionBuildForm()
        {
            InitializeComponent();
        }
        private Type entityType;
        private IRefreshParent refresher;
        public ConditionBuildForm(Type entityType)
        {
            InitializeComponent();
            this.entityType = entityType;
        }

        public ConditionBuildForm(Type entityType,IRefreshParent refresher)
        {
            InitializeComponent();
            this.entityType = entityType;
            this.refresher = refresher;
        }


        /// <summary>
        /// ���ù��쾲̬�Ĳ�������
        /// </summary>
        private static DataTable Operations;

        private DataTable GetOperations()
        {
            if (Operations == null)
            {
                Operations = new DataTable();
                Operations.Columns.Add("text");
                Operations.Columns.Add("value");
                Operations.Rows.Add(new string[]{"����","like"});
                Operations.Rows.Add(new string[]{"����","="});
                Operations.Rows.Add(new string[]{"����",">"});
                Operations.Rows.Add(new string[]{"���ڵ���",">="});
                Operations.Rows.Add(new string[]{"С��","<"});
                Operations.Rows.Add(new string[]{"С�ڵ���","<="});
                Operations.Rows.Add(new string[]{"������","<>"});
            }
            return Operations;
        }

        private void ConditionBuildForm_Load(object sender, EventArgs e)
        {
            this.cbOperations.DataSource = this.GetOperations();
            this.cbOperations.DisplayMember = "text";
            this.cbOperations.ValueMember = "value";
            this.InitEntityFields();
        }

        private void InitEntityFields()
        {
            if (this.entityType != null)
            {
                //
                DataTable dt = FT.DAL.Orm.SimpleOrmCache.GetConditionDT(this.entityType);
                if (dt != null)
                {
                    this.cbFields.DataSource = dt;
                    this.cbFields.DisplayMember = "text";
                    this.cbFields.ValueMember = "value";
                }
            }
        }

        private void radioAnd_CheckedChanged(object sender, EventArgs e)
        {
            this.radioOr.Checked = !this.radioAnd.Checked;
        }

        private void radioOr_CheckedChanged(object sender, EventArgs e)
        {
            this.radioAnd.Checked = !this.radioOr.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtConditions.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtValue.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("ֵΪ�ղ�����ӣ�");
                return;
            }
            if (this.txtConditions.Text.Trim().Length == 0)
            {

            }
            else
            {
                if (this.radioAnd.Checked)
                {
                    this.txtConditions.Text += " and ";
                }
                else
                {
                    this.txtConditions.Text += " or ";
                }
            }
            this.txtConditions.Text += this.cbFields.SelectedValue.ToString();
            string op = this.cbOperations.SelectedValue.ToString();
            this.txtConditions.Text +=" "+op +" ";
            if (op == "like")
            {
                this.txtConditions.Text += "'%" + this.txtValue.Text.Trim() + "%'";
            }
            else if (op == "=")
            {
                this.txtConditions.Text += "'" + this.txtValue.Text.Trim() + "'";
            }
            else if (op == "<>")
            {
                this.txtConditions.Text += "'" + this.txtValue.Text.Trim() + "'";
            }
            else//> >= < <=Ϊ��������
            {
                this.txtConditions.Text +=  this.txtValue.Text.Trim() ;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.entityType != null)
            {
                string table = FT.DAL.Orm.SimpleOrmCache.GetTableName(this.entityType);
                string sql = "select count(*) from " + table;
                string condition=this.txtConditions.Text.Trim();
                if (condition.Length > 0)
                {
                    sql += " where " + condition;
                }
                object obj= FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(sql);
                MessageBoxHelper.Show("ͳ�Ƽ�¼����Ϊ��"+obj.ToString());
            }
            else
            {
                MessageBoxHelper.Show("δ֪��ʵ�壬����û�а취��ѯ��");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (this.refresher != null)
            {
                refresher.SetConditions(this.txtConditions.Text);
            }
            this.Close();
        }
    }
}