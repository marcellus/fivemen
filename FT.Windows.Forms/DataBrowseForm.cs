using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.PrinterEx.SupportObject;
using FT.DAL.Orm;

namespace FT.Windows.Forms
{
    /// <summary>
    /// ���ʵ�����Ĵ��壬�������date��combo��ô����
    /// </summary>
    public partial class DataBrowseForm : Form
    {
        public DataBrowseForm()
        {
            InitializeComponent();
        }

        public DataBrowseForm(object entity)
        {
            InitializeComponent();
            FormHelper.SetDataToForm(this, entity);
        }

        /// <summary>
        /// ��ʵ���������ݵ�������
        /// </summary>
        /// <param name="entity">ʵ��</param>
        protected void LoadData(object entity)
        {
            FormHelper.SetDataToForm(this, entity);
        }

        protected void GetData(object entity)
        {
            FormHelper.SetDataToForm(this, entity);
        }

        /// <summary>
        /// ����ؼ���ֵ
        /// </summary>
        /// <param name="ctr">The CTR.</param>
        protected void ClearControl(Control ctr)
        {
            int count = ctr.Controls.Count;

            if (count == 0)
            {
                if (ctr is TextBox)
                {
                    ((TextBox)ctr).Text = string.Empty;
                }
            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    ClearControl(tmp);
                }
            }
        }

        

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool result= this.ValidateChildren(ValidationConstraints.Enabled);
            
            //MessageBoxHelper.Show("validate result is:"+result);
            if(result)
            {
                this.ClearValidateError();
                this.Save();
            }
            
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected virtual object GetEntity()
        {
            throw new Exception("�������̳и÷���������һ��ʵ�壡");
         //   return null;
        }

        protected virtual void Save()
        {
            object entity = this.GetEntity();
            FormHelper.GetDataFromForm(this, entity);
            
            if (this.lbId.Text.Length==0)
            {
                if (SimpleOrmOperator.Create(entity))
                {
                    FormHelper.SetDataToForm(this, entity);
                    MessageBoxHelper.Show("��ӳɹ���");
                   
                }
                else
                {
                    MessageBoxHelper.Show("���ʧ�ܣ�");
                }
            }
            else
            {
                if (SimpleOrmOperator.Update(entity))
                {
                    MessageBoxHelper.Show("�޸ĳɹ���");
                }
                else
                {
                    MessageBoxHelper.Show("�޸�ʧ�ܣ�");
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Preview();
            }
        }

        protected virtual PrinterContent GetPrinterContent()
        {
            MessageBoxHelper.Show("�Բ��𣬻�û��ʵ�ִ�ӡ�ö���");
            return null;
            //throw new Exception("");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Print();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
           
            this.ClearAdd();

        }

        /// <summary>
        /// ������֤����
        /// </summary>
        private void ClearValidateError()
        {
            this.errorProvider1.Clear();
        }
       // private int id=-1;
        /// <summary>
        /// ��������
        /// </summary>
        protected virtual void ClearAdd()
        {
            this.ClearValidateError();
            this.ClearControl(this);
            this.lbId.Text= string.Empty;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.ShowAbout();
        }
        /// <summary>
        /// ��ʾ���ڶԻ���
        /// </summary>
        protected virtual void ShowAbout()
        {
            SimpleAbout form = new SimpleAbout();
            form.ShowDialog();
        }
    }
}