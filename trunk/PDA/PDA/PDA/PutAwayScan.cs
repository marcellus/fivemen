using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PutAwayScan : Form
    {
        public PutAwayScan()
        {
            InitializeComponent();
            this.txt_PutAwayBill.Focus();
        }

        public PutAwayScan(DataSet ds)
        {
            InitializeComponent();
            init(ds);
        }

        public void init(DataSet ds)
        {
            PutAway.DataSource = ds;
            this.dg_PutAway.DataSource = ds.Tables["PutAwayBill"];
            //this.lbl_PutAway.Text = this.txt_PutAwayBill.Text;
            this.txt_PutAwayBill.Text = string.Empty;
            this.txt_PutAwayBill.Enabled = false;
        }

        private void txt_PutAwayBill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataSet ds = new DB().GetPutAway(this.txt_PutAwayBill.Text.ToUpper().Trim());
                if (ds == null)
                {
                    MessageBox.Show("获取数据失败，请检查网络！");
                }
                else
                {
                    if (ds.Tables["PutAwayBill"].Rows.Count == 0)
                    {
                        MessageBox.Show("上架单不存在或此上架单已完成上架！");
                        this.txt_PutAwayBill.Text = string.Empty;
                        this.txt_PutAwayBill.Focus();
                    }
                    else
                    {
                        PutAway.DataSource = ds;
                        this.dg_PutAway.DataSource = ds.Tables["PutAwayBill"];
                        this.lbl_PutAway.Text = "上架单：" + this.txt_PutAwayBill.Text;
                        this.txt_PutAwayBill.Text = string.Empty;
                        this.txt_PutAwayBill.Focus();
                    }
                }
            }
        }

        void pad_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            PutAwayDetail pad = new PutAwayDetail(PutAway.DataSource);
            pad.Show();
            pad.Closed += new EventHandler(pad_Closed);
            this.Hide();
        }
    }
}