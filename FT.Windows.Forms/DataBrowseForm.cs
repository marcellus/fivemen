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
    ///��ʼ��˳�򣬸��๹�죬���๹�죬����load������load
    /// ���Բ���ϰ�߿��ڸ����load����ʵ��
    /// <summary>
    /// ���ʵ�����Ĵ��壬�������date��combo��ô����
    /// </summary>
    public partial class DataBrowseForm : Form
    {
        public DataBrowseForm()
        {
            InitializeComponent();
            this.lbId.Text = string.Empty;
            //MessageBoxHelper.Show("����Ŀչ��캯����");
        }
        private object entity;

        public DataBrowseForm(object entity):this()
        {
            //MessageBoxHelper.Show("����Ĵ��ι��캯����");
            this.entity = entity;
            //InitializeComponent();
            //MessageBoxHelper.Show("����Ĺ��캯����");
        }

        private IRefreshParent refresher;

        public DataBrowseForm(object entity, IRefreshParent refresher):this()
        {
            this.entity = entity;
            this.refresher = refresher;
        }

        public DataBrowseForm(IRefreshParent refresher)
            : this()
        {
            this.refresher = refresher;
        }

        /// <summary>
        /// ��ʼ������ϰ�ߣ����簴�س���Ч��Tab
        /// </summary>
        protected void InitHabit()
        {
            FormHelper.InitHabitToForm(this);
        }
        /// <summary>
        /// Ϊ�ؼ�����text������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        protected void SetError(object sender, string text)
        {
            this.errorProvider1.SetError((Control)sender, text);
        }
        /// <summary>
        /// ���ĳ�ؼ��ϵĴ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        protected void ClearError(object sender)
        {
            SetError(sender, string.Empty);
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
            FormHelper.GetDataFromForm(this, entity);
        }

        /// <summary>
        /// ����ؼ���ֵ,ֻ����textbox��ֵ
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

        protected virtual void BeforeCreateEntity(object entity)
        {

        }

        protected virtual void BeforeUpdateEntity(object entity)
        {

        }
        protected virtual void BeforeSave(object entity)
        {
        }

        protected virtual bool Save()
        {
            if (this.entity == null)
            {
                this.entity = this.GetEntity();
            }
            FormHelper.GetDataFromForm(this, entity);
            this.BeforeSave(entity);
            if (this.lbId.Text.Length==0||this.lbId.Text.Trim()=="0")
            {
                this.BeforeCreateEntity(entity);
                if (SimpleOrmOperator.Create(entity))
                {
                    FormHelper.SetDataToForm(this, entity);
                    MessageBoxHelper.Show("��ӳɹ���");
                    if (refresher != null)
                    {
                        refresher.Add(entity);
                    }
                   
                }
                else
                {
                    MessageBoxHelper.Show("���ʧ�ܣ�");
                    return false;
                }
            }
            else
            {
                this.BeforeUpdateEntity(entity);
                if (SimpleOrmOperator.Update(entity))
                {
                    MessageBoxHelper.Show("�޸ĳɹ���");
                    if (refresher != null)
                    {
                        refresher.Update(entity);
                    }
                }
                else
                {
                    MessageBoxHelper.Show("�޸�ʧ�ܣ�");
                    return false;
                }
            }
            return true;
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
            //this.entity=
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
            this.entity = null;
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
            form.ShowInTaskbar = false;
            
            form.ShowDialog();
        }

        private void DataBrowseForm_Load(object sender, EventArgs e)
        {
            //MessageBoxHelper.Show("�����Load��");
            if (!this.DesignMode)
            {
                this.InitHabit();
                if (this.entity != null)
                {
                    this.LoadData(entity);
                }
            }
        }
    }
}