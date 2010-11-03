using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PDA.DataInit;
using PDA.DbManager;

namespace PDA
{
    public partial class CheckDetail : Form
    {
        public CheckDetail()
        {
            InitializeComponent();
            this.txt_Loc.Focus();
        }

        
        private void txt_Product_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_DiskDetail.Text = string.Empty;
                this.tabControl1.SelectedIndex = 0;
                CheckMain cm = new CheckMain();
                CheckDetailRecord cdr = new CheckDetailRecord();
                cm.Kw = this.txt_Loc.Text;
                cm.Pnno = this.txt_Product.Text.Substring(2, 10);
                cm.Sl = 1;
                cm.Status = 1;
                cm.Cpqufen = string.Empty;

                cdr.Sn = txt_Product.Text;
                cdr.Scantime = System.DateTime.Now;
                cdr.Xxjh = string.Empty;
                cdr.Tph = string.Empty;
                cdr.Scaner = Program.UserID;
                cdr.Kw = this.txt_Loc.Text;
                string RollBack = string.Empty;
                if (this.ck_Rollback.Checked)
                {
                    RollBack = "RollBack";
                }
                string msg=cdr.SaveCheckData(cm, cdr, "SN", RollBack);
                if (msg != string.Empty)
                {
                    MessageBox.Show(msg);                   
                }
                else
                {
                    this.txt_DiskDetail.Text += "库位：" + this.txt_Loc.Text + "\r\n";
                    this.txt_DiskDetail.Text += "PN：" + this.txt_Product.Text.Substring(2, 10) + "\r\n";
                    this.txt_DiskDetail.Text += "SN：" + this.txt_Product.Text;
                }
                ClearInput();
                txt_Product.Focus();
                ck_Rollback.Checked = false;
            }
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (!ck_Rollback.Checked)
                {
                    this.txt_Product.Focus();
                    this.txt_Loc.Enabled = false;
                }
                else
                {
                    ClearInput();
                }
            }
        }

        
        private void btn_ClearLoc_Click(object sender, EventArgs e)
        {
            this.txt_Loc.Text = string.Empty;
            this.txt_Loc.Enabled = true;
            this.txt_Loc.Focus();
        }

       
        private void ClearInput()
        {
            txt_Product.Text = string.Empty;
            txt_Tray.Text = string.Empty;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (this.txt_Loc.Enabled)
            {
                txt_Loc.Focus();
            }
            else
            {
                this.txt_Product.Focus();
            }
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string sql = string.Format(@"select sn as SN,tph as 托盘,kuwei as 库位 from pandiandetail where scaner='{0}'", Program.UserID);
                DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
                this.dg_Resume.DataSource = dt;
                new DB().SetDataGridCloumnWidth(dg_Resume);
            }
            if(tabControl1.SelectedIndex==2)
            {
                string sql = string.Format(@"select pnno as 产品 ,sl as 数量 from pandianrecord");
                DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
                this.dg_Summarizing.DataSource = dt;
                new DB().SetDataGridCloumnWidth(dg_Summarizing);
            }
        }

        private void txt_Tray_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_DiskDetail.Text = string.Empty;
                this.tabControl1.SelectedIndex = 0;
                CheckMain cm = new CheckMain();
                CheckDetailRecord cdr = new CheckDetailRecord();
                cm.Kw = this.txt_Loc.Text;
                cm.Pnno = string.Empty;
                cm.Sl = 1;
                cm.Status = 1;
                cm.Cpqufen = string.Empty;

                cdr.Tph = this.txt_Tray.Text;
                cdr.Scantime = System.DateTime.Now;
                cdr.Xxjh = string.Empty;
                cdr.Sn = string.Empty;
                cdr.Scaner = Program.UserID;
                cdr.Kw = this.txt_Loc.Text;
                string RollBack = string.Empty;
                if (this.ck_RollbackTray.Checked)
                {
                    RollBack = "RollBack";
                }
                string msg = cdr.SaveCheckData(cm, cdr, "TP", RollBack);
                if (msg != string.Empty)
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    this.txt_DiskDetail.Text += "库位：" + this.txt_Loc.Text + "\r\n";
                    this.txt_DiskDetail.Text += "托盘：" + this.txt_Tray.Text + "\r\n";
                    this.txt_Loc.Enabled = false;
                    this.txt_Tray.Focus();
                }
                ClearInput();
                ck_RollbackTray.Checked = false;
            }
        }

        private void txt_LocNoTray_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Tray.Focus();
                txt_LocNoTray.Enabled = false;
            }
        }

        private void btn_ClearLocTray_Click(object sender, EventArgs e)
        {
            this.txt_LocNoTray.Text = string.Empty;
            this.txt_LocNoTray.Enabled = true;
            this.txt_LocNoTray.Focus();
        }

        private void ck_RollbackTray_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (txt_Loc.Enabled)
            {
                txt_Loc.Focus();
            }
            else
            {
                txt_Tray.Focus();
            }
        }
    }
}