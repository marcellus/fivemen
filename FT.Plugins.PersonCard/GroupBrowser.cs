using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;

namespace FT.Plugins.PersonCard
{
    public partial class GroupBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public GroupBrowser()
        {
            InitializeComponent();
            

            //this.InitHabit();
        }
        public GroupBrowser(object entity)
            : base(entity)
        {
            InitializeComponent();
        }
        public GroupBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            //MessageBoxHelper.Show("����Ĺ��캯����");
            //this.LoadData(entity);
        }


        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new Group();
            //   return null;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                this.SetError(sender, "��������Ϊ�գ�");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }
        }

    }
}

