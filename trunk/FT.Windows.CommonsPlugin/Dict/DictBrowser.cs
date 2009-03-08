using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;
using System.Collections;

namespace FT.Windows.CommonsPlugin
{
    public partial class DictBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public DictBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public DictBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public DictBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(DictType));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbGroupType.DataSource = lists;
                    this.cbGroupType.DisplayMember = "类型名称";
                    this.cbGroupType.ValueMember = "类型名称";
                }
                this.cbGroupType.SelectedIndex = 0;
                this.cbValid.SelectedIndex = 0;
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new Dict();
            //   return null;
        }
        #endregion

        protected override bool Save()
        {
            bool result=base.Save();
            if (result)
            {
                DictManager.RefreshDicts(this.cbGroupType.Text);
            }
            return result;
        }

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            if (txtText.Text.Trim().Length == 0)
            {
                this.SetError(sender, "数据文本不得为空！");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }
        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if (txtValue.Text.Trim().Length == 0)
            {
                this.SetError(sender, "数据值不得为空！");
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

