using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DataInit;
using PDA.DbManager;


namespace PDA
{
    public partial class ZuTuoDetail : Form
    {
        public ZuTuoDetail()
        {
            InitializeComponent();            
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SN.Focus();
                this.txt_TrayNo.Enabled = false;
            }
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_XiaXiangJi.Enabled)
                {
                    txt_XiaXiangJi.Focus();
                }
                else
                {
                    //TODO:逻辑处理
                    this.SaveData();
                    this.RebindData();
                    ClearInput();
                    
                }
            }
        }
        
        private void btn_ClearTray_Click(object sender, EventArgs e)
        {
            txt_TrayNo.Text = string.Empty;
            txt_TrayNo.Enabled = true;
            txt_TrayNo.Focus();
        }
        private void ClearInput()
        {
            txt_SN.Text = string.Empty;
            txt_XiaXiangJi.Text = string.Empty;
        }

        private void cb_XiaXiangJi_CheckStateChanged_1(object sender, EventArgs e)
        {
            txt_XiaXiangJi.Enabled = cb_XiaXiangJi.Checked;
        }

        private void txt_XiaXiangJi_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                txt_SN.Focus();
            }
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_SN.Focus();
        }

        private void ZuTuoDetail_Load(object sender, EventArgs e)
        {
            this.RebindData();
        }

        private void RebindData()
        {
            this.dg_ScanList.DataSource = ZuTuoManager.GetUserData(Program.UserID);
        }

        private void SaveData()
        {
            ZuTuo zutuo = new ZuTuo();
            zutuo.Tph = this.txt_TrayNo.Text.Trim();
            zutuo.Xxjh = this.txt_XiaXiangJi.Text.Trim();
            zutuo.Sn = this.txt_SN.Text.Trim();
            ZuTuoManager.Save(zutuo);

        }
    }
}