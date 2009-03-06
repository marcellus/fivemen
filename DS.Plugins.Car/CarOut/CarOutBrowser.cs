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

        #region 子类必须实现的
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
                    this.cbHmhp.DisplayMember = "号码号牌";
                    this.cbHmhp.ValueMember = "号码号牌";
                }
            }
            this.cbHmhp.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new CarOut();
            //   return null;
        }
        #endregion
    }
}

