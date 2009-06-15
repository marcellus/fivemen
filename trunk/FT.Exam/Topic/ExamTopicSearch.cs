using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Exam
{
    public partial class ExamTopicSearch : FT.Windows.Forms.DataSearchControl
    {
        public ExamTopicSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(ExamTopic);
            this.DetailFormType=typeof(ExamTopicBrowser);
        }
        #region ×ÓÀà±ØÐë¼Ì³Ð
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(ExamTopic);
            this.pager.OrderField = "id"; 
        }
        #endregion
    }
}

