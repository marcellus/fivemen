using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool
{
    public partial class IpSearchForm : Form
    {
        public IpSearchForm()
        {
            InitializeComponent();
        }

        private void txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string key = this.txtIp.Text.Trim();
                string r = @"\b(25[0-5]   
  |2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]   
  |2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]   
  |2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]   
  |2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
                Regex rCode = new Regex(r);

                if (!rCode.IsMatch(key))
                {
                    try
                    {
                        IPHostEntry hostInfo = Dns.GetHostByName(key);
                        IPAddress ip = hostInfo.AddressList[0];
                        key = ip.ToString();
                    }
                    catch (System.Exception exe)
                    {
                        MessageBoxHelper.Show("解析域名失败，请检查网络和输入！");
                        return;
                    }
                   
                }
                string[] keys=key.Split('.');
                double first = Convert.ToDouble(keys[0].ToString());
                double second = Convert.ToDouble(keys[1].ToString());
                double three = Convert.ToDouble(keys[2].ToString());
                double four = Convert.ToDouble(keys[3].ToString());
                double all = first * 16777216 + second * 65536 + three * 255
                + four - 1;
                string sql = "select country,city from  table_ips_list where " + all + "  between ip1 and ip2";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if (dt != null && dt.Rows.Count == 1)
                {
                    this.lbCountry.Text = dt.Rows[0][0].ToString();
                    this.lbCity.Text = dt.Rows[0][1].ToString();
                    this.lbIp.Text = key;
                }
                else
                {
                    this.lbCountry.Text = "对不起，没有找到本IP的归属地！";
                    this.lbCity.Text = string.Empty;
                    this.lbIp.Text = key;

                }
                
                
            }
        }

       

        //ip=CLng(str1)*16777216+CLng(str2)*65536+CLng(str3)*256+CLng(str4)-1
    }
}