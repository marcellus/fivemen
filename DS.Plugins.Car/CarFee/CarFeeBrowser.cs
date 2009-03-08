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
    public partial class CarFeeBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarFeeBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public CarFeeBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CarFeeBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                BindingHelper.BindCars(this.cbHmhp);
                FT.Windows.CommonsPlugin.DictManager.BindCarFeeType(this.cbFeeType); 
            }
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new CarFee();
            //   return null;
        }
        #endregion

        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtFee.Text.Trim().Length == 0)
            {
                this.SetError(sender, "����������ý�");
                e.Cancel = true;
            }
            else
            {
                try
                {
                    Convert.ToDouble(this.txtFee.Text.Trim());
                    this.ClearError(sender);
                    e.Cancel = false;

                }
                catch (Exception ex)
                {
                    this.SetError(sender, "���ý����������֣�");
                    e.Cancel = true;
                }
            }
        }
    }
}

