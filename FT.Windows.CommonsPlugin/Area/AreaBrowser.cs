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

namespace FT.Windows.CommonsPlugin
{
    public partial class AreaBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public AreaBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public AreaBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public AreaBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
                if (lists.Count > 0)
                {
                    //this.cbgroup
                    this.cbProvinceCodeValue.DataSource = lists;
                    this.cbProvinceCodeValue.DisplayMember = "省份名称";
                    this.cbProvinceCodeValue.ValueMember = "省份代码";
                    this.cbProvinceCodeValue.SelectedIndex = 0;
                }
                this.cbFatherCodeValue.DisplayMember = "市名称";
                this.cbFatherCodeValue.ValueMember = "市代码";
                City city=new City();
                //city.FatherCode="-1";
                city.Code="-1";
                city.Text="--请选择--";
                this.cbFatherCodeValue.Items.Add(city);
                this.cbFatherCodeValue.SelectedIndex = 0;

                //ArrayList lists2 = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(City));
                //if (lists2.Count > 0)
                //{
                //    //this.cbgroup
                //    this.cbFatherCodeValue.DataSource = lists2;
                //    this.cbFatherCodeValue.DisplayMember = "市名称";
                //    this.cbFatherCodeValue.ValueMember = "市代码";
                //    
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
            return new Area();
            //   return null;
        }
        #endregion

        private void cbProvinceCodeValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList(typeof(City), " where c_father_code='"+this.cbProvinceCodeValue.SelectedValue.ToString()+"'");
            if (lists.Count > 0)
            {
                //this.cbgroup
                this.cbFatherCodeValue.DataSource = lists;

                this.cbFatherCodeValue.SelectedIndex = 0;
            }
        }

        private void AreaBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (this.entity != null)
                {
                    object obj = FormHelper.GetObjectValue(this.entity, "FatherCode");
                    if (obj != null)
                    {
                        this.cbFatherCodeValue.SelectedValue = obj.ToString();
                    }
                }

                //FormHelper.set
            }
        }

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
                this.ValidateNotNull(sender, e, "县区名称不得为空！");
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "县区代码不得为空！");
        }
    }
}

