using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.CommonsPlugin
{
    public partial class AreaSearchForm : Form
    {
        public AreaSearchForm()
        {
            InitializeComponent();
        }

        private void txtSearchArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string area=this.txtSearchArea.Text.Trim();
                string sql="select province as 省份,City as 市,area as 县市 from (select d.c_text as province,c.city,c.area from (select a.c_text as area,b.c_text as city,a.c_province_code from table_area a left join table_city b on a.c_father_code=b.c_code)  c left join table_province"
+ " d on c.c_province_code=d.c_code) where province like '%" + area + "%' or city like  '%" + area + "%' or area  like  '%" + area + "%'";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
                this.dataGridView1.DataSource = dt;
            }
        }
    }
}