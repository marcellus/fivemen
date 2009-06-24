using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;
using FT.Commons.Tools;

namespace Jxc.Plugin
{
    public partial class SellRecordBrowser : FT.Windows.Forms.DataBrowseForm
    {
        private decimal oldNum=0.0M;
        public SellRecordBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public SellRecordBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public SellRecordBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                if (this.entity != null)
                    this.oldNum = ((SellRecord)this.entity).DunShu;
                //this.lbSellDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                JxcHelper.BindTypeName(this.cbTypeName);
            }
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new SellRecord();
            
        }

        protected override void AfterSuccessCreate()
        {
            base.AfterSuccessCreate();
            string sql = "update table_jxc_basedata set i_store_num=i_store_num-"+this.txtDunShu.Text.Trim()
                + " where c_name='"+FT.DAL.DALSecurityTool.TransferInsertField(this.cbTypeName.Text)+"'";
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        }

        protected override void AfterSuccessUpdate()
        {
            base.AfterSuccessUpdate();
            if(this.oldNum>0)
            {
                string sql = "update table_jxc_basedata set i_store_num=i_store_num+"+this.oldNum+"-" + this.txtDunShu.Text.Trim()
               + " where c_name='" + FT.DAL.DALSecurityTool.TransferInsertField(this.cbTypeName.Text) + "'";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            }
           
        }
        #endregion

        private void txtZhiShu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int zhi = Convert.ToInt32(this.txtZhiShu.Text.Trim());
                if(zhi>0)
                {
                    BaseData data = JxcHelper.GetTypeData(this.cbTypeName.Text);
                    if (data != null)
                    {
                        decimal dun = data.Weight * zhi;
                        this.txtDunShu.Text = dun.ToString();
                        decimal price = data.Price * data.Weight * zhi;
                        this.txtPrice.Text = price.ToString();
                    }
                    else
                    {
                        MessageBoxHelper.Show("��Ʒ����û�л������Ϣ��");
                    }

                }
                
            }
            catch (System.Exception ex)
            {
                MessageBoxHelper.Show("֧��������������");
            }
        }

        private void cbTypeName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lbStoreNum.Text = this.cbTypeName.SelectedValue.ToString()+"��";
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
}

