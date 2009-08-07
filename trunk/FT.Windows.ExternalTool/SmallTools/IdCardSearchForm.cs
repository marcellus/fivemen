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
                    MessageBoxHelper.Show("必须输入至少身份证前6位的号码！");
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
                    this.lbArea.Text = "对不起，没有找到该身份证的归属地！";

                }
            }
        }

        private void btn15To18_Click(object sender, EventArgs e)
        {
            string key = this.txtIdCard.Text.Trim();
            if(key.Length!=15)
            {

                MessageBoxHelper.Show("必须是15位的身份证才可以升级，请检查！");
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
                 MessageBoxHelper.Show("必须是18位的身份证，请检查！");
                 return;
             }
             else
             {
                 string result = IDCardHelper.Validate(key);
                 if(result==string.Empty)
                 {
                     MessageBoxHelper.Show("正确的身份证号码！");
                     return;
                 }
                 else{
                     MessageBoxHelper.Show("错误，"+result+"！");
                     return;
                 }
             }
        }
        //table_idcard_list
    }
}