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
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new Card();
            //   return null;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtName.Text.Trim().Length == 0)
            {
                this.SetError(sender, "必须输入姓名！");
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
                this.SetError(sender, "电话号码格式错误，必须为区号-号码！");
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
                this.SetError(sender, "手机号码格式错误！");
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
                this.SetError(sender, "URL格式错误，必须是HTTP://！");
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
                this.SetError(sender, "Email格式错误，必须为example@site.com！");
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

