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

        #region 子类必须实现的
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
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
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
                this.SetError(sender, "电话号码格式错误,格式是12345678或010-12345678！");
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
                this.SetError(sender, "手机号码格式错误！");
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
                this.SetError(sender, "姓名不得为空！");
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
                    coaches.CreateColumn("姓名", 80);
                    coaches.CreateColumn("身份证号",120);
                    coaches.CreateColumn("准教车型", 80);
                    coaches.CreateColumn("号码号牌", 80);
                    coaches.CreateColumn("教练证号", 80);
                    coaches.CreateColumn("驾驶证编号");
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
                    cars.CreateColumn("号码号牌", 80);
                    cars.CreateColumn("车辆类型", 80);
                    cars.CreateColumn("车辆品牌", 80);
                    cars.CreateColumn("车辆状态",80);
                    cars.CreateColumn("是否教练车");
                    cars.CreateColumn("是否考试车");
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

