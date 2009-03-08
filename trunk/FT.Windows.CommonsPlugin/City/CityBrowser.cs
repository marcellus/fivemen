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

namespace FT.Windows.CommonsPlugin
{
    public partial class CityBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CityBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public CityBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public CityBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
                if (lists.Count > 0)
                {
                    //this.cbgroup
                    this.cbFatherCodeValue.DataSource = lists;
                    this.cbFatherCodeValue.DisplayMember = "省份名称";
                    this.cbFatherCodeValue.ValueMember = "省份代码";
                    this.cbFatherCodeValue.SelectedIndex = 0;
                }
                //FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbCarType, "准驾车型");
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new City();
            //   return null;
        }
        #endregion

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "市名称不得为空！");
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "市代码不得为空！");
        }
    }
}

