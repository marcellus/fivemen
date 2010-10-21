using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLotScan : Form
    {
        public MoveLotScan()
        {
            InitializeComponent();
            this.txt_MoveLotBill.Focus();
        }

        public MoveLotScan(DataSet ds)
        {
            InitializeComponent();
            init(ds);
        }

        public void init(DataSet ds)
        {
            this.dg_MoveLot.DataSource = ds.Tables["MoveLotBill"];
            MoveLot.DataSource = ds;
            this.txt_MoveLotBill.Text = string.Empty;
            this.txt_MoveLotBill.Enabled = false;
            this.txt_OldLot.Text = string.Empty;
            this.txt_OldLot.Enabled = false;
        }

        private void txt_MoveLotBill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_OldLot.Focus();
            }
        }

        private void txt_OldLot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataSet ds = new DB().GetMoveLotData(this.txt_MoveLotBill.Text.ToUpper().Trim(), this.txt_OldLot.Text.ToUpper().Trim());
                if (ds == null)
                {
                    MessageBox.Show("获取数据失败，请检查网络！");
                }
                else
                {
                    if (ds.Tables["MoveLotBill"].Rows.Count == 0)
                    {
                        MessageBox.Show("移储单不存在或者此移储单已经处理完毕！");
                        this.txt_MoveLotBill.Text = string.Empty;
                        this.txt_MoveLotBill.Focus();
                        return;
                    }
                    else if (ds.Tables["MoveLotDisk"].Rows.Count == 0)
                    {
                        MessageBox.Show("当前批次已处理完毕！");
                        this.txt_MoveLotBill.Text = string.Empty;
                        this.txt_MoveLotBill.Focus();
                        return;
                    }
                    else
                    {
                        dg_MoveLot.DataSource = ds.Tables["MoveLotBill"];
                        MoveLot.DataSource = ds;
                    }
                }               
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MoveLotDetail mld = new MoveLotDetail(MoveLot.DataSource);
            mld.Show();
            mld.Closed += new EventHandler(mld_Closed);
            this.Hide();
        }

        void mld_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}