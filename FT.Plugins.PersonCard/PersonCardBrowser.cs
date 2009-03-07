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

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public PersonCardBrowser()
        {
            InitializeComponent();
            this.InitComBox();
            //this.InitHabit();
            //MessageBoxHelper.Show("����Ĺ��캯����");
        }

        protected override void BeforeSave(object entity)
        {
            base.BeforeSave(entity);
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "GroupId", this.cbGroup.SelectedValue.ToString());
        }

        #region �������ʵ�ֵ�
        public PersonCardBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
            //MessageBoxHelper.Show("����Ĺ��캯����");
            //this.LoadData(entity);
        }
        public PersonCardBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
            //MessageBoxHelper.Show("����Ĺ��캯����");
            //this.LoadData(entity);
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists=FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Group));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbGroup.DataSource = lists;
                    this.cbGroup.DisplayMember = "��������";
                    this.cbGroup.ValueMember = "���";
                }
            }
            this.cbSex.SelectedIndex = 0;
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
        #endregion

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
            if (!ValidatorHelper.ValidatePhone(this.txtPhone.Text,true))
            {
                this.SetError(sender, "�绰�����ʽ����,��ʽ��12345678��010-12345678��");
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
            if (!ValidatorHelper.ValidateMobile(this.txtMobile.Text, true))
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
            if (!ValidatorHelper.ValidateUrl(this.txtUrl.Text, true))
            {
                this.SetError(sender, "URL��ʽ���󣬱�����http://����ftp��https��ͷ��");
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
            if (!ValidatorHelper.ValidateEmail(this.txtEmail.Text, true))
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

        private void PersonCardBrowser_Load(object sender, EventArgs e)
        {
            //MessageBoxHelper.Show("�����Load��");
            
        }

       
    }
}

