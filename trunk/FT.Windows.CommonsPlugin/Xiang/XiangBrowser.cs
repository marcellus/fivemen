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
    public partial class XiangBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public XiangBrowser()
        {
            InitializeComponent();
             this.InitComBox();
        }
        #region 子类必须实现的
        public XiangBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public XiangBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                
                this.cbValid.SelectedIndex = 0;
                FT.Windows.CommonsPlugin.DictManager.BindBelongArea(this.cbBlongArea);
            }
            
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new Xiang();
            //   return null;
        }
        #endregion

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "乡镇代码不得为空！");
        }

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "乡镇名称不得为空！");
        }
    }
}

