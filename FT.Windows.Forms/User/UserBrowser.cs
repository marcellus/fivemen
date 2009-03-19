using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;

namespace FT.Windows.Forms
{
    public partial class UserBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public UserBrowser()
        {
            InitializeComponent();
            this.cbValid.SelectedIndex = 0;
        }

        #region 子类必须实现的
        public UserBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.cbValid.SelectedIndex = 0;
            
            //MessageBoxHelper.Show("子类的构造函数！");
            //this.LoadData(entity);
        }
        public UserBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.cbValid.SelectedIndex = 0;
            
            //MessageBoxHelper.Show("子类的构造函数！");
            //this.LoadData(entity);
        }
        protected override object GetEntity()
        {
            return new User();
        }

        protected override void BeforeCreateEntity(object entity)
        {

            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "Password", FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt("123456"));
        }
      
        #endregion

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtName.Text.Trim().Length == 0)
            {
                this.SetError(sender, "登录名不能为空！");
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

