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
using FT.Device.IDCard;

namespace DS.Plugins.Car
{
    public partial class CoachBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CoachBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }

        #region �������ʵ�ֵ�
        public CoachBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public CoachBrowser(object entity, IRefreshParent refresher)
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
                FT.Windows.CommonsPlugin.DictManager.BindCarType(this.cbCarType);
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new Coach();
            //   return null;
        }
        #endregion

        private void txtCoachId_Validating(object sender, CancelEventArgs e)
        {
            if (txtCoachId.Text.Trim().Length == 0)
            {
                this.SetError(sender, "����֤�Ų���Ϊ�գ�");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }

        }

        private void txtDriverId_Validating(object sender, CancelEventArgs e)
        {

            if (txtDriverId.Text.Trim().Length == 0)
            {
                this.SetError(sender, "��ʻ֤��Ų���Ϊ�գ�");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }
        }

        private void CoachBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                IDCardConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<IDCardConfig>();
                if(config.UseIDCard)
                    reader = new IDCardReaderHelper(new De_ReadICCardComplete(AfterReadIdCard));
            }
        }
        private IDCardReaderHelper reader = null;
        private void AfterReadIdCard(IDCard card)
        {
            this.personDetail1.SetIDCard(card);
        }
    }
}

