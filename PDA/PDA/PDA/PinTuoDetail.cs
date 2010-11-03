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
    public partial class PinTuoDetail : Form
    {
        public PinTuoDetail(DataSet ds)
        {
            InitializeComponent();
        }

        public PinTuoDetail()
        {
            InitializeComponent();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SN.Focus();
            }
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.cb_Rollback.Checked)
                {
                    txt_Location.Focus();
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

        private void txt_Location_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SaveData();
                this.RebindData();
                ClearInput();
                txt_TrayNo.Focus();

            }
        }

        private void cb_XiaXiangJi_CheckStateChanged(object sender, EventArgs e)
        {
            txt_XiaXiangJi.Enabled = cb_XiaXiangJi.Checked;
            if (this.txt_XiaXiangJi.Enabled)
            {
                txt_XiaXiangJi.Text = string.Empty;
                txt_XiaXiangJi.Focus();
            }
            else
            {
                txt_XiaXiangJi.Text = string.Empty;

            }
        }
        private void ClearInput()
        {
            txt_TrayNo.Text = string.Empty;
            txt_SN.Text = string.Empty;
            txt_Location.Text = string.Empty;
            txt_XiaXiangJi.Text = string.Empty;
            txt_NewTrayNo.Text = string.Empty;
            txt_OldTrayNo.Text = string.Empty;
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_SN.Focus();
        }

        private void txt_XiaXiangJi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ClearInput();
                txt_TrayNo.Focus();
            }
        }

        private void RebindData()
        {
            this.dg_ScanList.DataSource = PinTuoManager.GetUserData(Program.UserID);
            new DB().SetDataGridCloumnWidth(dg_ScanList);
        }

        private PinTuo ComputeData()
        {

            PinTuo pintuo = new PinTuo();
            pintuo.Sn = this.txt_SN.Text.Trim();
            pintuo.Tph = this.txt_TrayNo.Text.Trim();
            pintuo.Wz = this.txt_Location.Text.Trim();
            pintuo.Xxjh = this.txt_XiaXiangJi.Text.Trim();
            pintuo.Scaner = Program.UserID;
            pintuo.date = System.DateTime.Now;
            return pintuo;
        }
        private void RemoveData()
        {
            PinTuo entity = this.ComputeData();
            if (!PinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("产品尚未扫描，不能撤消！");
                return;
            }
            PinTuoManager.Delete(entity);
            MessageBox.Show("撤消扫描成功！");
        }

        private void SaveData()
        {
            PinTuo entity = this.ComputeData();
            if (PinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                PinTuoManager.Save(entity);
            }


        }

        private void PinTuoDetail_Load(object sender, EventArgs e)
        {
            this.RebindData();
        }

        private void cb_RollbackTray_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_NewTrayNo.Focus();
        }
        private void txt_OldTrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ZtSaveData();
                this.ZtRebindData();

                ClearInput();
                txt_NewTrayNo.Focus();
            }
        }

        private void txt_NewTrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.cb_RollbackTray.Checked)
                {
                    txt_OldTrayNo.Focus();
                }
                else
                {
                    this.ZtRemoveData();
                    this.ZtRebindData();
                    ClearInput();
                    cb_RollbackTray.Checked = false;
                }
            }
        }

        private ZtPinTuo ZtComputeData()
        {

            ZtPinTuo entity = new ZtPinTuo();

            entity.Tph = this.txt_NewTrayNo.Text.Trim();
            entity.Ytph = this.txt_OldTrayNo.Text.Trim();

            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }
        private void ZtRebindData()
        {
            this.dg_ScanList.DataSource = ZtPinTuoManager.GetUserData(Program.UserID);
            new DB().SetDataGridCloumnWidth(dg_ScanList);
        }


        private void ZtRemoveData()
        {
            ZtPinTuo entity = this.ZtComputeData();
            if (!ZtPinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("托盘尚未扫描，不能撤消！");
                return;
            }
            ZtPinTuoManager.Delete(entity);
            MessageBox.Show("撤消扫描成功！");
        }

        private void ZtSaveData()
        {

            ZtPinTuo entity = this.ZtComputeData();
            if (ZtPinTuoManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该托盘！");
                return;
            }
            ZtPinTuoManager.Save(entity);


        }
    }
}