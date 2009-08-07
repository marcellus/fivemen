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
    public partial class IdCardSearchForm : Form
    {
        public IdCardSearchForm()
        {
            InitializeComponent();
        }

        private void txtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string key = this.txtIdCard.Text.Trim();
                if (key.Length < 6)
                {
                    MessageBoxHelper.Show("���������������֤ǰ6λ�ĺ��룡");
                    return;
                }
                key = key.Substring(0, 6);
                string sql = "select dq from  table_idcard_list where bm=" + key ;
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if (dt != null && dt.Rows.Count == 1)
                {
                    this.lbArea.Text = dt.Rows[0][0].ToString();
                    
                }
                else
                {
                    this.lbArea.Text = "�Բ���û���ҵ������֤�Ĺ����أ�";

                }
            }
        }

        private void btn15To18_Click(object sender, EventArgs e)
        {
            string key = this.txtIdCard.Text.Trim();
            if(key.Length!=15)
            {

                MessageBoxHelper.Show("������15λ�����֤�ſ������������飡");
                return;
            }
            else{
                this.txtIdCard.Text = IDCardHelper.IdCard15To18(key);
            }
        }

        private void btnValidator_Click(object sender, EventArgs e)
        {
             string key = this.txtIdCard.Text.Trim();
             if ( key.Length != 18)
             {
                 MessageBoxHelper.Show("������18λ�����֤�����飡");
                 return;
             }
             else
             {
                 string result = IDCardHelper.Validate(key);
                 if(result==string.Empty)
                 {
                     MessageBoxHelper.Show("��ȷ�����֤���룡");
                     return;
                 }
                 else{
                     MessageBoxHelper.Show("����"+result+"��");
                     return;
                 }
             }
        }
        //table_idcard_list
    }
}