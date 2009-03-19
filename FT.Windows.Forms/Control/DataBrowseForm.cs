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
using FT.Commons.Cache;

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
        protected object entity;

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


        #region ��֤����Ļ��෽��
        protected void ValidateIdCard(object sender, CancelEventArgs e,  bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                string tmp=txt.Text.Trim();
                if (allowBlank)
                {
                    if (tmp.Length == 0)
                    {   
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                    else
                    {
                        tmp = IDCardHelper.Validate(tmp);
                        if (tmp.Length != 0)
                        {
                            this.errorProvider1.SetError(txt, tmp);
                            e.Cancel = true;
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt, string.Empty);
                            e.Cancel = false;
                        }
                    }
                }
                else if (tmp.Length == 0)
                {
                    this.errorProvider1.SetError(txt, "���������֤��!");
                    e.Cancel = true;
                }
                else
                {
                    tmp = IDCardHelper.Validate(tmp);
                    if (tmp.Length != 0)
                    {
                        this.errorProvider1.SetError(txt, tmp);
                        e.Cancel = true;
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
                
                
            }
        }

        protected void ValidateAlapha(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateAlapha(sender, e, "��������ȷ����ĸ��", allowBlank);
        }

        protected void ValidateAlapha(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateAlapha(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateUrl(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateUrl(sender, e, "��������ȷ��Url��ʽ��", allowBlank);
        }

        protected void ValidateUrl(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateUrl(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }
        protected void ValidateEmail(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateEmail(sender, e, "��������ȷ��Email��ʽ��", allowBlank);
        }

        protected void ValidateEmail(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateEmail(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateIp(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateIp(sender, e, "��������ȷ��IP��ʽ��", allowBlank);
        }

        protected void ValidateIp(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateIp(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidatePostCode(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePostCode(sender, e, "��������λ�ʱ�ţ�", allowBlank);
        }

        protected void ValidatePostCode(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePostCode(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateDate(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {

                try
                {
                    Convert.ToDateTime(txt.Text);
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "�������ʽΪyyyy-MM-dd�����ڣ�");
                    e.Cancel = true;

                }

            }
        }

        protected void ValidateDateMasked(object sender, CancelEventArgs e)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (txt != null)
            {

                try
                {
                    DateTime dt=Convert.ToDateTime(txt.Text);
                    
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "�������ʽΪyyyy-MM-dd�����ڣ�");
                    e.Cancel = true;
                    
                }
                
            }
        }

        protected void ValidateNotNull(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "�����룡");
        }

        protected void ValidateNotNull(object sender, CancelEventArgs e, string text)
        {
            TextBox txt=sender as TextBox;
            if (txt != null)
            {
                if (txt.Text.Trim().Length == 0)
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }
        protected void ValidateNumber(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateNumber(sender, e, "���������֣�", allowBlank);
        }

        protected void ValidateNumber(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateNumber(txt.Text.Trim(),allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateInteger(object sender, CancelEventArgs e, bool allowBlank, int min)
        {
            ValidateInteger(sender, e, allowBlank, min, "��Ч���֣�");
        }

        protected void ValidateInteger(object sender, CancelEventArgs e,  bool allowBlank,int min,string text)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateNumber(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    if (!allowBlank)
                    {
                        int tmp = Convert.ToInt32(txt.Text.Trim());
                        if (tmp <= min)
                        {
                            this.errorProvider1.SetError(txt, "���������" + min + "������!");
                            e.Cancel = true;
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt, string.Empty);
                            e.Cancel = false;
                        }
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
            }
        }

        protected void ValidatePhone(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePhone(sender, e, "�������ʽ��ȷ�Ĺ̶��绰���룡", allowBlank);
        }

        protected void ValidatePhone(object sender, CancelEventArgs e, string text,bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePhone(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidatePhoneOrMobile(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePhoneOrMobile(sender, e, "�������ʽ��ȷ�Ĺ̶��绰���ֻ����룡", allowBlank);
        }

        protected void ValidatePhoneOrMobile(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePhoneOrMobile(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateMobile(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateMobile(sender, e,"�������ʽ��ȷ���ֻ����룡" ,allowBlank);
        }

        protected void ValidateMobile(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateMobile(txt.Text.Trim(),allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
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
        #endregion

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
        /// <summary>
        /// �ڸ���֮ǰ������֤
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeUpdate()
        {
            return true;
        }

        /// <summary>
        /// ���´���֮ǰ������֤
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeCreate()
        {
            return true;
        }
        
        

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool result= this.ValidateChildren(ValidationConstraints.Enabled);
            
            //MessageBoxHelper.Show("validate result is:"+result);
            if (result)
            {
                this.ClearValidateError();
                this.Save();
            }
            else
            {
                MessageBoxHelper.Show("�����������飡");
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
                if (this.CheckBeforeCreate())
                {

                    this.BeforeCreateEntity(entity);
                    if (SimpleOrmOperator.Create(entity))
                    {

                        this.AfterSuccessCreate();
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
                    //MessageBoxHelper.Show("���ʧ�ܣ�");
                    return false;
                }
            }
            else
            {
                if (this.CheckBeforeUpdate())
                {
                    this.BeforeUpdateEntity(entity);
                    if (SimpleOrmOperator.Update(entity))
                    {
                        this.AfterSuccessUpdate();
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
                else
                {
                    return false;
                }
            }
            return true;
        }

        protected virtual void AfterSuccessUpdate()
        {

        }
        protected virtual void AfterSuccessCreate()
        {

        }

        protected virtual AbstractPrinterContent GetPrinterContent()
        {
            
            return null;
            //throw new Exception("");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.entity == null)
            {
                MessageBoxHelper.Show("�޷���ӡδ��������ݣ�");
                return;
            }
            AbstractPrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Print();
            }
            else
            {
                MessageBoxHelper.Show("�Բ��𣬻�û��ʵ�ִ�ӡ�ö���");
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