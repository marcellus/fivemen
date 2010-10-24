using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DbManager;

namespace PDA
{
    public partial class JieTuoDetail : Form
    {
        public JieTuoDetail()
        {
            InitializeComponent();
        }

        public JieTuoDetail(DataSet ds)
        {
            InitializeComponent();
        }          

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!cb_AllTary.Checked)
                {
                    this.txt_SN.Focus();
                    this.txt_TrayNo.Enabled = false;
                }
                else
                {
                    //TODO:整盘解托
                }
            }
        }

        private void btn_ClearTray_Click(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Enabled = true;
            this.txt_TrayNo.Focus();
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.cb_Rollback.Checked)
                {
                    this.SaveData();
                    this.RebindData();
                }
                else
                {
                    this.RemoveData();
                    this.RebindData();
                }
                ClearInput();
            }
            
            //TODO:解托
        }
        private void ClearInput()
        {
            txt_SN.Text = string.Empty;
        }

        private void cb_AllTary_CheckStateChanged(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Enabled = true;
            this.txt_TrayNo.Focus();
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (!cb_AllTary.Checked)
            {
                txt_SN.Focus();
            }
            else
            {
                txt_TrayNo.Focus();
            }
        }
        private void RebindData()
        {
            this.dg_ScanList.DataSource = JieTuoManager.GetUserData(Program.UserID);
        }

        private JieTuo ComputeData()
        {

            JieTuo entity = new JieTuo();
            entity.IsWhole = this.cb_AllTary.Checked ? 1 : 0;
            entity.Sn = this.txt_SN.Text.Trim();
            entity.Tph = this.txt_TrayNo.Text.Trim();
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }

        private void RemoveData()
        {

            JieTuoManager.Delete(this.ComputeData());
        }

        private void SaveData()
        {
            JieTuo entity = this.ComputeData();
            if (JieTuoManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                JieTuoManager.Save(entity);
            }

        }

    }
}