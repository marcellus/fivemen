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
    public partial class CunBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public CunBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public CunBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public CunBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                this.cbValid.SelectedIndex = 0;
                FT.Windows.CommonsPlugin.DictManager.BindBelongArea(this.cbBlongArea);
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new Cun();
            //   return null;
        }
        #endregion

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "���벻��Ϊ�գ�");
        }

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "���Ʋ���Ϊ�գ�");
        }

        private void cbBlongArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList(typeof(Xiang), " where c_blongarea='"+this.cbBlongArea.Text+"'");
            if (lists.Count > 0)
            {
                //this.cbgroup
                this.cbXiang.DataSource = lists;
                this.cbXiang.DisplayMember = "�����ı�";
                this.cbXiang.ValueMember = "���ݴ���";
                this.cbXiang.SelectedIndex = 0;
            }
        }

        private void CunBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (this.entity != null)
                {
                    object obj = FormHelper.GetObjectValue(this.entity, "Xiang");
                    if (obj != null)
                    {
                        this.cbXiang.SelectedValue = obj.ToString();
                    }
                }

                //FormHelper.set
            }
        }
    }
}

