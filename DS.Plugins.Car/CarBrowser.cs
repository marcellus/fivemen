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

namespace DS.Plugins.Car
{
    public partial class CarBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }

        #region �������ʵ�ֵ�
        public CarBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CarBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarOwner));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbOwnerIdValue.DataSource = lists;
                    this.cbOwnerIdValue.DisplayMember = "����";
                    this.cbOwnerIdValue.ValueMember = "���";
                }
            }
            this.cbOwnerIdValue.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new CarInfo();
            //   return null;
        }
        #endregion

        protected override void BeforeSave(object entity)
        {
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "OwnerName", this.cbOwnerIdValue.Text);
            //base.BeforeSave(entity);
        }

        private void txtHmhp_Validating(object sender, CancelEventArgs e)
        {
            if (txtHmhp.Text.Trim().Length == 0)
            {
                this.SetError(sender, "������Ʋ���Ϊ�գ�");
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

