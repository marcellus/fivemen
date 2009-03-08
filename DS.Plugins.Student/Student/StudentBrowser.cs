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
using FT.Windows.CommonsPlugin;

namespace DS.Plugins.Student
{
    public partial class StudentBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public StudentBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public StudentBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public StudentBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                this.txtDescription.KeyDown -= FormHelper.EnterToTab;
                this.txtDescription.KeyDown+=new KeyEventHandler(txtDescription_KeyDown);
                this.cbSex.SelectedIndex = 0;
                this.cbListen.SelectedIndex = 0;
                this.cbMainBody.SelectedIndex = 0;
                this.cbTopBody.SelectedIndex = 0;
                this.cbLeftDownBody.SelectedIndex = 0;
                this.cbRightDownBody.SelectedIndex = 0;
                this.cbColor.SelectedIndex = 0;
                this.cbLearnType.SelectedIndex = 0;
                DictManager.BindBelongArea(this.cbBelongArea);
                DictManager.BindIdCardType(this.cbIdCardType);
                DictManager.BindNation(this.cbNation);
                DictManager.BindCarTypeDynamic(this.cbNewCarType);
                DictManager.BindCarTypeDynamic(this.cbOldCarType);
                this.cbOldCarType.DropDownStyle = ComboBoxStyle.DropDown;
                DictManager.BindCarStyle(this.cbNewCarStyle);
                DictManager.BindFromRoute(this.cbFromRoute);
                DictManager.BindHospital(this.cbHospital);
                DS.Plugins.Car.BindingHelper.BindCoach(this.cbCoachName);
                DictManager.BindRecommend(this.cbRecommend);
                DictManager.BindComeFrom(this.cbComeFrom);
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                //if (lists.Count > 0)
                //{
                //    //this.cbGroup
                //    this.cbHmhp.DataSource = lists;
                //    this.cbHmhp.DisplayMember = "号码号牌";
                //    this.cbHmhp.ValueMember = "号码号牌";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                //FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbCarType, "准驾车型");
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new StudentInfo();
            //   return null;
        }
        #endregion

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "姓名不得为空！");
        }

        private void txtTempId_Validating(object sender, CancelEventArgs e)
        {
            //this.ValidateNotNull(sender, e, "暂住证不得为空！");
        }

        private void txtIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbIdCardType.SelectedIndex == 0)
            {
                this.ValidateIdCard(sender, e, false);
            }
        }

        private void txtPostCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidatePostCode(sender, e, "请输入正确的邮政编码！", false);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "联系电话1不得为空！");
        }

        private void txtRegAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "住址地址不得为空！");
        }

        private void txtConnAddress_Validating(object sender, CancelEventArgs e)
        {
                this.ValidateNotNull(sender, e, "联系地址不得为空！");
        }

        /// <summary>
        /// 计算条码数据
        /// </summary>
        /// <returns></returns>
        private string ComputeDimension()
        {
            string result = string.Empty;
            return result;
        }

        protected override void BeforeSave(object entity)
        {
            string dimension = this.ComputeDimension();
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "Dimension", dimension);
            base.BeforeSave(entity);
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "CoachId", this.cbCoachName.SelectedValue.ToString());
        }

        protected override void BeforeCreateEntity(object entity)
        {
            base.BeforeCreateEntity(entity);
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "BaoMingDate", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void txtHeight_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "身高必须是数字！", true);
        }

        private void txtLeftEye_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "视力必须是数字！", true);
        }

        private void txtRightEye_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "视力必须是数字！", true);
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 1;
               // e.
                this.txtHeight.Focus();
            }
        }
    }
}

