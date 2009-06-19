using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Exam
{
    public partial class ExamUserSearch : FT.Windows.Forms.DataSearchControl
    {
        public ExamUserSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(ExamUser);
            this.DetailFormType = typeof(ExamUserBrowser);
        }
        #region ×ÓÀà±ØÐë¼Ì³Ð
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(ExamUser);
            this.pager.OrderField = "id"; 
        }
        #endregion
    }
}

