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

namespace CoachCar
{
    public partial class CoachCarBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CoachCarBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
         #region 子类必须实现的
        public CoachCarBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
        }
        public CoachCarBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
            
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
               // DictManager.BindCarType(this.cbCarType);
                DictManager.BindCarTypeDynamic(this.cbCarType);
                if(this.lbId.Text.Length==0)
                {

                    this.lbRegDate.Text = System.DateTime.Now.ToString();
                }
            }
            
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new CoachCarInfo();
            //   return null;
        }
        protected override void ClearAdd()
        {
            this.lbRegDate.Text = System.DateTime.Now.ToString();
            this.txtCarNo.Text = string.Empty;
            this.txtCjh.Text = string.Empty;
            this.txtCoachId.Text = string.Empty;
            this.txtCoachName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtIdCard.Text = string.Empty;
            this.txtKeyWords.Text = string.Empty;
            //base.ClearAdd();
        }
        #endregion

        private string GetKeyWords()
        {
            this.txtKeyWords.Text =
                this.cbCarType.Text + ";" + this.txtIdCard.Text + ";"
            + this.txtCoachId.Text + ";" + this.txtCoachName.Text
             + this.txtCjh.Text + ";" + this.txtDescription.Text
            + this.txtCarNo.Text + ";" + this.txtCompany.Text;
            return this.txtKeyWords.Text.Trim();
        }

        protected override void BeforeSave(object entity)
        {
            //this.GetKeyWords();
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "KeyWords", this.GetKeyWords());
            //base.BeforeSave(entity);
        }

        protected override bool CheckBeforeCreate()
        {
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_coach_cars where c_car_no='"+
                FT.DAL.DALSecurityTool.TransferInsertField(this.txtCarNo.Text.Trim()) + "' and c_coach_name='" +

                FT.DAL.DALSecurityTool.TransferInsertField(this.txtCoachName.Text.Trim()) + "'", "tmp");
            if(dt!=null&&dt.Rows.Count>0)
            {
                MessageBoxHelper.Show("已存在教练车号为：" + this.txtCarNo.Text.Trim() + "\r\n教练名：" + this.txtCoachName.Text.Trim()+"的记录");
                return false;
            }
            return true;
            //return base.CheckBeforeCreate();
        }
    }
}

