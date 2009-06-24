using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jxc.Plugin
{
    public partial class InRecordSearch : FT.Windows.Forms.DataSearchControl
    {
        public InRecordSearch()
        {
            InitializeComponent();
            this.EntityType = typeof(InRecord);
            this.DetailFormType = typeof(InRecordBrowser);
        }
        #region �������̳�
        protected override void InitPager()
        {
            base.InitPager();
            this.pager.EntityType = typeof(InRecord);
            this.pager.OrderField = "id"; 
        }

        protected override void AfterSuccessDelete(object entity)
        {
            if(entity!=null)
            {
                InRecord record = entity as InRecord;
                string sql = "update table_jxc_basedata set i_store_num=i_store_num-" + record.DunShu
                   + " where c_name='" + FT.DAL.DALSecurityTool.TransferInsertField(record.TypeName) + "'";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            }
            
           
        }
        #endregion
    }
}

