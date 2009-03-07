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
using FT.Windows.CommonsPlugin.Entity;

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
                BindingHelper.BindOwner(this.cbOwnerIdValue);
                DictManager.BindCarType(this.cbCarType);
                DictManager.BindCarPinPai(this.cbPinPai);
                DictManager.BindCarState(this.cbState);
                DictManager.BindCarColorDynamic(this.cbFirstColor);
                DictManager.BindCarColorDynamic(this.cbSecondColor);

                DictManager.BindCarColorDynamic(this.cbThirdColor);
            }
            
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbId.Text.Trim().Length > 0 && this.lbId.Text.Trim() != "0")
            {
                if (this.tabControl1.SelectedIndex == 1)
                {
                    this.ViewFees();
                }
                else if (this.tabControl1.SelectedIndex == 2)
                {
                    this.ViewOut();
                }
            }
        }

        private void ViewOut()
        {
            TabPage tb = this.tabControl1.TabPages[2];
            if (tb.Controls.Count == 0)
            {
                CarOutSearch outs = new CarOutSearch();
                outs.AllowCustomeSearch = false;
                outs.Dock = DockStyle.Fill;
                outs.InitBeforeAdd += new ProcessObjectDelegate(outs_InitBeforeAdd);
                tb.Controls.Add(outs);
                outs.ClearColumns();
                outs.CreateColumn("�������", 80);
                outs.CreateColumn("����ʱ��", 140);
                outs.CreateColumn("����ԭ��");
                // this.Width += 30;
                outs.SetConditions("c_hmhp='" + this.txtHmhp.Text.Trim() + "'");
            }
        }

        void outs_InitBeforeAdd(ref object entity)
        {
            CarOut tmp = new CarOut();
            tmp.Hmhp = this.txtHmhp.Text.Trim();
            entity = tmp;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void ViewFees()
        {
           
            
            TabPage tb = this.tabControl1.TabPages[1];
            if (tb.Controls.Count == 0)
            {
                CarFeeSearch fees = new CarFeeSearch();
                fees.AllowCustomeSearch = false;
                fees.Dock = DockStyle.Fill;
                fees.InitBeforeAdd += new ProcessObjectDelegate(fees_InitBeforeAdd);
                tb.Controls.Add(fees);
                fees.ClearColumns();
                fees.CreateColumn("�������", 80);
                fees.CreateColumn("����ʱ��", 140);
                fees.CreateColumn("���ý��", 80);
                fees.CreateColumn("�������", 100);
                    // this.Width += 30;
                fees.SetConditions("c_hmhp='" + this.txtHmhp.Text.Trim() + "'");
            }
            
        }

        void fees_InitBeforeAdd(ref object entity)
        {
            CarFee tmp = new CarFee();
            tmp.Hmhp = this.txtHmhp.Text.Trim();
            entity = tmp;
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}

