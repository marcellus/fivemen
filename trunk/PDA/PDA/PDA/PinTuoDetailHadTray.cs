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
    public partial class PinTuoDetailHadTray : Form
    {
        public PinTuoDetailHadTray(DataSet ds)
        {
            InitializeComponent();
        }

        public PinTuoDetailHadTray()
        {
            InitializeComponent();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.cb_Rollback.Checked)
                {
                    txt_OldTrayNo.Focus();
                }
                else
                {
                    this.RemoveData();
                    this.RebindData();
                    ClearInput();
                    cb_Rollback.Checked = false;
                }
            }
        }

        private void ClearInput()
        {
            txt_TrayNo.Text = string.Empty;
            txt_OldTrayNo.Text = string.Empty;
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_TrayNo.Focus();
        }

        private void txt_XiaXiangJi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                txt_TrayNo.Focus();
            }
        }

        private void txt_OldTrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SaveData();
                this.RebindData();

                ClearInput();
                txt_TrayNo.Focus();
            }
        }

        private void RebindData()
        {
            this.dg_ScanList.DataSource = ZtPinTuoManager.GetUserData(Program.UserID);
        }

        private ZtPinTuo ComputeData()
        {

            ZtPinTuo entity = new ZtPinTuo();

            entity.Tph = this.txt_TrayNo.Text.Trim();
            entity.Ytph = this.txt_OldTrayNo.Text.Trim();

            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }

        private void RemoveData()
        {
            ZtPinTuo entity = this.ComputeData();
            if (!ZtPinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("托盘尚未扫描，不能撤消！");
                return;
            }
            ZtPinTuoManager.Delete(entity);
        }

        private void SaveData()
        {

            ZtPinTuo entity = this.ComputeData();
            if (ZtPinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该托盘！");
            }
            else
            {
                ZtPinTuoManager.Save(entity);
            }


        }

        private void PinTuoDetailHadTray_Load(object sender, EventArgs e)
        {
            this.RebindData();
        }
    }
}