using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public PersonCardBrowser()
        {
            InitializeComponent();
        }

        public PersonCardBrowser(object entity):this()
        {
            this.LoadData(entity);
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new Card();
            //   return null;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtName.Text.Trim().Length == 0)
            {
                this.SetError(sender, "��������������");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatorHelper.ValidatePhone(this.txtPhone.Text,true))
            {
                this.SetError(sender, "�绰�����ʽ���󣬱���Ϊ����-���룡");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatorHelper.ValidateMobile(this.txtPhone.Text, true))
            {
                this.SetError(sender, "�ֻ������ʽ����");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtUrl_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatorHelper.ValidateUrl(this.txtPhone.Text, true))
            {
                this.SetError(sender, "URL��ʽ���󣬱�����HTTP://��");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatorHelper.ValidateEmail(this.txtPhone.Text, true))
            {
                this.SetError(sender, "Email��ʽ���󣬱���Ϊexample@site.com��");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

       
    }
}

