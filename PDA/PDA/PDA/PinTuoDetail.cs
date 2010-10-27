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


    }
}