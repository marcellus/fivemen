using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;
using System.Collections;

namespace DS.Plugins.Student
{
    public partial class StudentFeeBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public StudentFeeBrowser()
        {
            InitializeComponent();
             this.InitComBox();
        }

        #region �������ʵ�ֵ�
        public StudentFeeBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public StudentFeeBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                //if (lists.Count > 0)
                //{
                //    //this.cbGroup
                //    this.cbHmhp.DataSource = lists;
                //    this.cbHmhp.DisplayMember = "�������";
                //    this.cbHmhp.ValueMember = "�������";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                FT.Windows.CommonsPlugin.DictManager.BindStudentFee(this.cbFeeType);
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new StudentFee();
            //   return null;
        }
        #endregion

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
           if (this.txtFee.Text.Trim().Length == 0)
            {
                this.SetError(sender, "����������ý�");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    Convert.ToDouble(this.txtFee.Text.Trim());
                    this.ClearError(sender);
                    e.Cancel = false;

                }
                catch (Exception ex)
                {
                    this.SetError(sender, "���ý����������֣�");
                    e.Cancel = true;
                }
            }
        }

        private void cbIdCard_TextChanged(object sender, EventArgs e)
        {
            object obj = this.cbIdCard.SelectedValue;
            if (obj != null)
            {
                this.lbName.Text = obj.ToString();
            }
            else
            {
                //this.lbName.Text = this.cbIdCard.Text.Trim();
            }
        }

        private void BindIdCard(string id)
        {
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select c_name,c_idcard from table_students where c_idcard like '%" + id + "%'", "students");

            this.cbIdCard.ValueMember = "c_name";
            this.cbIdCard.DisplayMember = "c_idcard";
            this.cbIdCard.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string id = this.textbox1.Text.Trim();
            if (id.Length > 6)
            {
                this.BindIdCard(id);
            }
        }

        protected override void BeforeSave(object entity)
        {
           // FT.Commons.Tools.FormHelper.SetDataToObject(entity, "Name", this.cbIdCard.SelectedValue.ToString());
            base.BeforeSave(entity);
        }

        private void StudentFeeBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.entity != null)
            {
                //this.BindIdCard(this.lb
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbIdCard.SelectedValue == null&&this.lbName.Text.Length==0)
            {
                this.SetError(this.cbIdCard, "���֤���������ѡ��ģ�");
                e.Cancel = true;
            }
            else
            {
                this.SetError(this.cbIdCard, "");
                e.Cancel = false;
            }
        }
    }
}

