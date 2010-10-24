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
                    this.txt_Count.Text = string.Empty;
                    this.txt_Product.Text = string.Empty;
                }
            }
        }               

        private void txt_OldLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Product.Focus();
            }
        }

        private void txt_NewLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    if(!this.cb_Rollback.Checked)
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
        }

private void RebindData()
        {
            this.dg_ScanList.DataSource = AnHuoYiKuManager.GetUserData(Program.UserID);
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
            AnHuoYiKuManager.Delete(this.ComputeData());
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

        private void MoveLocDetail_Load(object sender, EventArgs e)
        {
this.RebindData();
        }

    }
}