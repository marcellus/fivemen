using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.ExternalTool
{
    public partial class PostCodeSearchForm : Form
    {
        public PostCodeSearchForm()
        {
            InitializeComponent();
        }

        private void txtPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string sql = "select province,city,area,street,postcode,areacode from table_postcode_list"
                   + " where 1=1 ";
                string postcode = this.txtPostCode.Text.Trim();
                string area = this.txtArea.Text.Trim();
                string areacode = this.txtAreaCode.Text.Trim();
                if(postcode.Length>0)
                {
                    sql += " and postcode='"+postcode+"'";
                }
                if (areacode.Length > 0)
                {
                    sql += " and areacode='" + areacode + "'";
                }
                if (area.Length > 0)
                {
                    sql += " and (province like '%"+area+"%' or city like '%"+area+"%' or area like '%"+area+"%' or street like '"+area+"')";

                }
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if(dt!=null&&dt.Rows.Count>0)
                {
                    DataRow dr=dt.Rows[0];
                    this.lbAreaCode.Text = dr[5].ToString();
                    this.lbPostCode.Text = dr[4].ToString();
                    this.lbDetail2.Text = dr[0].ToString()
                        + dr[1].ToString()
                        + dr[2].ToString()
                        + dr[3].ToString();
                    if(dt.Rows.Count>1)
                    {
                        this.lbSearchCount.Text = "查询结果共"+dt.Rows.Count+"条，请输入更精确的关键字进行查询！";
                    }
                    else
                    {
                        this.lbSearchCount.Text = string.Empty;
                    }
                }
                
            }
        }
    }
}