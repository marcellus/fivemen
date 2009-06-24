using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;

namespace Jxc.Plugin
{
    public partial class BaseDataBrowser : FT.Windows.Forms.DataBrowseForm
    {
       public BaseDataBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public BaseDataBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public BaseDataBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
            }
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new BaseData();
            
        }
        #endregion
    }
}

