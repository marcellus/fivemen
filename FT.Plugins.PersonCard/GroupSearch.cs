using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Plugins.PersonCard
{
    public partial class GroupSearch : FT.Windows.Forms.DataSearchControl
    {
        public GroupSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(Group);
            this.DetailFormType=typeof(GroupBrowser);
        }

        #region �������ʵ�ֵ�
        protected override string GetExportTitle()
        {
            return "��Ƭ��������";
        }
        protected override string GetExportField()
        {
            return "id as ���,c_name as ��������,c_description as ��������";
        }

        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(Group);
            this.pager.OrderField = "id";
        }
        #endregion
    }
}

