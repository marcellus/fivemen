using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLocScan : Form
    {
        public MoveLocScan()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MoveLocDetail mld = new MoveLocDetail(lbl_OldLocNo.Text.ToUpper().Trim());
            mld.Closed += new EventHandler(mld_Closed);
            mld.Show();
            this.Hide();
        }

        void mld_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_OldLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataSet ds = new DB().GetMoveLocData(txt_OldLoc.Text.ToUpper().Trim());
                if (ds == null)
                {
                    MessageBox.Show("获取数据失败，请检查网络！");
                    txt_OldLoc.Text = string.Empty;
                    return;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("该库位无物料，请重新扫描！");
                    txt_OldLoc.Text = string.Empty;
                    return;
                }
                MoveLoc.DataSource = ds;
                this.dg_DiskList.DataSource = ds.Tables["DiskList"];
                this.lbl_OldLocNo.Text = txt_OldLoc.Text.ToUpper().Trim();
                txt_OldLoc.Text = string.Empty;
            }
        }
    }
}