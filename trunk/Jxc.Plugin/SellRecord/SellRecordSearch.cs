using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jxc.Plugin
{
    public partial class SellRecordSearch : FT.Windows.Forms.DataSearchControl
    {
        public SellRecordSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(SellRecord);
            this.DetailFormType = typeof(SellRecordBrowser);
        }
        #region ×ÓÀà±ØÐë¼Ì³Ð
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(SellRecord);
            this.pager.OrderField = "id"; 
        }

        protected override void AfterSuccessDelete(object entity)
        {
            if (entity != null)
            {
                SellRecord record = entity as SellRecord;
                string sql = "update table_jxc_basedata set i_store_num=i_store_num+" + record.DunShu
                   + " where c_name='" + FT.DAL.DALSecurityTool.TransferInsertField(record.TypeName) + "'";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            }


        }

        #endregion
    }
}

