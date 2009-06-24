using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jxc.Plugin
{
    public partial class BaseDataSearch : FT.Windows.Forms.DataSearchControl
    {
        public BaseDataSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(BaseData);
            this.DetailFormType = typeof(BaseDataBrowser);
        }
        #region ×ÓÀà±ØÐë¼Ì³Ð
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(BaseData);
            this.pager.OrderField = "id"; 
        }
        #endregion
    }
}

