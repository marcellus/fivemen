using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class StockCondition : Form
    {
        public StockCondition()
        {
            //DB db=new DB();
            InitializeComponent();
            //DataSet ds = db.GetCompany();
            //db.BindComboBoxDatasource(this.cb_Company,ds.Tables[0],"COMPANY","COMPANY");
            //this.dateTimePicker1.Value = DateTime.Now;
            this.txt_ASN.Focus();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.txt_ASN.Text.Trim() == string.Empty && this.txt_Disk.Text.Trim() == string.Empty && this.txt_SKU.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请至少输入一个查询条件！");
            }
            else
            {
                DataSet ds = new DataSet();
                ds = new DB().GetDiskList(this.txt_Disk.Text.ToUpper().Trim(), this.txt_SKU.Text.ToUpper().Trim(), System.DateTime.Now, this.txt_ASN.Text.ToUpper().Trim());
                DiskList dl = new DiskList(ds);
                dl.Show();
                dl.Closed += new EventHandler(dl_Closed);
                this.Hide();
            }
        }

        void dl_Closed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}