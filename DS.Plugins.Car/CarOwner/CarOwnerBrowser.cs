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
    public partial class CarOwnerBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CarOwnerBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }

        #region �������ʵ�ֵ�
        public CarOwnerBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public CarOwnerBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                this.cbSex.SelectedIndex = 0;
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new CarOwner();
            //   return null;
        }
        #endregion

        

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatorHelper.ValidatePhone(this.txtPhone.Text, true))
            {
                this.SetError(sender, "�绰�����ʽ����,��ʽ��12345678��010-12345678��");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatorHelper.ValidateMobile(this.txtMobile.Text, true))
            {
                this.SetError(sender, "�ֻ������ʽ����");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtIdCard_Validating(object sender, CancelEventArgs e)
        {
            string idcard=this.txtIdCard.Text.Trim();
            if (idcard.Length > 0)
            {
                string str = IDCardHelper.Validate(idcard);
                if (str != string.Empty)
                {
                    this.SetError(sender, str);
                    e.Cancel = true;
                }
                else
                {
                    this.ClearError(sender);
                    e.Cancel = false;
                }
                
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.ViewCars();
            }

            if (this.tabControl1.SelectedIndex == 2)
            {
                this.ViewCoaches();
            }
        }

        private void ViewCoaches()
        {
            if (this.lbId.Text.Trim().Length > 0 && this.lbId.Text.Trim() != "0")
            {
                TabPage tb = this.tabControl1.TabPages[2];
                if (tb.Controls.Count == 0)
                {
                    CoachSearch coaches = new CoachSearch();
                    coaches.AllowCustomeSearch = false;
                    coaches.Dock = DockStyle.Fill;
                    coaches.InitBeforeAdd += new ProcessObjectDelegate(coaches_InitBeforeAdd);
                    tb.Controls.Add(coaches);
                    coaches.ClearColumns();
                    coaches.CreateColumn("����", 80);
                    coaches.CreateColumn("���֤��",120);
                    coaches.CreateColumn("׼�̳���", 80);
                    coaches.CreateColumn("�������", 80);
                    coaches.CreateColumn("����֤��", 80);
                    coaches.CreateColumn("��ʻ֤���");
                    // this.Width += 30;
                    coaches.SetConditions("c_hmhp in (select c_hmhp from table_cars where i_ownerid='" + this.lbId.Text + "')");

                }
            }
        }

        void coaches_InitBeforeAdd(ref object entity)
        {
            //Coach tmp = new Coach();
            //tmp.CoachId
            //entity = tmp;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void ViewCars()
        {
            if (this.lbId.Text.Trim().Length > 0 && this.lbId.Text.Trim() != "0")
            {
                TabPage tb = this.tabControl1.TabPages[1];
                if (tb.Controls.Count == 0)
                {
                    CarSearch cars = new CarSearch();
                    cars.AllowCustomeSearch = false;
                    cars.Dock = DockStyle.Fill;
                    cars.InitBeforeAdd += new ProcessObjectDelegate(cars_InitBeforeAdd);
                    tb.Controls.Add(cars);
                    cars.ClearColumns();
                    cars.CreateColumn("�������", 80);
                    cars.CreateColumn("��������", 80);
                    cars.CreateColumn("����Ʒ��", 80);
                    cars.CreateColumn("����״̬",80);
                    cars.CreateColumn("�Ƿ������");
                    cars.CreateColumn("�Ƿ��Գ�");
                   // this.Width += 30;
                    cars.SetConditions("i_ownerid='" + this.lbId.Text + "'");
                    
                }
            }
        }

        void cars_InitBeforeAdd(ref object entity)
        {
            CarInfo tmp = new CarInfo();
            tmp.OwnerId = this.lbId.Text;
            entity= tmp;
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}

