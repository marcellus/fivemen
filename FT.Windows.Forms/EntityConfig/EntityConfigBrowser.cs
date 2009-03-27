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

namespace FT.Windows.Forms
{
    public partial class EntityConfigBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public EntityConfigBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region 子类必须实现的
        public EntityConfigBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public EntityConfigBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(EntityDefine));
                if (lists.Count > 0)
                {
                    //this.cbGroup
                    this.cbClassCnName.DataSource = lists;
                    this.cbClassCnName.DisplayMember = "实体中文名称";
                    this.cbClassCnName.ValueMember = "关联类全称";
                    this.cbClassCnName.SelectedIndex = 0;
                }
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
            return new EntityColumnDefine();
            //   return null;
        }
        #endregion

        private void cbClassCnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typename = this.cbClassCnName.SelectedValue.ToString() ;
            object obj = FT.Commons.Tools.ReflectHelper.CreateInstance(typename);
            if(obj!=null)
            {
                DataTable dt = FT.DAL.Orm.SimpleOrmCache.GetConditionDT(obj.GetType());
                if (dt != null)
                {
                    this.cbPropertyName.DataSource = dt;
                    this.cbPropertyName.DisplayMember = "text";
                    this.cbPropertyName.ValueMember = "value";
                }
            }
        }

        protected override void BeforeSave(object entity)
        {
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "ClassFullName", this.cbClassCnName.SelectedValue.ToString());
        }
    }
}

