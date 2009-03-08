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
    public partial class ProvinceBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public ProvinceBrowser()
        {
            InitializeComponent();
        }
        #region 子类必须实现的
        public ProvinceBrowser(object entity):base(entity)
        {
            InitializeComponent();
            
           
        }
        public ProvinceBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            
        }

       

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new Province();
            //   return null;
        }
        #endregion

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "省份名称不得为空！");
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "省份代码不得为空！");
        }
    }
}

