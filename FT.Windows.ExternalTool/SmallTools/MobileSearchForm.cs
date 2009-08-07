using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool
{
    public partial class MobileSearchForm : Form
    {
        public MobileSearchForm()
        {
            InitializeComponent();
        }

        private void txtMobileNum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string key = this.txtMobileNum.Text.Trim();
                if (key.Length < 7)
                {
                    MessageBoxHelper.Show("�������������ֻ�����ǰ7λ�ĺ��룡");
                    return;
                }
                key = key.Substring(0, 7);
                string sql = "select city,cardtype from  table_mobile_list where num='" + key + "'";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if (dt != null && dt.Rows.Count == 1)
                {
                    this.lbArea.Text = dt.Rows[0][0].ToString();
                    this.lbCardType.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    this.lbArea.Text = "�Բ���û���ҵ������룡";
                    this.lbCardType.Text = string.Empty;

                }
            }
            
        }
    }
}