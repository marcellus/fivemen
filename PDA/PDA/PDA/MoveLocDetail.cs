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
    public partial class MoveLocDetail : Form
    {
        public MoveLoc moveLoc;
        public MoveLocDetail(string loc)
        {
            InitializeComponent();
        }
        public MoveLocDetail()
        {
            InitializeComponent();
        }


        private void txt_Product_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Count.Text = "1";
                if (!this.cb_Rollback.Checked)
                {
                    this.txt_NewLoc.Focus();
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

        private void txt_OldLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (KuWeiManager.IsExists(this.txt_OldLoc.Text.Trim()))
                {
                    this.txt_Product.Focus();
                }
                else
                {

                    MessageBox.Show("库位:" + this.txt_OldLoc.Text.Trim() + "已经不再使用！");
                }

            }
        }

        private void txt_NewLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (KuWeiManager.IsExists(this.txt_NewLoc.Text.Trim()))
                {
                    if (!this.cb_Rollback.Checked)
                    {
                        this.SaveData();
                        this.RebindData();
                    }
                }
                else
                {

                    MessageBox.Show("库位:" + this.txt_NewLoc.Text.Trim() + "已经不再使用！");
                }


                ClearInput();
                this.txt_OldLoc.Focus();
            }
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (cb_Rollback.Checked)
            {
                this.txt_Product.Focus();
            }
            else
            {
                this.txt_OldLoc.Focus();
            }
        }

        private void ClearInput()
        {
            this.txt_NewLoc.Text = string.Empty;
            this.txt_Product.Text = string.Empty;
            this.txt_Count.Text = string.Empty;

            this.txt_OldLoc.Text = string.Empty;
            this.txt_TrayNo.Text = string.Empty;
            this.txt_NewTrayLoc.Text = string.Empty;
        }

        private void RebindData()
        {
            this.dg_ScanList.DataSource = AnHuoYiKuManager.GetUserData(Program.UserID);
            new DB().SetDataGridCloumnWidth(dg_ScanList);
        }

        private AnHuoYiKu ComputeData()
        {

            AnHuoYiKu entity = new AnHuoYiKu();
            entity.Sl = this.txt_Count.Text;
            entity.MdKw = this.txt_NewLoc.Text.Trim();
            entity.Cp = this.txt_Product.Text.Trim();
            entity.Ykw = this.txt_OldLoc.Text.Trim();
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }

        private void RemoveData()
        {
            AnHuoYiKu entity = this.ComputeData();
            if (!AnHuoYiKuManager.CheckExists(entity))
            {
                MessageBox.Show("产品尚未扫描，不能撤消！");
                return;
            }
            AnHuoYiKuManager.Delete(entity);
            MessageBox.Show("撤消扫描成功！");
        }

        private void SaveData()
        {
            AnHuoYiKu entity = this.ComputeData();
            if (AnHuoYiKuManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                AnHuoYiKuManager.Save(entity);
            }

        }
        private AnTuoYiKu ComputeTrayData()
        {
            AnTuoYiKu entity = new AnTuoYiKu();
            entity.Mdkw = this.txt_NewTrayLoc.Text.Trim();
            entity.Tph = this.txt_TrayNo.Text.Trim();
            entity.Scaner = Program.UserID;
            entity.date = System.DateTime.Now;
            return entity;
        }
        private void SaveTrayData()
        {
            AnTuoYiKu entity = this.ComputeTrayData();
            if (AnTuoYiKuManager.CheckExists(entity))
            {
                MessageBox.Show("您已经扫描过该产品！");
            }
            else
            {
                AnTuoYiKuManager.Save(entity);
            }

        }
        private void MoveLocDetail_Load(object sender, EventArgs e)
        {
            this.RebindData();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.cb_RollbackTray.Checked)
                {
                    this.txt_NewTrayLoc.Focus();
                }
                else
                {
                    this.RemoveTaryData();
                    this.RebindTrayData();
                    ClearInput();
                    cb_RollbackTray.Checked = false;
                }
            }
        }

        private void txt_NewTrayLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txt_SN.Focus();
                if (KuWeiManager.IsExists(this.txt_NewTrayLoc.Text.Trim()))
                {
                    if (!this.cb_RollbackTray.Checked)
                    {
                        this.SaveTrayData();
                        this.RebindTrayData();
                    }
                }
                else
                {
                    MessageBox.Show("库位:" + this.txt_NewLoc.Text.Trim() + "已经不再使用！");
                }
                ClearInput();
                txt_TrayNo.Focus();
                //this.txt_TrayNo.Enabled = false;
            } 
        }

        private void RebindTrayData()
        {
            this.dg_ScanList.DataSource = AnTuoYiKuManager.GetUserData(Program.UserID);
            new DB().SetDataGridCloumnWidth(dg_ScanList);
        }

        private void cb_RollbackTray_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            this.txt_TrayNo.Focus();

        }
        private void RemoveTaryData()
        {
            AnTuoYiKu entity = this.ComputeTrayData();
            if (!AnTuoYiKuManager.CheckExists(entity))
            {
                MessageBox.Show("托盘尚未扫描，不能撤消！");
                return;
            }
            AnTuoYiKuManager.Delete(entity);
            MessageBox.Show("撤消扫描成功！");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                RebindData();
            }
            else
            {
                RebindTrayData();
            }
        }
    }
}