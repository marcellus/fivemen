using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms.SimpleLog
{
    public partial class CustomLogSearch : FT.Windows.Forms.DataSearchControl
    {
        public CustomLogSearch()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.EntityType = typeof(CustomLog);
           // this.DetailFormType = typeof(CustomLogBrowser);
        }
        #region ×ÓÀà±ØÐë¼Ì³Ð
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(CustomLog);
            this.pager.OrderField = "id";

        }

        protected override void ShowDetail(int index)
        {
            //base.ShowDetail(index);
        }
        #endregion
    }
}

