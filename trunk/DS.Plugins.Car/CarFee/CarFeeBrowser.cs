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
    public partial class CarFeeBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarFeeBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public CarFeeBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CarFeeBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbHmhp.DataSource = lists;
                    this.cbHmhp.DisplayMember = "号码号牌";
                    this.cbHmhp.ValueMember = "号码号牌";
                }

                FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbFeeType, "车辆费用类型"); 
            }
            this.cbHmhp.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new CarFee();
            //   return null;
        }
        #endregion

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtFee.Text.Trim().Length == 0)
            {
                this.SetError(sender, "必须输入费用金额！");
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
                    this.SetError(sender, "费用金额必须是数字！");
                    e.Cancel = true;
                }
            }
        }
    }
}

