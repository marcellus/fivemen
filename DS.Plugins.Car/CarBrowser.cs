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

namespace DS.Plugins.Car
{
    public partial class CarBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }

        #region 子类必须实现的
        public CarBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CarBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarOwner));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbOwnerIdValue.DataSource = lists;
                    this.cbOwnerIdValue.DisplayMember = "姓名";
                    this.cbOwnerIdValue.ValueMember = "编号";
                }
            }
            this.cbOwnerIdValue.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new CarInfo();
            //   return null;
        }
        #endregion

        protected override void BeforeSave(object entity)
        {
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "OwnerName", this.cbOwnerIdValue.Text);
            //base.BeforeSave(entity);
        }

        private void txtHmhp_Validating(object sender, CancelEventArgs e)
        {
            if (txtHmhp.Text.Trim().Length == 0)
            {
                this.SetError(sender, "号码号牌不得为空！");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }
        }
    }
}

