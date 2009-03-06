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
    public partial class CarOutBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarOutBrowser()
        {
            InitializeComponent();
        this.InitComBox();
        }

        #region �������ʵ�ֵ�
        public CarOutBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CarOutBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbHmhp.DataSource = lists;
                    this.cbHmhp.DisplayMember = "�������";
                    this.cbHmhp.ValueMember = "�������";
                }
            }
            this.cbHmhp.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new CarOut();
            //   return null;
        }
        #endregion
    }
}

